using System.ComponentModel;
using System.IO;
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
			State = RunningState.Running;

			var accessToken = YoutubeAccountService.GetAccessToken(Job.Account);
			var secret = YoutubeAccountService.GetClientSecretForAccessToken(accessToken);

			var request = HttpWebRequestCreator.CreateWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={Job.VideoId}&key={secret}",
				"POST", accessToken);

			FileInfo file = null;
			request.ContentLength = file.Length;
			request.ContentType = MimeMapping.GetMimeMapping(Job.Video.ThumbnailPath);

			fileUploader.PropertyChanged += FileUploaderPropertyChanged;

			bool successful = fileUploader.UploadFile(Job.Video.ThumbnailPath, request);
			if (successful)
			{
				Response = WebService.Communicate(request);
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
			var fileUploader = (FileUploader)sender;
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Job.Progress = ((FileUploader)sender).Progress;
			}
			else if (e.PropertyName == nameof(fileUploader.FailureReason))
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
