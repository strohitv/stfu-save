using Newtonsoft.Json;
using StrohisUploadLib.Accounts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StrohisUploadLib.Communication.Youtube
{
	internal class AccountCommunication
	{
		public static Account AddAccount()
		{
			var authRequestString = WebService.GetAuthUrl(true);
			Process.Start(authRequestString);

			string authtoken = Console.ReadLine();

			var response = WebService.ObtainAccessToken(authtoken);

			// Account holen
			Account account = new Account();

			if (response != null)
			{
				// Account 
				var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(response);

				if (!string.IsNullOrWhiteSpace(authResponse.access_token))
				{
					account.Access = new Accounts.Authentification()
					{
						AccessToken = authResponse.access_token,
						RefreshToken = authResponse.refresh_token,
						ExpireDate = DateTime.Now.Add(new TimeSpan(0, 0, authResponse.expires_in)),
						Type = authResponse.token_type,
					};
				}
			}

			return account;
		}

		public static Account RefreshAccess(Account account)
		{
			var response = WebService.RefreshAccess(account.Access.RefreshToken);

			if (response != null)
			{
				// Account 
				var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(response);

				if (!string.IsNullOrWhiteSpace(authResponse.access_token))
				{
					account.Access = new Accounts.Authentification()
					{
						AccessToken = authResponse.access_token,
						RefreshToken = account.Access.RefreshToken,
						ExpireDate = DateTime.Now.Add(new TimeSpan(0, 0, authResponse.expires_in)),
						Type = authResponse.token_type,
					};
				}
			}

			return account;
		}

		public static void RevokeAccess(Account account)
		{

		}

		private class YoutubeAuthResponse
		{
			public string access_token { get; set; }
			public string token_type { get; set; }
			public int expires_in { get; set; }
			public string refresh_token { get; set; }
		}
	}
}
