using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Upload.Steps;

namespace STFU.Lib.Youtube.Upload
{
	public class UploadStatus : INotifyPropertyChanged
	{
		private double progress = 0.0;
		private double currentSpeed = 0.0;

		private DateTime started = default(DateTime);
		private DateTime finished = default(DateTime);
		private TimeSpan uploadedDuration = default(TimeSpan);
		private TimeSpan remainingDuration = default(TimeSpan);

		private Uri uploadAddress;
		private long lastByte = 0;

		private IUploadStep currentStep = default(IUploadStep);
		private Type currentStepType = typeof(IUploadStep);

		private UploadState state = UploadState.NotStarted;

		public double Progress
		{
			get { return progress; }
			set
			{
				progress = value;
				OnPropertyChanged();
			}
		}

		public double CurrentSpeed
		{
			get { return currentSpeed; }
			set
			{
				currentSpeed = value;
				OnPropertyChanged();
			}
		}

		public DateTime Started
		{
			get { return started; }
			set
			{
				started = value;
				OnPropertyChanged();
			}
		}

		public DateTime Finished
		{
			get { return finished; }
			set
			{
				finished = value;
				OnPropertyChanged();
			}
		}

		public TimeSpan UploadedDuration
		{
			get { return uploadedDuration; }
			set
			{
				uploadedDuration = value;
				OnPropertyChanged();
			}
		}

		public TimeSpan RemainingDuration
		{
			get { return remainingDuration; }
			set
			{
				remainingDuration = value;
				OnPropertyChanged();
			}
		}

		public Uri UploadAddress
		{
			get { return uploadAddress; }
			set
			{
				uploadAddress = value;
				OnPropertyChanged();
			}
		}

		public long LastByte
		{
			get { return lastByte; }
			set
			{
				lastByte = value;
				OnPropertyChanged();
			}
		}

		[JsonIgnore]
		public IUploadStep CurrentStep
		{
			get { return currentStep; }
			set
			{
				currentStep = value;
				OnPropertyChanged();
				CurrentStepType = currentStep.GetType();
			}
		}

		[JsonIgnore]
		public Type CurrentStepType
		{
			get { return currentStepType; }
			private set
			{
				currentStepType = value;
				OnPropertyChanged();
			}
		}

		public UploadState State
		{
			get { return state; }
			private set
			{
				state = value;
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
