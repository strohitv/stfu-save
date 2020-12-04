using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.Lib.Playlistservice;
using STFU.Lib.Playlistservice.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class PlaylistServiceConnectionPersistor
	{
		public string Path { get; private set; } = null;
		public IPlaylistServiceConnectionContainer Container { get; private set; } = null;
		public IPlaylistServiceConnectionContainer Saved { get; private set; } = null;

		public PlaylistServiceConnectionPersistor(IPlaylistServiceConnectionContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			Container.Connection = null;

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						Container.Connection = JsonConvert.DeserializeObject<ServiceConnection>(reader.ReadToEnd());
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
			var json = JsonConvert.SerializeObject(Container.Connection);

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
			Saved = new PlaylistServiceConnectionContainer()
			{
				Connection = Container.Connection != null ? new ServiceConnection()
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
