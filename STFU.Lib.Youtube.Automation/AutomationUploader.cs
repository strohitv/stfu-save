using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Internal;
using STFU.Lib.Youtube.Automation.Internal.Templates;
using STFU.Lib.Youtube.Automation.Internal.Watcher;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Automation
{
	public class AutomationUploader : IAutomationUploader, INotifyPropertyChanged
	{
		public IYoutubeUploader Uploader { get; }

		private RunningState state = RunningState.NotRunning;
		public RunningState State
		{
			get
			{
				return state;
			}
			private set
			{
				if (state != value)
				{
					state = value;
					OnPropertyChaged();
				}
			}
		}

		private DirectoryWatcher Watcher { get; set; } = new DirectoryWatcher();
		private FileSearcher Searcher { get; set; } = new FileSearcher();

		public IYoutubeAccount Account { get; }

		private TemplateVideoCreator VideoCreator { get; set; }

		public AutomationUploader(IYoutubeUploader uploader, IYoutubeAccount account)
		{
			Uploader = uploader;
			Account = account;
		}

		public void Cancel()
		{
			if (State == RunningState.Running)
			{
				State = RunningState.CancelPending;
				Searcher.Cancel();
				Watcher.Cancel();
				Uploader.CancelAll();
			}
		}

		public async void StartAsync(DateTime standardStartTime, IObservationConfiguration[] pathsToObserve)
		{
			if (State == RunningState.NotRunning)
			{
				await Task.Run(() => Start(standardStartTime, pathsToObserve));
			}
		}

		private void Start(DateTime standardStartTime, IObservationConfiguration[] pathsToObserve)
		{
			State = RunningState.Running;

			var infos = pathsToObserve
				.Select(pto => new PublishTimeCalculator(
					pto.PathInfo,
					pto.HasCustomStartDate ? pto.StartDate : standardStartTime,
					pto.Template,
					pto.HasCustomStartDayIndex ? pto.CustomStartDayIndex : null))
				.ToList();
			VideoCreator = new TemplateVideoCreator(infos);

			Uploader.PropertyChanged += UploaderPropertyChanged;
			Searcher.PropertyChanged += SearcherPropertyChanged;

			Searcher.FileFound += FileToUploadOccured;
			Watcher.FileAdded += FileToUploadOccured;

			foreach (var path in pathsToObserve)
			{
				var pi = path.PathInfo;
				Searcher.SearchFilesAsync(pi.Fullname, pi.Filter, pi.SearchRecursively, pi.SearchHidden);
				Watcher.AddWatcher(pi.Fullname, pi.Filter, pi.SearchRecursively);
			}
		}

		private void WatcherPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (Watcher.State == RunningState.NotRunning)
			{
				RefreshState();
			}
		}

		private void SearcherPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (Searcher.State == RunningState.NotRunning)
			{
				RefreshState();
			}
		}

		private void UploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Uploader.State)
				&& Uploader.State == UploaderState.NotRunning)
			{
				RefreshState();
			}
		}

		private void RefreshState()
		{
			if (Searcher.State == RunningState.NotRunning
				&& Watcher.State == RunningState.NotRunning
				&& Uploader.State == UploaderState.NotRunning)
			{
				State = RunningState.NotRunning;
			}
		}

		private void FileToUploadOccured(FileSystemEventArgs e)
		{
			Uploader.QueueUpload(VideoCreator.CreateVideo(e.FullPath), Account);
			Uploader.StartUploader();
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
