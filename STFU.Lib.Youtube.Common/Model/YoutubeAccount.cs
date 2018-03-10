using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Common.Model
{
	public class YoutubeAccount : IYoutubeAccount
	{
		private string id = string.Empty;
		private string region = string.Empty;
		private string title = string.Empty;
		private Uri uri = null;
		private IYoutubeClient client = null;

		public string Id
		{
			get
			{
				return id;
			}
		}

		public string Region
		{
			get
			{
				return region;
			}
		}

		public string Title
		{
			get
			{
				return title;
			}
		}

		public Uri Uri
		{
			get
			{
				return uri;
			}
		}

		internal YoutubeAccount(string id, string region, string title, Uri uri)
		{
			this.id = id;
			this.region = region;
			this.title = title;
			this.uri = uri;
		}

		public static YoutubeAccount Create(string id, string region, string title)
		{
			return new YoutubeAccount(id, region, title, new Uri($"https://youtube.com/channel/{id}"));
		}
	}
}
