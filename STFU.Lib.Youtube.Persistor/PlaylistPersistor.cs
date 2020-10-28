using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class PlaylistPersistor
	{
		public string Path { get; private set; } = null;
		public IYoutubePlaylistContainer Container { get; private set; } = null;
		public IYoutubePlaylistContainer Saved { get; private set; } = null;

		public PlaylistPersistor(IYoutubePlaylistContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			Container.UnregisterAllPlaylists();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var playlists = JsonConvert.DeserializeObject<YoutubePlaylist[]>(json);

						foreach (var loaded in playlists)
						{
							Container.RegisterPlaylist(loaded);
						}
					}
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			IYoutubePlaylist[] playlists = Container.RegisteredPlaylists.ToArray();

			var json = JsonConvert.SerializeObject(playlists);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			Saved = new YoutubePlaylistContainer();
			foreach (var playlist in Container.RegisteredPlaylists)
			{
				var newPlaylist = new YoutubePlaylist()
				{
					Id = playlist.Id,
					Title = playlist.Title,
					PublishedAt = playlist.PublishedAt
				};

				Saved.RegisterPlaylist(newPlaylist);
			}
		}
	}
}