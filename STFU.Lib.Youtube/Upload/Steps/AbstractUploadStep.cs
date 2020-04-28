using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public abstract class AbstractUploadStep : IUploadStep
	{
		protected Task RunningTask { get; set; }

		protected CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

		public IYoutubeJob Job { get; }

		public IYoutubeVideo Video => Job.Video;

		public IYoutubeAccount Account => Job.Account;

		public UploadStatus Status => Job.UploadStatus;

		public abstract double Progress { get; }

		public bool IsRunning => RunningTask != null && RunningTask.Status == TaskStatus.Running;

		public bool FinishedSuccessful { get; protected set; } = false;

		public AbstractUploadStep(IYoutubeJob job)
		{
			Job = job;
		}

		public abstract void Cancel();

		public async void RunAsync()
		{
			RunningTask = Task.Run(() => Run());
			await RunningTask;
		}

		internal abstract void Run();

		public event UploadStepStateChangedEventHandler StepStateChanged;

		protected void OnStepFinished()
		{
			StepStateChanged?.Invoke(this, new UploadStepStateChangedEventArgs(UploadStepState.Running, UploadStepState.Successful));
		}

		protected void OnStepStateChanged(UploadStepState oldState, UploadStepState newState)
		{
			StepStateChanged?.Invoke(this, new UploadStepStateChangedEventArgs(oldState, newState));
		}

		public abstract void RefreshDurationAndSpeed();
	}
}
