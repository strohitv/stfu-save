using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Interfaces.Model.Events;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface IAutomationUploader : INotifyPropertyChanged
	{
		IYoutubeUploader Uploader { get; set; }

		IYoutubeAccount Account { get; set; }

		ITemplateContainer Templates { get; set; }

		IPathContainer Paths { get; set; }
		
		IList<IObservationConfiguration> Configuration { get; }

		event FileToUploadPlannedEventHandler FileToUploadOccured;

		/// <summary>
		/// Setting this value while Uploader has state other than not running will be ignored.
		/// To set while running set Pause Property to true.
		/// Settings will be ignored if EndAfterUpload is set.
		/// </summary>
		IProcessList WatchedProcesses { get; set; }

		bool EndAfterUpload { get; set; }

		RunningState State { get; }

		void StartAsync();

		void StartWithExtraConfigAsync();

		void Cancel();
	}
}
