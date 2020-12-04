using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Lib.Playlistservice.Model
{
	public class ServiceConnection
	{
		public string Host { get; set; }
		public string Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public Account[] Accounts { get; set; }
	}
}
