using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STFU.Lib.Playlistservice.Model;

namespace STFU.Lib.Playlistservice
{
	public interface IPlaylistServiceConnectionContainer
	{
		PlaylistServiceConnection Connection { get; set; }
	}
}
