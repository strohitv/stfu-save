﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;
using STFU.Lib.Youtube.Internal;
using STFU.Lib.Youtube.Internal.Upload;
using STFU.Lib.Youtube.Internal.Upload.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeJob : IYoutubeJob
	{
		private IYoutubeError error = null;
		private double progress = 0.0;
		private UploadProgress state = UploadProgress.NotRunning;
		private UploadObject currentObject = UploadObject.Nothing;

		private bool shouldBeSkipped = false;

		public event JobFinishedEventHandler UploadCompletedAction;

		private String currentSpeed = String.Empty;
		private TimeSpan uploadedDuration = new TimeSpan(0, 0, 0);
		private TimeSpan remainingDuration = new TimeSpan(0, 0, 0);

		public IYoutubeAccount Account { get; set; }

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

		public UploadProgress State
		{
			get
			{
				return state;
			}

			set
			{
				if (value != state)
				{
					state = value;
					OnPropertyChanged();
				}
			}
		}

		public UploadObject CurrentObject
		{
			get
			{
				return currentObject;
			}
			set
			{
				if (value != currentObject)
				{
					currentObject = value;
					OnPropertyChanged();
				}
			}
		}

		public String CurrentSpeed
		{
			get
			{
				return currentSpeed;
			}
			set
			{
				if (currentSpeed != value)
				{
					currentSpeed = value;
					OnPropertyChanged();
				}
			}
		}

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

		public bool CleanUpSucceeded { get; private set; }

		private Queue<IUploadStep> Steps { get; } = new Queue<IUploadStep>();

		private IUploadStep RunningStep { get; set; }

		public bool IsInEditMode { get; private set; } = false;

		public YoutubeJob(IYoutubeVideo video, IYoutubeAccount account)
		{
			Account = account;
			Video = video;
		}

		[JsonConstructor]
		public YoutubeJob(YoutubeVideo video, YoutubeAccount account, YoutubeError error)
			: this (video, account)
		{
			Error = error;
		}

		public void StartUpload()
		{
			if (!ShouldBeSkipped && RunningStep == null)
			{
				if (Steps.Count == 0)
				{
					Steps.Enqueue(new YoutubeVideoUploadInitializer(Video, Account));
					Steps.Enqueue(new YoutubeVideoUploader(Video, Account, UploadedDuration));

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
				if (RunningStep == null || RunningStep.State == UploadStepState.Successful)
				{
					if (RunningStep != null)
					{
						RunningStep.PropertyChanged -= RunningStep_PropertyChanged;
					}

					if (Steps.Count > 0)
					{
						RunningStep = Steps.Dequeue();
						RunningStep.PropertyChanged += RunningStep_PropertyChanged;
						try
						{
							await RunningStep.RunAsync();
						}
						catch (Exception ex)
						{
							// Just survive!
							// TODO: Besser machen...
							State = UploadProgress.Failed;

							if (ex is WebException)
							{
								Error = FailReasonConverter.GetError(FailureReason.SendError);
							}
							else
							{
								Error = FailReasonConverter.GetError(FailureReason.Unknown);
							}
						}
					}
				}
				else
				{
					if (RunningStep.State == UploadStepState.PausePending
						|| RunningStep.State == UploadStepState.Paused)
					{
						try
						{
							RunningStep.Resume();
						}
						catch (Exception ex)
						{
							// Just survive!
							// TODO: Besser machen...
							State = UploadProgress.Failed;

							if (ex is WebException)
							{
								Error = FailReasonConverter.GetError(FailureReason.SendError);
							}
							else
							{
								Error = FailReasonConverter.GetError(FailureReason.Unknown);
							}
						}
					}
					else
					{
						try
						{
							await RunningStep.RunAsync();
						}
						catch (Exception ex)
						{
							// Just survive!
							// TODO: Besser machen...
							State = UploadProgress.Failed;

							if (ex is WebException)
							{
								Error = FailReasonConverter.GetError(FailureReason.SendError);
							}
							else
							{
								Error = FailReasonConverter.GetError(FailureReason.Unknown);
							}
						}
					}
				}
			}
		}

		private bool StepIsNotRunning()
		{
			return RunningStep != null
				&& RunningStep.State != UploadStepState.Initializing
				&& RunningStep.State != UploadStepState.Running
				&& RunningStep.State != UploadStepState.CancelPending
				&& RunningStep.State != UploadStepState.PausePending
				&& RunningStep.State != UploadStepState.Paused
				&& RunningStep.State != UploadStepState.Broke;
		}

		public void ForceUploadAsync()
		{
			RunningStep = null;

			Steps.Clear();

			Steps.Enqueue(new YoutubeVideoUploadInitializer(Video, Account));
			Steps.Enqueue(new YoutubeVideoUploader(Video, Account));

			if (!string.IsNullOrWhiteSpace(Video.ThumbnailPath))
			{
				Steps.Enqueue(new YoutubeThumbnailUploader(Video, Account));
			}

			CleanUpSucceeded = false;

			try
			{
				StartFirstStepAsync();
			}
			catch (Exception)
			{ }
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
			else
			{
				ForceUploadAsync();
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
				SetState(RunningStep);

				if (RunningStep.State == UploadStepState.Successful && State == UploadProgress.Running)
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
			else if (e.PropertyName == nameof(RunningStep.CurrentSpeed))
			{
				CurrentSpeed = RunningStep.CurrentSpeed;
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

		private void SetState(IUploadStep step)
		{
			switch (step.State)
			{
				case UploadStepState.NotRunning:
					if (!Steps.Any())
					{
						State = UploadProgress.NotRunning;
						CurrentObject = UploadObject.Nothing;
					}
					break;
				case UploadStepState.Initializing:
				case UploadStepState.Running:
					if (step is YoutubeVideoUploadInitializer || step is YoutubeVideoUploader || step is YoutubeVideoInformationChanger)
					{
						CurrentObject = UploadObject.Video;
					}
					else if (step is YoutubeThumbnailUploader)
					{
						CurrentObject = UploadObject.Thumbnail;
					}
					State = UploadProgress.Running;
					break;
				case UploadStepState.Successful:
					if (!Steps.Any())
					{
						if (!CleanUpSucceeded)
						{
							UploadCompletedAction?.Invoke(new JobFinishedEventArgs(this));
							CleanUpSucceeded = true;
						}

						State = UploadProgress.Successful;
						CurrentObject = UploadObject.Nothing;
					}
					else if (IsInEditMode)
					{
						State = UploadProgress.Paused;
					}
					else if (State == UploadProgress.PausePending)
					{
						State = UploadProgress.Paused;
					}
					else if (State == UploadProgress.CancelPending)
					{
						State = UploadProgress.Canceled;
						Steps.Clear();
					}
					break;
				case UploadStepState.Error:
					State = UploadProgress.Failed;
					Steps.Clear();
					break;
				case UploadStepState.CancelPending:
					State = UploadProgress.CancelPending;
					break;
				case UploadStepState.Canceled:
					State = UploadProgress.Canceled;
					break;
				case UploadStepState.PausePending:
					State = UploadProgress.PausePending;
					break;
				case UploadStepState.Paused:
					State = UploadProgress.Paused;
					break;
				case UploadStepState.Broke:
					State = UploadProgress.Broke;
					break;
				default:
					throw new InvalidEnumArgumentException("Dieses Feld existiert nicht.");
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

			if (State != UploadProgress.NotRunning && State != UploadProgress.Canceled && State != UploadProgress.Failed)
			{
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

		public void SetPaused()
		{
			State = UploadProgress.Paused;
		}

		public void Reset()
		{
			State = UploadProgress.NotRunning;
			CleanUpSucceeded = false;
		}
	}
}
