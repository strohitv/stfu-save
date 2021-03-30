using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public class UploadStatus : INotifyPropertyChanged
	{
		private double progress = 0.0;
		private long currentSpeed = 0;

		private DateTime started = default(DateTime);
		private DateTime finished = default(DateTime);
		private TimeSpan uploadedDuration = default(TimeSpan);
		private TimeSpan remainingDuration = default(TimeSpan);

		private Uri uploadAddress;
		private long lastByte = 0;

		private IUploadStep currentStep = default(IUploadStep);
		private Type currentStepType = typeof(IUploadStep);

		private JobState state = JobState.NotStarted;

		private bool quotaReached = false;
		private TimeSpan waitTime = default(TimeSpan);

		public double Progress
		{
			get
			{
				if (CurrentStep != null)
				{
					progress = CurrentStep.Progress;
				}
				return progress;
			}
			set
			{
				progress = value;
				OnPropertyChanged();
			}
		}

		public long CurrentSpeed
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
				CurrentStepType = currentStep?.GetType() ?? null;
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

		public JobState State
		{
			get { return state; }
			private set
			{
				state = value;
				OnPropertyChanged();
			}
		}

		[JsonIgnore]
		public bool QuotaReached
		{
			get { return quotaReached; }
			set
			{
				quotaReached = value;
				OnPropertyChanged();
			}
		}

		[JsonIgnore]
		public TimeSpan WaitTime
		{
			get { return waitTime; }
			set
			{
				waitTime = value;
				OnPropertyChanged();
			}
		}

		public void Reset()
		{
			Progress = 0;
			CurrentSpeed = 0;
			State = JobState.NotStarted;
			QuotaReached = false;
			WaitTime = default(TimeSpan);
			LastByte = 0;
			UploadedDuration = RemainingDuration = default(TimeSpan);
			Started = Finished = default(DateTime);
			UploadAddress = null;
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
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
