using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;

namespace STFU.Lib.Updater
{
	public class Updater : IUpdater
	{
		private string currentVersion = string.Empty;
		private UpdateInformation updateInfos = null;

		public Updater(string currentVersion)
		{
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

				return updateInfos.UpdateAvailable;
			}
		}

		public string NewVersion => updateInfos.Version;

		public FileInfo UpdateFile { get; private set; }

		public FileInfo DownloadUpdate()
		{
			string filename = $"stfu-update-{updateInfos.Version}.zip";
			var downloader = new Downloader();

			UpdateFile = downloader.DownloadVersion(updateInfos.FileId, filename);
			return UpdateFile;
		}

		public FileInfo ExtractUpdateExe()
		{
			FileInfo result = null;

			string extractPath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

			if (UpdateFile != null)
			{
				using (ZipArchive archive = ZipFile.OpenRead(UpdateFile.FullName))
				{
					foreach (ZipArchiveEntry entry in archive.Entries)
					{
						if (entry.Name.StartsWith("stfu-updater", StringComparison.OrdinalIgnoreCase)
							&& entry.Name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
						{
							// Gets the full path to ensure that relative segments are removed.
							string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

							// Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
							// are case-insensitive.
							if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
							{
								bool stop = false;

								while (!stop)
								{
									try
									{
										entry.ExtractToFile(destinationPath, true);
										stop = true;
									}
									catch (Exception ex)
									{
										Thread.Sleep(5000);
									}
								}

								result = new FileInfo(destinationPath);
								break;
							}
						}
					}
				}
			}

			return result;
		}
	}
}
