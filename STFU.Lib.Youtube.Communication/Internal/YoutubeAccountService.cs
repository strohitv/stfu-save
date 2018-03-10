using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Common.Model;
using STFU.Lib.Youtube.Communication.Interfaces.Enums;
using STFU.Lib.Youtube.Communication.InternalInterfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication.Internal
{
	internal static class YoutubeAccountService
	{
		private static IDictionary<IYoutubeAccount, IList<IYoutubeAccountAccess>> Accounts { get; set; }

		internal static IReadOnlyDictionary<IYoutubeAccount, IList<IYoutubeAccountAccess>> ConnectedAccounts
			=> new ReadOnlyDictionary<IYoutubeAccount, IList<IYoutubeAccountAccess>>(Accounts);

		static YoutubeAccountService()
		{
			Accounts = new Dictionary<IYoutubeAccount, IList<IYoutubeAccountAccess>>(new YoutubeAccountComparer());
		}

		internal static IYoutubeAccount ConnectAccount(string code, IYoutubeClient client, YoutubeRedirectUri redirectUri)
		{
			var uri = redirectUri.GetAttribute<EnumMemberAttribute>().Value;
			string content = $"code={code}&client_id={client.Id}&client_secret={client.Secret}&redirect_uri={uri}&grant_type=authorization_code";
			var bytes = Encoding.UTF8.GetBytes(content);

			// Request erstellen
			WebRequest request = WebRequest.Create("https://www.googleapis.com/oauth2/v4/token");
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			string result = WebService.Communicate(request, bytes);

			IYoutubeAccount account = null;
			var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(result);

			IYoutubeAccountAccess access = new YoutubeAccountAccess();
			access.Client = client;

			if (authResponse != null && !string.IsNullOrWhiteSpace(authResponse.access_token))
			{
				access.AccessToken = authResponse.access_token;
				access.RefreshToken = authResponse.refresh_token;
				access.TokenType = authResponse.token_type;
				access.ExpirationDate = DateTime.Now.AddSeconds(authResponse.expires_in);

				var accountDetails = GetAccountDetails(access);
				var acc = accountDetails.items.First();
				account = YoutubeAccount.Create(acc.id, acc.snippet.country, acc.snippet.title);

				AddAccess(account, access);
			}

			return account;
		}

		private static void AddAccess(IYoutubeAccount account, IYoutubeAccountAccess access)
		{
			if (Accounts.ContainsKey(account))
			{
				IYoutubeAccountAccess oldAccess;
				if ((oldAccess = Accounts[account].SingleOrDefault(ac => ac.Client.Id == access.Client.Id)) != null)
				{
					Accounts[account].Remove(oldAccess);
				}

				Accounts[account].Add(access);
			}
			else
			{
				Accounts.Add(account, new List<IYoutubeAccountAccess>() { access });
			}
		}

		internal static bool RefreshAccess(IYoutubeAccount account)
		{
			var firstOutdatedAccess = Accounts[account].FirstOrDefault(ac => ac.ExpirationDate < DateTime.Now);

			// Content zusammenbauen
			string content = $"client_id={firstOutdatedAccess.Client.Id}&client_secret={firstOutdatedAccess.Client.Secret}&refresh_token={firstOutdatedAccess.RefreshToken}&grant_type=refresh_token";
			var bytes = Encoding.UTF8.GetBytes(content);

			// Request erstellen
			WebRequest request = WebRequest.Create("https://www.googleapis.com/oauth2/v4/token");
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			var response = WebService.Communicate(request, bytes);

			bool result = false;
			if (response != null && !response.Contains("revoked"))
			{
				// Account 
				var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(response);

				if (!string.IsNullOrWhiteSpace(authResponse.access_token))
				{
					var access = new YoutubeAccountAccess();
					access.Client = firstOutdatedAccess.Client;
					access.AccessToken = authResponse.access_token;
					access.RefreshToken = authResponse.refresh_token;
					access.TokenType = authResponse.token_type;
					access.ExpirationDate = DateTime.Now.AddSeconds(authResponse.expires_in);

					AddAccess(account, access);
					result = true;
				}
			}

			return result;
		}

		internal static void RevokeAccessOfAccount(IYoutubeAccount account)
		{
			foreach (var access in Accounts[account])
			{
				RevokeSingleAccess(access);
			}
		}

		private static void RevokeSingleAccess(IYoutubeAccountAccess access)
		{
			string address = $"https://accounts.google.com/o/oauth2/revoke?token={access.RefreshToken}";

			WebRequest request = WebRequest.Create(address);
			request.ContentType = "application/x-www-form-urlencoded";

			WebService.Communicate(request);
		}

		private static Response GetAccountDetails(IYoutubeAccountAccess access)
		{
			string url = $"https://www.googleapis.com/youtube/v3/channels?part=snippet&mine=true&key={access.Client.Secret}";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add($"Authorization: Bearer {access.AccessToken}");

			Response response = JsonConvert.DeserializeObject<Response>(WebService.Communicate(request));

			return response;
		}

		private class YoutubeAuthResponse
		{
			public string access_token { get; set; }
			public string token_type { get; set; }
			public int expires_in { get; set; }
			public string refresh_token { get; set; }
		}

		private class YoutubeAccountComparer : IEqualityComparer<IYoutubeAccount>
		{
			public bool Equals(IYoutubeAccount x, IYoutubeAccount y)
			{
				return x.Id == y.Id;
			}

			public int GetHashCode(IYoutubeAccount x)
			{
				return x.Id.GetHashCode();
			}
		}
	}
}
