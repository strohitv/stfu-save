using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace STFU.Lib.Youtube.Automation.Internal
{
	internal delegate void FileFound(FileSystemEventArgs e);

	internal class FileSearcher
	{
		private int runningCount = 0;
		private bool shouldCancel = false;

		internal event FileFound FileFound;
		internal bool IsRunning => runningCount > 0;

		internal void Cancel()
		{
			shouldCancel = false;
		}

		internal async void SearchFilesAsync(string path, string filters, bool searchRecursively, bool searchHidden)
		{
			await Task.Run(() => SearchFiles(path, filters, searchRecursively, searchHidden));
		}

		private void SearchFiles(string path, string filters, bool searchRecursively, bool searchHidden)
		{
			try
			{
				runningCount++;

				if (shouldCancel)
				{
					return;
				}

				if (!searchHidden && new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.Hidden))
				{
					return;
				}

				string[] singleFilters = filters.Split(';');

				foreach (var filter in singleFilters)
				{
					var files = Directory.GetFiles(path, filter)
						.ToArray();

					foreach (var file in files)
					{
						var fileInfo = new FileInfo(file);
						FileFound?.Invoke(new FileSystemEventArgs(WatcherChangeTypes.All, fileInfo.DirectoryName, fileInfo.Name));
					}
				}

				if (searchRecursively)
				{
					Directory.GetDirectories(path)
						.ToList()
						.ForEach(s => SearchFiles(s, filters, true, searchHidden));
				}
			}
			catch (UnauthorizedAccessException) { }
			catch (ThreadAbortException) { }
			finally
			{
				runningCount--;
				shouldCancel &= runningCount > 0;
			}
		}
	}
}
