namespace STFU.Lib.Youtube.Model.Serializable
{
	public class YoutubeErrorResponse
	{
		public YoutubeErrorArray error { get; set; }

		public int code { get; set; }

		public string message { get; set; }
	}

	public class YoutubeErrorArray
	{
		public YoutubeErrorDetail[] errors { get; set; }
	}

	public class YoutubeErrorDetail
	{
		public string domain { get; set; }
		public string reason { get; set; }
		public string message { get; set; }
	}
}