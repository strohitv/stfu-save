using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Internal.Upload.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeThumbnailUploader : Uploadable, INotifyPropertyChanged
	{
		private FileUploader fileUploader = new FileUploader();

		private string response = null;
		public string Response
		{
			get
			{
				return response;
			}

			set
			{
				if (value != response)
				{
					response = value;
					OnPropertyChanged();
				}
			}
		}

		private string videoId = null;
		public string VideoId
		{
			get
			{
				return videoId;
			}

			set
			{
				if (value != videoId)
				{
					videoId = value;
					OnPropertyChanged();
				}
			}
		}

		internal YoutubeThumbnailUploader(IYoutubeVideo video, string videoId, IYoutubeAccount account)
		{
			Video = video;
			VideoId = videoId;
			Account = account;
		}

		internal bool UploadThumbnail()
		{
			var successful = true;

			if (File.Exists(Video.ThumbnailPath))
			{
				State = UploadState.ThumbnailUploading;

				var accessToken = YoutubeAccountService.GetAccessToken(Account);
				var secret = Account.Access.First(a => a.AccessToken == accessToken).Client.Secret;

				var request = HttpWebRequestCreator.CreateWithAuthHeader(
					$"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={VideoId}&key={secret}",
					"POST", accessToken);

				FileInfo file = new FileInfo(Video.ThumbnailPath);
				request.ContentLength = file.Length;
				request.ContentType = MimeMapping.GetMimeMapping(Video.ThumbnailPath);

				fileUploader.PropertyChanged += FileUploaderPropertyChanged;

				successful = fileUploader.UploadFile(Video.ThumbnailPath, request);
				if (successful)
				{
					Response = WebService.Communicate(request);
				}
				else
				{
					Error = FailReasonConverter.GetError(fileUploader.FailureReason);
				}
			}

			return successful;
		}

		internal void Cancel()
		{
			if (State.IsRunningOrInitializing())
			{
				State = UploadState.CancelPending;
				fileUploader.Cancel();
			}
		}

		private void FileUploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Progress = fileUploader.Progress;
			}
			else if (e.PropertyName == nameof(fileUploader.RemainingDuration))
			{
				RemainingDuration = fileUploader.RemainingDuration;
			}
			else if (e.PropertyName == nameof(fileUploader.UploadedDuration))
			{
				UploadedDuration = fileUploader.UploadedDuration;
			}
			else if (e.PropertyName == nameof(fileUploader.FailureReason))
			{
				Error = FailReasonConverter.GetError(fileUploader.FailureReason);
				State = UploadState.ThumbnailError;
			}
		}
	}
}
