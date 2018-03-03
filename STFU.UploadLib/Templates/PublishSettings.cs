using System;
using STFU.UploadLib.Automation;

namespace STFU.UploadLib.Templates
{
	public class PublishSettings
	{
		public PathInformation PathInfo { get; internal set; }
		public Template Template { get; internal set; }
		public bool IgnorePath { get; set; }
		public bool UploadPrivate { get; set; }
		public bool HasCustomStartDate { get; set; }
		public bool HasCustomStartDayIndex { get; set; }
		public DateTime StartDate { get; set; }
		public int? CustomStartDayIndex { get; set; }

		public PublishSettings(PathInformation pathInfo, Template template)
		{
			PathInfo = pathInfo;
			Template = template;
		}
	}
}
