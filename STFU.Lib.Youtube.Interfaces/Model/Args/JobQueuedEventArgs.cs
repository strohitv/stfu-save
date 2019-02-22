using System;

namespace STFU.Lib.Youtube.Interfaces.Model.Args
{
	public class JobQueuedEventArgs : EventArgs
	{
		public JobQueuedEventArgs (IYoutubeVideo video, int position)
		{
			Video = video;
			Position = position;
		}

		public IYoutubeVideo Video { get; }

		public int Position { get; }
	}
}
