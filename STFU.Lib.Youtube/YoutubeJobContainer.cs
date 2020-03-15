using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeJobContainer: IYoutubeJobContainer
	{
		private IList<IYoutubeJob> Jobs { get; } = new List<IYoutubeJob>();

		public IReadOnlyCollection<IYoutubeJob> RegisteredJobs => new ReadOnlyCollection<IYoutubeJob>(Jobs);

		public void RegisterJob(IYoutubeJob job)
		{
			if (!RegisteredJobs.Any(j => j == job))
			{
				Jobs.Add(job);
			}
		}

		public void RegisterJob(int newPosition, IYoutubeJob job)
		{
			if (!RegisteredJobs.Any(j => j == job))
			{
				Jobs.Insert(newPosition, job);
			}
		}

		public void UnregisterAllJobs()
		{
			Jobs.Clear();
		}

		public void UnregisterJob(IYoutubeJob job)
		{
			if (Jobs.Contains(job))
			{
				Jobs.Remove(job);
			}
		}

		public void UnregisterJobAt(int index)
		{
			if (Jobs.Count > index)
			{
				Jobs.RemoveAt(index);
			}
		}
	}
}
