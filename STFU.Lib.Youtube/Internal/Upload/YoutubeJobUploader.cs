using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Upload.Model;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeJobUploader : Uploadable, INotifyPropertyChanged
	{
		internal static YoutubeJobUploader EmptyUploader { get; } = new YoutubeJobUploader();

		public string VideoId { get; set; } = string.Empty;

		private YoutubeVideoUploadInitializer initializer = null;
		private YoutubeVideoUploader videoUploader = null;
		private YoutubeThumbnailUploader thumbnailUploader = null;

		private bool IsEmpty { get; set; } = false;

		private YoutubeJobUploader()
		{
			IsEmpty = true;
		}

		internal YoutubeJobUploader(IYoutubeVideo video, IYoutubeAccount account)
		{
			Video = video;
			Account = account;

			initializer = new YoutubeVideoUploadInitializer(video, account);
		}

		internal async Task UploadAsync()
		{
			State = UploadState.VideoInitializing;

			await Task.Run(() => Upload());
		}

		private void Upload()
		{
			initializer?.InitializeUpload();

			if (initializer != null && initializer.Successful && CancelNotRequested())
			{
				UploadUri = initializer.VideoUploadUri;

				videoUploader = new YoutubeVideoUploader(Video, Account, UploadUri);
				videoUploader.PropertyChanged += Uploader_PropertyChanged;

				UploadVideo();
			}
			else
			{
				Error = initializer.Error;
				State = UploadState.VideoError;
			}
		}

		private void Uploader_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var notifier = (Uploadable)sender;

			if (e.PropertyName == nameof(notifier.State))
			{
				State = notifier.State;
			}
			else if (e.PropertyName == nameof(notifier.Progress))
			{
				Progress = notifier.Progress;
			}
			else if (e.PropertyName == nameof(notifier.FailureReason))
			{
				Error = FailReasonConverter.GetError(notifier.FailureReason);

				if (sender is YoutubeThumbnailUploader)
				{
					State = UploadState.ThumbnailError;
				}
				else
				{
					State = UploadState.VideoError;
				}
			}
			else if (e.PropertyName == nameof(notifier.Error))
			{
				Error = notifier.Error;
			}
			else if (e.PropertyName == nameof(notifier.RemainingDuration))
			{
				RemainingDuration = notifier.RemainingDuration;
			}
			else if (e.PropertyName == nameof(notifier.Started))
			{
				Started = notifier.Started;
			}
			else if (e.PropertyName == nameof(notifier.UploadedDuration))
			{
				UploadedDuration = notifier.UploadedDuration;
			}
		}

		private void UploadVideo()
		{
			int uploadUnsuccessfulCounter = 0;
			while (CancelNotRequested() && NotTooManyAttempts(uploadUnsuccessfulCounter))
			{
				bool uploadSuccessful = TryUploadVideo();
				if (uploadSuccessful)
				{
					State = UploadState.Successful;
					break;
				}
				else if (State.IsPausingOrPaused())
				{
					break;
				}

				uploadUnsuccessfulCounter++;
				Thread.Sleep(new TimeSpan(0, 0, 1));
			}
		}

		private bool TryUploadVideo()
		{
			bool finished = false;
			string result = null;

			bool uploadFinished = UploadVideoAndMoveFile(out result);
			if (uploadFinished && State != UploadState.Canceled && State != UploadState.Paused && result != null)
			{
				VideoId = JsonConvert.DeserializeObject<SerializableYoutubeVideo>(result).id;
				videoUploader.PropertyChanged -= Uploader_PropertyChanged;

				thumbnailUploader = new YoutubeThumbnailUploader(Video, VideoId, Account);
				thumbnailUploader.PropertyChanged += Uploader_PropertyChanged;

				finished = thumbnailUploader.UploadThumbnail();

				thumbnailUploader.PropertyChanged -= Uploader_PropertyChanged;

				if (finished)
				{
					State = UploadState.Successful;
				}
			}

			return finished;
		}

		private bool UploadVideoAndMoveFile(out string result)
		{
			result = null;

			var successful = videoUploader.Upload();
			if (successful)
			{
				var movedPath = Path.GetDirectoryName(Video.File.FullName)
					   + "\\_" + Path.GetFileNameWithoutExtension(Video.File.FullName).Remove(0, 1)
					   + Path.GetExtension(Video.File.FullName);
				File.Move(Video.File.FullName, movedPath);
				result = videoUploader.Response;
			}

			return successful;
		}

		internal void Cancel()
		{
			if (State.IsRunningOrInitializing())
			{
				State = UploadState.CancelPending;

				if (videoUploader != null && videoUploader.State.IsRunningOrInitializing() && !videoUploader.State.IsPausingOrPaused())
				{
					videoUploader.Cancel();
				}
				else if (thumbnailUploader != null && thumbnailUploader.State.IsRunningOrInitializing() && !thumbnailUploader.State.IsPausingOrPaused())
				{
					thumbnailUploader.Cancel();
				}
				else
				{
					State = UploadState.Canceled;
				}
			}
		}

		private UploadState oldState = UploadState.NotStarted;
		internal void Pause()
		{
			if (State.IsRunningOrInitializing())
			{
				oldState = State;
				State = UploadState.PausePending;

				if (videoUploader != null)
				{
					videoUploader.Pause();
				}

				if (thumbnailUploader != null)
				{
					thumbnailUploader.Pause();
				}
			}
		}

		internal void Resume()
		{
			if (State.IsRunningOrInitializing())
			{
				if (videoUploader != null && oldState.IsVideo())
				{
					UploadVideo();
				}

				if (thumbnailUploader != null && oldState.IsThumbnail())
				{
					thumbnailUploader.Resume();
				}
			}
		}

		private static bool NotTooManyAttempts(int counter)
		{
			return counter < 4;
		}

		private bool CancelNotRequested()
		{
			return !State.IsCanceled() || State == UploadState.CancelPending;
		}
	}
}
