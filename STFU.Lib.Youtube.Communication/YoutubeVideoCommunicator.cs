using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Common.Model;
using STFU.Lib.Youtube.Communication.Internal;
using STFU.Lib.Youtube.Communication.Internal.Serializable;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Communication
{
	public class YoutubeVideoCommunicator
	{
		private InternalYoutubeJob Job { get; set; }

		public YoutubeVideoCommunicator(IYoutubeJob job)
		{
			Job = job as InternalYoutubeJob;
		}

		public void UploadVideo()
		{

		}

		public void UploadThumbnail()
		{

		}

		internal string InitializeUpload()
		{
			// Inhalt erstellen
			var ytVideo = new YoutubeVideo(Job.Video);
			string content = JsonConvert.SerializeObject(ytVideo);
			var bytes = Encoding.UTF8.GetBytes(content);

			// Request erstellen
			WebRequest request = WebRequest.Create($"https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable&autoLevels={Job.Video.AutoLevels}&notifySubscribers={Job.Video.NotifySubscribers}&stabilize={Job.Video.Stabilize}&part=snippet,status,contentDetails");
			request.Method = "POST";
			request.Headers.Add($"Authorization: Bearer {YoutubeAccountService.GetAccessToken(Job.Account)}");
			request.Headers.Add($"x-upload-content-length: {Job.Video.File.Length}");
			request.Headers.Add($"x-upload-content-type: {MimeMapping.GetMimeMapping(Job.Video.File.Name)}");

			request.ContentLength = bytes.Length;
			request.ContentType = "application/json; charset=utf-8";

			return WebService.Communicate(request, bytes, "Location");
		}

		internal HttpWebRequest CreateNewUploadRequest()
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Job.Uri.AbsoluteUri);
			request.Proxy = null;
			request.Method = "PUT";
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add($"Authorization: Bearer {YoutubeAccountService.GetAccessToken(Job.Account)}");
			request.ContentLength = Job.Video.File.Length;
			request.ContentType = MimeMapping.GetMimeMapping(Job.Video.File.Name);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		internal HttpWebRequest CreateResumeUploadRequest(long lastbyte)
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Job.Uri.AbsoluteUri);
			request.Proxy = null;
			request.Method = "PUT";
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add($"Authorization: Bearer {YoutubeAccountService.GetAccessToken(Job.Account)}");
			request.Headers.Add($"Content-Range: bytes {lastbyte + 1}-{Job.Video.File.Length - 1}/{Job.Video.File.Length}");
			request.ContentLength = Job.Video.File.Length - (lastbyte + 1);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		internal string UploadVideo(ref bool shouldCancel)
		{
			var lastbyte = CheckUploadStatus();

			FileStream fileStream = new FileStream(Job.Video.Path, FileMode.Open, FileAccess.Read);

			HttpWebRequest request = null;
			if (lastbyte == -1)
			{
				request = CreateNewUploadRequest();
			}
			else
			{
				request = CreateResumeUploadRequest(lastbyte);
				fileStream.Position = lastbyte + 1;
			}

			Job.State = UploadState.Running;

			// Upload initiieren
			Stream requestStream = request.GetRequestStream();
			byte[] buffer = new byte[128 * 1024];
			int bytesRead = 0;

			// Hochladen
			while (!shouldCancel && (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
			{
				try
				{
					requestStream.Write(buffer, 0, bytesRead);
					var save = Convert.ToInt32(Job.Progress * 100);
					Job.Progress = fileStream.Position / (double)Job.Video.File.Length * 100;
				}
				catch (WebException)
				{
					requestStream.Close();
					return Job.Uri.AbsolutePath;
				}
				catch (IOException)
				{
					requestStream.Close();
					return Job.Uri.AbsolutePath;
				}
			}
			fileStream.Close();

			try
			{
				requestStream.Close();
				Job.Progress = 100.0;
				Job.State = UploadState.Successful;
			}
			catch (WebException)
			{
				Job.State = UploadState.Error;
			}

			var response = WebService.Communicate(request);

			request = null;

			return response;
		}

		internal long CheckUploadStatus()
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Job.Uri.AbsoluteUri);
			request.Proxy = null;
			request.Method = "PUT";
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add($"Authorization: Bearer {YoutubeAccountService.GetAccessToken(Job.Account)}");
			request.ContentLength = 0;
			request.Headers.Add($"content-range: bytes */{Job.Video.File.Length}");

			var answer = WebService.Communicate(request);
			if (answer == null)
			{
				return -1;
			}

			answer = answer.Substring("bytes=".Length);

			long lastbyte;
			try
			{
				lastbyte = Convert.ToInt64(answer.Split('-')[1]);
			}
			catch (Exception)
			{
				return -1;
			}

			return lastbyte;
		}

		internal string UploadThumbnail(string videoId, ref bool shouldCancel)
		{
			var token = YoutubeAccountService.GetAccessToken(Job.Account);
			var secret = YoutubeAccountService.GetClientSecretForAccessToken(token);

			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={videoId}&key={secret}");
			request.Proxy = null;
			request.Method = "POST";
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add($"Authorization: Bearer {token}");

			string result = null;

			FileInfo file = null;
			if (File.Exists(Job.Video.ThumbnailPath) && (file = new FileInfo(Job.Video.ThumbnailPath)).Length < 2000000)
			{
				request.ContentLength = file.Length;
				request.ContentType = MimeMapping.GetMimeMapping(Job.Video.ThumbnailPath);

				FileStream fileStream = new FileStream(Job.Video.ThumbnailPath, FileMode.Open, FileAccess.Read);

				Stream requestStream = request.GetRequestStream();
				byte[] buffer = new byte[128 * 1024];
				int bytesRead = 0;

				// Hochladen
				while (!shouldCancel && (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
				{
					try
					{
						requestStream.Write(buffer, 0, bytesRead);
						requestStream.Flush();
						var save = Convert.ToInt32(Job.Progress * 100);
						Job.Progress = fileStream.Position / (double)file.Length * 100;
					}
					catch (WebException)
					{
						requestStream.Close();
						return Job.Uri.AbsolutePath;
					}
					catch (IOException)
					{
						requestStream.Close();
						return Job.Uri.AbsolutePath;
					}
				}
				fileStream.Close();

				try
				{
					requestStream.Close();
					Job.Progress = 100.0;
					Job.State = UploadState.Successful;
				}
				catch (WebException)
				{
					Job.State = UploadState.Error;
				}

				result = WebService.Communicate(request);

				request = null;
			}

			return result;
		}
	}
}
