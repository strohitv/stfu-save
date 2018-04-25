using System;

namespace STFU.Lib.Youtube.Automation.Interfaces.Model
{
	public interface IObservationConfiguration
	{
		IPath PathInfo { get; }
		ITemplate Template { get; }
		bool IgnorePath { get; set; }
		bool UploadPrivate { get; set; }
		bool HasCustomStartDate { get; set; }
		bool HasCustomStartDayIndex { get; set; }
		DateTime StartDate { get; set; }
		int? CustomStartDayIndex { get; set; }
	}
}
