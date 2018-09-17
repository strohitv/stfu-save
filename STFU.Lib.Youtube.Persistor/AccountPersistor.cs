using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class AccountPersistor
	{
		private string path = null;
		public string Path { get => path; private set => path = value; }

		IYoutubeAccountContainer container = null;
		public IYoutubeAccountContainer Container { get => container; private set => container = value; }

		IYoutubeAccountContainer saved = null;
		public IYoutubeAccountContainer Saved { get => saved; private set => saved = value; }

		private IYoutubeClientContainer clients { get; set; }

		public AccountPersistor(IYoutubeAccountContainer container, string path, IYoutubeClientContainer clients)
		{
			Path = path;
			Container = container;
			this.clients = clients;
		}

		public bool Load()
		{
			container.UnregisterAllAccounts();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var accounts = JsonConvert.DeserializeObject<YoutubeAccount[]>(json);

						foreach (var loaded in accounts)
						{
							foreach (var ac in loaded.Access)
							{
								ac.Client = clients.RegisteredClients.SingleOrDefault(rc => rc.Id == ac.ClientId);
							}

							for (int i = 0; i < loaded.Access.Count; i++)
							{
								if (loaded.Access[i].Client == null)
								{
									loaded.Access.RemoveAt(i);
									i--;
								}
							}

							container.RegisterAccount(loaded);
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
			IYoutubeAccount[] accounts = container.RegisteredAccounts.ToArray();

			var json = JsonConvert.SerializeObject(accounts);

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
			Saved = new YoutubeAccountContainer();
			foreach (var account in Container.RegisteredAccounts)
			{
				var newAccount = YoutubeAccount.Create(account.Id, account.Title, account.Region);

				Saved.RegisterAccount(newAccount);
			}
		}
	}
}
