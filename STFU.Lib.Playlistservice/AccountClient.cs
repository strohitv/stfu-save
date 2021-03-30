using System;
using System.Net;
using System.Text;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Playlistservice.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Playlistservice
{
	public class AccountClient : AbstractClient
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(AccountClient));

		public AccountClient(Uri host) : base(host) { }
		public AccountClient(Uri host, string user, string pass) : base(host, user, pass) { }

		public Account[] GetAllAccounts()
		{
			LOGGER.Info($"Getting all accounts");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, "/accounts"));
			request.Method = "GET";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			string json = WebService.Communicate(request);
			Account[] accounts = JsonConvert.DeserializeObject<Account[]>(json);

			LOGGER.Info($"Returning {accounts.Length} accounts");

			return accounts;
		}

		public Account AddAccount(AuthCode code)
		{
			LOGGER.Info($"Adding a new account");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, "/accounts"));
			request.Method = "POST";
			request.Accept = "application/json";
			request.ContentType = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(code));
			string json = WebService.Communicate(request, bytes);

			LOGGER.Info($"Got a result, returning account");

			return JsonConvert.DeserializeObject<Account>(json);
		}

		public string DeleteAccount(Account account)
		{
			LOGGER.Info($"Deleting account with id: {account.id}");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, $"/accounts/{account.id}"));
			request.Method = "DELETE";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}
			
			string result = WebService.Communicate(request);

			LOGGER.Info($"Got a result, returning it");

			return result;
		}

		public string DeleteAllAccounts()
		{
			LOGGER.Info($"Deleting all accounts");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, $"/accounts"));
			request.Method = "DELETE";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			string result = WebService.Communicate(request);

			LOGGER.Info($"Got a result, returning it");

			return result;
		}
	}
}
