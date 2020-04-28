using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
				return maxSimultaneousUploads;
			}

			set
			{
				if (maxSimultaneousUploads != value && value > 0)
				{
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
				return state;
			}

			internal set
			{
				if (state != value)
				{
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
				return stopAfterCompleting;
			}

			set
			{
				if (stopAfterCompleting != value)
				{
					stopAfterCompleting = value;
					OnPropertyChanged();
				}
			}
		}

		private int progress = 0;
		/// <see cref="IYoutubeUploader.MaxSimultaneousUploads"/>
		public int Progress
		{
			get
			{
				return progress;
			}

			set
			{
				if (progress != value && value > 0)
				{
					progress = value;
					OnPropertyChanged();
				}
			}
		}

		public bool LimitUploadSpeed { get => ThrottledReadStream.ShouldThrottle; set => ThrottledReadStream.ShouldThrottle = value; }

		public long UploadLimitKByte { get => ThrottledReadStream.ThrottleByteperSeconds; set => ThrottledReadStream.ThrottleByteperSeconds = value; }

		public YoutubeUploader()
		{
			ServicePointManager.DefaultConnectionLimit = 100;
		}

		public YoutubeUploader(IYoutubeJobContainer queue)
			: this()
		{
			JobQueue = queue;

			for (int i = 0; i < JobQueue.RegisteredJobs.Count; i++)
			{
				YoutubeJob job = JobQueue.RegisteredJobs.ElementAt(i) as YoutubeJob;
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
			if (Queue.Any(existing => existing.Video == video && existing.Account == account))
			{
				return Queue.Single(existing => existing.Video == video && existing.Account == account);
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
			if (Queue.Any(existing => existing == job))
			{
				return Queue.Single(existing => existing == job);
			}

			RegisterJob(job);

			return job;
		}

		private void RegisterJob(IYoutubeJob job)
		{
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
				StartJobs();
			}
		}

		private void Job_TriggerDeletion(object sender, System.EventArgs args)
		{
			RemoveFromQueue((YoutubeJob)sender);
		}

		/// <see cref="IYoutubeUploader.CancelAll"/>
		public void CancelAll()
		{
			var runningJobs = JobQueue.RegisteredJobs.Where(j => j.State.IsStarted()).ToArray();
			if (runningJobs.Length > 0
				&& (State == UploaderState.Uploading || State == UploaderState.Waiting))
			{
				State = UploaderState.CancelPending;

				foreach (var runningJob in runningJobs)
				{
					runningJob.Cancel();
				}
			}
			else
			{
				State = UploaderState.NotRunning;
			}
		}

		/// <see cref="IYoutubeUploader.ChangePosition(IYoutubeJob job, int newPosition)"/>
		public void ChangePosition(IYoutubeJob job, int newPosition)
		{
			if (Queue.Contains(job))
			{
				int oldPosition = JobQueue.RegisteredJobs.ToList().IndexOf(job);

				JobQueue.UnregisterJobAt(oldPosition);

				if (JobQueue.RegisteredJobs.Count < newPosition)
				{
					newPosition = JobQueue.RegisteredJobs.Count;
				}
				else if (newPosition < 0)
				{
					newPosition = 0;
				}

				JobQueue.RegisterJob(newPosition, job);
				OnJobPositionChanged(job, oldPosition, newPosition);
			}
		}

		/// <see cref="IYoutubeUploader.RemoveFromQueue(IYoutubeJob)"/>
		public void RemoveFromQueue(IYoutubeJob job)
		{
			if (Queue.Contains(job))
			{
				int position = JobQueue.RegisteredJobs.ToList().IndexOf(job);
				job.TriggerDeletion -= Job_TriggerDeletion;
				job.PropertyChanged -= RunningJobPropertyChanged;
				job.UploadStatus.PropertyChanged -= UploadStatusPropertyChanged;
				JobQueue.UnregisterJob(job);
				OnJobDequeued(job, position);
			}
		}

		private void UploadStatusPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(UploadStatus.Progress))
			{
				RecalculateProgress();
			}
		}

		/// <see cref="IYoutubeUploader.StartUploader"/>
		public void StartUploader()
		{
			if (State == UploaderState.NotRunning)
			{
				State = UploaderState.Waiting;
				StartJobs();
			}
		}

		private void StartJobs()
		{
			HashSet<IYoutubeJob> startedJobs = new HashSet<IYoutubeJob>();

			while (State != UploaderState.CancelPending
				&& JobQueue.RegisteredJobs.Where(j => j.State.IsStarted() && !startedJobs.Contains(j)).Count() + startedJobs.Count < MaxSimultaneousUploads
				&& Queue.Any(job => job.State == JobState.NotStarted && job.Video.File.Exists && !job.ShouldBeSkipped))
			{
				var nextJob = Queue.FirstOrDefault(job => job.State == JobState.NotStarted && job.Video.File.Exists && !job.ShouldBeSkipped);

				if (nextJob != null)
				{
					bool start = false;
					State = UploaderState.Uploading;
					while (!start && nextJob.Video.File.Exists)
					{
						try
						{
							using (StreamWriter writer = new StreamWriter(nextJob.Video.File.FullName, true))
							{
								start = true;
							}
						}
						catch (System.Exception)
						{ }
					}

					if (!startedJobs.Contains(nextJob) && nextJob.Video.File.Exists)
					{
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
			if (State != UploaderState.CancelPending)
			{
				if (JobQueue.RegisteredJobs.ToList().Where(j => j.State.IsStarted()).Count() == 0)
				{
					if (StopAfterCompleting || State == UploaderState.NotRunning)
					{
						State = UploaderState.NotRunning;
					}
					else
					{
						State = UploaderState.Waiting;
					}
				}
				else
				{
					State = UploaderState.Uploading;
				}
			}
			else
			{
				State = UploaderState.NotRunning;
			}
		}

		private void RunningJobPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var job = sender as IYoutubeJob;
			if (e.PropertyName == nameof(IYoutubeJob.State))
			{
				if (job.State.IsFailed() && job.Error?.FailReason == FailureReason.UserUploadLimitExceeded)
				{
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
						RemoveFromQueue(job);
					}

					if (State == UploaderState.Uploading
						|| State == UploaderState.Waiting)
					{
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
		}

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public event JobQueuedEventHandler JobQueued;
		private void OnJobQueued(IYoutubeJob job, int position)
		{
			JobQueued?.Invoke(this, new JobQueuedEventArgs(job, position));
		}

		public event JobDequeuedEventHandler JobDequeued;
		private void OnJobDequeued(IYoutubeJob job, int position)
		{
			JobDequeued?.Invoke(this, new JobDequeuedEventArgs(job, position));
		}

		public event JobPositionChangedEventHandler JobPositionChanged;
		private void OnJobPositionChanged(IYoutubeJob job, int oldPosition, int newPosition)
		{
			JobPositionChanged?.Invoke(this, new JobPositionChangedEventArgs(job, oldPosition, newPosition));
		}

		#endregion Events
	}
}
