using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;
using STFU.Lib.Youtube.Interfaces.Model.Handler;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Upload.Steps;

namespace STFU.Lib.Youtube.Upload
{
	public class YoutubeJob : IYoutubeJob
	{
		public IYoutubeVideo Video { get; set; }

		public IYoutubeAccount Account { get; set; }

		private JobState state = JobState.NotStarted;
		public JobState State
		{
			get
			{
				return state;
			}
			set
			{
				if (state != value)
				{
					state = value;
					OnPropertyChanged();
				}
			}
		}

		private bool shouldBeSkipped = false;
		public bool ShouldBeSkipped
		{
			get
			{
				return shouldBeSkipped;
			}
			set
			{
				if (shouldBeSkipped != value)
				{
					shouldBeSkipped = value;
					OnPropertyChanged();
				}
			}
		}

		private IYoutubeError error;

		public IYoutubeError Error
		{
			get
			{
				return error;
			}
			set
			{
				if (error != value)
				{
					error = value;
					OnPropertyChanged();
				}
			}
		}

		// Das gehört eigentlich zum Job
		[JsonConverter(typeof(ConcreteTypeConverter<NotificationSettings>))]
		public INotificationSettings NotificationSettings { get; set; } = new NotificationSettings() { };

		// TODO: Step-Gedöns muss vermutlich vom UploadStatus weg, da der JobUploader eig. die Stepverwaltung ist (?)
		// Frage: Wie benachrichtige ich die GUI dann über den aktuellen Schritt? Enum?
		public UploadStatus UploadStatus { get; set; } = new UploadStatus();

		private JobUploader JobUploader { get; }

		public YoutubeJob(IYoutubeVideo video, IYoutubeAccount account, UploadStatus uploadStatus)
		{
			Video = video;
			Account = account;
			UploadStatus = uploadStatus;

			JobUploader = new JobUploader(this);
			JobUploader.StateChanged += JobUploaderStateChanged;
		}

		[JsonConstructor]
		public YoutubeJob(YoutubeVideo video, YoutubeAccount account, YoutubeError error, UploadStatus uploadStatus)
			: this(video, account, uploadStatus)
		{
			Error = error;
		}

		private void JobUploaderStateChanged(object sender, UploaderStateChangedEventArgs e)
		{
			State = e.NewState;

			if (State == JobState.Successful)
			{
				UploadCompletedAction?.Invoke(new JobFinishedEventArgs(this));
			}
		}

		public void Run()
		{
			JobUploader.Run();
		}

		public void Pause()
		{
			UploadStatus.CurrentStep.Cancel();
			State = JobState.Paused;
		}

		public void Resume()
		{
			UploadStatus.CurrentStep.RunAsync();
			State = JobState.Running;
		}

		public void Cancel()
		{
			JobUploader.Reset();
			State = JobState.Canceled;
		}

		public void Reset()
		{
			JobUploader.Reset();
		}

		public void Delete()
		{
			JobUploader.Reset();

			TriggerDeletion?.Invoke(this, new EventArgs());
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public event JobFinishedEventHandler UploadCompletedAction;
		public event TriggerDeletionEventHandler TriggerDeletion;

		private void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public void RefreshDurationAndSpeed()
		{
			UploadStatus.CurrentStep?.RefreshDurationAndSpeed();
		}
	}
}
