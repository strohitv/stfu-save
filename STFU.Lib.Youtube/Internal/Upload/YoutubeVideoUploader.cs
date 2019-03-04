using System;
using System.ComponentModel;
using System.Net;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Upload.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoUploader : Uploadable, INotifyPropertyChanged
	{
		FileUploader fileUploader = new FileUploader();

		internal string Response { get; private set; }

		internal YoutubeVideoUploader(IYoutubeVideo video, IYoutubeAccount account, Uri uploadUri)
		{
			Video = video;
			Account = account;
			UploadUri = uploadUri;

			fileUploader.PropertyChanged += OnUploadProgressChanged;
		}

		internal bool Upload()
		{
			var lastbyte = CheckUploadStatus();

			HttpWebRequest request = null;
			if (lastbyte == -1)
			{
				request = HttpWebRequestCreator.CreateForNewUpload(UploadUri, Video, Account);
			}
			else
			{
				request = HttpWebRequestCreator.CreateForResumeUpload(UploadUri, Video, Account, lastbyte);
			}

			State = UploadState.VideoUploading;

			bool successful = fileUploader.UploadFile(Video.Path, request, (long)128 * 1000 * 1000 * 1000, lastbyte);

			if (successful)
			{
				request.Headers.Set("Authorization", $"Bearer {Account.GetActiveToken()}");
				Response = WebService.Communicate(request);
				State = UploadState.VideoUploaded;
			}
			else if (State == UploadState.CancelPending)
			{
				State = UploadState.Canceled;
			}
			else if (State != UploadState.Paused)
			{
				State = UploadState.VideoError;
			}

			return successful;
		}

		private void OnUploadProgressChanged(object sender, PropertyChangedEventArgs e)
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
				State = UploadState.VideoError;
			}
			else if (e.PropertyName == nameof(fileUploader.RunningState))
			{
				if (fileUploader.RunningState == RunningState.Paused)
				{
					State = UploadState.Paused;
				}
				else if (fileUploader.RunningState == RunningState.Running 
					&& State.IsPausingOrPaused())
				{
					State = UploadState.VideoUploading;
				}
			}
		}

		internal long CheckUploadStatus()
		{
			var request = HttpWebRequestCreator.CreateWithAuthHeader(UploadUri.AbsoluteUri, "PUT", Account.GetActiveToken());
			request.ContentLength = 0;
			request.Headers.Add($"content-range: bytes */{Video.File.Length}");

			var answer = WebService.Communicate(request);
			if (answer == null)
			{
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

		internal void Cancel()
		{
			if (State.IsRunningOrInitializing())
			{
				State = UploadState.CancelPending;
				fileUploader.Cancel();
			}
		}

		internal void Pause()
		{
			if (State.IsRunningOrInitializing())
			{
				State = UploadState.PausePending;
				fileUploader.Pause();
			}
		}

		internal void Resume()
		{
			if (State.IsPausingOrPaused())
			{
				fileUploader.Resume(); 
			}
		}
	}
}
