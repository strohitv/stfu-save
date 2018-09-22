﻿using System;
using System.Linq;
using System.Runtime.Serialization;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Model.Helpers;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;
using System.Collections.Generic;
using System.Text;
using System.Net;
using STFU.Lib.Youtube.Internal;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Model.Serializable;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeAccountCommunicator : IYoutubeAccountCommunicator
	{
		public YoutubeAccountCommunicator() { }

		public Uri CreateAuthUri(IYoutubeClient client, YoutubeRedirectUri redirectUri, YoutubeScope scope)
		{
			string scopeString = JoinScopes(scope);
			string redirectUriString = redirectUri.GetAttribute<EnumMemberAttribute>().Value;
			string authRequestString = $"https://accounts.google.com/o/oauth2/auth?client_id={client.Id}&redirect_uri={redirectUriString}&scope={scopeString}&response_type=code&approval_prompt=force&access_type=offline";

			return new Uri(authRequestString);
		}

		public IYoutubeAccount ConnectToAccount(string code, IYoutubeClient client, YoutubeRedirectUri redirectUri)
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
				access.ClientId = client.Id;

				var accountDetails = GetAccountDetails(access);
				var acc = accountDetails.items.First();
				account = YoutubeAccount.Create(acc.id, acc.snippet.country, acc.snippet.title);

				account.Access.Add(access);
			}

			return account;
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

		public void RevokeAccount(IYoutubeAccountContainer container, IYoutubeAccount account)
		{
			YoutubeAccountService.RevokeAccessOfAccount(account);
			container.UnregisterAccount(account);
		}

		public void RevokeAccounts(IYoutubeAccountContainer container, IEnumerable<IYoutubeAccount> accounts)
		{
			foreach (var account in accounts)
			{
				RevokeAccount(container, account);
			}
		}

		private string JoinScopes(YoutubeScope scope)
		{
			string result = string.Empty;
			bool needsPlus = false;
			foreach (YoutubeScope value in typeof(YoutubeScope).GetEnumValues())
			{
				if (scope.HasFlag(value))
				{
					if (needsPlus)
					{
						result += "+";
					}
					else
					{
						needsPlus = true;
					}

					result += value.GetAttribute<EnumMemberAttribute>().Value;
				}
			}

			return result;
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