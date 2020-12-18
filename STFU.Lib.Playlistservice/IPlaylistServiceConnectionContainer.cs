using STFU.Lib.Playlistservice.Model;

namespace STFU.Lib.Playlistservice
{
	public interface IPlaylistServiceConnectionContainer
	{
		PlaylistServiceConnection Connection { get; set; }
	}
}
