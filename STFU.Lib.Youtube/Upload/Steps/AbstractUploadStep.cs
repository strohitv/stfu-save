using System;
using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public abstract class AbstractUploadStep : IUploadStep
	{
		protected Task RunningTask { get; set; }

		protected CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

		protected IYoutubeVideo Video { get; }

		protected IYoutubeAccount Account { get; }

		protected UploadStatus Status { get; }

		public bool IsRunning => RunningTask != null && RunningTask.Status == TaskStatus.Running;

		public bool FinishedSuccessful { get; protected set; } = false;

		public AbstractUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
		{
			Video = video;
			Account = account;
			Status = status;
		}

		public void Cancel()
		{
			if (RunningTask != null && RunningTask.Status == TaskStatus.Running)
			{
				CancellationTokenSource.Cancel();
			}
		}

		public async void RunAsync()
		{
			RunningTask = Task.Run(() => Run());
			await RunningTask;
		}

		internal abstract void Run();

		public event StepFinishedEventHandler StepFinished;

		protected void OnStepFinished()
		{
			StepFinished?.Invoke(this, new EventArgs());
		}
	}
}
