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
	internal static class YoutubeCategoryService
	{
		private static bool loaded = false;
		private static List<ICategory> categories = new List<ICategory>();

		internal static IReadOnlyList<ICategory> LoadCategories(IYoutubeAccountContainer container)
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

					categories = GetVideoCategories(region, YoutubeAccountService.GetAccessToken(account)).ToList();
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

		internal static ICategory[] GetVideoCategories(string regionCode, string accessToken)
		{
			var pageToken = string.Empty;
			CultureInfo ci = CultureInfo.CurrentUICulture;
			string url = string.Format("https://www.googleapis.com/youtube/v3/videoCategories?part=snippet&hl={2}&regionCode={1}&key={0}", "cKUCRQz0sE4UUmvUHW6qckbP", regionCode, ci.Name);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Proxy = null;
			request.Method = "GET";
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format("Authorization: Bearer {0}", accessToken));

			Response response = JsonConvert.DeserializeObject<Response>(WebService.Communicate(request));

			var categories = response.items.Where(i => i.snippet.assignable).Select(i => new VideoCategory(int.Parse(i.id), i.snippet.title)).ToArray();

			return categories;
		}

		private static class StandardCategories
		{
			public static ICategory[] Categories = new VideoCategory[] {
				new VideoCategory(1, "Film & Animation"),
				new VideoCategory(2, "Autos & Fahrzeuge"),
				new VideoCategory(10, "Musik"),
				new VideoCategory(15, "Tiere"),
				new VideoCategory(17, "Sport"),
				new VideoCategory(19, "Reisen & Events"),
				new VideoCategory(20, "Gaming"),
				new VideoCategory(22, "Menschen & Blogs"),
				new VideoCategory(23, "Komödie"),
				new VideoCategory(24, "Unterhaltung"),
				new VideoCategory(25, "Nachrichten & Politik"),
				new VideoCategory(26, "Praktische Tipps & Styling"),
				new VideoCategory(27, "Bildung"),
				new VideoCategory(28, "Wissenschaft & Technik")
			};
		}
	}
}
