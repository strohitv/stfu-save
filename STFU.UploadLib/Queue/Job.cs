using STFU.UploadLib.Accounts;
using STFU.UploadLib.Videos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.UploadLib.Queue
{
	public class Job
	{
		public UploadDetails Status { get; set; }
		public Account UploadingAccount { get; set; }
		public Video SelectedVideo { get; set; }
	}
}
