using System;
using System.Linq;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Communication.Youtube.Serializable
{
	public class YoutubeVideo
	{
		public YoutubeSnippet snippet { get; set; }
		public YoutubeStatus status { get; set; }

		public YoutubeVideo()
		{
		}

		internal YoutubeVideo(Video video)
		{
			snippet = new YoutubeSnippet()
			{
				categoryId = video.Category?.Id ?? 20,
				title = video.Title,
				defaultLanguage = video.DefaultLanguage?.Hl ?? "de",
				description = video.Description,
				tags = video.Tags.ToArray()
			};

			status = new YoutubeStatus()
			{
				IsEmbeddable = video.IsEmbeddable,
				Privacy = video.Privacy,
				License = video.License,
				PublishAt = (video.PublishAt ?? default(DateTime)).ToString("yyyy-MM-ddTHH:mm:ss.ffffzzz"),
				ShouldPublishAt = video.PublishAt != null,
				PublicStatsViewable = video.PublicStatsViewable
			};
		}
	}
}

