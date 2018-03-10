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

				if (Accounts.ContainsKey(account))
				{
					IYoutubeAccountAccess oldAccess;
					if ((oldAccess = Accounts[account].SingleOrDefault(ac => ac.Client.Id == client.Id)) != null)
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

			return account;
		}

		internal static bool RefreshAccess(IYoutubeAccount account)
		{

		}

		internal static bool RevokeAccess(IYoutubeAccount account)
		{

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
