using System;

namespace STFU.UploadLib.Templates
{
	public class PublishTime
	{
		public DayOfWeek DayOfWeek { get; set; }

		public TimeSpan Time { get; set; }

		public int SkipDays { get; set; }
	}
}
