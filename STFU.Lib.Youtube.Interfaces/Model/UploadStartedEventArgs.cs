using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
