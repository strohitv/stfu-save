using System.Threading;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public interface IUploadStep
	{
		event StepFinishedEventHandler StepFinished;

		bool FinishedSuccessful { get; }

		bool IsRunning { get; }

		void RunAsync();

		void Cancel();
	}
}
