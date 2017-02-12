using System;
using Newtonsoft.Json;
using STFU.UploadLib.Accounts;

namespace STFU.UploadLib.Communication.Youtube
{
	internal class AccountCommunication
	{
		public static string GetAuthUrl(bool showAuthToken)
		{
			return WebService.GetAuthUrl(showAuthToken);
		}

		public static string GetLogoffAndAuthUrl(bool showAuthToken)
		{
			return WebService.LogoutAndThenGetAuthUrl(showAuthToken);
		}

		public static Account ConnectAccount(string authToken)
		{
			//var authRequestString = WebService.GetAuthUrl(true);
			//Process.Start(authRequestString);

			//string authtoken = Console.ReadLine();

			var response = WebService.ObtainAccessToken(authToken);

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

		public static bool RevokeAccess(Account account)
		{
			return !string.IsNullOrWhiteSpace(WebService.RevokeAccess(account));
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
