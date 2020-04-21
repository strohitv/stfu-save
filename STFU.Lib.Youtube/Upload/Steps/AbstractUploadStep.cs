using System;
using System.Threading;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public abstract class AbstractUploadStep : IUploadStep
	{
		private Thread RunningThread { get; set; }

		private IYoutubeVideo Video { get; }

		private IYoutubeAccount Account { get; }

		private UploadStatus Status { get; }

		public bool IsRunning => RunningThread != null && RunningThread.IsAlive;

		public AbstractUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
		{
			Video = video;
			Account = account;
			Status = status;
		}

		public void Cancel()
		{
			if (RunningThread != null && RunningThread.IsAlive)
			{
				RunningThread.Abort();
			}
		}

		public void StartThread()
		{
			if (RunningThread != null || !RunningThread.IsAlive)
			{
				RunningThread = new Thread(() => Run());
				RunningThread.Start();
			}
		}

		internal abstract void Run();
		
		public event StepFinishedEventHandler StepFinished;

		protected void OnStepFinished()
		{
			StepFinished?.Invoke(this, new EventArgs());
		}
	}
}
