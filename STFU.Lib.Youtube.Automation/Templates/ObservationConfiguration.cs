using System;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Templates
{
	public class ObservationConfiguration: IObservationConfiguration
	{
		public IPath PathInfo { get; internal set; }
		public ITemplate Template { get; internal set; }
		public bool IgnorePath { get; set; }
		public bool UploadPrivate { get; set; }
		public bool HasCustomStartDate { get; set; }
		public bool HasCustomStartDayIndex { get; set; }
		public DateTime StartDate { get; set; }
		public int? CustomStartDayIndex { get; set; }

		public ObservationConfiguration(IPath pathInfo, ITemplate template)
		{
			PathInfo = pathInfo;
			Template = template;
		}
	}
}
