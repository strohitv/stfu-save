using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeVideo : IYoutubeVideo
	{
		public YoutubeVideo()
		{ }

		public YoutubeVideo(string path)
		{
			Path = path;
		}

		public bool AutoLevels { get; set; }

		public ICategory Category { get; set; }

		public ILanguage DefaultLanguage { get; set; }

		public string Description { get; set; }

		public FileInfo File => new FileInfo(Path);

		public bool IsEmbeddable { get; set; }

		public License License { get; set; }

		public string MediaType => MimeMapping.GetMimeMapping(Path);

		public bool MediaTypeOk
			=> MediaType.ToLower().StartsWith("video/") || MediaType.ToLower().StartsWith("application/");

		public bool NotifySubscribers { get; set; }

		public string Path { get; set; }

		public PrivacyStatus Privacy { get; set; }

		public bool PublicStatsViewable { get; set; }

		public DateTime? PublishAt { get; set; }

		public bool SizeOk => File.Length < (long)128 * 1000 * 1000 * 1000;

		public bool Stabilize { get; set; }

		public ICollection<string> Tags { get; } = new List<string>();

		public string ThumbnailPath { get; set; }

		public string Title { get; set; }

		public static int MaxTitleLength => 100;

		public static int MaxDescriptionLength => 5000;

		public static int MaxTagsLength => 500;

		public override string ToString()
		{
			return Title;
		}
	}
}
