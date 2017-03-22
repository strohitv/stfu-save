using System;
using System.Collections.Generic;
using System.Linq;

namespace STFU.UploadLib.Templates
{
	public class PublishRule
	{
		private int currentCount = 0;

		private IDictionary<DayOfWeek, IList<TimeSpan>> Times { get; set; }

		public PublishRule()
		{
			Times = new Dictionary<DayOfWeek, IList<TimeSpan>>();

			Times.Add(DayOfWeek.Sunday, new List<TimeSpan>());
			Times.Add(DayOfWeek.Monday, new List<TimeSpan>());
			Times.Add(DayOfWeek.Tuesday, new List<TimeSpan>());
			Times.Add(DayOfWeek.Wednesday, new List<TimeSpan>());
			Times.Add(DayOfWeek.Thursday, new List<TimeSpan>());
			Times.Add(DayOfWeek.Friday, new List<TimeSpan>());
			Times.Add(DayOfWeek.Saturday, new List<TimeSpan>());
		}

		public IList<TimeSpan> GetTimes(DayOfWeek day)
		{
			// ToList, um zu verhindern, dass Zugriff auf die eigentliche Liste möglich ist.
			return Times[day].ToList();
		}

		public void Add(DayOfWeek day, TimeSpan time)
		{
			Times[day].Add(time);
			Times[day].OrderBy(key => key);
		}

		internal void ResetCounter()
		{
			currentCount = 0;
		}

		internal DateTime NextTime(DateTime start)
		{
			return NextTime(start, currentCount++);
		}

		internal DateTime NextTime(DateTime start, int counter)
		{
			var firstTime = FirstTime(start, start.TimeOfDay);

			return default(DateTime);
		}

		private DateTime FirstTime(DateTime day, TimeSpan time)
		{
			if (CompleteCount == 0)
			{
				return default(DateTime);
			}

			var nextDate = DateTime.Now.Date;
			int dayCount = 7 - (int)nextDate.DayOfWeek - (int)day.DayOfWeek;
			nextDate = nextDate.AddDays(dayCount);

			if (Times[day.DayOfWeek].Count > 0)
			{
				var nextTime = Times[day.DayOfWeek].FirstOrDefault(t => t > time);

				if (nextTime == default(TimeSpan))
				{
					return FirstTime(day.AddDays(1), time);
				}

				return nextDate.Add(nextTime);
			}

			return FirstTime((DayOfWeek)(((int)day + 1) % 7), time);
		}

		private int CompleteCount
		{
			get
			{
				return Times[DayOfWeek.Monday].Count
					+ Times[DayOfWeek.Tuesday].Count
					+ Times[DayOfWeek.Wednesday].Count
					+ Times[DayOfWeek.Thursday].Count
					+ Times[DayOfWeek.Friday].Count
					+ Times[DayOfWeek.Saturday].Count
					+ Times[DayOfWeek.Sunday].Count;
			}
		}
	}
}
