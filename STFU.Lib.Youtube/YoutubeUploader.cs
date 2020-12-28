using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using log4net;
using STFU.Lib.MailSender.Generator;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;
using STFU.Lib.Youtube.Upload;
using STFU.Lib.Youtube.Upload.Steps;

namespace STFU.Lib.Youtube
{
	public class YoutubeUploader : IYoutubeUploader
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(YoutubeUploader));

		private int maxSimultaneousUploads = 1;
		private IList<IYoutubeJob> jobQueue = new List<IYoutubeJob>();
		private UploaderState state = UploaderState.NotRunning;
		private bool stopAfterCompleting = true;

		public bool RemoveCompletedJobs { get; set; }

		/// <see cref="IYoutubeUploader.MaxSimultaneousUploads"/>
		public int MaxSimultaneousUploads
		{
			get
			{
				LOGGER.Debug($"Returning maxSimultaneousUploads with value {maxSimultaneousUploads}");
				return maxSimultaneousUploads;
			}

			set
			{
				if (maxSimultaneousUploads != value && value > 0)
				{
					LOGGER.Debug($"Setting maxSimultaneousUploads to new value {value}");
					maxSimultaneousUploads = value;
					OnPropertyChanged();
				}
			}
		}

		private IYoutubeJobContainer JobQueue { get; set; } = new YoutubeJobContainer();

		/// <see cref="IYoutubeUploader.Queue"/>
		public IReadOnlyCollection<IYoutubeJob> Queue => new ReadOnlyCollection<IYoutubeJob>(JobQueue.RegisteredJobs.ToList());

		/// <see cref="IYoutubeUploader.State"/>
		public UploaderState State
		{
			get
			{
				LOGGER.Debug($"Returning state with value {state}");
				return state;
			}

			internal set
			{
				if (state != value)
				{
					LOGGER.Debug($"Setting state to new value {value}");
					state = value;
					OnPropertyChanged();
				}
			}
		}

		/// <see cref="IYoutubeUploader.StopAfterCompleting"/>
		public bool StopAfterCompleting
		{
			get
			{
				LOGGER.Debug($"Returning stopAfterCompleting with value {stopAfterCompleting}");
				return stopAfterCompleting;
			}

			set
			{
				if (stopAfterCompleting != value)
				{
					LOGGER.Debug($"Setting stopAfterCompleting to new value {value}");
					stopAfterCompleting = value;
					OnPropertyChanged();
				}
			}
		}

		private int progress = 0;
		/// <see cref="IYoutubeUploader.Progress"/>
		public int Progress
		{
			get
			{
				LOGGER.Debug($"Returning progress with value {progress}");
				return progress;
			}

			set
			{
				if (progress != value && value > 0)
				{
					LOGGER.Debug($"Setting progress to new value {value}");
					progress = value;
					OnPropertyChanged();
				}
			}
		}

		public bool LimitUploadSpeed { get => ThrottledReadStream.ShouldThrottle; set => ThrottledReadStream.ShouldThrottle = value; }

		public long UploadLimitKByte { get => ThrottledReadStream.GlobalLimit; set => ThrottledReadStream.GlobalLimit = value; }

		public YoutubeUploader()
		{
			LOGGER.Debug($"Creating a new instance of youtube uploader");
			ServicePointManager.DefaultConnectionLimit = 100;
		}

		public YoutubeUploader(IYoutubeJobContainer queue)
			: this()
		{
			LOGGER.Debug($"Creating a new instance of youtube uploader with {queue.RegisteredJobs.Count} jobs");

			JobQueue = queue;

			for (int i = 0; i < JobQueue.RegisteredJobs.Count; i++)
			{
				YoutubeJob job = JobQueue.RegisteredJobs.ElementAt(i) as YoutubeJob;

				LOGGER.Info($"Registering job for video {job.Video.Title}");

				job.TriggerDeletion += Job_TriggerDeletion;
				job.PropertyChanged += RunningJobPropertyChanged;
				job.UploadStatus.PropertyChanged += UploadStatusPropertyChanged;

				OnJobQueued(job, i);
			}
		}

		public event UploadStarted NewUploadStarted;

		/// <see cref="IYoutubeUploader.QueueUpload(IYoutubeVideo, IYoutubeAccount)"/>
		public IYoutubeJob QueueUpload(IYoutubeVideo video, IYoutubeAccount account, INotificationSettings notificationSettings)
		{
			LOGGER.Info($"Queueing Video '{video.Title}' for account '{account.Title}' was called");

			if (Queue.Any(existing => existing.Video == video && existing.Account == account))
			{
				var foundJob = Queue.Single(existing => existing.Video == video && existing.Account == account);
				LOGGER.Info($"Requested video was already in queue at position {Queue.ToList().IndexOf(foundJob)}, it won't be added again.");
				return foundJob;
			}

			var job = new YoutubeJob(video, account, new UploadStatus())
			{
				NotificationSettings = notificationSettings
			};

			RegisterJob(job);

			return job;
		}

		/// <see cref="IYoutubeUploader.QueueUpload(IYoutubeJob)"/>
		public IYoutubeJob QueueUpload(IYoutubeJob job)
		{
			LOGGER.Info($"Queueing job with video '{job.Video.Title}' for account '{job.Account.Title}' was called");

			if (Queue.Any(existing => existing == job))
			{
				LOGGER.Info($"Requested job was already in queue at position {Queue.ToList().IndexOf(job)}, it won't be added again.");
				return Queue.Single(existing => existing == job);
			}

			RegisterJob(job);

			return job;
		}

		private void RegisterJob(IYoutubeJob job)
		{
			LOGGER.Debug("Registering job");

			job.TriggerDeletion += Job_TriggerDeletion;
			job.PropertyChanged += RunningJobPropertyChanged;
			job.UploadStatus.PropertyChanged += UploadStatusPropertyChanged;

			if (job.NotificationSettings.NotifyOnVideoFoundMail)
			{
				MailSender.MailSender.Send(
					job.Account,
					job.NotificationSettings.MailReceiver,
					$"Wartet: '{job.Video.Title}' ist in der Warteschlange!",
					new NewVideoFoundMailGenerator().Generate(job));
			}

			JobQueue.RegisterJob(job);

			OnJobQueued(job, JobQueue.RegisteredJobs.ToList().IndexOf(job));

			if (State == UploaderState.Waiting || State == UploaderState.Uploading)
			{
				LOGGER.Info("Starting uploader now");
				StartJobs();
			}
		}

		private void Job_TriggerDeletion(object sender, System.EventArgs args)
		{
			LOGGER.Info($"Removing job for video '{((YoutubeJob)sender).Video.Title}' from queue");
			RemoveFromQueue((YoutubeJob)sender);
		}

		/// <see cref="IYoutubeUploader.CancelAll"/>
		public void CancelAll()
		{
			LOGGER.Info("Cancelling all jobs");

			var runningJobs = JobQueue.RegisteredJobs.Where(j => j.State.IsStarted()).ToArray();
			if (runningJobs.Length > 0
				&& (State == UploaderState.Uploading || State == UploaderState.Waiting))
			{
				LOGGER.Info($"Found {runningJobs.Length} running jobs to cancel");
				State = UploaderState.CancelPending;

				foreach (var runningJob in runningJobs)
				{
					LOGGER.Info($"Cancelling job for video {runningJob.Video.Title}");
					runningJob.Cancel();
				}
			}
			else
			{
				State = UploaderState.NotRunning;
			}

			LOGGER.Info("Cancelling completed");
		}

		/// <see cref="IYoutubeUploader.ChangePosition(IYoutubeJob job, int newPosition)"/>
		public void ChangePosition(IYoutubeJob job, int newPosition)
		{
			LOGGER.Debug($"Switching position of job with video {job.Video.Title} to new positon {newPosition}");

			if (Queue.Contains(job))
			{
				int oldPosition = JobQueue.RegisteredJobs.ToList().IndexOf(job);
				LOGGER.Info($"Switching position of job with video {job.Video.Title} from old position {oldPosition} to new positon {newPosition}");

				JobQueue.UnregisterJobAt(oldPosition);

				if (JobQueue.RegisteredJobs.Count < newPosition)
				{
					LOGGER.Debug($"Setting newPosition to {JobQueue.RegisteredJobs.Count} since there are not enough videos in queue");
					newPosition = JobQueue.RegisteredJobs.Count;
				}
				else if (newPosition < 0)
				{
					LOGGER.Debug($"Setting newPosition to 0 since it was < 0");
					newPosition = 0;
				}

				JobQueue.RegisterJob(newPosition, job);
				OnJobPositionChanged(job, oldPosition, newPosition);
			}
		}

		/// <see cref="IYoutubeUploader.RemoveFromQueue(IYoutubeJob)"/>
		public void RemoveFromQueue(IYoutubeJob job)
		{
			LOGGER.Debug($"Removing job with video {job.Video.Title} from queue");

			if (Queue.Contains(job))
			{
				int position = JobQueue.RegisteredJobs.ToList().IndexOf(job);

				LOGGER.Info($"Removing job with video {job.Video.Title} from position {position} in queue");

				job.TriggerDeletion -= Job_TriggerDeletion;
				job.PropertyChanged -= RunningJobPropertyChanged;
				job.UploadStatus.PropertyChanged -= UploadStatusPropertyChanged;

				JobQueue.UnregisterJob(job);

				OnJobDequeued(job, position);
			}
		}

		private void UploadStatusPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			LOGGER.Info($"Handling upload status property changed event for property {e.PropertyName}");

			if (e.PropertyName == nameof(UploadStatus.Progress))
			{
				RecalculateProgress();
			}
		}

		/// <see cref="IYoutubeUploader.StartUploader"/>
		public void StartUploader()
		{
			LOGGER.Debug($"Starting uploader");

			if (State == UploaderState.NotRunning)
			{
				LOGGER.Info($"Uploader was not running. Starting it now.");
				State = UploaderState.Waiting;
				StartJobs();
			}
		}

		private void StartJobs()
		{
			LOGGER.Info($"Starting jobs");
			HashSet<IYoutubeJob> startedJobs = new HashSet<IYoutubeJob>();

			while (State != UploaderState.CancelPending
				&& JobQueue.RegisteredJobs.Where(j => j.State.IsStarted() && !startedJobs.Contains(j)).Count() + startedJobs.Count < MaxSimultaneousUploads
				&& Queue.Any(job => job.State == JobState.NotStarted && job.Video.File.Exists && !job.ShouldBeSkipped))
			{
				var nextJob = Queue.FirstOrDefault(job => job.State == JobState.NotStarted && job.Video.File.Exists && !job.ShouldBeSkipped);

				if (nextJob != null)
				{
					LOGGER.Info($"Preparing waiting job for video '{nextJob.Video.Title}'");

					bool start = false;
					State = UploaderState.Uploading;
					while (!start && nextJob.Video.File.Exists)
					{
						try
						{
							LOGGER.Debug($"Trying to open the video for write access to see if it's ready");
							using (StreamWriter writer = new StreamWriter(nextJob.Video.File.FullName, true))
							{
								LOGGER.Debug($"Video can be accessed");
								start = true;
							}
						}
						catch (System.Exception)
						{
							LOGGER.Debug($"Video file was in write access by another program. Waiting until it's being released");
						}
					}

					if (!startedJobs.Contains(nextJob) && nextJob.Video.File.Exists)
					{
						LOGGER.Info($"Starting waiting job for video '{nextJob.Video.Title}'");

						NewUploadStarted?.Invoke(new UploadStartedEventArgs(nextJob));

						nextJob.Run();

						if (nextJob.NotificationSettings.NotifyOnVideoUploadStartedMail)
						{
							MailSender.MailSender.Send(
								nextJob.Account,
								nextJob.NotificationSettings.MailReceiver,
										$"Start: '{nextJob.Video.Title}' wird jetzt hochgeladen!",
										new UploadStartedMailGenerator().Generate(nextJob));
						}

						startedJobs.Add(nextJob);
					}
				}
			}
		}

		private void RefreshUploaderState()
		{
			LOGGER.Debug($"Refreshing uploader state");

			if (State != UploaderState.CancelPending)
			{
				if (JobQueue.RegisteredJobs.ToList().Where(j => j.State.IsStarted()).Count() == 0)
				{
					if (StopAfterCompleting || State == UploaderState.NotRunning)
					{
						LOGGER.Info($"Setting uploader state to not running");
						State = UploaderState.NotRunning;
					}
					else
					{
						LOGGER.Info($"Setting uploader state to waiting");
						State = UploaderState.Waiting;
					}
				}
				else
				{
					LOGGER.Info($"Setting uploader state to uploading");
					State = UploaderState.Uploading;
				}
			}
			else
			{
				LOGGER.Info($"Setting uploader state to not running");
				State = UploaderState.NotRunning;
			}
		}

		private void RunningJobPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var job = sender as IYoutubeJob;

			LOGGER.Debug($"Received property change of property '{e.PropertyName}' from job for video '{job.Video.Title}'");

			if (e.PropertyName == nameof(IYoutubeJob.State))
			{
				LOGGER.Info($"Reachting to property change of property '{e.PropertyName}' from job for video '{job.Video.Title}'");

				if (job.State.IsFailed() && job.Error?.FailReason == FailureReason.UserUploadLimitExceeded)
				{
					LOGGER.Info($"Setting uploader state to cancel pending");
					State = UploaderState.CancelPending;
				}

				if (job.State == JobState.Successful && job.NotificationSettings.NotifyOnVideoUploadFinishedMail)
				{
					MailSender.MailSender.Send(
						job.Account,
						job.NotificationSettings.MailReceiver,
						$"Erfolg: '{job.Video.Title}' wurde erfolgreich hochgeladen!",
						new UploadFinishedMailGenerator().Generate(job));
				}
				else if (job.State.IsFailed() && job.NotificationSettings.NotifyOnVideoUploadFailedMail)
				{
					MailSender.MailSender.Send(
						job.Account,
						job.NotificationSettings.MailReceiver,
						$"Fehler: '{job.Video.Title}' konnte nicht hochgeladen werden",
						new UploadFailedMailGenerator().Generate(job));
				}

				RefreshUploaderState();

				if (State != UploaderState.CancelPending && State != UploaderState.NotRunning
					&& (job.State == JobState.Successful
					|| job.State.IsFailed()
					|| job.State.IsCanceled()))
				{
					if (!job.State.IsCanceled() && !job.State.IsFailed() && RemoveCompletedJobs)
					{
						LOGGER.Info($"Job didn't fail - removing it from queue");
						RemoveFromQueue(job);
					}

					if (State == UploaderState.Uploading
						|| State == UploaderState.Waiting)
					{
						LOGGER.Debug($"Calling start method to maybe start next job");
						StartJobs();
					}
				}
			}
		}

		private void RecalculateProgress()
		{
			var runningJobs = JobQueue.RegisteredJobs.ToList().Where(j => j.State.IsStarted()).ToArray();

			if (runningJobs.Length > 0)
			{
				Progress = runningJobs.Sum(j => (int)(j.UploadStatus.Progress * 100)) / runningJobs.Length;
			}
			else
			{
				Progress = 0;
			}

			LOGGER.Info($"Recalculated progress to: {Progress} %");
		}

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string caller = "")
		{
			LOGGER.Debug($"Property {caller} changed, invoking handler");
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
		}

		public event JobQueuedEventHandler JobQueued;
		private void OnJobQueued(IYoutubeJob job, int position)
		{
			LOGGER.Debug($"Job for video '{job.Video.Title}' was added on position {position}, invoking handler");
			JobQueued?.Invoke(this, new JobQueuedEventArgs(job, position));
		}

		public event JobDequeuedEventHandler JobDequeued;
		private void OnJobDequeued(IYoutubeJob job, int position)
		{
			LOGGER.Debug($"Job for video '{job.Video.Title}' on position {position} was dequeued, invoking handler");
			JobDequeued?.Invoke(this, new JobDequeuedEventArgs(job, position));
		}

		public event JobPositionChangedEventHandler JobPositionChanged;
		private void OnJobPositionChanged(IYoutubeJob job, int oldPosition, int newPosition)
		{
			LOGGER.Debug($"Position of job for video '{job.Video.Title}' changed to {position}, invoking handler");
			JobPositionChanged?.Invoke(this, new JobPositionChangedEventArgs(job, oldPosition, newPosition));
		}

		#endregion Events
	}
}
