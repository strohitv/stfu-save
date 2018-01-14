using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STFU.UploadLib.Automation;

namespace STFU.UploadLib.Templates
{
	internal class PublishInformation
	{
		private PathInformation PathInfo { get; set; }
		private Template Template { get; set; }
		private DateTime LastVideoPublishTime { get; set; }
		private int PublishTimePosition { get; set; }

		internal PublishInformation(PathInformation pathInfo, DateTime startTime, Template template)
		{
			PathInfo = pathInfo;
			LastVideoPublishTime = startTime;
			Template = template;

			int publishPosition = -1;
			DateTime saveTime = startTime;
			for (int i = 0; i < Template.PublishTimes.Count; i++)
			{
				var nextSaveTime = startTime;
				if (startTime.TimeOfDay > Template.PublishTimes[i].Time)
				{
					// Heute ist nicht mehr möglich => Tag hinzufügen
					nextSaveTime += new TimeSpan(1, 0, 0, 0);
				}

				int daysUntilTuesday = ((int)Template.PublishTimes[i].DayOfWeek - (int)nextSaveTime.DayOfWeek + 7) % 7;
				nextSaveTime = nextSaveTime.AddDays(daysUntilTuesday);
				nextSaveTime = nextSaveTime.Date.Add(Template.PublishTimes[i].Time);
				if (saveTime - nextSaveTime > new TimeSpan(0, 0, 0) || publishPosition < 0)
				{
					// Zeit liegt näher
					saveTime = nextSaveTime;
					publishPosition = i;
				}
			}

			PublishTimePosition = publishPosition;
		}

		internal DateTime GetNextPublishTime()
		{
			LastVideoPublishTime = PreviewNextPublishTime(); 
			PublishTimePosition = (PublishTimePosition + 1) % Template.PublishTimes.Count;

			return LastVideoPublishTime;
		}

		internal DateTime PreviewNextPublishTime()
		{
			// Skipdays einbeziehen.

			int daysUntilTuesday = ((int)Template.PublishTimes[PublishTimePosition].DayOfWeek - (int)LastVideoPublishTime.DayOfWeek + 7) % 7;
			return LastVideoPublishTime.AddDays(daysUntilTuesday).Date.Add(Template.PublishTimes[PublishTimePosition].Time);
		}
	}
}
