using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Common.Model.Serializable;

namespace STFU.Lib.Youtube.Common.Internal.Upload
{
	internal class YoutubeJobUploader
	{
		public InternalYoutubeJob Job { get; set; }

		internal CancellationToken CancelToken { get; set; }

		internal YoutubeJobUploader(InternalYoutubeJob job, CancellationToken cancelToken)
		{
			Job = job;
			CancelToken = cancelToken;
		}

		public async Task UploadAsync()
		{
			await Task.Run(() => Upload());
		}

		public void Upload()
		{
			var initializer = new YoutubeVideoUploadInitializer(Job);
			initializer.PrepareUpload();

			if (initializer.Result)
			{
				Job.Uri = initializer.Uri;

				int uploadCounter = 0;
				while (CancelNotRequested() && NotTooManyAttempts(uploadCounter))
				{
					if (TryUpload())
					{
						break;
					}

					uploadCounter++;
					Thread.Sleep(new TimeSpan(0, 1, 0));
				}
			}
		}

		private bool TryUpload()
		{
			bool finished = false;
			string result = null;

			bool uploadFinished = UploadVideo(out result);
			if (uploadFinished)
			{
				Job.VideoId = JsonConvert.DeserializeObject<YoutubeVideo>(result).id;
				var thumbnailUploader = new YoutubeThumbnailUploader(CancelToken, Job);
				var thumbnailResult = thumbnailUploader.UploadThumbnail();

				finished = true;
			}

			return finished;
		}

		private bool UploadVideo(out string result)
		{
			Uri testUrl = null;
			var videoUploader = new YoutubeVideoUploader(Job);
			return Uri.TryCreate(result = videoUploader.Upload(), UriKind.Absolute, out testUrl);
		}

		private static bool NotTooManyAttempts(int counter)
		{
			return counter < 4;
		}

		private bool CancelNotRequested()
		{
			return !CancelToken.IsCancellationRequested;
		}
	}
}
