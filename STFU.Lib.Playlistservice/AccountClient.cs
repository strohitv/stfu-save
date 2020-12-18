using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using STFU.Lib.Playlistservice.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Playlistservice
{
	public class AccountClient : AbstractClient
	{
		public AccountClient(Uri host) : base(host) { }
		public AccountClient(Uri host, string user, string pass) : base(host, user, pass) { }

		public Account[] GetAllAccounts()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, "/accounts"));
			request.Method = "GET";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			string json = WebService.Communicate(request);

			return JsonConvert.DeserializeObject<Account[]>(json);
		}

		public Account AddAccount(AuthCode code)
		{
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

			return JsonConvert.DeserializeObject<Account>(json);
		}

		public string DeleteAccount(Account account)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, $"/accounts/{account.id}"));
			request.Method = "DELETE";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			return WebService.Communicate(request);
		}

		public string DeleteAllAccounts()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, $"/accounts"));
			request.Method = "DELETE";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			return WebService.Communicate(request);
		}
	}
}
