using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace STFU.Lib.Youtube.Common.Internal.Upload
{
	internal class FileUploader : INotifyPropertyChanged
	{
		private CancellationToken CancelToken { get; set; }

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

		internal FileUploader(CancellationToken cancelToken)
		{
			CancelToken = cancelToken;
		}

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

				// Upload initiieren
				Stream requestStream = request.GetRequestStream();
				byte[] buffer = new byte[128 * 1024];
				int bytesRead = 0;

				try
				{
					// Hochladen
					while (!CancelToken.IsCancellationRequested && (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
					{
						requestStream.Write(buffer, 0, bytesRead);
						Progress = fileStream.Position / (double)fileStream.Length * 100;
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

				return !CancelToken.IsCancellationRequested;
			}
			else
			{
				FailureReason = FailureReason.FileDoesNotExist;
			}

			return false;
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
