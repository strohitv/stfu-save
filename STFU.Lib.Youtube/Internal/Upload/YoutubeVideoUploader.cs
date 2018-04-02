using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoUploader
	{
		private InternalYoutubeJob Job { get; set; }
		private CancellationToken Token { get; set; }

		internal string Response { get; private set; }

		internal YoutubeVideoUploader(IYoutubeJob job)
		{
			Job = job as InternalYoutubeJob;
		}

		internal bool Upload()
		{
			var lastbyte = CheckUploadStatus();

			FileStream fileStream = new FileStream(Job.Video.Path, FileMode.Open, FileAccess.Read);

			HttpWebRequest request = null;
			if (lastbyte == -1)
			{
				request = HttpWebRequestCreator.CreateForNewUpload(Job);
			}
			else
			{
				request = HttpWebRequestCreator.CreateForResumeUpload(Job, lastbyte);
				fileStream.Position = lastbyte + 1;
			}

			Job.State = UploadState.Running;

			FileUploader fileUploader = new FileUploader(Token);
			fileUploader.PropertyChanged += OnUploadProgressChanged;

			bool successful = fileUploader.UploadFile(Job.Video.Path, request, (long)128 * 1000 * 1000 * 1000, lastbyte);

			if (successful)
			{
				Response = WebService.Communicate(request);
				Job.State = UploadState.Successful;
			}
			else if (Token.IsCancellationRequested)
			{
				Job.State = UploadState.Canceled;
			}
			else
			{
				Job.State = UploadState.Error;
			}

			return successful;
		}

		private void OnUploadProgressChanged(object sender, PropertyChangedEventArgs e)
		{
			var fileUploader = (FileUploader)sender;
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Job.Progress = ((FileUploader)sender).Progress;
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
	}
}
