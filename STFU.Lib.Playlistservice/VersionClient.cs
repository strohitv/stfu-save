using System;
using System.Net;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Playlistservice
{
	public class VersionClient : AbstractClient
	{
		public VersionClient(Uri host) : base(host) { }
		public VersionClient(Uri host, string user, string pass) : base(host, user, pass) { }

		public bool IsAvailable()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, "/version"));
			request.Method = "GET";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			WebException ex = null;
			string answer = WebService.Communicate(request, out ex);
			return ex == null && !string.IsNullOrWhiteSpace(answer);
		}
	}
}
