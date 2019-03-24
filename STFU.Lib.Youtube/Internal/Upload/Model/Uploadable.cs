using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Internal.Upload.Model
{
	internal class Uploadable : INotifyPropertyChanged
	{
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

		private DateTime started;
		private TimeSpan uploadedDuration = new TimeSpan(0, 0, 0);
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

		public TimeSpan UploadedDuration
		{
			get
			{
				return uploadedDuration;
			}
			protected set
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
			protected set
			{
				if (remainingDuration != value)
				{
					remainingDuration = value;
					OnPropertyChanged();
				}
			}
		}

		private RunningState runningState = RunningState.NotRunning;
		public RunningState RunningState
		{
			get
			{
				return runningState;
			}
			protected set
			{
				if (runningState != value)
				{
					runningState = value;
					OnPropertyChanged();
				}
			}
		}

		private FailureReason failureReason = FailureReason.None;
		public FailureReason FailureReason
		{
			get
			{
				return failureReason;
			}

			protected set
			{
				failureReason = value;
				OnPropertyChanged();
			}
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion INofityPropertyChanged
	}
}
