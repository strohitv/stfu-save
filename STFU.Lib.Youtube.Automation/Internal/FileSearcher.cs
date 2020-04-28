using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Common;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
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
			if (State != RunningState.NotRunning)
			{
				State = RunningState.CancelPending;
			}
		}

		internal async void SearchFilesAsync(string path, string filters, bool searchRecursively, bool searchHidden, FoundFilesOrderByFilter order)
		{
			await Task.Run(() => SearchFiles(path, filters, searchRecursively, searchHidden, order));
		}

		private void SearchFiles(string path, string filters, bool searchRecursively, bool searchHidden, FoundFilesOrderByFilter order)
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
					var files = Directory.GetFiles(path, filter).Select(p => new FileInfo(p)).ToArray();

					switch (order)
					{
						case FoundFilesOrderByFilter.NameAsc:
							files = files.OrderBy((file) => file.Name).ToArray();
							break;
						case FoundFilesOrderByFilter.NameDsc:
							files = files.OrderByDescending((file) => file.Name).ToArray();
							break;
						case FoundFilesOrderByFilter.CreationDateAsc:
							files = files.OrderBy((file) => file.CreationTime).ToArray();
							break;
						case FoundFilesOrderByFilter.CreationDateDsc:
							files = files.OrderByDescending((file) => file.CreationTime).ToArray();
							break;
						case FoundFilesOrderByFilter.ChangedDateAsc:
							files = files.OrderBy((file) => file.LastWriteTime).ToArray();
							break;
						case FoundFilesOrderByFilter.ChangedDateDsc:
							files = files.OrderByDescending((file) => file.LastWriteTime).ToArray();
							break;
						case FoundFilesOrderByFilter.SizeAsc:
							files = files.OrderBy((file) => file.Length).ToArray();
							break;
						case FoundFilesOrderByFilter.SizeDsc:
							files = files.OrderByDescending((file) => file.Length).ToArray();
							break;
						default:
							break;
					}


					foreach (var file in files.Where(f => !f.Name.StartsWith("_") && IsVideoAnalyzer.IsVideo(f.Name)))
					{
						FileFound?.Invoke(new FileSystemEventArgs(WatcherChangeTypes.All, file.DirectoryName, file.Name));
					}
				}

				if (searchRecursively)
				{
					Directory.GetDirectories(path)
						.ToList()
						.ForEach(s => SearchFiles(s, filters, true, searchHidden, order));
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
