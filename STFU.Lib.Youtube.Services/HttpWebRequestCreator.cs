using System.Net;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model;
using System;

namespace STFU.Lib.Youtube.Services
{
	public static class HttpWebRequestCreator
	{
		public static HttpWebRequest Create(string address, string method)
		{
			var request = (HttpWebRequest)WebRequest.Create(address);
			request.Method = method;
			request.Proxy = null;
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			return request;
		}

		public static HttpWebRequest CreateWithAuthHeader(string address, string method, string token)
		{
			var request = Create(address, method);
			request.Headers.Add($"Authorization: Bearer {token}");

			return request;
		}

		public static HttpWebRequest CreateForNewUpload(Uri uri,  IYoutubeVideo video, IYoutubeAccount account)
		{
			var request = CreateWithAuthHeader(uri.AbsoluteUri, "PUT", account.GetActiveToken());
			request.ContentLength = video.File.Length;
			request.ContentType = MimeMapping.GetMimeMapping(video.File.Name);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		public static HttpWebRequest CreateForResumeUpload(Uri uri, IYoutubeVideo video, IYoutubeAccount account, long lastbyte)
		{
			var request = CreateWithAuthHeader(uri.AbsoluteUri, "PUT", account.GetActiveToken());
			request.Headers.Add($"Content-Range: bytes {lastbyte + 1}-{video.File.Length - 1}/{video.File.Length}");
			request.ContentLength = video.File.Length - (lastbyte + 1);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}
	}
}
