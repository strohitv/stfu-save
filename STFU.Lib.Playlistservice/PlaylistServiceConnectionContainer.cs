using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STFU.Lib.Playlistservice.Model;

namespace STFU.Lib.Playlistservice
{
	public class PlaylistServiceConnectionContainer : IPlaylistServiceConnectionContainer
	{
		public PlaylistServiceConnection Connection { get; set; }
	}
}
