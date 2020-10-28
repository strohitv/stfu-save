using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IYoutubePlaylistContainer
	{
		IReadOnlyCollection<IYoutubePlaylist> RegisteredPlaylists { get; }

		void RegisterPlaylist(IYoutubePlaylist playlist);
		void UnregisterAllPlaylists();
		void UnregisterPlaylist(IYoutubePlaylist playlist);
		void UnregisterPlaylistAt(int index);
	}
}
