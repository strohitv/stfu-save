using System;
using System.IO;
using Newtonsoft.Json;
using STFU.Lib.Twitter;
using STFU.Lib.Twitter.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class TwitterAccountPersistor
	{
		public string Path { get; private set; } = null;
		public ITwitterAccountContainer Container { get; private set; } = null;

		public TwitterAccountPersistor(ITwitterAccountContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			Container.Account = null;

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var account = JsonConvert.DeserializeObject<TwitterAccount>(json);
						Container.Account = account;
					}
				}
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
			ITwitterAccount account = Container.Account;

			var json = JsonConvert.SerializeObject(account);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}
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
	}
}
