using System;
using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class RetryingUploadStep<T> : AbstractUploadStep where T : AbstractUploadStep
	{
		private T Step { get; set; }

		private int WaitInterval { get; set; }

		public override double Progress => Step != null ? Step.Progress : 0;

		public new bool FinishedSuccessful => Step != null ? Step.FinishedSuccessful : false;

		public RetryingUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status, int waitInterval = 90000)
			: base(video, account, status)
		{
			Step = (T)Activator.CreateInstance(typeof(T), video, account, status);
			WaitInterval = waitInterval;
		}

		internal override void Run()
		{
			int tries = 0;
			var lastProgress = Status.Progress = 0.0;

			OnStepStateChanged(UploadStepState.NotStarted, UploadStepState.Running);
			CancellationTokenSource = new CancellationTokenSource();

			while (tries < 10 && !Step.FinishedSuccessful && !CancellationTokenSource.IsCancellationRequested)
			{
				tries++;

				try
				{
					Step.Run();

					if (!Step.FinishedSuccessful && !CancellationTokenSource.IsCancellationRequested)
					{
						WaitBeforeRetry();
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
					WaitBeforeRetry();
				}

				if (lastProgress < Status.Progress)
				{
					lastProgress = Status.Progress;
					tries = 0;
				}
			}

			if (Step.FinishedSuccessful)
			{
				OnStepFinished();
			}
			else if (!CancellationTokenSource.IsCancellationRequested)
			{
				OnStepStateChanged(UploadStepState.Running, UploadStepState.Error);
			}
		}

		private void WaitBeforeRetry()
		{
			OnStepStateChanged(UploadStepState.Running, UploadStepState.Broke);
			Thread.Sleep(WaitInterval);
			OnStepStateChanged(UploadStepState.Broke, UploadStepState.Running);
		}

		public override void RefreshDurationAndSpeed()
		{
			Step.RefreshDurationAndSpeed();
		}

		public override void Cancel()
		{
			if (RunningTask != null && RunningTask.Status == TaskStatus.Running)
			{
				CancellationTokenSource.Cancel();
				Step?.Cancel();
			}
		}
	}
}
