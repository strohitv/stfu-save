using System;
using STFU.UploadLib.Accounts;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Queue
{
	public class Job
	{
		public UploadDetails Status { get; set; }
		public Account UploadingAccount { get; set; }
		public Video SelectedVideo { get; set; }
		public Uri Url { get; set; }
	}
}
