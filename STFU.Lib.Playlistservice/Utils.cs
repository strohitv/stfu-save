using System;
using System.Net;
using System.Text;
using log4net;

namespace STFU.Lib.Playlistservice
{
	public class Utils
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(Utils));

		public static void AddBasicAuth(HttpWebRequest request, string username, string password)
		{
			LOGGER.Info($"Request is being sent with username: '{username}' and password: '{password}'");
			request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password)));
		}
	}
}
