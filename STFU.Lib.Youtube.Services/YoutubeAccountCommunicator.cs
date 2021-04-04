using System;
using System.Linq;
using System.Runtime.Serialization;
using STFU.Lib.Youtube.Model.Helpers;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Model.Serializable;
using STFU.Lib.Youtube.Model;
using log4net;

namespace STFU.Lib.Youtube.Services
{
	public class YoutubeAccountCommunicator : IYoutubeAccountCommunicator
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(YoutubeAccountCommunicator));

		public YoutubeAccountCommunicator() { }

		public Uri CreateAuthUri(IYoutubeClient client, YoutubeRedirectUri redirectUri, GoogleScope scope)
		{
			string scopeString = JoinScopes(scope);
			string redirectUriString = redirectUri.GetAttribute<EnumMemberAttribute>().Value;
			string authRequestString = $"https://accounts.google.com/o/oauth2/auth?client_id={client.Id}&redirect_uri={redirectUriString}&scope={scopeString}&response_type=code&approval_prompt=force&access_type=offline";

			return new Uri(authRequestString);
		}

		public string GetAdditionalScope(GoogleScope scope)
		{
			return $"+{JoinScopes(scope)}";
		}

		public IYoutubeAccount ConnectToAccount(string code, bool mailsAllowed, IYoutubeClient client, YoutubeRedirectUri redirectUri)
		{
			LOGGER.Info($"Connecting to account, mails allowed: {mailsAllowed}, redirect uri: {redirectUri}");

			var uri = redirectUri.GetAttribute<EnumMemberAttribute>().Value;
			string content = $"code={code}&client_id={client.Id}&client_secret={client.Secret}&redirect_uri={uri}&grant_type=authorization_code";
			var bytes = Encoding.UTF8.GetBytes(content);

			// Request erstellen
			WebRequest request = WebRequest.Create("https://www.googleapis.com/oauth2/v4/token");
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			string result = WebService.Communicate(request, bytes);
			QuotaProblemHandler.ThrowOnQuotaLimitReached(result);

			IYoutubeAccount account = null;
			var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(result);

			IYoutubeAccountAccess access = new YoutubeAccountAccess();
			access.Client = client;
			access.HasSendMailPrivilegue = mailsAllowed;

			if (authResponse != null && !string.IsNullOrWhiteSpace(authResponse.access_token))
			{
				access.AccessToken = authResponse.access_token;
				access.RefreshToken = authResponse.refresh_token;
				access.TokenType = authResponse.token_type;
				access.ExpirationDate = DateTime.Now.AddSeconds(authResponse.expires_in);
				access.ClientId = client.Id;

				LOGGER.Info($"Connection successful, loading account details");

				var accountDetails = GetAccountDetails(access);
				var acc = accountDetails.items.First();
				account = YoutubeAccount.Create(acc.id, acc.snippet.country, acc.snippet.title);

				account.Access.Add(access);
			}

			LOGGER.Info($"Connected to account with id: {account.Id} and title: '{account.Title}'");

			return account;
		}

		private static Response GetAccountDetails(IYoutubeAccountAccess access)
		{
			string url = $"https://www.googleapis.com/youtube/v3/channels?part=snippet&mine=true&key={YoutubeClientData.YoutubeApiKey}";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add($"Authorization: Bearer {access.AccessToken}");

			var result = WebService.Communicate(request);
			QuotaProblemHandler.ThrowOnQuotaLimitReached(result);

			Response response = JsonConvert.DeserializeObject<Response>(result);

			return response;
		}

		public void RevokeAccount(IYoutubeAccountContainer container, IYoutubeAccount account)
		{
			LOGGER.Info($"Revoking connecgtion to account with id: {account.Id} and title: '{account.Title}'");

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

		private string JoinScopes(GoogleScope scope)
		{
			string result = string.Empty;
			bool needsPlus = false;
			foreach (GoogleScope value in typeof(GoogleScope).GetEnumValues())
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
