using STFU.Lib.Youtube.Interfaces.Model.Handler;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IUploadStep
	{
		event UploadStepStateChangedEventHandler StepStateChanged;

		IYoutubeJob Job { get; }

		IYoutubeVideo Video { get; }

		IYoutubeAccount Account { get; }

		UploadStatus Status { get; }

		bool FinishedSuccessful { get; }

		double Progress { get; }

		bool IsRunning { get; }

		void RunAsync();

		void Cancel();

		void RefreshDurationAndSpeed();
	}
}
