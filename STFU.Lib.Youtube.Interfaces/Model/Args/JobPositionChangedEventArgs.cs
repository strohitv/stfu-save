using System;

namespace STFU.Lib.Youtube.Interfaces.Model.Args
{
	public class JobPositionChangedEventArgs : EventArgs
	{
		public JobPositionChangedEventArgs(IYoutubeJob job, int oldPosition, int newPosition)
		{
			Job = job;
			OldPosition = oldPosition;
			NewPosition = newPosition;
		}

		public IYoutubeJob Job { get; }

		public int OldPosition { get; }

		public int NewPosition { get; }
	}
}
