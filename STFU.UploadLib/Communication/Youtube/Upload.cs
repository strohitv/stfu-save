using System;
using System.Threading;
using STFU.UploadLib.Accounts;
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

		internal static bool Upload(ref Job job)
		{
			//Trace.WriteLine(testUrl.AbsoluteUri);

			WebService.ProgressChanged += ReactToProgressChanged;

			Uri testUrl = null;
			while (Uri.TryCreate(WebService.UploadFile(ref job), UriKind.Absolute, out testUrl))
			{
				//Trace.WriteLine("Upload wurde unerwartet abgebrochen. Warte 1 Minuten vor Neuversuch...");
				Thread.Sleep(new TimeSpan(0, 1, 0));
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
