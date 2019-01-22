using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class FileUploader : INotifyPropertyChanged
	{
		private double progress = 0.0;
		internal double Progress
		{
			get
			{
				return progress;
			}
			private set
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

		public TimeSpan UploadedDuration
		{
			get
			{
				return uploadedDuration;
			}
			private set
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
			private set
			{
				if (remainingDuration != value)
				{
					remainingDuration = value;
					OnPropertyChanged();
				}
			}
		}

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

		private FailureReason failureReason = FailureReason.None;
		internal FailureReason FailureReason
		{
			get
			{
				return failureReason;
			}

			set
			{
				failureReason = value;
				OnPropertyChanged();
			}
		}

		internal FileUploader() { }

		internal bool UploadFile(string path, HttpWebRequest request)
		{
			return UploadFile(path, request, (long)128 * 1000 * 1000 * 1000, 0);
		}

		internal bool UploadFile(string path, HttpWebRequest request, long maxFileSize, long startPosition)
		{
			if (File.Exists(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

				if (fileStream.Length > maxFileSize)
				{
					FailureReason = FailureReason.FileTooBig;
					return false;
				}

				if (startPosition > 0)
				{
					fileStream.Position = startPosition;
				}

				started = DateTime.Now;
				State = RunningState.Running;

				// Upload initiieren
				Stream requestStream = request.GetRequestStream();
				byte[] buffer = new byte[128 * 1024];
				int bytesRead = 0;

				try
				{
					// Hochladen
					while (State != RunningState.CancelPending && (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
					{
						requestStream.Write(buffer, 0, bytesRead);
						Progress = fileStream.Position / (double)fileStream.Length * 100;

						UploadedDuration = DateTime.Now - started;
						RemainingDuration = new TimeSpan(0 , 0, (int)(UploadedDuration.TotalSeconds / Progress * 100));
					}
				}
				catch (WebException)
				{
					requestStream.Close();
					FailureReason = FailureReason.SendError;
					return false;
				}
				catch (IOException)
				{
					requestStream.Close();
					FailureReason = FailureReason.ReadError;
					return false;
				}

				fileStream.Close();

				try
				{
					requestStream.Close();
					Progress = 100.0;
				}
				catch (WebException)
				{
					FailureReason = FailureReason.Unknown;
					return false;
				}

				var result = State != RunningState.CancelPending;
				State = RunningState.NotRunning;
				return result;
			}
			else
			{
				FailureReason = FailureReason.FileDoesNotExist;
			}

			return false;
		}

		internal void Cancel()
		{
			if (State == RunningState.Running)
			{
				State = RunningState.CancelPending;
			}
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
