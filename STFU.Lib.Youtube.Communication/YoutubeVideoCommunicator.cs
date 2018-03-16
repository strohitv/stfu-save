using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Communication.Internal;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication
{
	public class YoutubeVideoCommunicator
	{
		private IYoutubeJob Job { get; set; }

		public YoutubeVideoCommunicator(IYoutubeJob job)
		{
			Job = job;
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
			WebRequest request = WebRequest.Create(string.Format(resourceManager.GetString("UploadUrl"), Job.Video.NotifySubscribers, Job.Video.AutoLevels, Job.Video.Stabilize));
			request.Method = resourceManager.GetString("UpoadInitMethod");
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), Job.Account.Access.AccessToken));
			request.Headers.Add(string.Format(resourceManager.GetString("XUploadContentLengthHeader"), Job.SelectedVideo.File.Length));
			request.Headers.Add(string.Format(resourceManager.GetString("XUploadContentTypeHeader"), MimeMapping.GetMimeMapping(Job.SelectedVideo.File.Name)));

			request.ContentLength = bytes.Length;
			request.ContentType = resourceManager.GetString("JSONContentType");

			return WebService.Communicate(request, bytes, "Location");
		}

		internal HttpWebRequest CreateNewUploadRequest()
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Job.Url.AbsoluteUri);
			request.Proxy = null;
			request.Method = "PUT";
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), Job.UploadingAccount.Access.AccessToken));
			request.ContentLength = Job.SelectedVideo.File.Length;
			request.ContentType = MimeMapping.GetMimeMapping(Job.SelectedVideo.File.Name);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		internal HttpWebRequest CreateResumeUploadRequest(long lastbyte)
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Job.Url.AbsoluteUri);
			request.Proxy = null;
			request.Method = "PUT";
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), Job.UploadingAccount.Access.AccessToken));
			request.Headers.Add(string.Format(resourceManager.GetString("ResumeUploadContentRangeHeader"), lastbyte + 1, Job.SelectedVideo.File.Length - 1, Job.SelectedVideo.File.Length));
			request.ContentLength = Job.SelectedVideo.File.Length - (lastbyte + 1);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		internal string UploadVideo(ref bool shouldCancel)
		{
			var lastbyte = CheckUploadStatus(ref Job);

			FileStream fileStream = new FileStream(Job.SelectedVideo.Path, FileMode.Open, FileAccess.Read);

			HttpWebRequest request = null;
			if (lastbyte == -1)
			{
				request = CreateNewUploadRequest(ref Job);
			}
			else
			{
				request = CreateResumeUploadRequest(ref Job, lastbyte);
				fileStream.Position = lastbyte + 1;
			}

			Job.Status.Running = true;

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
					Job.Progress = fileStream.Position / (double)Job.SelectedVideo.File.Length * 100;
					if (Convert.ToInt32(Job.Progress) != save)
					{
						OnProgressChanged(Job.SelectedVideo.Title, save);
					}
				}
				catch (WebException)
				{
					requestStream.Close();
					return Job.Url.AbsolutePath;
				}
				catch (IOException)
				{
					requestStream.Close();
					return Job.Url.AbsolutePath;
				}
			}
			fileStream.Close();

			try
			{
				requestStream.Close();
				Job.Progress = 100.0;
				Job.Status.Finished = true;
			}
			catch (WebException)
			{
			}

			Job.Status.Running = false;

			var response = WebService.Communicate(request);

			request = null;

			return response;
		}

		internal long CheckUploadStatus()
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Job.Url.AbsoluteUri);
			request.Proxy = null;
			request.Method = "PUT";
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), Job.UploadingAccount.Access.AccessToken));
			request.ContentLength = 0;
			request.Headers.Add(string.Format(resourceManager.GetString("CheckStatusContentRangeHeader"), Job.SelectedVideo.File.Length));

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
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(resourceManager.GetString("UploadThumbnailUrl"), clientSecret, videoId));
			request.Proxy = null;
			request.Method = resourceManager.GetString("UploadThumbnailMethod");
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), Job.UploadingAccount.Access.AccessToken));

			string result = null;

			FileInfo file = null;
			if (File.Exists(Job.SelectedVideo.ThumbnailPath) && (file = new FileInfo(Job.SelectedVideo.ThumbnailPath)).Length < 2000000)
			{
				request.ContentLength = file.Length;
				request.ContentType = MimeMapping.GetMimeMapping(Job.SelectedVideo.ThumbnailPath);

				FileStream fileStream = new FileStream(Job.SelectedVideo.ThumbnailPath, FileMode.Open, FileAccess.Read);

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
						if (Convert.ToInt32(Job.Progress) != save)
						{
							OnProgressChanged($"Thumbnail für {Job.SelectedVideo.Title}", save);
						}
					}
					catch (WebException)
					{
						requestStream.Close();
						return Job.Url.AbsolutePath;
					}
					catch (IOException)
					{
						requestStream.Close();
						return Job.Url.AbsolutePath;
					}
				}
				fileStream.Close();

				try
				{
					requestStream.Close();
					Job.Progress = 100.0;
					Job.Status.Finished = true;
				}
				catch (WebException)
				{
				}

				Job.Status.Running = false;

				result = WebService.Communicate(request);

				request = null;
			}

			return result;
		}
	}
}
