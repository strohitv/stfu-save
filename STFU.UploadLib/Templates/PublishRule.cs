using System;
using System.Collections.Generic;
using System.Linq;

namespace STFU.UploadLib.Templates
{
	public class PublishRule
	{
		private int currentDayCount = 0;
		private DateTime startDateTime = DateTime.Now;
		private List<DateTime> allTimes = new List<DateTime>();
		private int dayOfWeek = 0;

		private bool isStarted = false;

		private IDictionary<DayOfWeek, IList<TimeSpan>> Times { get; set; }

		public bool IsStarted { get { return isStarted; } }

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

		/// <summary>
		/// returns a copy of Timespans for the asked day. Changes on this copy do not affect the PublishRule.
		/// </summary>
		/// <param name="day"></param>
		/// <returns></returns>
		public IList<TimeSpan> GetTimes(DayOfWeek day)
		{
			// ToList, um zu verhindern, dass Zugriff auf die eigentliche Liste möglich ist.
			return Times[day].Select(key => new TimeSpan(key.Ticks)).ToList();
		}

		public void Add(DayOfWeek day, TimeSpan time)
		{
			Times[day].Add(time);
			Times[day].OrderBy(key => key);
		}

		public void ClearForDay(DayOfWeek day)
		{
			Times[day].Clear();
		}

		public void ClearAll()
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

		internal void ResetCounter()
		{
			currentDayCount = 0;
		}

		internal DateTime NextTime(int skipCount)
		{
			if (CompleteCount == 0)
			{
				return default(DateTime);
			}

			// Fill the list with new times if it is empty or more items than in the list should be skipped.
			while (allTimes.Count == 0 || allTimes.Count < skipCount)
			{
				foreach (var t in Times[(DayOfWeek)dayOfWeek])
				{
					allTimes.Add(startDateTime.Date.AddDays(currentDayCount).Add(t));
				}

				currentDayCount++;
				dayOfWeek++;
				dayOfWeek %= 7;
			}

			DateTime next;
			do
			{
				next = allTimes.First();
				allTimes.RemoveAt(0);
				skipCount--;
			} while (skipCount > 0);

			return next;
		}

		internal void Start(DateTime startDt)
		{
			startDateTime = startDt;
			currentDayCount = 0;
			dayOfWeek = (int)startDateTime.DayOfWeek;

			var greaterTimesToday = Times[(DayOfWeek)dayOfWeek].Where(t => t >= startDateTime.TimeOfDay);
			foreach (var t in greaterTimesToday)
			{
				allTimes.Add(startDateTime.Date.Add(t));
			}

			currentDayCount++;
			dayOfWeek++;
			dayOfWeek %= 7;

			isStarted = true;
		}

		/// <summary>
		/// returns the first publish time after the given date and time.
		/// </summary>
		/// <param name="day"></param>
		/// <param name="time"></param>
		/// <returns></returns>
		internal DateTime NextTime()
		{
			return NextTime(0);
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
