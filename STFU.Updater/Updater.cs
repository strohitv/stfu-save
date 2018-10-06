using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace STFU.Updater
{
	internal class Updater
	{
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
					Directory.Delete(oldDir, true);
				}

				Message = $"Erstelle neues Sicherungsverzeichnis.{Environment.NewLine}Bitte Warten...";
				Directory.CreateDirectory(oldDir);

				Message = $"Sicherungkopie der alten Anwendung wird in den Ordner 'stfu.old' verschoben.{Environment.NewLine}Bitte Warten...";
				string currentDir = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
				DirectoryInfo directory = new DirectoryInfo(currentDir);

				foreach (var folder in directory.EnumerateDirectories().Where(d => d.Name != oldDir))
				{
					Message = $"Sichere Ordner {folder.Name}.{Environment.NewLine}Bitte Warten...";
					DirectoryCopy(folder, Path.Combine(oldDir, folder.Name), true);

					if (folder.Name != "settings")
					{
						Directory.Delete(folder.FullName, true);
					}
				}

				foreach (var file in directory.EnumerateFiles())
				{
					if (file.Name != Path.GetFileName(Assembly.GetExecutingAssembly().Location)
						&& file.Name != Path.GetFileName(zipFile))
					{
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
							Message = $"Installiere Datei {entry.Name} in den Ordner {entry.FullName}.{Environment.NewLine}Bitte Warten...";
							// Gets the full path to ensure that relative segments are removed.
							string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

							// Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
							// are case-insensitive.
							if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
							{
								CreateDirsRecursively(Path.GetDirectoryName(destinationPath));
								entry.ExtractToFile(destinationPath, true);
							}
						}
					}
				}
			}
		}

		private void CreateDirsRecursively(string destinationFolderPath)
		{
			string parentFolder = Path.GetDirectoryName(destinationFolderPath);

			if (!Directory.Exists(parentFolder))
			{
				CreateDirsRecursively(parentFolder);
			}

			Directory.CreateDirectory(destinationFolderPath);
		}

		private void DirectoryCopy(DirectoryInfo dir, string destDirName, bool copySubDirs)
		{
			DirectoryInfo[] dirs = dir.GetDirectories();
			// If the destination directory doesn't exist, create it.
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				string temppath = Path.Combine(destDirName, file.Name);
				file.CopyTo(temppath, false);
			}

			// If copying subdirectories, copy them and their contents to new location.
			if (copySubDirs)
			{
				foreach (DirectoryInfo subdir in dirs)
				{
					string temppath = Path.Combine(destDirName, subdir.Name);
					DirectoryCopy(subdir, temppath, true);
				}
			}
		}
	}
}
