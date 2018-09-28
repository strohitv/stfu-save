using System;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public class UploadStartedEventArgs : EventArgs
	{
		public IYoutubeJob Job { get; }

		public UploadStartedEventArgs(IYoutubeJob job)
		{
			Job = job;
		}
	}
}
