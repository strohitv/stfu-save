using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OAuth;

namespace STFU.Lib.Twitter
{
	public class OauthCommunicator
	{
		// https://stackoverflow.com/questions/61244505/how-to-make-an-oauth-1-twitter-api-call-with-c-sharp-dotnet-core-3-1

		public static string TryThisShitOut()
		{
			string CONSUMER_KEY = "4HYYUwh4J2ztSpEDAIIh4M5c5";
			string CONSUMER_TOKEN = "ZjXBXxRkuDDVrYqn1hOurXLUdNXPMwIjAQNRNNMuqB8o3yoVii";

			// this is the endpoint we will be calling
			string REQUEST_URL = "https://api.twitter.com/oauth/request_token?oauth_callback=oob";

			// Create a new connection to the OAuth server, with a helper method
			OAuthRequest client = OAuthRequest.ForRequestToken(CONSUMER_KEY, CONSUMER_TOKEN, "oob");
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

			Console.WriteLine(strResponse); // we have a string (JSON)

			var queryParams = HttpUtility.ParseQueryString(strResponse);

			return $"https://api.twitter.com/oauth/authorize?oauth_token={queryParams["oauth_token"]}";
		}
	}
}
