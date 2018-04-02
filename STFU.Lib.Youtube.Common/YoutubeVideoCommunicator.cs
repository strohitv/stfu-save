using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Common.Internal;
using STFU.Lib.Youtube.Common.Internal.Interfaces;
using STFU.Lib.Youtube.Common.Internal.Services;
using STFU.Lib.Youtube.Common.Model.Serializable;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Common
{
	public class YoutubeVideoCommunicator : IYoutubeVideoCommunicator
	{
		private InternalYoutubeJob Job { get; set; }
		private CancellationToken Token { get; set; }

		public YoutubeVideoCommunicator(IYoutubeJob job)
		{
			Job = job as InternalYoutubeJob;
		}

		public void Upload(CancellationToken token)
		{
			Token = token;

			Uri testUrl = null;
			string result = null;
			int counter = 0;
			while (!Token.IsCancellationRequested
				&& Uri.TryCreate(result = UploadVideo(), UriKind.Absolute, out testUrl)
				&& counter < 4)
			{
				counter++;
				Thread.Sleep(new TimeSpan(0, 1, 0));
			}

			if (!Token.IsCancellationRequested && counter < 4)
			{
				var videoId = JsonConvert.DeserializeObject<YoutubeVideo>(result).id;
				var thumbnailResult = UploadThumbnail(videoId);
			}
		}

		internal string InitializeUpload()
		{
			var ytVideo = new YoutubeVideo(Job.Video);
			string content = JsonConvert.SerializeObject(ytVideo);
			var bytes = Encoding.UTF8.GetBytes(content);

			var request = CreateHttpWebRequestWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable"
				+ $"&autoLevels={Job.Video.AutoLevels}&notifySubscribers={Job.Video.NotifySubscribers}"
				+ $"&stabilize={Job.Video.Stabilize}&part=snippet,status,contentDetails",
				"POST",
				YoutubeAccountService.GetAccessToken(Job.Account));

			request.Headers.Add($"x-upload-content-length: {Job.Video.File.Length}");
			request.Headers.Add($"x-upload-content-type: {MimeMapping.GetMimeMapping(Job.Video.File.Name)}");

			request.ContentLength = bytes.Length;
			request.ContentType = "application/json; charset=utf-8";

			return WebService.Communicate(request, bytes, "Location");
		}

		internal HttpWebRequest CreateNewUploadRequest()
		{
			var request = CreateHttpWebRequestWithAuthHeader(Job.Uri.AbsoluteUri, "PUT", YoutubeAccountService.GetAccessToken(Job.Account));
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
			var request = CreateHttpWebRequestWithAuthHeader(Job.Uri.AbsoluteUri, "PUT", YoutubeAccountService.GetAccessToken(Job.Account));
			request.Headers.Add($"Content-Range: bytes {lastbyte + 1}-{Job.Video.File.Length - 1}/{Job.Video.File.Length}");
			request.ContentLength = Job.Video.File.Length - (lastbyte + 1);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		private string UploadVideo()
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
			while (!Token.IsCancellationRequested && (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
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
			var request = CreateHttpWebRequestWithAuthHeader(Job.Uri.AbsoluteUri, "PUT",
				YoutubeAccountService.GetAccessToken(Job.Account));
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

		internal string UploadThumbnail(string videoId)
		{
			var token = YoutubeAccountService.GetAccessToken(Job.Account);
			var secret = YoutubeAccountService.GetClientSecretForAccessToken(token);

			var request = CreateHttpWebRequestWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={videoId}&key={secret}",
				"POST", token);

			string result = null;

			FileInfo file = null;
			if (File.Exists(Job.Video.ThumbnailPath))
			{
				if ((file = new FileInfo(Job.Video.ThumbnailPath)).Length < 2000000)
				{
					request.ContentLength = file.Length;
					request.ContentType = MimeMapping.GetMimeMapping(Job.Video.ThumbnailPath);

					FileStream fileStream = new FileStream(Job.Video.ThumbnailPath, FileMode.Open, FileAccess.Read);

					Stream requestStream = request.GetRequestStream();
					byte[] buffer = new byte[128 * 1024];
					int bytesRead = 0;

					// Hochladen
					while (!Token.IsCancellationRequested
						&& (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
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
				else
				{
					Job.State = UploadState.Error;
					Job.Error = new InternalYoutubeError("Das Thumbnail konnte nicht hochgeladen werden, weil es zu groß ist.");
				}
			}

			return result;
		}

		private HttpWebRequest CreateHttpWebRequest(string address, string method)
		{
			var request = (HttpWebRequest)WebRequest.Create(address);
			request.Method = method;
			request.Proxy = null;
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			return request;
		}

		private HttpWebRequest CreateHttpWebRequestWithAuthHeader(string address, string method, string token)
		{
			var request = CreateHttpWebRequest(address, token);
			request.Headers.Add($"Authorization: Bearer {token}");

			return request;
		}
	}
}
