using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubePlaylistContainer : IYoutubePlaylistContainer
	{
		private IList<IYoutubePlaylist> Playlists { get; } = new List<IYoutubePlaylist>();

		public IReadOnlyCollection<IYoutubePlaylist> RegisteredPlaylists => new ReadOnlyCollection<IYoutubePlaylist>(Playlists);

		public void RegisterPlaylist(IYoutubePlaylist playlist)
		{
			if (!RegisteredPlaylists.Any(p => p == playlist))
			{
				Playlists.Add(playlist);
			}
		}

		public void RegisterPlaylist(int newPosition, IYoutubePlaylist playlist)
		{
			if (!RegisteredPlaylists.Any(p => p == playlist))
			{
				Playlists.Insert(newPosition, playlist);
			}
		}

		public void UnregisterAllPlaylists()
		{
			Playlists.Clear();
		}

		public void UnregisterPlaylist(IYoutubePlaylist playlist)
		{
			if (Playlists.Contains(playlist))
			{
				Playlists.Remove(playlist);
			}
		}

		public void UnregisterPlaylistAt(int index)
		{
			if (Playlists.Count > index)
			{
				Playlists.RemoveAt(index);
			}
		}
	}
}
