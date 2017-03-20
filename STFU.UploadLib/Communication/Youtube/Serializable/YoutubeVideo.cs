using System;
using System.IO;
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
				categoryId = video.CategoryId,
				title = video.Title,
				defaultLanguage = video.DefaultLanguage,
				description = video.Description,
				tags = video.Tags.ToArray()
			};

			status = new YoutubeStatus()
			{
				IsEmbeddable = video.IsEmbeddable,
				Privacy = video.Privacy,
				License = video.License,
				PublishAt = video.PublishAt ?? default(DateTime),
				ShouldPublishAt = video.PublishAt != null,
				PublicStatsViewable = video.PublicStatsViewable,
			};
		}

		//public bool ShouldSerializestatus()
		//{
		//	if (status == null || (!status.IsEmbeddable && status.License == License.Youtube && status.Privacy == PrivacyStatus.Private && !status.PublicStatsViewable))
		//	{
		//		return false;
		//	}
		//	return true;
		//}

		//public bool ShouldSerializesnippet()
		//{
		//	if (snippet == null || (snippet.categoryId == 0 && snippet.description == "" && snippet.title == "" && (snippet.tags == null || snippet.tags.Length == 0)))
		//	{
		//		return false;
		//	}

		//	return true;
		//}
	}
}

