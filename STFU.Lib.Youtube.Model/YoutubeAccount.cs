using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeAccount : IYoutubeAccount
	{
		public string Id { get; } = string.Empty;

		public string Region { get; } = string.Empty;

		public string Title { get; } = string.Empty;

		public Uri Uri { get; } = null;

		internal YoutubeAccount(string id, string region, string title, Uri uri)
		{
			Id = id;
			Region = region;
			Title = title;
			Uri = uri;
		}

		public static YoutubeAccount Create(string id, string region, string title)
		{
			return new YoutubeAccount(id, region, title, new Uri($"https://youtube.com/channel/{id}"));
		}
	}
}
