using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using log4net;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeJobContainer: IYoutubeJobContainer
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(YoutubeJobContainer));

		private IList<IYoutubeJob> Jobs { get; } = new List<IYoutubeJob>();

		public IReadOnlyCollection<IYoutubeJob> RegisteredJobs => new ReadOnlyCollection<IYoutubeJob>(Jobs);

		public void RegisterJob(IYoutubeJob job)
		{
			if (!RegisteredJobs.Any(j => j == job))
			{
				LOGGER.Debug($"Adding a new job, video title: '{job.Video.Title}'");
				Jobs.Add(job);
			}
		}

		public void RegisterJob(int newPosition, IYoutubeJob job)
		{
			if (!RegisteredJobs.Any(j => j == job))
			{
				LOGGER.Debug($"Adding a new job, video title: '{job.Video.Title}' on position {newPosition}");
				Jobs.Insert(newPosition, job);
			}
		}

		public void UnregisterAllJobs()
		{
			LOGGER.Debug($"Removing all jobs");
			Jobs.Clear();
		}

		public void UnregisterJob(IYoutubeJob job)
		{
			if (Jobs.Contains(job))
			{
				LOGGER.Debug($"Removing job, video title: '{job.Video.Title}'");
				Jobs.Remove(job);
			}
		}

		public void UnregisterJobAt(int index)
		{
			if (Jobs.Count > index)
			{
				LOGGER.Debug($"Removing job at index {index}, video title: '{Jobs[index].Video.Title}'");
				Jobs.RemoveAt(index);
			}
		}
	}
}
