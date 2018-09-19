using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace STFU.Lib.Youtube.Internal.Services
{
	internal static class YoutubeAccountService
	{
		static YoutubeAccountService()
		{ }

		internal static string GetAccessToken(IYoutubeAccount account)
		{
			string token = null;

			if (account.Access.Any(ac => ac.Client != null && !ac.Client.LimitReached))
			{
				var firstUsefullAccess = account.Access.FirstOrDefault(ac => !ac.Client.LimitReached && !ac.IsExpired);

				if (firstUsefullAccess == null && RefreshAccess(account))
				{
					firstUsefullAccess = account.Access.FirstOrDefault(ac => !ac.Client.LimitReached && !ac.IsExpired);
				}

				token = firstUsefullAccess?.AccessToken;
			}

			return token;
		}

		internal static bool RefreshAccess(IYoutubeAccount account)
		{
			var firstOutdatedAccess = account.Access.FirstOrDefault(ac => !ac.Client.LimitReached && ac.IsExpired);

			bool result = true;
			if (firstOutdatedAccess != null)
			{
				// Content zusammenbauen
				string content = $"client_id={firstOutdatedAccess.Client.Id}&client_secret={firstOutdatedAccess.Client.Secret}&refresh_token={firstOutdatedAccess.RefreshToken}&grant_type=refresh_token";
				var bytes = Encoding.UTF8.GetBytes(content);

				// Request erstellen
				WebRequest request = WebRequest.Create("https://www.googleapis.com/oauth2/v4/token");
				request.Method = "POST";
				request.ContentType = "application/x-www-form-urlencoded";

				var response = WebService.Communicate(request, bytes);

				if (response != null && !response.Contains("revoked"))
				{
					// Account 
					var authResponse = JsonConvert.DeserializeObject<YoutubeAuthResponse>(response);

					if (!string.IsNullOrWhiteSpace(authResponse.access_token))
					{
						var access = new YoutubeAccountAccess();
						access.Client = firstOutdatedAccess.Client;
						access.AccessToken = authResponse.access_token;
						access.TokenType = authResponse.token_type;
						access.ExpirationDate = DateTime.Now.AddSeconds(authResponse.expires_in);

						account.Access.Remove(firstOutdatedAccess);
						account.Access.Add(access);
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}

			return result;
		}

		internal static void RevokeAccessOfAccount(IYoutubeAccount account)
		{
			while (account.Access.Count > 0)
			{
				RevokeSingleAccess(account, account.Access[0]);
			}
		}

		internal static void RevokeSingleAccess(IYoutubeAccount account, IYoutubeAccountAccess access)
		{
			string address = $"https://accounts.google.com/o/oauth2/revoke?token={access.RefreshToken}";

			WebRequest request = WebRequest.Create(address);
			request.ContentType = "application/x-www-form-urlencoded";

			WebService.Communicate(request);

			account.Access.Remove(access);
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
