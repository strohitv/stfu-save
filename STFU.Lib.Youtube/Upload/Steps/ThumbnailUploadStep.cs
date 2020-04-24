using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ThumbnailUploadStep : AbstractUploadStep
	{
		public ThumbnailUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
			: base(video, account, status) { }

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

						try
						{
							filestream.CopyToAsync(requestStream, 81920, CancellationTokenSource.Token).Wait();
							FinishedSuccessful = true;
						}
						catch (AggregateException)
						{
							// Upload wurde abgebrochen
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
	}
}
