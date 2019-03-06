using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Internal.Upload.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal abstract class UploadStep : IUploadStep
	{
		public IYoutubeVideo Video { get; }

		public IYoutubeAccount Account { get; }

		private double progress = 0.0;
		public double Progress
		{
			get
			{
				return progress;
			}
			protected set
			{
				if (progress != value)
				{
					progress = value;
					OnPropertyChanged();
				}
			}
		}

		private UploadStepState state = UploadStepState.NotRunning;
		public UploadStepState State
		{
			get
			{
				return state;
			}
			protected set
			{
				if (state != value)
				{
					state = value;
					OnPropertyChanged();
				}
			}
		}

		private IYoutubeError error = null;
		public IYoutubeError Error
		{
			get
			{
				return error;
			}
			protected set
			{
				if (error != value)
				{
					error = value;
					OnPropertyChanged();
				}
			}
		}

		private DateTime started;
		private TimeSpan currentDuration = new TimeSpan(0, 0, 0);
		private TimeSpan remainingDuration = new TimeSpan(0, 0, 0);

		public DateTime Started
		{
			get
			{
				return started;
			}
			protected set
			{
				if (started != value)
				{
					started = value;
					OnPropertyChanged();
				}
			}
		}

		public TimeSpan CurrentDuration
		{
			get
			{
				return currentDuration;
			}
			protected set
			{
				if (currentDuration != value)
				{
					currentDuration = value;
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
			protected set
			{
				if (remainingDuration != value)
				{
					remainingDuration = value;
					OnPropertyChanged();
				}
			}
		}

		public UploadStep(IYoutubeVideo video, IYoutubeAccount account)
		{
			Video = video;
			Account = account;
		}

		public abstract Task RunAsync();

		public abstract void Cancel();

		public abstract void Pause();

		public abstract void Resume();

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion INofityPropertyChanged
	}
}
