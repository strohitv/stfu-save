using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Web;
using STFU.Lib.Youtube.Common.Internal.Services;

namespace STFU.Lib.Youtube.Common.Internal.Upload
{
	internal class YoutubeThumbnailUploader
	{
		private CancellationToken CancelToken { get; set; }
		private InternalYoutubeJob Job { get; set; }

		internal YoutubeThumbnailUploader(CancellationToken cancelToken, InternalYoutubeJob job)
		{
			CancelToken = cancelToken;
			Job = job;
		}

		internal string UploadThumbnail()
		{
			var accessToken = YoutubeAccountService.GetAccessToken(Job.Account);
			var secret = YoutubeAccountService.GetClientSecretForAccessToken(accessToken);

			var request = HttpWebRequestCreator.CreateWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={Job.VideoId}&key={secret}",
				"POST", accessToken);

			string result = null;

			FileInfo file = null;
			request.ContentLength = file.Length;
			request.ContentType = MimeMapping.GetMimeMapping(Job.Video.ThumbnailPath);

			var fileUploader = new FileUploader(CancelToken);
			fileUploader.PropertyChanged += FileUploaderPropertyChanged;

			bool successful = fileUploader.UploadFile(Job.Video.ThumbnailPath, request);
			if (successful)
			{
				result = WebService.Communicate(request);
			}

			return result;
		}

		private void FileUploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var fileUploader = (FileUploader)sender;
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Job.Progress = ((FileUploader)sender).Progress;
			}
			else
			{
				Job.Error = FailReasonConverter.GetError(fileUploader.FailureReason);
			}
		}
	}
}
