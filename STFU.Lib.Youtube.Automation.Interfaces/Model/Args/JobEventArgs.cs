using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Interfaces.Model.Args
{
	public class JobEventArgs : EventArgs
	{
		public IYoutubeJob Job { get; set; }

		public JobEventArgs(IYoutubeJob job)
		{
			Job = job;
		}
	}
}
