using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;
using STFU.Lib.Youtube.Internal.Upload;

namespace STFU.Lib.Youtube.Internal
{
	internal class YoutubeJob : IYoutubeJob
	{
		private IYoutubeError error = null;
		private double progress = 0.0;
		private UploadState state = UploadState.NotStarted;

		private bool shouldBeSkipped = false;

		private TimeSpan uploadedDuration = new TimeSpan(0, 0, 0);
		private TimeSpan remainingDuration = new TimeSpan(0, 0, 0);

		public IYoutubeAccount Account { get; }

		public IYoutubeError Error
		{
			get
			{
				return error;
			}

			set
			{
				if (value != error)
				{
					error = value;
					OnPropertyChanged();
				}
			}
		}

		public double Progress
		{
			get
			{
				return progress;
			}

			set
			{
				if (value != progress)
				{
					progress = value;
					OnPropertyChanged();
				}
			}
		}

		public UploadState State
		{
			get
			{
				return state;
			}

			set
			{
				if (value != state)
				{
					var oldState = state;
					state = value;
					OnPropertyChanged();

					if (state == UploadState.VideoInitializing || oldState == UploadState.ThumbnailUploading
						|| oldState == UploadState.VideoUploading || state == UploadState.ThumbnailUploading
						|| state == UploadState.VideoUploading || state == UploadState.CancelPending 
						|| state == UploadState.Canceled)
					{
						OnPropertyChanged(nameof(IsUploading));
					}

					if (oldState == UploadState.Paused || state == UploadState.Paused)
					{
						OnPropertyChanged(nameof(IsUploadPaused));
					}
				}
			}
		}

		public bool IsUploading => State == UploadState.VideoUploading || State == UploadState.ThumbnailUploading;

		public TimeSpan UploadedDuration
		{
			get
			{
				return uploadedDuration;
			}
			set
			{
				if (uploadedDuration != value)
				{
					uploadedDuration = value;
					OnPropertyChanged();
				}
			}
		}

		public TimeSpan RemainingDuration
		{
			get
			{
				return remainingDuration;
			}
			set
			{
				if (remainingDuration != value)
				{
					remainingDuration = value;
					OnPropertyChanged();
				}
			}
		}

		public IYoutubeVideo Video { get; }

		public Uri Uri { get; set; }

		public string VideoId { get; set; }

		public bool IsUploadPaused => State == UploadState.Paused;

		public bool ShouldBeSkipped
		{
			get
			{
				return shouldBeSkipped;
			}

			set
			{
				if (value != shouldBeSkipped)
				{
					shouldBeSkipped = value;
					OnPropertyChanged();
				}
			}
		}

		private YoutubeJobUploader JobUploader { get; set; } = YoutubeJobUploader.EmptyUploader;

		internal YoutubeJob(IYoutubeVideo video, IYoutubeAccount account)
		{
			Account = account;
			Video = video;
		}

		public async void UploadAsync()
		{
			if (!ShouldBeSkipped && (JobUploader == null || !JobUploader.State.IsRunningOrInitializing()))
			{
				JobUploader = new YoutubeJobUploader(Video, Account);
				JobUploader.PropertyChanged += JobUploader_PropertyChanged;

				await JobUploader.UploadAsync();
			}
		}

		public async void ForceUploadAsync()
		{
			if (JobUploader == null || !JobUploader.State.IsRunningOrInitializing())
			{
				JobUploader = new YoutubeJobUploader(Video, Account);
				JobUploader.PropertyChanged += JobUploader_PropertyChanged;

				await JobUploader.UploadAsync();
			}
		}

		public async void CancelUploadAsync()
		{
			await InternalCancelUploadAsync();
		}

		private async Task InternalCancelUploadAsync()
		{
			await Task.Run(() => JobUploader.Cancel());
		}

		public async void PauseUploadAsync()
		{
			await Task.Run(() => JobUploader.Pause());
		}

		public async void ResumeUploadAsync()
		{
			await Task.Run(() => JobUploader.Resume());
		}

		public async void DeleteAsync()
		{
			await InternalCancelUploadAsync();

			OnShouldDelete();
		}

		private void JobUploader_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(JobUploader.State))
			{
				State = JobUploader.State;
			}
			else if (e.PropertyName == nameof(JobUploader.Progress))
			{
				Progress = JobUploader.Progress;
			}
			else if (e.PropertyName == nameof(JobUploader.RemainingDuration))
			{
				RemainingDuration = JobUploader.RemainingDuration;
			}
			else if (e.PropertyName == nameof(JobUploader.UploadedDuration))
			{
				UploadedDuration = JobUploader.UploadedDuration;
			}
			else if (e.PropertyName == nameof(JobUploader.VideoId))
			{
				VideoId = JobUploader.VideoId;
			}
			else if (e.PropertyName == nameof(JobUploader.Error))
			{
				Error = JobUploader.Error;
			}
		}

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;
		public event TriggerDeletionEventHandler TriggerDeletion;

		private void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private void OnShouldDelete()
		{
			TriggerDeletion?.Invoke(this, new EventArgs());
		}

		#endregion Events

		public override string ToString()
		{
			return Video?.ToString() ?? "kein Titel";
		}
	}
}
