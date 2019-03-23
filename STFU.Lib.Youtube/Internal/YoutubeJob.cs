using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;
using STFU.Lib.Youtube.Internal.Upload;
using STFU.Lib.Youtube.Internal.Upload.Model;

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

		private Queue<IUploadStep> Steps { get; } = new Queue<IUploadStep>();

		private IUploadStep RunningStep { get; set; }

		public bool IsInEditMode { get; private set; }

		private bool RefreshVideoInfosOnYoutube { get; set; }

		internal YoutubeJob(IYoutubeVideo video, IYoutubeAccount account)
		{
			Account = account;
			Video = video;
		}

		public void StartUpload()
		{
			if (!ShouldBeSkipped && RunningStep == null)
			{
				if (Steps.Count == 0)
				{
					Steps.Enqueue(new YoutubeVideoUploadInitializer(Video, Account));
					Steps.Enqueue(new YoutubeVideoUploader(Video, Account));

					if (!string.IsNullOrWhiteSpace(Video.ThumbnailPath))
					{
						Steps.Enqueue(new YoutubeThumbnailUploader(Video, Account));
					}
				}

				try
				{
					StartFirstStepAsync();
				}
				catch (Exception)
				{ }
			}
		}

		private async void StartFirstStepAsync()
		{
			if ((Steps.Count > 0 && RunningStep == null) || StepIsNotRunning())
			{
				if (RunningStep == null)
				{
					RunningStep = Steps.Dequeue();
					RunningStep.PropertyChanged += RunningStep_PropertyChanged;
				}

				await RunningStep.RunAsync();
			}
		}

		private bool StepIsNotRunning()
		{
			return RunningStep != null
				&& RunningStep.State != UploadStepState.Initializing
				&& RunningStep.State != UploadStepState.Running
				&& RunningStep.State != UploadStepState.CancelPending
				&& RunningStep.State != UploadStepState.PausePending
				&& RunningStep.State != UploadStepState.PausePending;
		}

		public void ForceUploadAsync()
		{
			if (RunningStep == null)
			{
				if (Steps.Count == 0)
				{
					Steps.Enqueue(new YoutubeVideoUploadInitializer(Video, Account));
					Steps.Enqueue(new YoutubeVideoUploader(Video, Account));

					if (!string.IsNullOrWhiteSpace(Video.ThumbnailPath))
					{
						Steps.Enqueue(new YoutubeThumbnailUploader(Video, Account));
					}
				}

				try
				{
					StartFirstStepAsync();
				}
				catch (Exception)
				{ }
			}
		}

		public async void CancelUploadAsync()
		{
			await InternalCancelUploadAsync();
		}

		private async Task InternalCancelUploadAsync()
		{
			if (RunningStep != null)
			{
				await Task.Run(() => RunningStep.Cancel());
			}
		}

		public async void PauseUploadAsync()
		{
			if (RunningStep != null)
			{
				await Task.Run(() => RunningStep.Pause());
			}
		}

		public async void ResumeUploadAsync()
		{
			if (RunningStep != null)
			{
				await Task.Run(() => RunningStep.Resume());
			}
		}

		public async void DeleteAsync()
		{
			await InternalCancelUploadAsync();

			OnShouldDelete();
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

		#region Runningstep Property changed

		private void RunningStep_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(RunningStep.State))
			{
				SetState(RunningStep.State, RunningStep);

				if (RunningStep.State == UploadStepState.Successful)
				{
					RunningStep.PropertyChanged -= RunningStep_PropertyChanged;
					RunningStep = null;

					if (Steps.Count > 0)
					{
						StartFirstStepAsync();
					}
				}
			}
			else if (e.PropertyName == nameof(RunningStep.Progress))
			{
				Progress = RunningStep.Progress;
			}
			else if (e.PropertyName == nameof(RunningStep.RemainingDuration))
			{
				RemainingDuration = RunningStep.RemainingDuration;
			}
			else if (e.PropertyName == nameof(RunningStep.CurrentDuration))
			{
				UploadedDuration = RunningStep.CurrentDuration;
			}
			else if (e.PropertyName == nameof(RunningStep.Error))
			{
				Error = RunningStep.Error;
			}
		}

		private void SetState(UploadStepState state, IUploadStep step)
		{
			switch (state)
			{
				case UploadStepState.NotRunning:
					State = UploadState.NotStarted;
					break;
				case UploadStepState.Initializing:
					if (step is YoutubeVideoUploadInitializer || step is YoutubeVideoUploader)
					{
						State = UploadState.VideoInitializing;
					}
					else if (step is YoutubeThumbnailUploader)
					{
						State = UploadState.ThumbnailUploading;
					}
					break;
				case UploadStepState.Running:
					if (step is YoutubeVideoUploadInitializer)
					{
						State = UploadState.VideoInitializing;
					}
					else if (step is YoutubeVideoUploader)
					{
						State = UploadState.VideoUploading;
					}
					else if (step is YoutubeThumbnailUploader)
					{
						State = UploadState.ThumbnailUploading;
					}
					break;
				case UploadStepState.Successful:
					if (step is YoutubeVideoUploadInitializer)
					{
						State = UploadState.VideoInitializing;
					}
					else if (step is YoutubeVideoUploader)
					{
						State = UploadState.VideoUploaded;
					}
					else if (step is YoutubeThumbnailUploader)
					{
						State = UploadState.Successful;
					}
					break;
				case UploadStepState.Error:
					if (step is YoutubeVideoUploadInitializer || step is YoutubeVideoUploader)
					{
						State = UploadState.VideoError;
					}
					else if (step is YoutubeThumbnailUploader)
					{
						State = UploadState.ThumbnailError;
					}
					break;
				case UploadStepState.CancelPending:
					State = UploadState.CancelPending;
					break;
				case UploadStepState.Canceled:
					State = UploadState.Canceled;
					break;
				case UploadStepState.PausePending:
					State = UploadState.PausePending;
					break;
				case UploadStepState.Paused:
					State = UploadState.Paused;
					break;
				default:
					throw new ArgumentException($"Der gewünschte Status {state} wird nicht unterstützt.");
			}
		}

		#endregion Runningstep Property changed

		public override string ToString()
		{
			return Video?.ToString() ?? "kein Titel";
		}

		public void BeginEdit()
		{
			IsInEditMode = true;
		}

		public void FinishEdit()
		{
			IsInEditMode = false;

			if (Video.IsDirty && !Steps.Any(s => s is YoutubeVideoInformationChanger))
			{
				Steps.Enqueue(new YoutubeVideoInformationChanger(Video, Account));
			}

			if (Video.IsThumbnailDirty && !Steps.Any(s => s is YoutubeThumbnailUploader))
			{
				Steps.Enqueue(new YoutubeThumbnailUploader(Video, Account));
			}

			StartFirstStepAsync();
		}
	}
}
