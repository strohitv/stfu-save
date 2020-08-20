namespace STFU.Lib.Twitter.Model
{
	public interface ITwitterAccount
	{
		string OAuthToken { get; set; }
		string OAuthTokenSecret { get; set; }
		string UserId { get; set; }
		string ScreenName { get; set; }
	}
}
