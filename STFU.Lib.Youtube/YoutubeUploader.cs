using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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

		public event UploadStarted NewUploadStarted;

		/// <see cref="IYoutubeUploader.QueueUpload(IYoutubeJob)"/>
		public IYoutubeJob QueueUpload(IYoutubeVideo video, IYoutubeAccount account)
		{
			if (Queue.Any(job => job.Video == video && job.Account == account))
			{
				return Queue.Single(job => job.Video == video && job.Account == account);
			}

			var newJob = new YoutubeJob(video, account);
			JobQueue.Add(newJob);

			OnJobQueued(video, JobQueue.IndexOf(newJob));

			if (State == UploaderState.Waiting || State == UploaderState.Uploading)
			{
				StartJobs();
			}

			return newJob;
		}

		/// <see cref="IYoutubeUploader.CancelAll"/>
		public void CancelAll()
		{
			var runningJobs = JobQueue.Where(j => j.State.IsRunningOrInitializing()).ToArray();
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

		/// <see cref="IYoutubeUploader.ChangePositionInQueue(IYoutubeJob, IYoutubeJob)"/>
		public void ChangePositionInQueue(IYoutubeJob first, IYoutubeJob second)
		{
			if (!Queue.Contains(first) || !Queue.Contains(second))
			{
				return;
			}

			int firstPos = JobQueue.IndexOf(first);
			int secondPos = JobQueue.IndexOf(second);

			JobQueue[firstPos] = second;
			JobQueue[secondPos] = first;
		}

		/// <see cref="IYoutubeUploader.RemoveFromQueue(IYoutubeJob)"/>
		public void RemoveFromQueue(IYoutubeJob job)
		{
			if (!Queue.Contains(job))
			{
				return;
			}

			JobQueue.Remove(job);
		}

		/// <see cref="IYoutubeUploader.StartUploader"/>
		public void StartUploader()
		{
			if (State == UploaderState.NotRunning)
			{
				StartJobs();
			}
		}

		private void StartJobs()
		{
			while (State != UploaderState.CancelPending
				&& JobQueue.Where(j => j.State.IsRunningOrInitializing()).Count() < MaxSimultaneousUploads
				&& Queue.Any(job => job.State == UploadState.NotStarted && job.Video.File.Exists))
			{
				var nextJob = Queue.First(job => job.State == UploadState.NotStarted && job.Video.File.Exists);
				nextJob.PropertyChanged += RunningJobPropertyChanged;

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

				if (nextJob.Video.File.Exists)
				{
					NewUploadStarted?.Invoke(new UploadStartedEventArgs(nextJob));
					nextJob.UploadAsync();
				}
			}
		}

		private void RefreshUploaderState()
		{
			if (State != UploaderState.CancelPending)
			{
				if (JobQueue.Where(j => j.State.IsRunningOrInitializing()).Count() == 0)
				{
					if (StopAfterCompleting)
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
				RefreshUploaderState();

				if ((job.State == UploadState.Successful
				|| job.State.IsCanceled()
				|| job.State.IsFailed()))
				{
					if (RemoveCompletedJobs)
					{
						RemoveFromQueue(job);
					}

					StartJobs();
				}
			}
		}

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public event JobQueuedEventHandler VideoQueued;
		private void OnJobQueued(IYoutubeVideo video, int position)
		{
			VideoQueued?.Invoke(this, new JobQueuedEventArgs(video, position));
		}

		#endregion Events
	}
}
