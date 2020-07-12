using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using STFU.Lib.Twitter;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class BrowserForm : Form
	{
		public BrowserForm()
		{
			InitializeComponent();
		}

		private void BrowserForm_Load(object sender, EventArgs e)
		{
			webBrowser.Navigate(OauthCommunicator.TryThisShitOut());
			
			//string url = "https://api.twitter.com/oauth/request_token?oauth_callback=oob";
			//var request = HttpWebRequest.Create(url);
			//request.Method = "POST";


			//var request_timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

			//var oauth_callback = "oauth_callback=oob";
			//var oauth_consumer_key = "oauth_consumer_key=4HYYUwh4J2ztSpEDAIIh4M5c5";
			//var oauth_nonce = "oauth_nonce=K7ny27JTpKVsTgdyLdDfmQQWVLERj2zAK5BslRsqyw";
			//var oauth_signature_method = "oauth_signature_method=HMAC-SHA1";
			//var oauth_timestamp = $"oauth_timestamp={request_timestamp}";
			//var oauth_version = "oauth_version=1.0";

			//var oauth_callback1 = "oauth_callback=\"oob\"";
			//var oauth_consumer_key1 = "oauth_consumer_key=\"4HYYUwh4J2ztSpEDAIIh4M5c5\"";
			//var oauth_nonce1 = "oauth_nonce=\"K7ny27JTpKVsTgdyLdDfmQQWVLERj2zAK5BslRsqyw\"";
			//var oauth_signature_method1 = "oauth_signature_method=\"HMAC-SHA1\"";
			//var oauth_timestamp1 = $"oauth_timestamp=\"{request_timestamp}\"";
			//var oauth_version1 = "oauth_version=\"1.0\"";

			//var output_string = $"{oauth_callback}&{oauth_consumer_key}&{oauth_nonce}&{oauth_signature_method}&{oauth_timestamp}&{oauth_version}";

			//var signatureDecrypted = $"POST&{UrlEncodeUpperCase(url)}&{UrlEncodeUpperCase(output_string)}";

			//var consumer_secret = "ZjXBXxRkuDDVrYqn1hOurXLUdNXPMwIjAQNRNNMuqB8o3yoVii&";
			//var oauth_signature = UrlEncodeUpperCase(Convert.ToBase64String(Encoding.UTF8.GetBytes(Encode(signatureDecrypted, Encoding.UTF8.GetBytes(consumer_secret)))));

			//string authHeader = $" OAuth {oauth_nonce1}, {oauth_callback1},  {oauth_signature_method1}, {oauth_timestamp1}, {oauth_consumer_key1}, oauth_signature=\"{oauth_signature}\",  {oauth_version1}";
			//request.Headers.Add("Authorization", authHeader);

			//try
			//{
			//	using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
			//	{
			//		var test = reader.ReadToEnd();
			//		Console.WriteLine(test);
			//	}
			//}
			//catch (WebException ex)
			//{
			//	try
			//	{
			//		using (StreamReader reader2 = new StreamReader(ex.Response.GetResponseStream()))
			//		{
			//			var test = reader2.ReadToEnd();
			//			Console.WriteLine(test);
			//		}
			//	}
			//	catch (Exception ex2)
			//	{
			//		Console.WriteLine(ex2.Message);
			//	}

			//	Console.WriteLine(ex.Message);
			//}
		}

		private static string Encode(string input, byte[] key)
		{
			HMACSHA1 myhmacsha1 = new HMACSHA1(key);
			byte[] byteArray = Encoding.ASCII.GetBytes(input);
			MemoryStream stream = new MemoryStream(byteArray);
			return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
		}

		private static string UrlEncodeUpperCase(string stringToEncode)
		{
			var reg = new Regex(@"%[a-f0-9]{2}");
			stringToEncode = HttpUtility.UrlEncode(stringToEncode);
			return reg.Replace(stringToEncode, m => m.Value.ToUpperInvariant());
		}
	}
}
