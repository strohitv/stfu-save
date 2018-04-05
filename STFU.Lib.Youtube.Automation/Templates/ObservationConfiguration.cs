using System;

namespace STFU.Lib.Youtube.Automation.Templates
{
	public class ObservationConfiguration
	{
		public Path PathInfo { get; internal set; }
		public Template Template { get; internal set; }
		public bool IgnorePath { get; set; }
		public bool UploadPrivate { get; set; }
		public bool HasCustomStartDate { get; set; }
		public bool HasCustomStartDayIndex { get; set; }
		public DateTime StartDate { get; set; }
		public int? CustomStartDayIndex { get; set; }

		public ObservationConfiguration(Path pathInfo, Template template)
		{
			PathInfo = pathInfo;
			Template = template;
		}
	}
}
