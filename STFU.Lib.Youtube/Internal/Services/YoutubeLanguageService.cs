using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Internal.Services
{
	internal static class YoutubeLanguageService
	{
		private static bool loaded = false;
		private static List<ILanguage> languages = new List<ILanguage>();

		internal static IReadOnlyList<ILanguage> LoadLanguages(IYoutubeAccountContainer container)
		{
			if (!loaded)
			{
				var communicator = new YoutubeAccountCommunicator();
				if (container.RegisteredAccounts.Count > 0)
				{
					var account = container.RegisteredAccounts.First();
					languages = GetLanguages(YoutubeAccountService.GetAccessToken(account)).ToList();
				}
				else
				{
					// Fallback
					foreach (var lang in StandardLanguages.Languages)
					{
						languages.Add(lang);
					}
				}

				loaded = true;
			}

			return languages.AsReadOnly();
		}

		internal static ILanguage[] GetLanguages(string accessToken)
		{
			var pageToken = string.Empty;
			CultureInfo ci = CultureInfo.CurrentUICulture;
			string url = string.Format("https://www.googleapis.com/youtube/v3/i18nLanguages?part=snippet&hl={1}&key={0}", "cKUCRQz0sE4UUmvUHW6qckbP", ci.Name);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Proxy = null;
			request.Method = "GET";
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format("Authorization: Bearer {0}", accessToken));

			Response response = JsonConvert.DeserializeObject<Response>(WebService.Communicate(request));

			var languages = response.items.Select(i => new VideoLanguage() { Id = i.id, Hl = i.snippet.hl, Name = i.snippet.name }).OrderBy(lang => lang.Name).ToArray();

			return languages;
		}

		private static class StandardLanguages
		{
			public static ILanguage[] Languages = new VideoLanguage[] {
				new VideoLanguage()
						{
							Hl = "de",
							Id = "de",
							Name = "Deutsch"
						},
				new VideoLanguage()
						{
							Hl = "en",
							Id = "en",
							Name = "Englisch"
						}
			};
		}
	}
}
