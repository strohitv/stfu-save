using System;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface IAutomationUploader
	{
		IYoutubeUploader Uploader { get; }

		RunningState State { get; }

		void StartAsync(DateTime standardStartTime, IObservationConfiguration[] pathsToObserve);

		void Cancel();
	}
}
