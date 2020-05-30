using System;

namespace STFU.Lib.Youtube.Interfaces.Model.Args
{
	public class JobQueuedEventArgs : EventArgs
	{
		public JobQueuedEventArgs (IYoutubeJob job, int position)
		{
			Job = job;
			Position = position;
		}

		public IYoutubeJob Job { get; }

		public int Position { get; }
	}
}
