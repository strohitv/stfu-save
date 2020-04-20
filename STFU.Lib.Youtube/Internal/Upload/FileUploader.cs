using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Upload.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class FileUploader : Uploadable, INotifyPropertyChanged
	{
		const double multiplier = 1.1;

		private static TimeSpan MinimalReferenceTime { get; } = new TimeSpan(0, 0, 0, 0, 50);
		private static TimeSpan MaximalReferenceTime { get; } = new TimeSpan(0, 0, 0, 2, 0);

		internal FileUploader() { }

		internal FileUploader(TimeSpan currentDuration)
		{
			UploadedDuration = currentDuration;
		}

		internal bool UploadFile(string path, HttpWebRequest request)
		{
			return UploadFile(path, request, (long)128 * 1000 * 1000 * 1000, 0);
		}

		internal bool UploadFile(string path, HttpWebRequest request, long maxFileSize, long startPosition)
		{
			bool finishedSuccessful = false;

			if (File.Exists(path))
			{
				using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					if (fileStream.Length > maxFileSize)
					{
						FailureReason = FailureReason.FileTooBig;
						return false;
					}

					if (startPosition > 0)
					{
						fileStream.Position = startPosition;
					}

					if (Started == default(DateTime))
					{
						Started = DateTime.Now;
					}

					RunningState = RunningState.Running;

					try
					{
						var uri = request.RequestUri;
						ServicePointManager.FindServicePoint(uri).UseNagleAlgorithm = false;
						request.Proxy = new WebProxy();
						request.AllowWriteStreamBuffering = false;

						// Upload initiieren
						using (Stream requestStream = request.GetRequestStream())
						{
							finishedSuccessful = TryUpload(fileStream, requestStream);
						}

						if (finishedSuccessful)
						{
							Progress = 100.0;
							RunningState = RunningState.NotRunning;
						}
					}
					catch (WebException)
					{
						if (RunningState == RunningState.CancelPending)
						{
							RunningState = RunningState.Canceled;
						}
					}
				}
			}
			else
			{
				FailureReason = FailureReason.FileDoesNotExist;
			}

			return finishedSuccessful;
		}

		private bool TryUpload(FileStream fileStream, Stream requestStream)
		{
			var result = false;

			try
			{
				Upload(fileStream, requestStream);
				result = RunningState != RunningState.CancelPending
					&& RunningState != RunningState.Canceled
					&& RunningState != RunningState.PausePending
					&& RunningState != RunningState.Paused;
			}
			catch (WebException)
			{
				// Hier fliegt im Falle eines gewollten Abbruchs eine erwartete WebException.
				requestStream.Close();
				FailureReason = FailureReason.SendError;
			}
			catch (Exception)
			{
				requestStream.Close();
				// FailureReason = FailureReason.ReadError;
			}

			return result;
		}

		private void Upload(FileStream fileStream, Stream requestStream)
		{
			byte[] buffer = new byte[128];
			int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

			while (RunningState != RunningState.CancelPending
				&& RunningState != RunningState.Paused
				&& bytesRead != 0)
			{
				if (RunningState != RunningState.PausePending)
				{
					var sendStart = DateTime.Now;
					requestStream.Write(buffer, 0, bytesRead);
					var sendTime = DateTime.Now - sendStart;

					CurrentSpeed = CalculateAverageSpeed(sendTime, buffer);

					if (sendTime < MinimalReferenceTime)
					{
						buffer = new byte[(int)(buffer.Length * multiplier)];
					}
					else if (sendTime > MaximalReferenceTime && buffer.Length / multiplier > 128)
					{
						buffer = new byte[(int)(buffer.Length / multiplier)];
					}

					Progress = fileStream.Position / (double)fileStream.Length * 100;

					UploadedDuration += sendTime;
					RemainingDuration = new TimeSpan(0, 0, 0, 0, (int)(UploadedDuration.TotalSeconds * 1000 / Progress * (100 - Progress)));

					bytesRead = fileStream.Read(buffer, 0, buffer.Length);
				}
				else
				{
					RunningState = RunningState.Paused;
				}
			}
		}

		string[] dataUnits = new[] { "B/s", "kB/s", "MB/s", "GB/s", "TB/s" };
		private string CalculateAverageSpeed(TimeSpan sendTime, byte[] buffer)
		{
			string result = "0 kb/s";

			if (sendTime.TotalSeconds != 0)
			{
				var speed = buffer.Length / sendTime.TotalSeconds;
				int unitIndex = 0;
				while (speed > 1000)
				{
					speed /= 1000;
					unitIndex++;
				}

				result = $"{speed:0.00} {dataUnits[unitIndex]}";
			}

			return result;
		}

		internal void Cancel()
		{
			if (RunningState == RunningState.Running)
			{
				RunningState = RunningState.CancelPending;
			}
		}

		internal void Pause()
		{
			RunningState = RunningState.PausePending;
		}

		internal void SetSateToRunning()
		{
			RunningState = RunningState.Running;
		}
	}
}
