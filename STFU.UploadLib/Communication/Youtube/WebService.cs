using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using STFU.UploadLib.Accounts;
using STFU.UploadLib.Communication.Youtube.Serializable;
using STFU.UploadLib.Queue;

namespace STFU.UploadLib.Communication.Youtube
{
	internal static class WebService
	{
		private static ResourceManager resourceManager;

		private static string clientId;
		private static string clientSecret;

		public static event ProgressChangedEventHandler ProgressChanged;

		private static string Communicate(WebRequest request, byte[] bytes = null, string headerName = null)
		{
			if (bytes != null && bytes.Length != 0)
			{
				// Senden
				var requestStream = request.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
			}

			try
			{
				// Verbinden
				var response = request.GetResponse();
				var responseStream = response.GetResponseStream();

				if (string.IsNullOrWhiteSpace(headerName))
				{
					// Lesen
					StreamReader responseReader = new StreamReader(responseStream);
					return responseReader.ReadToEnd();
				}
				else
				{
					// Url erhalten
					return response.Headers.Get(headerName);
				}
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					var response = ex.Response as HttpWebResponse;
					if ((int)response.StatusCode == 308)
					{
						var range = response.Headers.Get("range");
						return range;
					}
				}

				if (ex.Response != null)
				{
					using (var stream = ex.Response.GetResponseStream())
					{
						using (var reader = new StreamReader(stream))
						{
							return reader.ReadToEnd();
						}
					}
				}
				return null;
			}
		}

		private static void OnProgressChanged(string fileName, double progress)
		{
			ProgressChangedEventArgs args = new ProgressChangedEventArgs();
			args.FileName = fileName;
			args.Progress = progress;

			ProgressChanged?.Invoke(args);
		}

		internal static string GetAuthUrl(bool showAuthToken = false)
		{
			string scope = resourceManager.GetString("UploadScope");
			string redirectUri = (showAuthToken) ? resourceManager.GetString("RedirectUriManuGet") : resourceManager.GetString("RedirectUriAutoGet");
			string responseType = resourceManager.GetString("AuthResponseType");
			string authRequestString = resourceManager.GetString("AuthRequestUrl");

			var link = string.Format(authRequestString, clientId, redirectUri, scope, responseType);

			// Später evtl Link kürzen..

			return link;
		}

		internal static string LogoutAndThenGetAuthUrl(bool showAuthToken = false)
		{
			string logoffAndContinueString = resourceManager.GetString("LogoffAndContinueLink");
			var escaped = string.Format(logoffAndContinueString, Uri.EscapeDataString(GetAuthUrl(showAuthToken)));
			return escaped;
		}

		internal static string ObtainAccessToken(string code, bool useLocalhostRedirect = true)
		{
			// Content zusammenbauen
			string content = resourceManager.GetString("AuthCodeContent");

			content = string.Format(content, code, clientId, clientSecret, useLocalhostRedirect ? resourceManager.GetString("RedirectUriAutoGet") : resourceManager.GetString("RedirectUriManuGet"));
			var bytes = Encoding.UTF8.GetBytes(content);

			// Request erstellen
			WebRequest request = WebRequest.Create(resourceManager.GetString("AuthCodeAddress"));
			request.Method = resourceManager.GetString("AuthCodeMethod");
			request.ContentType = resourceManager.GetString("FormContentType");

			return Communicate(request, bytes);
		}

		internal static string RefreshAccess(string refreshToken)
		{
			// Content zusammenbauen
			string content = resourceManager.GetString("AuthRefreshContent");

			content = string.Format(content, clientId, clientSecret, refreshToken);
			var bytes = System.Text.Encoding.UTF8.GetBytes(content);

			// Request erstellen
			WebRequest request = WebRequest.Create(resourceManager.GetString("AuthCodeAddress"));
			request.Method = resourceManager.GetString("AuthCodeMethod");
			request.ContentType = resourceManager.GetString("FormContentType");

			return Communicate(request, bytes);
		}

		internal static string RevokeAccess(Account account)
		{
			// Token setzen und prüfen
			string token = (!string.IsNullOrWhiteSpace(account.Access.RefreshToken)) ? account.Access.RefreshToken : account.Access.AccessToken;
			if (!string.IsNullOrWhiteSpace(token))
			{
				string address = string.Format(resourceManager.GetString("AuthRevokeAddress"), token);

				WebRequest request = WebRequest.Create(address);
				request.ContentType = resourceManager.GetString("FormContentType");

				var status = Communicate(request);
				return status;
			}

			return null;
		}

		internal static string InitializeUpload(ref Job job)
		{
			// Inhalt erstellen
			var ytVideo = new YoutubeVideo(job.SelectedVideo);
			string content = JsonConvert.SerializeObject(ytVideo);
			var bytes = System.Text.Encoding.UTF8.GetBytes(content);

			// Request erstellen
			WebRequest request = WebRequest.Create(string.Format(resourceManager.GetString("UploadUrl"), job.SelectedVideo.NotifySubscribers, job.SelectedVideo.AutoLevels, job.SelectedVideo.Stabilize));
			request.Method = resourceManager.GetString("UpoadInitMethod");
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), job.UploadingAccount.Access.AccessToken));
			request.Headers.Add(string.Format(resourceManager.GetString("XUploadContentLengthHeader"), job.SelectedVideo.File.Length));
			request.Headers.Add(string.Format(resourceManager.GetString("XUploadContentTypeHeader"), MimeMapping.GetMimeMapping(job.SelectedVideo.File.Name)));

			request.ContentLength = bytes.Length;
			request.ContentType = resourceManager.GetString("JSONContentType");

			return Communicate(request, bytes, "Location");
		}

		internal static HttpWebRequest CreateNewUploadRequest(ref Job job)
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(job.Url.AbsoluteUri);
			request.Proxy = null;
			request.Method = resourceManager.GetString("UploadMethod");
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), job.UploadingAccount.Access.AccessToken));
			request.ContentLength = job.SelectedVideo.File.Length;
			request.ContentType = MimeMapping.GetMimeMapping(job.SelectedVideo.File.Name);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		internal static HttpWebRequest CreateResumeUploadRequest(ref Job job, long lastbyte)
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(job.Url.AbsoluteUri);
			request.Proxy = null;
			request.Method = resourceManager.GetString("UploadMethod");
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), job.UploadingAccount.Access.AccessToken));
			request.Headers.Add(string.Format(resourceManager.GetString("ResumeUploadContentRangeHeader"), lastbyte + 1, job.SelectedVideo.File.Length - 1, job.SelectedVideo.File.Length));
			request.ContentLength = job.SelectedVideo.File.Length - (lastbyte + 1);

			// Am Leben halten (wichtig bei großen Dateien)!
			request.ServicePoint.SetTcpKeepAlive(true, 10000, 1000);
			request.AllowWriteStreamBuffering = false;
			request.Timeout = int.MaxValue;

			return request;
		}

		internal static string UploadVideo(ref Job job, ref bool shouldCancel)
		{
			var lastbyte = CheckUploadStatus(ref job);

			FileStream fileStream = new FileStream(job.SelectedVideo.Path, FileMode.Open, FileAccess.Read);

			HttpWebRequest request = null;
			if (lastbyte == -1)
			{
				request = CreateNewUploadRequest(ref job);
			}
			else
			{
				request = CreateResumeUploadRequest(ref job, lastbyte);
				fileStream.Position = lastbyte + 1;
			}

			job.Status.Running = true;

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
					var save = Convert.ToInt32(job.Status.Progress * 100);
					job.Status.Progress = fileStream.Position / (double)job.SelectedVideo.File.Length * 100;
					if (Convert.ToInt32(job.Status.Progress) != save)
					{
						OnProgressChanged(job.SelectedVideo.Title, save);
					}
				}
				catch (WebException)
				{
					requestStream.Close();
					return job.Url.AbsolutePath;
				}
				catch (IOException)
				{
					requestStream.Close();
					return job.Url.AbsolutePath;
				}
			}
			fileStream.Close();

			try
			{
				requestStream.Close();
				job.Status.Progress = 100.0;
				job.Status.Finished = true;
			}
			catch (WebException)
			{
			}

			job.Status.Running = false;

			var response = Communicate(request);

			request = null;

			return response;
		}

		internal static long CheckUploadStatus(ref Job job)
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(job.Url.AbsoluteUri);
			request.Proxy = null;
			request.Method = resourceManager.GetString("UploadMethod");
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), job.UploadingAccount.Access.AccessToken));
			request.ContentLength = 0;
			request.Headers.Add(string.Format(resourceManager.GetString("CheckStatusContentRangeHeader"), job.SelectedVideo.File.Length));

			var answer = Communicate(request);
			if (answer == null)
			{
				return -1;
			}
			Trace.WriteLine(answer);
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

		internal static string UploadThumbnail(ref Job job, string videoId, ref bool shouldCancel)
		{
			// Request erstellen
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(resourceManager.GetString("UploadThumbnailUrl"), clientSecret, videoId));
			request.Proxy = null;
			request.Method = resourceManager.GetString("UploadThumbnailMethod");
			request.KeepAlive = true;
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), job.UploadingAccount.Access.AccessToken));

			string result = null;

			FileInfo file = null;
			if (File.Exists(job.SelectedVideo.ThumbnailPath) && (file = new FileInfo(job.SelectedVideo.ThumbnailPath)).Length < 2000000)
			{
				request.ContentLength = file.Length;
				request.ContentType = MimeMapping.GetMimeMapping(job.SelectedVideo.ThumbnailPath);

				FileStream fileStream = new FileStream(job.SelectedVideo.ThumbnailPath, FileMode.Open, FileAccess.Read);

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
						var save = Convert.ToInt32(job.Status.Progress * 100);
						job.Status.Progress = fileStream.Position / (double)file.Length * 100;
						if (Convert.ToInt32(job.Status.Progress) != save)
						{
							OnProgressChanged($"Thumbnail für {job.SelectedVideo.Title}", save);
						}
					}
					catch (WebException)
					{
						requestStream.Close();
						return job.Url.AbsolutePath;
					}
					catch (IOException)
					{
						requestStream.Close();
						return job.Url.AbsolutePath;
					}
				}
				fileStream.Close();

				try
				{
					requestStream.Close();
					job.Status.Progress = 100.0;
					job.Status.Finished = true;
				}
				catch (WebException)
				{
				}

				job.Status.Running = false;

				result = Communicate(request);

				request = null;
			}

			return result;
		}

		internal static string[] GetPlaylistItems(string accessToken, string playlistId)
		{
			var pageToken = string.Empty;
			string url = string.Format(resourceManager.GetString("GetPlaylistItemsUrl"), playlistId, pageToken);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Proxy = null;
			request.Method = resourceManager.GetString("GetPlaylistMethod");
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), accessToken));

			var list = new List<string>();
			Response response = null;

			// Wurde auf Webservice-Response umgestellt und muss noch vertestet werden.
			while (!string.IsNullOrWhiteSpace((response = JsonConvert.DeserializeObject<Response>(Communicate(request))).nextPageToken))
			{
				foreach (var item in response.items)
				{
					list.Add(item.contentDetails.videoId);
				}

				pageToken = string.Empty;
				if (!string.IsNullOrWhiteSpace(response.nextPageToken))
				{
					pageToken = string.Format(resourceManager.GetString("GetPlaylistTokenAddition"), response.nextPageToken);
				}

				url = string.Format(resourceManager.GetString("GetPlaylistItemsUrl"), playlistId, pageToken);
				request = (HttpWebRequest)WebRequest.Create(url);
				request.Proxy = null;
				request.Method = resourceManager.GetString("GetPlaylistMethod");
				request.Credentials = CredentialCache.DefaultCredentials;
				request.ProtocolVersion = HttpVersion.Version11;

				// Header schreiben
				request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), accessToken));
			}

			foreach (var item in response.items)
			{
				list.Add(item.contentDetails.videoId);
			}

			return list.ToArray();
		}

		internal static Response GetAccountDetails(string accessToken)
		{
			var pageToken = string.Empty;
			string url = string.Format(resourceManager.GetString("GetChannelDetailsUrl"), clientSecret);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Proxy = null;
			request.Method = resourceManager.GetString("GetChannelDetailsMethod");
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), accessToken));

			Response response = JsonConvert.DeserializeObject<Response>(Communicate(request));

			return response;
		}

		internal static Response GetVideoCategories(string regionCode, string accessToken)
		{
			var pageToken = string.Empty;
			CultureInfo ci = CultureInfo.CurrentUICulture;
			string url = string.Format(resourceManager.GetString("GetVideoCategoriesUrl"), clientSecret, regionCode, ci.Name);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Proxy = null;
			request.Method = resourceManager.GetString("GetVideoCategoriesMethod");
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), accessToken));

			Response response = JsonConvert.DeserializeObject<Response>(Communicate(request));

			return response;
		}

		internal static Response GetLanguages(string accessToken)
		{
			var pageToken = string.Empty;
			CultureInfo ci = CultureInfo.CurrentUICulture;
			string url = string.Format(resourceManager.GetString("GetLanguagesUrl"), clientSecret, ci.Name);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Proxy = null;
			request.Method = resourceManager.GetString("GetLanguagesMethod");
			request.Credentials = CredentialCache.DefaultCredentials;
			request.ProtocolVersion = HttpVersion.Version11;

			// Header schreiben
			request.Headers.Add(string.Format(resourceManager.GetString("AuthHeader"), accessToken));

			Response response = JsonConvert.DeserializeObject<Response>(Communicate(request));

			return response;
		}

		#region MonoSSL
		static WebService()
		{
			resourceManager = new ResourceManager(new WebResources().GetType());

			clientId = resourceManager.GetString("ClientId");
			clientSecret = resourceManager.GetString("ClientSecret");

			ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });
		}

		// Um an die Assembly zu kommen
		private class AssemblyGetter { }

		private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			//Return true if the server certificate is ok
			if (sslPolicyErrors == SslPolicyErrors.None)
				return true;

			bool acceptCertificate = true;
			string msg = "The server could not be validated for the following reason(s):\r\n";

			//The server did not present a certificate
			if ((sslPolicyErrors &
				 SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable)
			{
				msg = msg + "\r\n    -The server did not present a certificate.\r\n";
				acceptCertificate = false;
			}
			else
			{
				//The certificate does not match the server name
				if ((sslPolicyErrors &
					 SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
				{
					msg = msg + "\r\n    -The certificate name does not match the authenticated name.\r\n";
					acceptCertificate = false;
				}

				//There is some other problem with the certificate
				if ((sslPolicyErrors &
					 SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
				{
					foreach (X509ChainStatus item in chain.ChainStatus)
					{
						if (item.Status != X509ChainStatusFlags.RevocationStatusUnknown &&
							item.Status != X509ChainStatusFlags.OfflineRevocation)
							break;

						if (item.Status != X509ChainStatusFlags.NoError)
						{
							msg = msg + "\r\n    -" + item.StatusInformation;
							acceptCertificate = false;
						}
					}
				}
			}

			//If Validation failed, present message box
			if (acceptCertificate == false)
			{
				msg = msg + "\r\nDo you wish to override the security check?";
				//          if (MessageBox.Show(msg, "Security Alert: Server could not be validated",
				//                       MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
				acceptCertificate = true;
			}

			return acceptCertificate;
		}
		#endregion MonoSSL
	}
}
