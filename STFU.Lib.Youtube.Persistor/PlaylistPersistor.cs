using System;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class PlaylistPersistor
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(PlaylistPersistor));

		public string Path { get; private set; } = null;
		public IYoutubePlaylistContainer Container { get; private set; } = null;
		public IYoutubePlaylistContainer Saved { get; private set; } = null;

		public PlaylistPersistor(IYoutubePlaylistContainer container, string path)
		{
			LOGGER.Debug($"Creating path persistor for path '{path}'");

			Path = path;
			Container = container;
		}

		public bool Load()
		{
			LOGGER.Info($"Loading playlists from path '{Path}'");
			Container.UnregisterAllPlaylists();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();
						LOGGER.Debug($"Json from loaded path: '{json}'");

						var playlists = JsonConvert.DeserializeObject<YoutubePlaylist[]>(json);
						LOGGER.Info($"Loaded {playlists.Length} playlists");

						foreach (var loaded in playlists)
						{
							LOGGER.Info($"Adding playlist '{loaded.Title}'");
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
				LOGGER.Error($"Could not load playlists, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			IYoutubePlaylist[] playlists = Container.RegisteredPlaylists.ToArray();
			LOGGER.Info($"Saving {playlists.Length} playlists to file '{Path}'");

			var json = JsonConvert.SerializeObject(playlists);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}
				LOGGER.Info($"Playlists saved");

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
				LOGGER.Error($"Could not save playlists, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			LOGGER.Debug($"Recreating cache of saved playlists");
			Saved = new YoutubePlaylistContainer();
			foreach (var playlist in Container.RegisteredPlaylists)
			{
				LOGGER.Debug($"Recreating cache for playlist '{playlist.Title}'");
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