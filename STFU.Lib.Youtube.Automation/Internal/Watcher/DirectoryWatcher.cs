using System.Collections.Generic;
using System.IO;
using SPath = System.IO.Path;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Common;
using log4net;

namespace STFU.Lib.Youtube.Automation.Internal.Watcher
{
	internal delegate void FileAdded(FileSystemEventArgs e);

	internal class DirectoryWatcher : INotifyPropertyChanged
	{
		private static ILog LOGGER { get; set; } = LogManager.GetLogger(nameof(DirectoryWatcher));

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
					LOGGER.Info($"Directory watcher state updated to {value}");

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
				LOGGER.Info($"Adding directory watcher for settings path: '{path}', filter: '{filter}', recursive: {searchRecursively}");

				State = RunningState.Running;

				// Wenn alle Watcher einen anderen Pfad haben, dann passt es.
				if (Watchers.All(w => SPath.GetFullPath(w.Path).ToLower() != SPath.GetFullPath(path).ToLower()))
				{
					LOGGER.Info($"There is no watcher for path '{path}' => adding new one");

					var filters = filter.Split(';');
					foreach (var f in filters)
					{
						var watcher = new FileSystemWatcher(path, f.Trim());
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

						LOGGER.Info($"Adding watcher for path '{path}' and filter '{f}'");

						Watchers.Add(watcher);
					}
				}
				else
				{
					LOGGER.Warn($"Watcher for path '{path}' already exists, skipping add");
				}
			}
		}

		internal void Cancel()
		{
			State = RunningState.CancelPending;

			LOGGER.Info($"Canceling watchers");

			while (Watchers.Count > 0)
			{
				LOGGER.Info($"Removing watcher for path '{Watchers.First().Path}'");

				Watchers.First().Created -= ReactOnFileChanges;
				Watchers.First().Changed -= ReactOnFileChanges;
				Watchers.First().Renamed -= ReactOnFileChanges;

				Watchers.First().Dispose();
				Watchers.RemoveAt(0);
			}

			LOGGER.Info($"Watchers canceled");

			State = RunningState.NotRunning;
		}

		private void ReactOnFileChanges(object sender, FileSystemEventArgs e)
		{
			if (IsVideoAnalyzer.IsVideo(e.Name))
			{
				LOGGER.Info($"Watcher found file '{e.FullPath}'");

				FileAdded?.Invoke(e);
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
