namespace STFU.UploadLib.Communication.Youtube.Serializable
{
	public class YoutubeSnippet
	{
		public string title { get; set; }
		public string description { get; set; }
		public string[] tags { get; set; }
		public int categoryId { get; set; }
		public string defaultLanguage { get; set; }

		public bool shouldSerializedefaultLanguage { get { return defaultLanguage != null; } }
	}
}
