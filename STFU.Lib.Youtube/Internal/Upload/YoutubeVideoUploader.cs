using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using System.Runtime.CompilerServices;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoUploader : INotifyPropertyChanged
	{
		FileUploader fileUploader = new FileUploader();

		private InternalYoutubeJob Job { get; set; }

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

		internal string Response { get; private set; }

		internal YoutubeVideoUploader(IYoutubeJob job)
		{
			Job = job as InternalYoutubeJob;

			fileUploader.PropertyChanged += OnUploadProgressChanged;
		}

		internal bool Upload()
		{
			State = RunningState.Running;

			var lastbyte = CheckUploadStatus();

			HttpWebRequest request = null;
			if (lastbyte == -1)
			{
				request = HttpWebRequestCreator.CreateForNewUpload(Job);
			}
			else
			{
				request = HttpWebRequestCreator.CreateForResumeUpload(Job, lastbyte);
			}

			Job.State = UploadState.Running;

			bool successful = fileUploader.UploadFile(Job.Video.Path, request, (long)128 * 1000 * 1000 * 1000, lastbyte);

			if (successful)
			{
				Response = WebService.Communicate(request);
				Job.State = UploadState.Successful;
			}
			else if (State == RunningState.CancelPending)
			{
				Job.State = UploadState.Canceled;
			}
			else
			{
				Job.State = UploadState.Error;
			}

			State = RunningState.NotRunning;
			return successful;
		}

		private void OnUploadProgressChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Job.Progress = fileUploader.Progress;
			}
			else
			{
				Job.Error = FailReasonConverter.GetError(fileUploader.FailureReason);
			}
		}

		internal long CheckUploadStatus()
		{
			var request = HttpWebRequestCreator.CreateWithAuthHeader(Job.Uri.AbsoluteUri, "PUT",
				YoutubeAccountService.GetAccessToken(Job.Account));
			request.ContentLength = 0;
			request.Headers.Add($"content-range: bytes */{Job.Video.File.Length}");

			var answer = WebService.Communicate(request);
			if (answer == null)
			{
				return -1;
			}

			answer = answer.Substring("bytes=".Length);

			long lastbyte;
			try
			{
				lastbyte = Convert.ToInt64(answer.Split('-')[1]);
			}
			catch (Exception)
			{
				return -1;
			}

			return lastbyte;
		}

		internal void Cancel()
		{
			if (State == RunningState.Running)
			{
				State = RunningState.CancelPending;
				fileUploader.Cancel();
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
