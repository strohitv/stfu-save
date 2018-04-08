using System.Collections.Generic;
using System.IO;
using SPath = System.IO.Path;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Automation.Internal.Watcher
{
	internal delegate void FileAdded(FileSystemEventArgs e);

	internal class DirectoryWatcher : INotifyPropertyChanged
	{
		internal event FileAdded FileAdded;

		private IList<FileSystemWatcher> Watchers { get; } = new List<FileSystemWatcher>();

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

		internal DirectoryWatcher() { }

		internal void AddWatcher(string path, string filter, bool searchRecursively)
		{
			if (State != RunningState.CancelPending)
			{
				State = RunningState.Running;

				if (!Watchers.Any(w => SPath.GetFullPath(w.Path).ToLower() != SPath.GetFullPath(path).ToLower()))
				{
					var watcher = new FileSystemWatcher(path, filter);
					watcher.NotifyFilter = NotifyFilters.Attributes
						| NotifyFilters.CreationTime
						| NotifyFilters.DirectoryName
						| NotifyFilters.FileName
						| NotifyFilters.LastAccess
						| NotifyFilters.LastWrite
						| NotifyFilters.Security
						| NotifyFilters.Size;
					watcher.IncludeSubdirectories = searchRecursively;
					watcher.Created += ReactOnFileChanges;
					watcher.Changed += ReactOnFileChanges;
					watcher.Renamed += ReactOnFileChanges;
					watcher.EnableRaisingEvents = true;

					Watchers.Add(watcher);
				}
			}
		}

		internal void Cancel()
		{
			State = RunningState.CancelPending;

			while (Watchers.Count > 0)
			{
				Watchers.First().Created -= ReactOnFileChanges;
				Watchers.First().Changed -= ReactOnFileChanges;
				Watchers.First().Renamed -= ReactOnFileChanges;

				Watchers.First().Dispose();
				Watchers.RemoveAt(0);
			}

			State = RunningState.NotRunning;
		}

		private void ReactOnFileChanges(object sender, FileSystemEventArgs e)
		{
			FileAdded?.Invoke(e);
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
