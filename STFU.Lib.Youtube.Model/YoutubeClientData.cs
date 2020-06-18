namespace STFU.Lib.Youtube.Model
{
	public static class YoutubeClientData
	{
		public static YoutubeClient Client => new YoutubeClient("youtube api key here",
				   "youtube api secret here",
				   "youtube api project name here", false);

		public static string TwitterOauthToken => "twitter api key here";

		public static string TwitterOauthTokenSecret => "twitter api secret here";

		public static string UpdaterApiKey => "gdrive api key here";
	}
}
