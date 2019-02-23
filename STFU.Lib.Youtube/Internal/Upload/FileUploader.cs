using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Upload.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class FileUploader : Uploadable, INotifyPropertyChanged
	{
		const double multiplier = 1.1;

		private static TimeSpan MinimalReferenceTime { get; } = new TimeSpan(0, 0, 0, 0, 50);
		private static TimeSpan MaximalReferenceTime { get; } = new TimeSpan(0, 0, 0, 2, 0);

		private bool Skip { get; set; } = false;

		internal FileUploader() { }

		internal bool UploadFile(string path, HttpWebRequest request)
		{
			return UploadFile(path, request, (long)128 * 1000 * 1000 * 1000, 0);
		}

		internal bool UploadFile(string path, HttpWebRequest request, long maxFileSize, long startPosition)
		{
			bool result = false;

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

					Started = DateTime.Now;
					RunningState = RunningState.Running;

					try
					{
						// Upload initiieren
						using (Stream requestStream = request.GetRequestStream())
						{
							TryUpload(fileStream, requestStream);
						}

						result = true;
						Progress = 100.0;
						RunningState = RunningState.NotRunning;
					}
					catch (WebException)
					{
						if (RunningState != RunningState.CancelPending)
						{
							FailureReason = FailureReason.Unknown;
						}
						else
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

			return result;
		}

		private void TryUpload(FileStream fileStream, Stream requestStream)
		{
			try
			{
				Upload(fileStream, requestStream);
			}
			catch (WebException)
			{
				requestStream.Close();
				FailureReason = FailureReason.SendError;
			}
			catch (IOException)
			{
				requestStream.Close();
				FailureReason = FailureReason.ReadError;
			}
		}

		private void Upload(FileStream fileStream, Stream requestStream)
		{
			// Hochladen
			byte[] buffer = new byte[128];
			int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

			while (RunningState != RunningState.CancelPending && bytesRead != 0)
			{
				if (RunningState == RunningState.PausePending)
				{
					RunningState = RunningState.Paused;
				}

				if (!Skip)
				{
					var sendStart = DateTime.Now;
					requestStream.Write(buffer, 0, bytesRead);
					var sendTime = DateTime.Now - sendStart;

					if (sendTime < MinimalReferenceTime)
					{
						buffer = new byte[(int)(buffer.Length * multiplier)];
					}
					else if (sendTime > MaximalReferenceTime && buffer.Length / multiplier > 128)
					{
						buffer = new byte[(int)(buffer.Length / multiplier)];
					}

					Progress = fileStream.Position / (double)fileStream.Length * 100;

					UploadedDuration = DateTime.Now - Started;
					RemainingDuration = new TimeSpan(0, 0, (int)(UploadedDuration.TotalSeconds / Progress * (100 - (int)Progress)));

					bytesRead = fileStream.Read(buffer, 0, buffer.Length);
				}
			}
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
			Skip = true;
		}

		internal void Resume()
		{
			RunningState = RunningState.Running;
			Skip = false;
		}
	}
}
