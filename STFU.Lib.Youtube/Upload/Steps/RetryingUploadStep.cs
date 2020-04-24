using System;
using System.Threading;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class RetryingUploadStep<T> : AbstractUploadStep where T : AbstractUploadStep
	{
		private T Step { get; set; }

		private int WaitInterval { get; set; }

		public RetryingUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status, int waitInterval = 90000)
			: base(video, account, status)
		{
			Step = (T)Activator.CreateInstance(typeof(T), video, account, status);
			WaitInterval = waitInterval;
		}

		// TODO: Status setzen!
		internal override void Run()
		{
			int tries = 0;
			var lastProgress = Status.Progress;

			while (tries < 10 && !Step.FinishedSuccessful)
			{
				tries++;

				try
				{
					Step.Run();

					if (!Step.FinishedSuccessful)
					{
						Thread.Sleep(WaitInterval);
					}
				}
				catch (Exception)
				{
					Thread.Sleep(WaitInterval);
				}

				if (lastProgress < Status.Progress)
				{
					lastProgress = Status.Progress;
					tries = 0;
				}
			}

			OnStepFinished();
		}
	}
}
