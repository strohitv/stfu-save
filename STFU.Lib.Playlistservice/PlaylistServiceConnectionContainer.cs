using STFU.Lib.Playlistservice.Model;

namespace STFU.Lib.Playlistservice
{
	public class PlaylistServiceConnectionContainer : IPlaylistServiceConnectionContainer
	{
		public PlaylistServiceConnection Connection { get; set; }
	}
}
