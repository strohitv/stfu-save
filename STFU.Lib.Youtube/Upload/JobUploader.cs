using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using STFU.Lib.Youtube.Upload.Steps;

namespace STFU.Lib.Youtube.Upload
{
	public class JobUploader
	{
		readonly string[] videoPropertyNames;

		public YoutubeJob Job { get; }

		private Queue<IUploadStep> Steps { get; } = new Queue<IUploadStep>();

		public JobUploader(YoutubeJob job)
		{
			Job = job;

			Job.Video.PropertyChanged += VideoPropertyChanged;

			Steps.Enqueue(new VideoUploadStep(Job.Video, Job.Account, Job.UploadStatus));
			Steps.Enqueue(new ThumbnailUploadStep(Job.Video, Job.Account, Job.UploadStatus));
			Steps.Enqueue(new ChangeVideoDetailsStep(Job.Video, Job.Account, Job.UploadStatus));

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
				Steps.Enqueue(new VideoUploadStep(Job.Video, Job.Account, Job.UploadStatus));
				Steps.Enqueue(new ThumbnailUploadStep(Job.Video, Job.Account, Job.UploadStatus));
				Steps.Enqueue(new ChangeVideoDetailsStep(Job.Video, Job.Account, Job.UploadStatus));
			}

			if (Job.UploadStatus.CurrentStep == null || !Job.UploadStatus.CurrentStep.IsRunning)
			{
				if (Job.UploadStatus.CurrentStep != null)
				{
					Job.UploadStatus.CurrentStep.StepFinished -= RunningStepFinished;
				}

				Job.UploadStatus.CurrentStep = Steps.Dequeue();
				Job.UploadStatus.CurrentStep.StepFinished += RunningStepFinished;
			}

			Job.UploadStatus.CurrentStep.StartThread();
		}

		private void VideoPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Job.Video.ThumbnailPath)
				&& !Steps.Any(step => step is ThumbnailUploadStep))
			{
				Steps.Enqueue(new ThumbnailUploadStep(Job.Video, Job.Account, Job.UploadStatus));
				Run();
			}
			else if (videoPropertyNames.Contains(e.PropertyName)
				&& !Steps.Any(step => step is ChangeVideoDetailsStep))
			{
				Steps.Enqueue(new ChangeVideoDetailsStep(Job.Video, Job.Account, Job.UploadStatus));
				Run();
			}
		}

		private void RunningStepFinished(object sender, System.EventArgs e)
		{
			if (Steps.Count > 0)
			{
				if (Job.UploadStatus.CurrentStep != null)
				{
					Job.UploadStatus.CurrentStep.StepFinished -= RunningStepFinished;
				}

				Job.UploadStatus.CurrentStep = Steps.Dequeue();
				Job.UploadStatus.CurrentStep.StepFinished += RunningStepFinished;

				Job.UploadStatus.CurrentStep.StartThread();
			}
		}

		public void Reset()
		{
			Steps.Clear();

			if (Job.UploadStatus.CurrentStep != null)
			{
				Job.UploadStatus.CurrentStep.StepFinished -= RunningStepFinished;
				Job.UploadStatus.CurrentStep.Cancel();
				Job.UploadStatus.CurrentStep = null;
			}
		}
	}
}
