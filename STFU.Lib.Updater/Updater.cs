using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;
using log4net;

namespace STFU.Lib.Updater
{
	public class Updater : IUpdater
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(Updater));

		private string currentVersion = string.Empty;
		private UpdateInformation updateInfos = null;

		public Updater(string currentVersion)
		{
			LOGGER.Info($"Creating new instance of Updater with program Version: {currentVersion}");
			this.currentVersion = currentVersion;
		}

		public bool UpdateAvailable
		{
			get
			{
				if (updateInfos == null)
				{
					updateInfos = new VersionChecker().CheckStfuVersion(currentVersion);
				}

				LOGGER.Info($"Is an update availabe: {updateInfos.UpdateAvailable}");
				return updateInfos.UpdateAvailable;
			}
		}

		public string NewVersion => updateInfos.Version;

		public FileInfo UpdateFile { get; private set; }

		public FileInfo DownloadUpdate()
		{
			string filename = $"stfu-update-{updateInfos.Version}.zip";
			UpdateFile = new Downloader().DownloadVersion(updateInfos.FileId, filename);
			return UpdateFile;
		}

		public FileInfo ExtractUpdateExe()
		{
			FileInfo result = null;

			string extractPath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

			if (UpdateFile != null)
			{
				LOGGER.Info($"Extracting updater executable from zip file to folder: '{extractPath}'");

				using (ZipArchive archive = ZipFile.OpenRead(UpdateFile.FullName))
				{
					foreach (ZipArchiveEntry entry in archive.Entries)
					{
						if (entry.Name.StartsWith("stfu-updater", StringComparison.OrdinalIgnoreCase)
							&& entry.Name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
						{
							result = new FileInfo(ExtractEntry(extractPath, entry));
						}
						else if (entry.Name.StartsWith("log4net-updater", StringComparison.OrdinalIgnoreCase)
							&& entry.Name.EndsWith(".config", StringComparison.OrdinalIgnoreCase))
						{
							ExtractEntry(extractPath, entry);
						}
					}
				}
			}
			else
			{
				LOGGER.Warn($"Update could not be extracted because the zip file could not found on your local drive - did the download fail?");
			}

			return result;
		}

		private static string ExtractEntry(string extractPath, ZipArchiveEntry entry)
		{
			// Gets the full path to ensure that relative segments are removed.
			string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

			// Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
			// are case-insensitive.
			if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
			{
				bool stop = false;
				int tries = 0;

				while (!stop)
				{
					try
					{
						tries++;
						entry.ExtractToFile(destinationPath, true);
						LOGGER.Info($"File '{entry.Name}' was successfully extracted");
						stop = true;
					}
					catch (Exception) when (tries <= 12)
					{
						Thread.Sleep(5000);
					}
				}
			}

			return destinationPath;
		}
	}
}
