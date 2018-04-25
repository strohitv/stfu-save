using System;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Internal.Templates
{
	internal class PublishTimeCalculator
	{
		public IPath PathInfo { get; internal set; }
		public ITemplate Template { get; internal set; }
		internal bool IgnorePath { get; set; }
		internal bool UploadPrivate { get; set; }
		private DateTime LastVideoPublishTime { get; set; }
		private int PublishTimePosition { get; set; }

		bool first = true;

		internal PublishTimeCalculator(IPath pathInfo, DateTime startTime, ITemplate template, int? publishPosition = null)
		{
			PathInfo = pathInfo;
			LastVideoPublishTime = startTime;
			Template = template;

			if (publishPosition == null || publishPosition < 0)
			{
				publishPosition = -1;

				DateTime saveTime = startTime;
				for (int i = 0; i < Template.PublishTimes.Count; i++)
				{
					var nextSaveTime = startTime;
					if (startTime.TimeOfDay > Template.PublishTimes[i].Time)
					{
						// Heute ist nicht mehr möglich => Tag hinzufügen
						nextSaveTime += new TimeSpan(1, 0, 0, 0);
					}

					int daysUntilPublishDay = ((int)Template.PublishTimes[i].DayOfWeek - (int)nextSaveTime.DayOfWeek + 7) % 7;
					nextSaveTime = nextSaveTime.AddDays(daysUntilPublishDay);
					nextSaveTime = nextSaveTime.Date.Add(Template.PublishTimes[i].Time);
					if (saveTime - nextSaveTime > new TimeSpan(0, 0, 0) || publishPosition < 0)
					{
						// Zeit liegt näher
						saveTime = nextSaveTime;
						publishPosition = i;
					}
				}
			}

			PublishTimePosition = publishPosition.Value;
		}

		internal DateTime GetNextPublishTime(bool preview = false)
		{
			int daysUntilNextTimesWeekday = ((int)Template.PublishTimes[PublishTimePosition].DayOfWeek - (int)LastVideoPublishTime.DayOfWeek + 7) % 7;

			if (CheckSameDayPublishing(daysUntilNextTimesWeekday))
			{
				daysUntilNextTimesWeekday = 7;
			}

			var publishDate = LastVideoPublishTime.AddDays(daysUntilNextTimesWeekday).Date.Add(Template.PublishTimes[PublishTimePosition].Time);

			if (!preview)
			{
				first = false;

				// Jetzt noch basierend der SkipDays die Daten berechnen, wenn das nicht nur eine Vorschau des nächsten Veröffentlichungsdatums sein sollte.
				LastVideoPublishTime = publishDate.AddDays(Template.PublishTimes[PublishTimePosition].SkipDays);
				var position = PublishTimePosition;
				var date = publishDate;
				while (true)
				{
					position = (position + 1) % Template.PublishTimes.Count;

					int days = ((int)Template.PublishTimes[position].DayOfWeek - (int)date.DayOfWeek + 7) % 7;

					if (days == 0 && Template.PublishTimes[position].Time <= date.TimeOfDay)
					{
						days = 7;
					}

					date = date.AddDays(days).Date.Add(Template.PublishTimes[position].Time);

					if (date > LastVideoPublishTime)
					{
						PublishTimePosition = position;
						break;
					}
				}
			}

			return publishDate;
		}

		private bool CheckSameDayPublishing(int daysUntilNextTimesWeekday)
		{
			if (first)
			{
				return daysUntilNextTimesWeekday == 0 && Template.PublishTimes[PublishTimePosition].Time < LastVideoPublishTime.TimeOfDay;
			}

			return daysUntilNextTimesWeekday == 0 && Template.PublishTimes[PublishTimePosition].Time <= LastVideoPublishTime.TimeOfDay;
		}

		internal int? GetDifference(string pathToCheck)
		{
			return PathInfo.GetDifference(pathToCheck);
		}
	}
}
