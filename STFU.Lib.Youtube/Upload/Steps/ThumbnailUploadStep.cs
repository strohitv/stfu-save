using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ThumbnailUploadStep : AbstractUploadStep
	{
		public override double Progress
		{
			get
			{
				if (stream != null)
				{
					return ((double)stream.Position) * 100 / stream.Length;
				}

				return 0;
			}
		}

		public ThumbnailUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
			: base(video, account, status) { }

		private FileStream stream = null;

		internal override void Run()
		{
			if (File.Exists(Video.ThumbnailPath))
			{
				HttpWebRequest request = CreateThumbnailUploadRequest();

				try
				{
					using (FileStream filestream = new FileStream(Video.ThumbnailPath, FileMode.Open))
					using (var requestStream = request.GetRequestStream())
					{
						CancellationTokenSource = new CancellationTokenSource();
						stream = filestream;

						try
						{
							filestream.CopyToAsync(requestStream, 81920, CancellationTokenSource.Token).Wait();
							FinishedSuccessful = true;
						}
						catch (AggregateException)
						{
							// Upload wurde abgebrochen
						}
						finally
						{
							stream = null;
						}
					}
				}
				catch (Exception)
				{
					// im Falle eines Abbruchs fliegt da noch ne Webexception, da der RequestStream abgebrochen wurde.
				}

				if (FinishedSuccessful)
				{
					request.Headers.Set("Authorization", $"Bearer {Account.GetActiveToken()}");
					var thumbnailResource = WebService.Communicate(request);
				}
			}
			else
			{
				// Keine Datei -> Upload war erfolgreich
			}

			OnStepFinished();
		}

		private HttpWebRequest CreateThumbnailUploadRequest()
		{
			var accessToken = Account.GetActiveToken();
			var secret = Account.Access.First(a => a.AccessToken == accessToken).Client.Secret;

			var request = HttpWebRequestCreator.CreateWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={Video.Id}&key={secret}",
				"POST", accessToken);

			FileInfo file = new FileInfo(Video.ThumbnailPath);
			request.ContentLength = file.Length;
			request.ContentType = MimeMapping.GetMimeMapping(Video.ThumbnailPath);
			return request;
		}

		private List<Tuple<TimeSpan, long>> speeds = new List<Tuple<TimeSpan, long>>();
		private DateTime lastRead = default(DateTime);
		private long lastPosition = 0;

		public override void RefreshDurationAndSpeed()
		{
			while (speeds.Count >= 30)
			{
				speeds.RemoveAt(0);
			}

			var now = DateTime.Now;
			TimeSpan span = now.Subtract(lastRead);
			long difference = stream != null ? lastPosition - stream.Position : 0;

			lastRead = now;

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

		public override void Cancel()
		{
			if (RunningTask != null && RunningTask.Status == TaskStatus.Running)
			{
				CancellationTokenSource.Cancel();
			}
		}
	}
}
