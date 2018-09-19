using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeAccount : IYoutubeAccount
	{
		public string Id { get; } = string.Empty;

		public string Region { get; } = string.Empty;

		public string Title { get; } = string.Empty;

		[JsonIgnore]
		public Uri Uri { get; } = null;

		public IList<IYoutubeAccountAccess> Access { get; private set; } = new List<IYoutubeAccountAccess>();

		internal YoutubeAccount(string id, string region, string title, Uri uri)
		{
			Id = id;
			Region = region;
			Title = title;
			Uri = uri;
		}

		public YoutubeAccount(string id, string region, string title, IList<YoutubeAccountAccess> access)
		{
			Id = id;
			Region = region;
			Title = title;
			Uri = new Uri($"https://youtube.com/channel/{id}");

			foreach (var ac in access)
			{
				Access.Add(ac);
			}
		}

		public static YoutubeAccount Create(string id, string region, string title)
		{
			return new YoutubeAccount(id, region, title, new Uri($"https://youtube.com/channel/{id}"));
		}
	}
}
