using System;
using System.IO;
using System.Net;
using System.Web;
using OAuth;
using STFU.Lib.Twitter.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Twitter
{
	public class TwitterAccountConnector
	{
		// https://stackoverflow.com/questions/61244505/how-to-make-an-oauth-1-twitter-api-call-with-c-sharp-dotnet-core-3-1
		private string RequestToken { get; set; }

		public string CreateBrowseableUrl()
		{
			// this is the endpoint we will be calling
			string REQUEST_URL = "https://api.twitter.com/oauth/request_token?oauth_callback=oob";

			// Create a new connection to the OAuth server, with a helper method
			OAuthRequest client = OAuthRequest.ForRequestToken(YoutubeClientData.TwitterOauthToken, YoutubeClientData.TwitterOauthTokenSecret, "oob");
			client.RequestUrl = REQUEST_URL;

			// add HTTP header authorization
			string auth = client.GetAuthorizationHeader();
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(client.RequestUrl);
			request.Headers.Add("Authorization", auth);

			Console.WriteLine("Calling " + REQUEST_URL);

			// make the call and print the string value of the response JSON
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string strResponse = reader.ReadToEnd();

			var queryParams = HttpUtility.ParseQueryString(strResponse);
			RequestToken = queryParams["oauth_token"];

			return $"https://api.twitter.com/oauth/authorize?oauth_token={RequestToken}";
		}

		public ITwitterAccount ConnectAccount(string pin)
		{
			string REQUEST_URL = $"https://api.twitter.com/oauth/access_token?oauth_token={RequestToken}&oauth_verifier={pin}";

			OAuthRequest client = OAuthRequest.ForAccessToken(YoutubeClientData.TwitterOauthToken, YoutubeClientData.TwitterOauthTokenSecret, RequestToken, pin);
			client.RequestUrl = REQUEST_URL;

			string auth = client.GetAuthorizationHeader();
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(client.RequestUrl);
			request.Headers.Add("Authorization", auth);

			Console.WriteLine("Calling " + REQUEST_URL);

			// make the call and print the string value of the response JSON
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string strResponse = reader.ReadToEnd();

			var queryParams = HttpUtility.ParseQueryString(strResponse);

			return new TwitterAccount(queryParams["oauth_token"], queryParams["oauth_token_secret"], queryParams["user_id"], queryParams["screen_name"]);
		}

		public static bool InvalidateAccount(ITwitterAccount account)
		{
			try
			{
				string REQUEST_URL = $"https://api.twitter.com/1.1/oauth/invalidate_token?oauth_token={account.OAuthToken}";

				OAuthRequest client = OAuthRequest.ForProtectedResource("POST", YoutubeClientData.TwitterOauthToken, YoutubeClientData.TwitterOauthTokenSecret, account.OAuthToken, account.OAuthTokenSecret);
				client.RequestUrl = REQUEST_URL;
				client.Method = "POST";

				string auth = client.GetAuthorizationHeader();
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(client.RequestUrl);
				request.Headers.Add("Authorization", auth);
				request.Method = "POST";

				Console.WriteLine("Calling " + REQUEST_URL);

				// make the call and print the string value of the response JSON
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				string strResponse = reader.ReadToEnd();

				var queryParams = HttpUtility.ParseQueryString(strResponse);

				return true;
			}
			catch (WebException ex)
			{
				using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
				{
					var response = reader.ReadToEnd();
					Console.WriteLine(response);
				}

				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}
		}

		public static bool ScheduleTweet(ITwitterAccount account)
		{
			try
			{
				string GET_REQUEST_URL = "https://api.twitter.com/1.1/statuses/update.json?status=Hello%20world";

				OAuthRequest client = OAuthRequest.ForProtectedResource("POST", YoutubeClientData.TwitterOauthToken, YoutubeClientData.TwitterOauthTokenSecret, account.OAuthToken, account.OAuthTokenSecret);
				client.RequestUrl = GET_REQUEST_URL;
				client.Method = "POST";

				string auth = client.GetAuthorizationHeader();
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(client.RequestUrl);
				request.Headers.Add("Authorization", auth);
				request.Method = "POST";
				request.ContentType = "application/x-www-form-urlencoded";

				Console.WriteLine("Calling " + GET_REQUEST_URL);

				using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
				{
					writer.Write("status=Hello%20world");
				}
				
				// make the call and print the string value of the response JSON
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				string strResponse = reader.ReadToEnd();

				ScheduleTweetPOST(account);

				return true;
			}
			catch (WebException ex)
			{
				using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
				{
					var response = reader.ReadToEnd();
					Console.WriteLine(response);
				}

				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}
		}

		private static void ScheduleTweetPOST(ITwitterAccount account)
		{
			string REQUEST_URL = $"https://ads-api.twitter.com/7/accounts/{account.UserId}/scheduled_tweets?";

			OAuthRequest client = OAuthRequest.ForProtectedResource("POST", YoutubeClientData.TwitterOauthToken, YoutubeClientData.TwitterOauthTokenSecret, account.OAuthToken, account.OAuthTokenSecret);
			client.RequestUrl = REQUEST_URL;
			client.Method = "POST";

			string auth = client.GetAuthorizationHeader();
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(client.RequestUrl);
			request.Headers.Add("Authorization", auth);

			Console.WriteLine("Calling " + REQUEST_URL);

			// make the call and print the string value of the response JSON
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string strResponse = reader.ReadToEnd();

			var queryParams = HttpUtility.ParseQueryString(strResponse);
		}
	}
}
