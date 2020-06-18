using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Services
{
	public static class YoutubeCategoryService
	{
		private static bool loaded = false;
		private static List<ICategory> categories = new List<ICategory>();

		public static IReadOnlyList<ICategory> LoadCategories(IYoutubeAccountContainer container)
		{
			if (!loaded)
			{
				var communicator = new YoutubeAccountCommunicator();
				if (container.RegisteredAccounts.Count > 0)
				{
					var account = container.RegisteredAccounts.First();

					var region = account.Region;
					if (account.Region == null)
					{
						region = "de";
					}

					categories = GetVideoCategories(region, account.GetActiveToken()).ToList();
				}
				else
				{
					// Fallback
					foreach (var cat in StandardCategories.Categories)
					{
						categories.Add(cat);
					}
				}

				loaded = true;
			}

			return categories.AsReadOnly();
		}

		public static ICategory[] GetVideoCategories(string regionCode, string accessToken)
		{
			var pageToken = string.Empty;
			CultureInfo ci = CultureInfo.CurrentUICulture;
			string url = string.Format("https://www.googleapis.com/youtube/v3/videoCategories?part=snippet&hl={2}&regionCode={1}&key={0}", YoutubeClientData.Client.Secret, regionCode, ci.Name);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Proxy = null;
			request.Method = "GET";
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format("Authorization: Bearer {0}", accessToken));

			var result = WebService.Communicate(request);
			QuotaProblemHandler.ThrowOnQuotaLimitReached(result);

			Response response = JsonConvert.DeserializeObject<Response>(result);

			var categories = response.items.Where(i => i.snippet.assignable).Select(i => new YoutubeCategory(int.Parse(i.id), i.snippet.title)).ToArray();

			return categories;
		}

		private static class StandardCategories
		{
			public static ICategory[] Categories = new YoutubeCategory[] {
				new YoutubeCategory(1, "Film & Animation"),
				new YoutubeCategory(2, "Autos & Fahrzeuge"),
				new YoutubeCategory(10, "Musik"),
				new YoutubeCategory(15, "Tiere"),
				new YoutubeCategory(17, "Sport"),
				new YoutubeCategory(19, "Reisen & Events"),
				new YoutubeCategory(20, "Gaming"),
				new YoutubeCategory(22, "Menschen & Blogs"),
				new YoutubeCategory(23, "Komödie"),
				new YoutubeCategory(24, "Unterhaltung"),
				new YoutubeCategory(25, "Nachrichten & Politik"),
				new YoutubeCategory(26, "Praktische Tipps & Styling"),
				new YoutubeCategory(27, "Bildung"),
				new YoutubeCategory(28, "Wissenschaft & Technik")
			};
		}
	}
}
