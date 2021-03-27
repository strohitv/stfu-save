using System;
using System.IO;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using log4net;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Updater
{
	public class Downloader
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(Downloader));

		public FileInfo DownloadVersion(string fileId, string filename)
		{
			LOGGER.Info($"Downloading google drive file '{fileId}' to file '{filename}' on local drive");

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
								LOGGER.Debug($"Downloading, current progress: {progress.BytesDownloaded}");

								break;
							}
						case DownloadStatus.Completed:
							{
								Console.WriteLine("Download complete.");
								LOGGER.Info($"Download complete");

								stream.Flush();
								stream.Close();
								break;
							}
						case DownloadStatus.Failed:
							{
								Console.WriteLine("Download failed.");
								LOGGER.Error($"Download failed", progress.Exception);

								stream.Flush();
								stream.Close();
								break;
							}
					}
				};

			request.Download(stream);

			LOGGER.Info($"Download finished");

			return new FileInfo(filename);
		}
	}
}
