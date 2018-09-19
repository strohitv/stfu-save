using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeJobUploader : INotifyPropertyChanged
	{
		private YoutubeVideoUploadInitializer initializer = null;
		private YoutubeVideoUploader videoUploader = null;
		private YoutubeThumbnailUploader thumbnailUploader = null;

		public InternalYoutubeJob Job { get; set; }

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

		internal YoutubeJobUploader(InternalYoutubeJob job)
		{
			Job = job;
			initializer = new YoutubeVideoUploadInitializer(Job);
			videoUploader = new YoutubeVideoUploader(Job);
			thumbnailUploader = new YoutubeThumbnailUploader(Job);
		}

		public async void UploadAsync()
		{
			State = RunningState.Running;
			Job.State = UploadState.Running;
			await Task.Run(() => Upload());
		}

		public void Upload()
		{
			initializer.InitializeUpload();

			if (initializer.Successful && CancelNotRequested())
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
			else
			{
				State = RunningState.NotRunning;
				Job.State = UploadState.Error;
			}
		}

		private bool TryUploadVideo()
		{
			bool finished = false;
			string result = null;

			bool uploadFinished = UploadVideo(out result);
			if (uploadFinished && State != RunningState.CancelPending)
			{
				Job.VideoId = JsonConvert.DeserializeObject<SerializableYoutubeVideo>(result).id;
				finished = thumbnailUploader.UploadThumbnail();
			}

			return finished;
		}

		private bool UploadVideo(out string result)
		{
			result = null;

			var successful = videoUploader.Upload();
			if (successful)
			{
				var movedPath = Path.GetDirectoryName(Job.Video.File.FullName)
					   + "\\_" + Path.GetFileNameWithoutExtension(Job.Video.File.FullName).Remove(0, 1)
					   + Path.GetExtension(Job.Video.File.FullName);
				File.Move(Job.Video.File.FullName, movedPath);
				result = videoUploader.Response;
			}

			return successful;
		}

		internal void Cancel()
		{
			if (State == RunningState.Running)
			{
				State = RunningState.CancelPending;
				videoUploader.Cancel();
				thumbnailUploader.Cancel();
			}
		}

		private static bool NotTooManyAttempts(int counter)
		{
			return counter < 4;
		}

		private bool CancelNotRequested()
		{
			return State != RunningState.CancelPending;
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
