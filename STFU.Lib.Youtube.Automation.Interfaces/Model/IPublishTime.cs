using System;

namespace STFU.Lib.Youtube.Automation.Interfaces.Model
{
	public interface IPublishTime
	{
		DayOfWeek DayOfWeek { get; set; }
		int SkipDays { get; set; }
		TimeSpan Time { get; set; }

		string ToString();
	}
}