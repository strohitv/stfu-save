using System;
using System.IO;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Updater
{
	public class Downloader
	{
		public FileInfo DownloadVersion(string fileId, string filename)
		{
			var driveService = new DriveService(new BaseClientService.Initializer
			{
				ApiKey = YoutubeClientData.UpdaterApiKey
			});

			var request = driveService.Files.Get(fileId);
			var stream = new FileStream(filename, FileMode.Create);

			// Add a handler which will be notified on progress changes.
			// It will notify on each chunk download and when the
			// download is completed or failed.
			request.MediaDownloader.ProgressChanged +=
				(IDownloadProgress progress) =>
				{
					switch (progress.Status)
					{
						case DownloadStatus.Downloading:
							{
								Console.WriteLine(progress.BytesDownloaded);
								break;
							}
						case DownloadStatus.Completed:
							{
								Console.WriteLine("Download complete.");
								stream.Flush();
								stream.Close();
								break;
							}
						case DownloadStatus.Failed:
							{
								Console.WriteLine("Download failed.");
								stream.Flush();
								stream.Close();
								break;
							}
					}
				};

			request.Download(stream);

			return new FileInfo(filename);
		}
	}
}
