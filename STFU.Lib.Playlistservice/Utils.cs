using System;
using System.Net;
using System.Text;

namespace STFU.Lib.Playlistservice
{
	public class Utils
	{
		public static void AddBasicAuth(HttpWebRequest request, string username, string password)
		{
			request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password)));
		}
	}
}
