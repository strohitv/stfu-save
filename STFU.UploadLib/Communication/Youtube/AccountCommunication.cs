using System;
using System.Linq;
using Newtonsoft.Json;
using STFU.UploadLib.Accounts;
using STFU.UploadLib.Communication.Youtube.Serializable;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Communication.Youtube
{
	internal class AccountCommunication
	{
		public static string GetAuthUrl(bool showAuthToken)
		{
			return WebService.GetAuthUrl(showAuthToken);
		}

		public static string GetLogoffAndAuthUrl(bool showAuthToken, bool logout = false)
		{
			if (logout)
			{
				return WebService.LogoutAndThenGetAuthUrl(showAuthToken);
			}
			else
			{
				return WebService.GetAuthUrl(showAuthToken);
			}
		}

		public static Account LoadAccountDetails(Account account)
		{
			var accountDetails = WebService.GetAccountDetails(account.Access.AccessToken);

			account.Title = accountDetails.items.First().snippet.title;
			account.Id = accountDetails.items.First().id;
			account.Region = accountDetails.items.First().snippet.country;

			return account;
		}

		public static Account FillAccountWithAvailableVideoCategories(Account account)
		{
			var categories = WebService.GetVideoCategories(account.Region, account.Access.AccessToken);

			account.AvailableCategories = categories.items.Where(i => i.snippet.assignable).Select(i => new Category(int.Parse(i.id), i.snippet.title)).ToArray();

			return account;
		}

		public static Language[] LoadYoutubeLanguages(string accessToken)
		{
			return WebService.GetLanguages(accessToken).items.Select(i => new Language() { Id = i.id, Hl = i.snippet.hl, Name = i.snippet.name }).OrderBy(lang => lang.Name).ToArray();
		} 

		public static Account ConnectAccount(string authToken, bool useLocalHostRedirect = true)
		{
			var response = WebService.ObtainAccessToken(authToken, useLocalHostRedirect);

			// Account holen
			Account account = new Account();

			if (response != null)
			{
				// Account 
				var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(response);

				if (!string.IsNullOrWhiteSpace(authResponse.access_token))
				{
					account.Access = new Authentification()
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

			if (response != null && !response.Contains("revoked"))
			{
				// Account 
				var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(response);

				if (!string.IsNullOrWhiteSpace(authResponse.access_token))
				{
					account.Access = new Authentification()
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
