using System;
using System.ComponentModel;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Internal.Upload.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal interface IUploadStep : INotifyPropertyChanged
	{
		IYoutubeVideo Video { get; }

		IYoutubeAccount Account { get; }

		double Progress { get; }

		DateTime Started { get; }

		String CurrentSpeed { get; }

		TimeSpan CurrentDuration { get; }

		TimeSpan RemainingDuration { get; }

		UploadStepState State { get; }

		IYoutubeError Error { get; }

		Task RunAsync();
		void Cancel();
		void Pause();
		void Resume();
	}
}
