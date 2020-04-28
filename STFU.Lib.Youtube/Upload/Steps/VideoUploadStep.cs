using System;
using System.Collections.Generic;
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
		public override double Progress
		{
			get
			{
				if (fileStream != null)
				{
					return ((double)fileStream.Position) * 100 / fileStream.Length;
				}

				return 0;
			}
		}

		public VideoUploadStep(IYoutubeJob job)
			: base(job) { }

		private FileStream fileStream = null;
		private Stream throttledStream = null;
		private Stream requestStream = null;

		internal override void Run()
		{
			// Initialisieren
			GenerateInitUri();
			var request = CreateRequest();

			if (request == null)
			{
				// evtl. vorhandene UploadUri hat nicht geklappt => Versuch, den Upload von vorne zu beginnen.
				Status.UploadAddress = null;
				GenerateInitUri();
				request = CreateRequest();
			}

			// Hochladen
			if (request != null && File.Exists(Video.Path))
			{
				try
				{
					ServicePointManager.FindServicePoint(Status.UploadAddress).UseNagleAlgorithm = false;
					request.Proxy = new WebProxy();
					request.AllowWriteStreamBuffering = false;

					using (fileStream = new FileStream(Video.Path, FileMode.Open))
					using (throttledStream = new ThrottledReadStream(fileStream))
					using (requestStream = request.GetRequestStream())
					{
						CancellationTokenSource = new CancellationTokenSource();
						fileStream.Position = Status.LastByte + 1;

						try
						{
							lastRead = DateTime.Now;
							lastPosition = fileStream.Position;
							throttledStream.CopyToAsync(requestStream, 81920, CancellationTokenSource.Token).Wait();
							FinishedSuccessful = true;
							Status.Progress = 100;
						}
						catch (AggregateException)
						{
							// Upload wurde abgebrochen
						}
						finally
						{
							fileStream = null;
							requestStream = null;
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
					// im Falle eines Abbruchs fliegt da noch ne Webexception, da der RequestStream abgebrochen wurde.
				}

				if (FinishedSuccessful)
				{
					request.Headers.Set("Authorization", $"Bearer {Account.GetActiveToken()}");
					string result = WebService.Communicate(request);

					Video.Id = JsonConvert.DeserializeObject<SerializableYoutubeVideo>(result).id;
				}
			}

			OnStepFinished();
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
			// Default: Upload klappt nicht
			HttpWebRequest request = null;

			Status.LastByte = CheckUploadStatus();

			if (Status.LastByte == -1)
			{
				// Komplette Datei hochladen
				request = HttpWebRequestCreator.CreateForNewUpload(Status.UploadAddress, Video, Account);
			}
			else if (Status.LastByte >= 0)
			{
				// Nur einen Teil der Datei hochladen
				request = HttpWebRequestCreator.CreateForResumeUpload(Status.UploadAddress, Video, Account, Status.LastByte);
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
				if (ex.Response != null && ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
				{
					// Upload kann nicht fortgesetzt werden, da Verarbeitung mittlerweile abgebrochen wurde.
					// Workaround: Upload neu starten
					return -2;
				}
				else if (ex.Response != null && (int)((HttpWebResponse)ex.Response).StatusCode != 308)
				{
					// Es gab einen anderen unerwarteten Fehler.
					// Auch hier ist der Workaround ein Neustart.
					return -3;
				}

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

		private List<Tuple<TimeSpan, long>> speeds = new List<Tuple<TimeSpan, long>>();
		private DateTime lastRead = default(DateTime);
		private long lastPosition = 0;

		public override void RefreshDurationAndSpeed()
		{
			if (fileStream != null && lastRead != default(DateTime))
			{
				while (speeds.Count >= 30)
				{
					speeds.RemoveAt(0);
				}

				var now = DateTime.Now;
				TimeSpan span = now.Subtract(lastRead);
				long difference = fileStream.Position - lastPosition;

				lastRead = now;
				lastPosition = fileStream.Position;

				speeds.Add(new Tuple<TimeSpan, long>(span, difference));

				var progress = Progress;

				Status.UploadedDuration += span;
				Status.RemainingDuration = new TimeSpan(0, 0, 0, 0, (int)(Status.UploadedDuration.TotalSeconds * 1000 / progress * (100 - progress)));

				long lastSecondSize = 0;
				TimeSpan lastSecondSpan = new TimeSpan();

				for (int i = speeds.Count - 1; i >= 0; i--)
				{
					lastSecondSpan += speeds[i].Item1;
					lastSecondSize += speeds[i].Item2;

					if (lastSecondSpan > new TimeSpan(0, 0, 1))
					{
						break;
					}
				}

				var factor = 1000 / (double)(long)lastSecondSpan.TotalMilliseconds;
				Status.CurrentSpeed = (long)(lastSecondSize * factor);
			}
		}

		public override void Cancel()
		{
			CancellationTokenSource.Cancel();
		}
	}
}
