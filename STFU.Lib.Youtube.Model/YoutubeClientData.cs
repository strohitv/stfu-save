namespace STFU.Lib.Youtube.Model
{
	public static class YoutubeClientData
	{
		public static YoutubeClient Client => new YoutubeClient("your api key",
				   "your api secret",
				   "your api name", false);
	}
}
