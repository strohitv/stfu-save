using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Upload.Steps;

namespace STFU.Lib.Youtube.Upload
{
	public class JobUploader
	{
		public event UploaderStateChangedEventHandler StateChanged;

		readonly string[] videoPropertyNames;

		public YoutubeJob Job { get; }

		private Queue<IUploadStep> Steps { get; } = new Queue<IUploadStep>();

		public JobUploader(YoutubeJob job)
		{
			Job = job;

			Job.Video.PropertyChanged += VideoPropertyChanged;

			Steps.Enqueue(new RetryingUploadStep<VideoUploadStep>(Job));
			Steps.Enqueue(new RetryingUploadStep<ThumbnailUploadStep>(Job));
			Steps.Enqueue(new RetryingUploadStep<ChangeVideoDetailsStep>(Job));
			Steps.Enqueue(new RetryingUploadStep<AddToPlaylistStep>(Job));
			Steps.Enqueue(new RetryingUploadStep<SendToPlaylistServiceStep>(Job));

			videoPropertyNames = new[] {
				// Todo: Wie mach ich das mit den Tags..?
				nameof(Job.Video.Title),
				nameof(Job.Video.Description),
				nameof(Job.Video.Category),
				nameof(Job.Video.DefaultLanguage),
				nameof(Job.Video.IsEmbeddable),
				nameof(Job.Video.License),
				nameof(Job.Video.Privacy),
				nameof(Job.Video.PublicStatsViewable),
				nameof(Job.Video.PublishAt),
				nameof(Job.Video.ThumbnailPath)
			};
		}

		~JobUploader()
		{
			Job.Video.PropertyChanged -= VideoPropertyChanged;
		}

		public void Run()
		{
			if (Steps.Count == 0)
			{
				Steps.Enqueue(new RetryingUploadStep<VideoUploadStep>(Job));
				Steps.Enqueue(new RetryingUploadStep<ThumbnailUploadStep>(Job));
				Steps.Enqueue(new RetryingUploadStep<ChangeVideoDetailsStep>(Job));
				Steps.Enqueue(new RetryingUploadStep<AddToPlaylistStep>(Job));
				Steps.Enqueue(new RetryingUploadStep<SendToPlaylistServiceStep>(Job));
			}

			if (Job.UploadStatus.CurrentStep == null || !Job.UploadStatus.CurrentStep.IsRunning)
			{
				if (Job.UploadStatus.CurrentStep != null)
				{
					Job.UploadStatus.CurrentStep.StepStateChanged -= RunningStepStateChanged;
				}

				Job.UploadStatus.CurrentStep = Steps.Dequeue();
				Job.UploadStatus.CurrentStep.StepStateChanged += RunningStepStateChanged;
			}

			Job.UploadStatus.CurrentStep.RunAsync();
			StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.Running));
		}

		private void VideoPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Job.Video.ThumbnailPath)
				&& !Steps.Any(step => step is RetryingUploadStep<ThumbnailUploadStep>))
			{
				Steps.Enqueue(new RetryingUploadStep<ThumbnailUploadStep>(Job));
				Run();
			}
			else if (videoPropertyNames.Contains(e.PropertyName)
				&& !Steps.Any(step => step is RetryingUploadStep<ChangeVideoDetailsStep>))
			{
				Steps.Enqueue(new RetryingUploadStep<ChangeVideoDetailsStep>(Job));
				Run();
			}
			else if (new string[] { nameof(Job.Video.AddToPlaylist), nameof(Job.Video.PlaylistId) }.Contains(e.PropertyName)
				&& !Steps.Any(step => step is RetryingUploadStep<AddToPlaylistStep>))
			{
				Steps.Enqueue(new RetryingUploadStep<AddToPlaylistStep>(Job));
				Run();
			}
			else if (e.PropertyName == nameof(Job.Video.PlaylistServiceSettings)
				&& !Steps.Any(step => step is RetryingUploadStep<SendToPlaylistServiceStep>))
			{
				Steps.Enqueue(new RetryingUploadStep<SendToPlaylistServiceStep>(Job));
				Run();
			}
		}

		private void RunningStepStateChanged(object sender, UploadStepStateChangedEventArgs e)
		{
			if (e.NewState == UploadStepState.Successful)
			{
				if (Steps.Count > 0)
				{
					if (Job.UploadStatus.CurrentStep != null)
					{
						Job.UploadStatus.CurrentStep.StepStateChanged -= RunningStepStateChanged;
					}

					Job.UploadStatus.CurrentStep = Steps.Dequeue();
					Job.UploadStatus.CurrentStep.StepStateChanged += RunningStepStateChanged;

					Job.UploadStatus.CurrentStep.RunAsync();
				}
				else
				{
					StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.Successful));
				}
			}
			else if (e.NewState == UploadStepState.Error)
			{
				StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.Error));
			}
			else if (e.NewState == UploadStepState.Broke)
			{
				StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.Broke));
			}
			else if (e.NewState == UploadStepState.Running)
			{
				StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.Running));
			}
			else if (e.NewState == UploadStepState.QuotaReached)
			{
				StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.QuotaReached));
			}
		}

		public void Reset()
		{
			Steps.Clear();

			if (Job.UploadStatus.CurrentStep != null)
			{
				Job.UploadStatus.CurrentStep.StepStateChanged -= RunningStepStateChanged;
				Job.UploadStatus.CurrentStep.Cancel();
				Job.UploadStatus.CurrentStep = null;
			}

			StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.NotStarted));
		}
	}
}
