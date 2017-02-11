using System;
using System.Diagnostics;
using System.Threading;
using STFU.UploadLib.Queue;

namespace STFU.UploadLib.Communication.Youtube
{
	internal class UploadCommunication
	{
		public static event ProgressChangedEventHandler ProgressChanged;

		internal static bool Upload(ref Job video)
		{
			string url = WebService.InitializeUpload(ref video);

			Uri testUrl = null;
			if (!Uri.TryCreate(url, UriKind.Absolute, out testUrl))
			{
				return false;
			}

			Trace.WriteLine(testUrl.AbsoluteUri);

			WebService.ProgressChanged += ReactToProgressChanged;

			while (Uri.TryCreate(WebService.UploadFile(ref video, url), UriKind.Absolute, out testUrl))
			{
				Trace.WriteLine("Upload wurde unerwartet abgebrochen. Warte 1 Minuten vor Neuversuch...");
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
