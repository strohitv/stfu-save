using System;
using log4net;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Internal.Templates
{
	public class PublishTimeCalculator
	{
		private static ILog LOGGER { get; set; } = LogManager.GetLogger(nameof(PublishTimeCalculator));

		public IPath PathInfo { get; internal set; }
		public ITemplate Template { get; internal set; }
		public bool UploadPrivate { get; set; }
		private DateTime LastVideoPublishTime { get; set; }
		private int PublishTimePosition { get; set; }

		bool first = true;

		public PublishTimeCalculator(IPath pathInfo, ITemplate template)
			: this(pathInfo, template.NextUploadSuggestion, template, null)
		{ }

		public PublishTimeCalculator(IPath pathInfo, DateTime startTime, ITemplate template, int? publishPosition = null)
		{
			LOGGER.Info($"Creating new publish time calculator for path: '{pathInfo?.Fullname}' with start time: '{startTime}', template with id: {template?.Id} and name: '{template?.Name}', and publish position: {publishPosition}");

			PathInfo = pathInfo;
			LastVideoPublishTime = startTime;
			Template = template;

			if (publishPosition == null || publishPosition < 0)
			{
				LOGGER.Info($"publish position is either not set or greater than zero => calculating next upload time from given values");

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

						LOGGER.Info($"next upload time '{nextSaveTime}' for publish position {publishPosition} fits better => taking this one");
					}
				}
			}

			LOGGER.Info($"Using publish time position {publishPosition.Value}");

			PublishTimePosition = publishPosition.Value;
		}

		public DateTime GetNextPublishTime(bool preview = false)
		{
			LOGGER.Info($"Calculating next publish time for template with id: {Template?.Id} and name: '{Template?.Name}', preview mode: {preview}");

			var publishDate = new DateTime(2000, 1, 1);

			var lastVidPubTime = LastVideoPublishTime;
			var pubTimePos = PublishTimePosition;

			while (publishDate < DateTime.Now)
			{
				LOGGER.Info($"Publish date '{publishDate}' is smaller than current date: '{DateTime.Now}', finding next upload possibility");

				int daysUntilNextTimesWeekday = ((int)Template.PublishTimes[pubTimePos].DayOfWeek - (int)lastVidPubTime.DayOfWeek + 7) % 7;

				if (CheckSameDayPublishing(daysUntilNextTimesWeekday))
				{
					daysUntilNextTimesWeekday = 7;
				}

				publishDate = lastVidPubTime.AddDays(daysUntilNextTimesWeekday).Date.Add(Template.PublishTimes[pubTimePos].Time);

				LOGGER.Info($"Days to add until next times weekday: {daysUntilNextTimesWeekday}, next possible publish time: '{publishDate}'");

				first = false;

				// Jetzt noch basierend der SkipDays die Daten berechnen, wenn das nicht nur eine Vorschau des nächsten Veröffentlichungsdatums sein sollte.
				lastVidPubTime = publishDate.AddDays(Template.PublishTimes[pubTimePos].SkipDays);

				var position = pubTimePos;
				var date = publishDate;
				while (date <= lastVidPubTime)
				{
					LOGGER.Info($"Publish date: '{date}' is older than last video publish time: '{lastVidPubTime}', calculating new publish time position");

					position = (position + 1) % Template.PublishTimes.Count;

					int days = ((int)Template.PublishTimes[position].DayOfWeek - (int)date.DayOfWeek + 7) % 7;

					if (days == 0 && Template.PublishTimes[position].Time <= date.TimeOfDay)
					{
						days = 7;
					}

					date = date.AddDays(days).Date.Add(Template.PublishTimes[position].Time);

					if (date > lastVidPubTime)
					{
						LOGGER.Info($"Publish time position was found to be: {position}");

						pubTimePos = position;
					}
				}
			}

			if (!preview)
			{
				LOGGER.Info($"No preview mode => saving last video publish time to '{lastVidPubTime}' and publish time position to {pubTimePos}");

				LastVideoPublishTime = lastVidPubTime;
				PublishTimePosition = pubTimePos;
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

		public int? GetDifference(string pathToCheck)
		{
			return PathInfo.GetDifference(pathToCheck);
		}
	}
}
