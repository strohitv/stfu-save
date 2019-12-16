using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;
using STFU.Lib.Youtube.Internal;

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

		private IList<IYoutubeJob> JobQueue
		{
			get
			{
				return jobQueue;
			}

			set
			{
				if (jobQueue != value)
				{
					jobQueue = value;
					OnPropertyChanged();
				}
			}
		}

		/// <see cref="IYoutubeUploader.Queue"/>
		public IReadOnlyCollection<IYoutubeJob> Queue => new ReadOnlyCollection<IYoutubeJob>(JobQueue);

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

		public YoutubeUploader()
		{
			ServicePointManager.DefaultConnectionLimit = 100;
		}

		public event UploadStarted NewUploadStarted;

		/// <see cref="IYoutubeUploader.QueueUpload(IYoutubeJob)"/>
		public IYoutubeJob QueueUpload(IYoutubeVideo video, IYoutubeAccount account)
		{
			if (Queue.Any(job => job.Video == video && job.Account == account))
			{
				return Queue.Single(job => job.Video == video && job.Account == account);
			}

			var newJob = new YoutubeJob(video, account);
			newJob.TriggerDeletion += Job_TriggerDeletion;
			newJob.PropertyChanged += RunningJobPropertyChanged;

			JobQueue.Add(newJob);

			OnJobQueued(newJob, JobQueue.IndexOf(newJob));

			if (State == UploaderState.Waiting || State == UploaderState.Uploading)
			{
				StartJobs();
			}

			return newJob;
		}

		private void Job_TriggerDeletion(object sender, System.EventArgs args)
		{
			RemoveFromQueue((YoutubeJob)sender);
		}

		/// <see cref="IYoutubeUploader.CancelAll"/>
		public void CancelAll()
		{
			var runningJobs = JobQueue.Where(j => j.State.IsStarted()).ToArray();
			if (runningJobs.Length > 0
				&& (State == UploaderState.Uploading || State == UploaderState.Waiting))
			{
				State = UploaderState.CancelPending;

				foreach (var runningJob in runningJobs)
				{
					runningJob.CancelUploadAsync();
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
				int oldPosition = JobQueue.IndexOf(job);

				JobQueue.RemoveAt(oldPosition);

				if (JobQueue.Count < newPosition)
				{
					newPosition = JobQueue.Count;
				}
				else if (newPosition < 0)
				{
					newPosition = 0;
				}

				JobQueue.Insert(newPosition, job);
				OnJobPositionChanged(job, oldPosition, newPosition);
			}
		}

		/// <see cref="IYoutubeUploader.RemoveFromQueue(IYoutubeJob)"/>
		public void RemoveFromQueue(IYoutubeJob job)
		{
			if (Queue.Contains(job))
			{
				int position = JobQueue.IndexOf(job);
				job.TriggerDeletion -= Job_TriggerDeletion;
				job.PropertyChanged -= RunningJobPropertyChanged;
				JobQueue.Remove(job);
				OnJobDequeued(job, position);
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
				&& JobQueue.Where(j => j.State.IsStarted() && !startedJobs.Contains(j)).Count() + startedJobs.Count < MaxSimultaneousUploads
				&& Queue.Any(job => job.State == UploadProgress.NotRunning && job.Video.File.Exists && !job.ShouldBeSkipped))
			{
				var nextJob = Queue.FirstOrDefault(job => job.State == UploadProgress.NotRunning && job.Video.File.Exists && !job.ShouldBeSkipped);

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
						nextJob.StartUpload();

						startedJobs.Add(nextJob);
					}
				}
			}
		}

		private void RefreshUploaderState()
		{
			if (State != UploaderState.CancelPending)
			{
				if (JobQueue.Where(j => j.State.IsStarted()).Count() == 0)
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

				RefreshUploaderState();

				if (State != UploaderState.CancelPending && State != UploaderState.NotRunning
					&& (job.State == UploadProgress.Successful
					|| job.State.IsFailed()
					|| job.State.IsCanceled()))
				{
					if (RemoveCompletedJobs && !job.State.IsCanceled() && !job.State.IsFailed())
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
			else if (e.PropertyName == nameof(IYoutubeJob.Progress))
			{
				RecalculateProgress();
			}
		}

		private void RecalculateProgress()
		{
			var runningJobs = JobQueue.Where(j => j.State.IsStarted()).ToArray();

			if (runningJobs.Length > 0)
			{
				Progress = runningJobs.Sum(j => (int)(j.Progress * 100)) / runningJobs.Length;
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
