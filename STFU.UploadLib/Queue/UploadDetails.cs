using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.UploadLib.Queue
{
	public class UploadDetails
	{
		public double Progress { get; set; }
		public bool Finished { get; set; }
		public bool Failed { get; set; }
		public bool Running { get; set; }
	}
}
