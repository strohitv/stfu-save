using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Automation.Internal
{
	internal delegate void FileFound(FileSystemEventArgs e);

	internal class FileSearcher : INotifyPropertyChanged
	{
		private int runningCount = 0;

		internal event FileFound FileFound;

		private RunningState state = RunningState.NotRunning;
		internal RunningState State
		{
			get
			{
				return state;
			}
			set
			{
				if (value != state)
				{
					state = value;
					OnPropertyChaged();
				}
			}
		}

		internal void Cancel()
		{
			State = RunningState.CancelPending;
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
				State = RunningState.Running;

				if (State == RunningState.CancelPending)
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

				if (runningCount == 0)
				{
					State = RunningState.NotRunning;
				}
			}
		}

		#region PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChaged([CallerMemberName] string caller = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
		}
		#endregion PropertyChanged
	}
}
