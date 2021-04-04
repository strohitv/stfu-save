using System;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Playlistservice;
using STFU.Lib.Playlistservice.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class PlaylistServiceConnectionPersistor
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(PlaylistServiceConnectionPersistor));

		public string Path { get; private set; } = null;
		public IPlaylistServiceConnectionContainer Container { get; private set; } = null;
		public IPlaylistServiceConnectionContainer Saved { get; private set; } = null;

		public PlaylistServiceConnectionPersistor(IPlaylistServiceConnectionContainer container, string path)
		{
			LOGGER.Debug($"Creating playlist service connection persistor for path '{path}'");

			Path = path;
			Container = container;
		}

		public bool Load()
		{
			LOGGER.Info($"Loading playlist service connection from path '{Path}'");
			Container.Connection = null;

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();
						LOGGER.Debug($"Json from loaded path: '{json}'");

						Container.Connection = JsonConvert.DeserializeObject<PlaylistServiceConnection>(json);
						LOGGER.Info($"Loaded playlist service connection");
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
				LOGGER.Error($"Could not load playlist service connection, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			LOGGER.Info($"Saving playlist service connection to file '{Path}'");

			var json = JsonConvert.SerializeObject(Container.Connection);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}
				LOGGER.Info($"Playlist service connection saved");

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
				LOGGER.Error($"Could not save playlist service connection, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			LOGGER.Debug($"Recreating cache of saved playlist service connection");
			Saved = new PlaylistServiceConnectionContainer()
			{
				Connection = Container.Connection != null ? new PlaylistServiceConnection()
				{
					Host = Container.Connection.Host,
					Port = Container.Connection.Port,
					Username = Container.Connection.Username,
					Password = Container.Connection.Password,
					Accounts = Container.Connection.Accounts.Select(a => new Account()
					{
						id = a.id,
						channelId = a.channelId,
						title = a.title
					}).ToArray(),
				} : null
			};
		}
	}
}
