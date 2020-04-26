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

			Steps.Enqueue(new RetryingUploadStep<VideoUploadStep>(Job.Video, Job.Account, Job.UploadStatus));
			Steps.Enqueue(new RetryingUploadStep<ThumbnailUploadStep>(Job.Video, Job.Account, Job.UploadStatus));
			Steps.Enqueue(new RetryingUploadStep<ChangeVideoDetailsStep>(Job.Video, Job.Account, Job.UploadStatus));

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

		public void RefreshAccount(IYoutubeAccount account)
		{
			foreach (var step in Steps)
			{
				step.Account = account;
			}
		}

		public void Run()
		{
			if (Steps.Count == 0)
			{
				Steps.Enqueue(new RetryingUploadStep<VideoUploadStep>(Job.Video, Job.Account, Job.UploadStatus));
				Steps.Enqueue(new RetryingUploadStep<ThumbnailUploadStep>(Job.Video, Job.Account, Job.UploadStatus));
				Steps.Enqueue(new RetryingUploadStep<ChangeVideoDetailsStep>(Job.Video, Job.Account, Job.UploadStatus));
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
				Steps.Enqueue(new RetryingUploadStep<ThumbnailUploadStep>(Job.Video, Job.Account, Job.UploadStatus));
				Run();
			}
			else if (videoPropertyNames.Contains(e.PropertyName)
				&& !Steps.Any(step => step is RetryingUploadStep<ChangeVideoDetailsStep>))
			{
				Steps.Enqueue(new RetryingUploadStep<ChangeVideoDetailsStep>(Job.Video, Job.Account, Job.UploadStatus));
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
