using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IYoutubeJobContainer
	{
		IReadOnlyCollection<IYoutubeJob> RegisteredJobs { get; }

		void RegisterJob(IYoutubeJob job);
		void UnregisterAllJobs();
		void UnregisterJob(IYoutubeJob job);
		void UnregisterJobAt(int index);
		void RegisterJob(int newPosition, IYoutubeJob job);
	}
}
