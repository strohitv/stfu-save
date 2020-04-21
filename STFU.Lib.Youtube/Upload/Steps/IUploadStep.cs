using System.Threading;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public interface IUploadStep
	{
		// benötigt:
		// Start-Methode
		// Thread
		// Event bei Ende
		// Constructor nimmt Video, Account und UploadStatus
		event StepFinishedEventHandler StepFinished;

		bool IsRunning { get; }

		void StartThread();

		void Cancel();
	}
}
