using System;
using STFU.Lib.Twitter.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Twitter
{
	public static class CoreTweetTest
	{ 
		public static void Tweet(ITwitterAccount account)
		{
			var tokens = CoreTweet.Tokens.Create(YoutubeClientData.TwitterOauthToken, YoutubeClientData.TwitterOauthTokenSecret, account.OAuthToken, account.OAuthTokenSecret, Convert.ToInt64(account.UserId), account.ScreenName);
			tokens.Statuses.Update("Das hier ist ein Test-Status für eins meiner Programme. Ignoriert es einfach. :3");
		}
	}
}
