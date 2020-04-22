using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model.Serializable;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class VideoUploadStep : AbstractUploadStep
	{
		public VideoUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
			: base(video, account, status) { }

		internal override void Run()
		{
			// Initialisieren
			GenerateInitUri();
			var request = CreateRequest();

			if (request == null)
			{
				// evtl. vorhandene UploadUri hat nicht geklappt => Upload von vorne beginnen.
				Status.UploadAddress = null;
				GenerateInitUri();
				request = CreateRequest();
			}

			// Hochladen
			if (request != null && File.Exists(Video.Path))
			{
				try
				{
					using (FileStream filestream = new FileStream(Video.Path, FileMode.Open))
					using (var requestStream = request.GetRequestStream())
					{
						CancellationTokenSource = new CancellationTokenSource();
						filestream.Position = Status.LastByte + 1;

						try
						{
							filestream.CopyToAsync(requestStream, 81920, CancellationTokenSource.Token).Wait();
							FinishedSuccessful = true;
						}
						catch (AggregateException ex)
						{
							// Upload wurde abgebrochen
							Console.WriteLine(ex);
						}
					}
				}
				catch (Exception)
				{
					// im Falle eines Abbruchs fliegt da noch ne Webexception, da der RequestStream abgebrochen wurde.
				}

				if (FinishedSuccessful && !CancellationTokenSource.IsCancellationRequested)
				{
					using (var response = request.GetResponse())
					{
						Console.WriteLine(response);
					}
				}
			}
		}

		private void GenerateInitUri()
		{
			if (Status.UploadAddress == null)
			{
				string result = InitializeUploadOnYoutube();

				Uri uri = null;
				if (Uri.TryCreate(result, UriKind.Absolute, out uri))
				{
					Status.UploadAddress = uri;
				}
			}
		}

		private string InitializeUploadOnYoutube()
		{
			var ytVideo = SerializableYoutubeVideo.Create(Video);
			string content = JsonConvert.SerializeObject(ytVideo);
			var bytes = Encoding.UTF8.GetBytes(content);

			var request = HttpWebRequestCreator.CreateWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable"
				+ $"&autoLevels={Video.AutoLevels}&notifySubscribers={Video.NotifySubscribers}"
				+ $"&stabilize={Video.Stabilize}&part=snippet,status,contentDetails",
				"POST",
				Account.GetActiveToken());

			request.Headers.Add($"x-upload-content-length: {Video.File.Length}");
			request.Headers.Add($"x-upload-content-type: {MimeMapping.GetMimeMapping(Video.File.Name)}");

			request.ContentLength = bytes.Length;
			request.ContentType = "application/json; charset=utf-8";

			return WebService.Communicate(request, bytes, "Location");
		}

		private HttpWebRequest CreateRequest()
		{
			HttpWebRequest request;

			Status.LastByte = CheckUploadStatus();

			if (Status.LastByte == -1)
			{
				request = HttpWebRequestCreator.CreateForNewUpload(Status.UploadAddress, Video, Account);
			}
			else if (Status.LastByte >= 0)
			{
				request = HttpWebRequestCreator.CreateForResumeUpload(Status.UploadAddress, Video, Account, Status.LastByte);
			}
			else
			{
				// Todo: 
				request = null;
			}

			return request;
		}

		private long CheckUploadStatus()
		{
			var request = HttpWebRequestCreator.CreateWithAuthHeader(Status.UploadAddress.AbsoluteUri, "PUT", Account.GetActiveToken());
			request.ContentLength = 0;
			request.Headers.Add($"content-range: bytes */{Video.File.Length}");

			WebException ex = null;
			var answer = WebService.Communicate(request, out ex);
			if (answer == null)
			{
				// Check ob Link ungültig oder wirklich -1 gewünscht ist.
				// Dazu ex benutzen.
				// Wenn Link abgelaufen => -2

				// TestUrl: https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable&autoLevels=False&notifySubscribers=True&stabilize=False&part=snippet,status,contentDetails&upload_id=AAANsUnuyqK-CVQ3_EIehJI86MjDX8_Kg7_usm7WTQKldFA-gN2IRVxj8oNKWHPRngiyhfZBNywhy4KOvudTMbpGMoZ83KQITA
				// 22.04.2020 07:52 Uhr

				// Außerdem: Hier im Fehlerfall einer absolut unerwarteten Exception (z. B. Internet weg) schmeißen

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
	}
}
