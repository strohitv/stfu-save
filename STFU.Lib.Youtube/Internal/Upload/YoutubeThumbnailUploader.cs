using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Upload.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeThumbnailUploader : UploadStep
	{
		private FileUploader fileUploader = new FileUploader();

		internal YoutubeThumbnailUploader(IYoutubeVideo video, IYoutubeAccount account)
			: base(video, account)
		{
			fileUploader.PropertyChanged += FileUploaderPropertyChanged;
		}

		public override async Task RunAsync()
		{
			await Task.Run(() => Run());
		}

		public void Run()
		{
			State = UploadStepState.Initializing;

			if (File.Exists(Video.ThumbnailPath))
			{
				State = UploadStepState.Running;

				var accessToken = Account.GetActiveToken();
				var secret = Account.Access.First(a => a.AccessToken == accessToken).Client.Secret;

				var request = HttpWebRequestCreator.CreateWithAuthHeader(
					$"https://www.googleapis.com/upload/youtube/v3/thumbnails/set?videoId={Video.Id}&key={secret}",
					"POST", accessToken);

				FileInfo file = new FileInfo(Video.ThumbnailPath);
				request.ContentLength = file.Length;
				request.ContentType = MimeMapping.GetMimeMapping(Video.ThumbnailPath);

				var successful = fileUploader.UploadFile(Video.ThumbnailPath, request);
				if (successful)
				{
					request.Headers.Set("Authorization", $"Bearer {Account.GetActiveToken()}");
					var thumbnailResource = WebService.Communicate(request);
					State = UploadStepState.Successful;
					Video.IsThumbnailDirty = false;
				}
				else if (State == UploadStepState.CancelPending)
				{
					State = UploadStepState.Canceled;
				}
				else if (State != UploadStepState.Paused)
				{
					Error = FailReasonConverter.GetError(fileUploader.FailureReason);
					State = UploadStepState.Error;
				}
			}
			else
			{
				State = UploadStepState.Successful;
			}
		}

		public override void Cancel()
		{
			if (State == UploadStepState.Initializing || State == UploadStepState.Running)
			{
				State = UploadStepState.CancelPending;
				fileUploader.Cancel();
			}
		}

		private void FileUploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Progress = fileUploader.Progress;
			}
			else if (e.PropertyName == nameof(fileUploader.CurrentSpeed))
			{
				CurrentSpeed = fileUploader.CurrentSpeed;
			}
			else if (e.PropertyName == nameof(fileUploader.RemainingDuration))
			{
				RemainingDuration = fileUploader.RemainingDuration;
			}
			else if (e.PropertyName == nameof(fileUploader.UploadedDuration))
			{
				CurrentDuration = fileUploader.UploadedDuration;
			}
			else if (e.PropertyName == nameof(fileUploader.FailureReason))
			{
				Error = FailReasonConverter.GetError(fileUploader.FailureReason);
				State = UploadStepState.Error;
			}
			else if (e.PropertyName == nameof(fileUploader.RunningState))
			{
				if (fileUploader.RunningState == RunningState.Paused)
				{
					State = UploadStepState.Paused;
				}
				else if (fileUploader.RunningState == RunningState.Running
					&& (State == UploadStepState.PausePending || State == UploadStepState.Paused))
				{
					State = UploadStepState.Running;
				}
			}
		}

		public override void Pause()
		{
			if (State == UploadStepState.Initializing || State == UploadStepState.Running)
			{
				State = UploadStepState.PausePending;
				fileUploader.Pause();
			}
		}

		public override void Resume()
		{
			if (State == UploadStepState.PausePending || State == UploadStepState.Paused)
			{
				fileUploader.SetSateToRunning();
				Run();
			}
		}
	}
}
