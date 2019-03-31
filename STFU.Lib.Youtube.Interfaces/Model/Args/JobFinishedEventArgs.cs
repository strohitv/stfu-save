using System;

namespace STFU.Lib.Youtube.Interfaces.Model.Args
{
	public class JobFinishedEventArgs : EventArgs
	{
		public JobFinishedEventArgs(IYoutubeJob job)
		{
			Job = job;
		}

		public IYoutubeJob Job { get; }
	}
}
