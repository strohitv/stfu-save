using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using log4net;

namespace STFU.Executable.Updater
{
	internal class Updater
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(Updater));

		private string oldDir = "stfu.old";

		public string Message { get; private set; } = $"";

		public bool Successfull { get; private set; } = false;

		public void ExtractUpdate(string zipFile)
		{
			try
			{
				Message = $"Lösche altes Sicherungsverzeichnis.{Environment.NewLine}Bitte Warten...";

				if (Directory.Exists(oldDir))
				{
					LOGGER.Info($"Removing old recovery directory '{oldDir}'");
					Directory.Delete(oldDir, true);
				}

				Message = $"Erstelle neues Sicherungsverzeichnis.{Environment.NewLine}Bitte Warten...";
				LOGGER.Info($"Creating recovery directory '{oldDir}'");
				Directory.CreateDirectory(oldDir);

				Message = $"Sicherungkopie der alten Anwendung wird in den Ordner 'stfu.old' verschoben.{Environment.NewLine}Bitte Warten...";
				string currentDir = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
				DirectoryInfo directory = new DirectoryInfo(currentDir);

				LOGGER.Info($"Moving old directories recursively into recovery directory '{oldDir}'");
				foreach (var folder in directory.EnumerateDirectories().Where(d => d.Name != oldDir && d.Name != "updaterlogs"))
				{
					LOGGER.Info($"Moving directory '{folder.Name}'");
					Message = $"Sichere Ordner {folder.Name}.{Environment.NewLine}Bitte Warten...";
					DirectoryCopy(folder, Path.Combine(oldDir, folder.Name), true);

					if (folder.Name != "settings")
					{
						LOGGER.Info($"Removing directory '{folder.Name}'");
						Directory.Delete(folder.FullName, true);
					}
				}

				LOGGER.Info($"Moving old files into recovery directory '{oldDir}'");
				foreach (var file in directory.EnumerateFiles())
				{
					if (file.Name != Path.GetFileName(Assembly.GetExecutingAssembly().Location)
						&& file.Name != Path.GetFileName(zipFile))
					{
						LOGGER.Info($"Moving old file '{file.Name}' into recovery directory");
						Message = $"Sichere Datei {file.Name}.{Environment.NewLine}Bitte Warten...";
						file.MoveTo(Path.Combine(oldDir, file.Name));
					}
				}

				Message = $"Installiere neue Version.{Environment.NewLine}Bitte Warten...";
				ExtractNewVersion(zipFile);

				Message = $"Lösche Installationsdateien.{Environment.NewLine}Bitte Warten...";
				File.Delete(zipFile);

				Successfull = true;
			}
			catch (Exception)
			{
				Successfull = false;
			}
		}

		private void ExtractNewVersion(string zipFile)
		{
			LOGGER.Info($"Extracting new version from zip file '{zipFile}'");
			string extractPath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

			var UpdateFile = new FileInfo(zipFile);
			if (UpdateFile != null)
			{
				using (ZipArchive archive = ZipFile.OpenRead(UpdateFile.FullName))
				{
					foreach (ZipArchiveEntry entry in archive.Entries)
					{
						if (!entry.Name.StartsWith("stfu-updater", StringComparison.OrdinalIgnoreCase))
						{
							LOGGER.Info($"Extracting file '{entry.Name}' from zip");
							Message = $"Installiere Datei {entry.Name} in den Ordner {entry.FullName}.{Environment.NewLine}Bitte Warten...";
							// Gets the full path to ensure that relative segments are removed.
							string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

							// Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
							// are case-insensitive.
							if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
							{
								CreateDirsRecursively(Path.GetDirectoryName(destinationPath));
								entry.ExtractToFile(destinationPath, true);
								LOGGER.Info($"File was extracted");
							}
						}
					}
				}
			} 
			else
			{
				LOGGER.Error($"Zip file '{zipFile}' could not be found!!");
			}
		}

		private void CreateDirsRecursively(string destinationFolderPath)
		{
			string parentFolder = Path.GetDirectoryName(destinationFolderPath);

			if (!Directory.Exists(parentFolder))
			{
				CreateDirsRecursively(parentFolder);
			}

			LOGGER.Debug($"Creating directory '{destinationFolderPath}'");
			Directory.CreateDirectory(destinationFolderPath);
		}

		private void DirectoryCopy(DirectoryInfo dir, string destDirName, bool copySubDirs)
		{
			DirectoryInfo[] dirs = dir.GetDirectories();
			// If the destination directory doesn't exist, create it.
			if (!Directory.Exists(destDirName))
			{
				LOGGER.Info($"Creating destination directory '{destDirName}'");
				Directory.CreateDirectory(destDirName);
			}

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				LOGGER.Info($"Moving file '{file.Name}'");
				bool stop = false;
				int tries = 0;

				while (!stop)
				{
					try
					{
						tries++;
						string temppath = Path.Combine(destDirName, file.Name);
						file.CopyTo(temppath, false);
						stop = true;
					}
					catch (Exception) when (tries <= 12)
					{
						LOGGER.Warn($"Couldn't move file '{file.Name}' -> retrying in 5 seconds");
						Message = $"Konnte Datei nicht extrahieren...{Environment.NewLine}Versuche es gleich erneut...";
						Thread.Sleep(5000);
					}
				}

			}

			// If copying subdirectories, copy them and their contents to new location.
			if (copySubDirs)
			{
				LOGGER.Info($"Moving subdirectories of this directory");
				foreach (DirectoryInfo subdir in dirs)
				{
					LOGGER.Info($"Moving subdirectory '{subdir.Name}'");
					string temppath = Path.Combine(destDirName, subdir.Name);
					DirectoryCopy(subdir, temppath, true);
				}
			}
		}
	}
}
