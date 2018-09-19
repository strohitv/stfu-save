using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Services;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeThumbnailUploader : INotifyPropertyChanged
	{
		private FileUploader fileUploader = new FileUploader();

		private InternalYoutubeJob Job { get; set; }

		private RunningState state = RunningState.NotRunning;
		public RunningState State
		{
			get
			{
				return state;
			}
			private set
			{
				if (state != value)
				{
					state = value;
					OnPropertyChanged();
				}
			}
		}

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

		internal YoutubeThumbnailUploader(InternalYoutubeJob job)
		{
			Job = job;
		}

		internal bool UploadThumbnail()
		{
			var successful = true;

			if (File.Exists(Job.Video.ThumbnailPath))
			{
				State = RunningState.Running;
				Job.State = UploadState.ThumbnailUploading;

				var accessToken = YoutubeAccountService.GetAccessToken(Job.Account);
				var secret = Job.Account.Access.First(a => a.AccessToken == accessToken).Client.Secret;

				var request = HttpWebRequestCreator.CreateWithAuthHeader(
					$"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={Job.VideoId}&key={secret}",
					"POST", accessToken);

				FileInfo file = new FileInfo(Job.Video.ThumbnailPath);
				request.ContentLength = file.Length;
				request.ContentType = MimeMapping.GetMimeMapping(Job.Video.ThumbnailPath);

				fileUploader.PropertyChanged += FileUploaderPropertyChanged;

				successful = fileUploader.UploadFile(Job.Video.ThumbnailPath, request);
				if (successful)
				{
					Response = WebService.Communicate(request);
				}
			}

			State = RunningState.NotRunning;

			return successful;
		}

		internal void Cancel()
		{
			if (State == RunningState.Running)
			{
				State = RunningState.CancelPending;
				fileUploader.Cancel();
			}
		}

		private void FileUploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Job.Progress = fileUploader.Progress;
			}
			else
			{
				Job.Error = FailReasonConverter.GetError(fileUploader.FailureReason);
			}
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion INofityPropertyChanged
	}
}
