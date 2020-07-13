namespace STFU.Lib.Twitter.Model
{
	public class TwitterAccount : ITwitterAccount
	{
		public TwitterAccount() { }

		public TwitterAccount(string oauthToken, string oauthTokenSecret, string userId, string screenName)
		{
			OAuthToken = oauthToken;
			OAuthTokenSecret = oauthTokenSecret;
			UserId = userId;
			ScreenName = screenName;
		}

		public string OAuthToken { get; set; }
		public string OAuthTokenSecret { get; set; }
		public string UserId { get; set; }
		public string ScreenName { get; set; }
	}
}
