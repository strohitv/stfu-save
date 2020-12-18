using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Model.Serializable
{
	public class YoutubePlaylistItem
	{
		public YoutubePlaylistItem(string playlistId, string videoId)
		{
			snippet = new PlaylistSnippet(playlistId, videoId);
		}

		public PlaylistSnippet snippet { get; set; } 
	}

	public class PlaylistSnippet
	{
		public PlaylistSnippet(string playlistId, string videoId)
		{
			this.playlistId = playlistId;

			resourceId = new VideoResource()
			{
				videoId = videoId
			};
		}

		[JsonProperty(PropertyName = "playlistId")]
		public string playlistId { get; set; }

		[JsonProperty(PropertyName = "resourceId")]
		public VideoResource resourceId { get; set; }
	}

	public class VideoResource
	{
		[JsonProperty(PropertyName = "kind")]
		public string kind { get; set; } = "youtube#video";

		[JsonProperty(PropertyName = "videoId")]
		public string videoId { get; set; }
	}
}
