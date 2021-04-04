using System;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public abstract class AbstractUploadStep : IUploadStep
	{
		protected ILog LOGGER { get; set; } = LogManager.GetLogger(nameof(AbstractUploadStep));

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
			LOGGER = LogManager.GetLogger(TypeName);
			LOGGER.Info($"Creating new Step {TypeName} for Job '{job.Video.Title}'");
			Job = job;
		}

		private string typeName;
		private string TypeName
		{
			get
			{
				if (typeName == null)
				{
					typeName = GetType().Name;
					var test = GetType().AssemblyQualifiedName.Split(new[] { "STFU.Lib.Youtube.Upload.Steps.", "," }, StringSplitOptions.RemoveEmptyEntries);
					if (test.Length >= 1)
					{
						typeName = typeName.Replace("`1", $"<{test[1]}>");
					}
				}

				return typeName;
			}
		}

		public abstract void Cancel();

		public async void RunAsync()
		{
			LOGGER.Info($"Running Step async...");
			RunningTask = Task.Run(() => Run());
			await RunningTask;
			LOGGER.Info($"Finished async step");
		}

		internal abstract void Run();

		public event UploadStepStateChangedEventHandler StepStateChanged;

		protected void OnStepFinished()
		{
			LOGGER.Info($"{TypeName} finished for Job '{Job.Video.Title}'");
			StepStateChanged?.Invoke(this, new UploadStepStateChangedEventArgs(UploadStepState.Running, UploadStepState.Successful));
		}

		protected void OnStepStateChanged(UploadStepState oldState, UploadStepState newState)
		{
			LOGGER.Info($"{TypeName} state changed from '{oldState}' to '{newState}' for Job '{Job.Video.Title}'");
			StepStateChanged?.Invoke(this, new UploadStepStateChangedEventArgs(oldState, newState));
		}

		public abstract void RefreshDurationAndSpeed();
	}
}
