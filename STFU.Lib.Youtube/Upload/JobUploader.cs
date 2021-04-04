using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using log4net;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Upload.Steps;

namespace STFU.Lib.Youtube.Upload
{
	public class JobUploader
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(JobUploader));

		public event UploaderStateChangedEventHandler StateChanged;

		readonly string[] videoPropertyNames;

		public YoutubeJob Job { get; }

		private Queue<IUploadStep> Steps { get; } = new Queue<IUploadStep>();

		public JobUploader(YoutubeJob job)
		{
			Job = job;
			LOGGER.Info($"Creating JobUploader for Job '{Job.Video.Title}'");

			Job.Video.PropertyChanged += VideoPropertyChanged;

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
			LOGGER.Info($"Cleaning up JobUploader for Job '{Job.Video.Title}'");
			Job.Video.PropertyChanged -= VideoPropertyChanged;
		}

		public void Run()
		{
			LOGGER.Info($"Starting JobUploader for Job '{Job.Video.Title}'");

			if (Steps.Count == 0)
			{
				LOGGER.Info($"Enqueueing new Steps for Job '{Job.Video.Title}'");

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

				LOGGER.Info($"Using next Step for Job '{Job.Video.Title}'");

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
				LOGGER.Info($"Thumbnail changed for Job '{Job.Video.Title}'. Appending a new thumbnail upload step to refresh it.");

				Steps.Enqueue(new RetryingUploadStep<ThumbnailUploadStep>(Job));
				Run();
			}
			else if (videoPropertyNames.Contains(e.PropertyName)
				&& !Steps.Any(step => step is RetryingUploadStep<ChangeVideoDetailsStep>))
			{
				LOGGER.Info($"Video property '{e.PropertyName}' changed for Job '{Job.Video.Title}'. Appending a new change video details step to refresh it.");

				Steps.Enqueue(new RetryingUploadStep<ChangeVideoDetailsStep>(Job));
				Run();
			}
			else if (new string[] { nameof(Job.Video.AddToPlaylist), nameof(Job.Video.PlaylistId) }.Contains(e.PropertyName)
				&& !Steps.Any(step => step is RetryingUploadStep<AddToPlaylistStep>))
			{
				LOGGER.Info($"Playlist settings changed for Job '{Job.Video.Title}'. Appending a new add to playlist step to refresh it.");

				Steps.Enqueue(new RetryingUploadStep<AddToPlaylistStep>(Job));
				Run();
			}

			if ((e.PropertyName == nameof(Job.Video.PlaylistServiceSettings)
				|| e.PropertyName == nameof(Job.Video.PublishAt)
				|| e.PropertyName == nameof(Job.Video.Privacy))
				&& !Steps.Any(step => step is RetryingUploadStep<SendToPlaylistServiceStep>))
			{
				LOGGER.Info($"Playlist service settings changed for Job '{Job.Video.Title}'. Appending a new send to playlist service step to refresh it.");

				Steps.Enqueue(new RetryingUploadStep<SendToPlaylistServiceStep>(Job));
				Run();
			}
		}

		private void RunningStepStateChanged(object sender, UploadStepStateChangedEventArgs e)
		{
			LOGGER.Info($"Running step state changed to '{e.NewState}' for Job '{Job.Video.Title}'");

			if (e.NewState == UploadStepState.Successful)
			{
				if (Steps.Count > 0)
				{
					LOGGER.Info($"Running next step for Job '{Job.Video.Title}'");

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
					LOGGER.Info($"Job '{Job.Video.Title}' finished successful");

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
			LOGGER.Info($"Resetting JobUploader for Job '{Job.Video.Title}'");

			Steps.Clear();

			if (Job.UploadStatus.CurrentStep != null)
			{
				LOGGER.Info($"Canceling current step");

				Job.UploadStatus.CurrentStep.StepStateChanged -= RunningStepStateChanged;
				Job.UploadStatus.CurrentStep.Cancel();
				Job.UploadStatus.CurrentStep = null;
			}

			StateChanged?.Invoke(this, new UploaderStateChangedEventArgs(JobState.NotStarted));
		}
	}
}
