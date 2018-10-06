using System.IO;

namespace STFU.Lib.Updater
{
	public interface IUpdater
	{
		bool UpdateAvailable { get; }
		string NewVersion { get; }
		FileInfo UpdateFile { get; }

		FileInfo DownloadUpdate();
		FileInfo ExtractUpdateExe();
	}
}
