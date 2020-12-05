using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public class PlaylistServiceSettings
	{
		public bool ShouldSend { get; set; }

		public string Host { get; set; }
		public string Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public long AccountId { get; set; }

		public string PlaylistId { get; set; }
		public string PlaylistTitle { get; set; }
	}
}
