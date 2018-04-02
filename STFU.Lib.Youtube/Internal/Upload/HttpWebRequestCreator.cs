using System.Net;
using System.Web;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal static class HttpWebRequestCreator
	{
		internal static HttpWebRequest Create(string address, string method)
		{
			var request = (HttpWebRequest)WebRequest.Create(address);
			request.Method = method;
			request.Proxy = null;
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			return request;
		}

		internal static HttpWebRequest CreateWithAuthHeader(string address, string method, string token)
		{
			var request = Create(address, token);
			request.Headers.Add($"Authorization: Bearer {token}");

			return request;
		}
		
		internal static HttpWebRequest CreateForNewUpload(IYoutubeJob job)
		{
			var request = CreateWithAuthHeader(job.Uri.AbsoluteUri, "PUT", YoutubeAccountService.GetAccessToken(job.Account));
			request.ContentLength = job.Video.File.Length;
			request.ContentType = MimeMapping.GetMimeMapping(job.Video.File.Name);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		internal static HttpWebRequest CreateForResumeUpload(IYoutubeJob job, long lastbyte)
		{
			var request = CreateWithAuthHeader(job.Uri.AbsoluteUri, "PUT", YoutubeAccountService.GetAccessToken(job.Account));
			request.Headers.Add($"Content-Range: bytes {lastbyte + 1}-{job.Video.File.Length - 1}/{job.Video.File.Length}");
			request.ContentLength = job.Video.File.Length - (lastbyte + 1);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}
	}
}
