using System;
using System.Threading;
using Newtonsoft.Json;
using STFU.UploadLib.Accounts;
using STFU.UploadLib.Communication.Youtube.Serializable;
using STFU.UploadLib.Queue;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Communication.Youtube
{
	internal class UploadCommunication
	{
		public static event ProgressChangedEventHandler ProgressChanged;

		internal static Job PrepareUpload(Video video, Account account)
		{
			Job job = new Job();
			job.SelectedVideo = video;
			job.UploadingAccount = account;
			job.Status = new UploadDetails();

			string url = WebService.InitializeUpload(ref job);

			Uri testUrl = null;
			if (Uri.TryCreate(url, UriKind.Absolute, out testUrl))
			{
				job.Url = testUrl;
				return job;
			}

			// Fehler
			return null;
		}

		internal static bool Upload(ref Job job, ref bool shouldCancel)
		{
			WebService.ProgressChanged += ReactToProgressChanged;

			Uri testUrl = null;
			string result = null;
			while (!shouldCancel && Uri.TryCreate(result = WebService.UploadVideo(ref job, ref shouldCancel), UriKind.Absolute, out testUrl))
			{
				Thread.Sleep(new TimeSpan(0, 1, 0));
			}

			if (!shouldCancel)
			{
				var videoId = JsonConvert.DeserializeObject<YoutubeVideo>(result).id;
				var thumbnailResult = WebService.UploadThumbnail(ref job, videoId, ref shouldCancel);
			}

			return true;
		}

		private static void ReactToProgressChanged(ProgressChangedEventArgs args)
		{
			OnProgressChanged(args.FileName, args.Progress);
		}

		private static void OnProgressChanged(string fileName, double progress)
		{
			ProgressChangedEventArgs args = new ProgressChangedEventArgs();
			args.FileName = fileName;
			args.Progress = progress;

			ProgressChanged?.Invoke(args);
		}
	}
}
