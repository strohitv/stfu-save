using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using STFU.Lib.Youtube.Internal;
using STFU.Lib.Youtube.Internal.Upload;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using System.IO;
using System.Threading;

namespace STFU.Lib.Youtube
{
	public class YoutubeUploader : IYoutubeUploader
	{
		private int maxSimultaneousUploads = 1;
		private IList<IYoutubeJob> jobQueue = new List<IYoutubeJob>();
		private UploaderState state = UploaderState.NotRunning;
		private bool stopAfterCompleting = true;

		private IList<YoutubeJobUploader> runningJobUploaders = new List<YoutubeJobUploader>();

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

		public event UploadStarted NewUploadStarted = null;

		/// <see cref="IYoutubeUploader.QueueUpload(IYoutubeJob)"/>
		public IYoutubeJob QueueUpload(IYoutubeVideo video, IYoutubeAccount account)
		{
			if (Queue.Any(job => job.Video == video && job.Account == account))
			{
				return Queue.Single(job => job.Video == video && job.Account == account);
			}

			var newJob = new InternalYoutubeJob(video, account);
			JobQueue.Add(newJob);

			if (State == UploaderState.Waiting || State == UploaderState.Uploading)
			{
				StartJobUploaders();
			}

			return newJob;
		}

		/// <see cref="IYoutubeUploader.CancelAll"/>
		public void CancelAll()
		{
			if (State == UploaderState.Uploading || State == UploaderState.Waiting)
			{
				if (runningJobUploaders.Any(ju => ju.State != RunningState.NotRunning))
				{
					State = UploaderState.CancelPending;

					foreach (var uploader in runningJobUploaders)
					{
						uploader.Cancel();
					}
				}
				else
				{
					State = UploaderState.NotRunning;
				}
			}
		}

		public void CancelJob(IYoutubeJob job)
		{
			var jobUploader = runningJobUploaders.FirstOrDefault(ju => ju.Job == job);
			jobUploader?.Cancel();
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
				StartJobUploaders();
			}
		}

		private void StartJobUploaders()
		{
			while (State != UploaderState.CancelPending
				&& runningJobUploaders.Count < MaxSimultaneousUploads
				&& Queue.Any(job => job.State == UploadState.NotStarted && job.Video.File.Exists))
			{
				var nextJob = Queue.First(job => job.State == UploadState.NotStarted && job.Video.File.Exists);
				nextJob.PropertyChanged += RunningJobPropertyChanged;

				bool start = false;
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
					{
						Thread.Sleep(500);
					}
				}

				if (nextJob.Video.File.Exists)
				{
					var jobUploader = new YoutubeJobUploader(nextJob as InternalYoutubeJob);
					NewUploadStarted?.Invoke(new UploadStartedEventArgs(nextJob));
					jobUploader.UploadAsync();

					runningJobUploaders.Add(jobUploader);
				}
			}

			if (State != UploaderState.CancelPending)
			{
				if (runningJobUploaders.Count == 0)
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
			if (e.PropertyName == nameof(IYoutubeJob.State)
				&& (job.State == UploadState.Successful
				|| job.State == UploadState.Canceled
				|| job.State == UploadState.Error))
			{
				var jobUploader = runningJobUploaders.Single(upl => upl.Job == job);
				runningJobUploaders.Remove(jobUploader);

				StartJobUploaders();
			}
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion INofityPropertyChanged
	}
}
