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

		public async void UploadAsync()
		{
			await Task.Run(() => Upload());
		}

		public void Upload()
		{
			var initializer = new YoutubeVideoUploadInitializer(Job);
			initializer.InitializeUpload();

			if (initializer.Successful)
			{
				Job.Uri = initializer.VideoUploadUri;

				int uploadUnsuccessfulCounter = 0;
				while (CancelNotRequested() && NotTooManyAttempts(uploadUnsuccessfulCounter))
				{
					bool uploadSuccessful = TryUploadVideo();
					if (uploadSuccessful)
					{
						break;
					}

					uploadUnsuccessfulCounter++;
					Thread.Sleep(new TimeSpan(0, 1, 0));
				}
			}
		}

		private bool TryUploadVideo()
		{
			bool finished = false;
			string result = null;

			bool uploadFinished = UploadVideo(out result);
			if (uploadFinished)
			{
				Job.VideoId = JsonConvert.DeserializeObject<YoutubeVideo>(result).id;

				var thumbnailUploader = new YoutubeThumbnailUploader(CancelToken, Job);
				var thumbnailResponse = thumbnailUploader.UploadThumbnail();

				finished = true;
			}

			return finished;
		}

		private bool UploadVideo(out string result)
		{
			var videoUploader = new YoutubeVideoUploader(Job);
			result = null;

			var successful = videoUploader.Upload();
			if (successful)
			{
				result = videoUploader.Response;
			}

			return successful;
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
