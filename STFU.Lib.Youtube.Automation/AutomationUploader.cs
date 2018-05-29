using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Internal;
using STFU.Lib.Youtube.Automation.Internal.Templates;
using STFU.Lib.Youtube.Automation.Internal.Watcher;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Automation
{
	public class AutomationUploader : IAutomationUploader
	{
		private IYoutubeUploader uploader = null;
		public IYoutubeUploader Uploader
		{
			get
			{
				return uploader;
			}
			set
			{
				if (State == RunningState.NotRunning && uploader != value)
				{
					uploader = value;
					OnPropertyChaged();
				}
			}
		}

		private IYoutubeAccount account = null;
		public IYoutubeAccount Account
		{
			get
			{
				return account;
			}
			set
			{
				if (account != value)
				{
					account = value;
					OnPropertyChaged();
				}
			}
		}

		private IList<IObservationConfiguration> configuration = new List<IObservationConfiguration>();
		public IList<IObservationConfiguration> Configuration
		{
			get
			{
				return configuration;
			}
		}

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

		private IProcessContainer processesToWatch = new ProcessContainer();
		public IProcessContainer ProcessesToWatch
		{
			get
			{
				return processesToWatch;
			}
			set
			{
				if (processesToWatch != value && value != null)
				{
					processesToWatch = value;
					OnPropertyChaged();
				}
			}
		}

		public bool EndAfterUpload { get; set; } = false;

		private DirectoryWatcher Watcher { get; set; } = new DirectoryWatcher();
		private FileSearcher Searcher { get; set; } = new FileSearcher();

		private TemplateVideoCreator VideoCreator { get; set; }

		private ProcessWatcher processWatcher = new ProcessWatcher();
		public ProcessWatcher ProcessWatcher
		{
			get
			{
				return processWatcher;
			}
			set
			{
				if (value != null && processWatcher !=  value)
				{
					processWatcher = value;
					OnPropertyChaged();
				}
			}
		}

		public AutomationUploader() { }

		public AutomationUploader(IYoutubeUploader uploader, IYoutubeAccount account, IEnumerable<IObservationConfiguration> configurationsToAdd)
		{
			Uploader = uploader;
			Account = account;

			foreach (var config in configurationsToAdd)
			{
				Configuration.Add(config);
			}
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

		public async void StartAsync()
		{
			if (State == RunningState.NotRunning)
			{
				await Task.Run(() => Start());
			}
		}

		private void Start()
		{
			if (Account != null || Uploader == null)
			{
				return;
			}

			State = RunningState.Running;

			ProcessWatcher.AllProcessesCompleted += ProcessWatcherAllProcessesCompleted;

			foreach (var proc in ProcessesToWatch.ProcessesToWatch)
			{
				ProcessWatcher.Add(proc);
			}

			var infos = Configuration
				.Select(pto => new PublishTimeCalculator(
					pto.PathInfo,
					pto.StartDate,
					pto.Template,
					pto.HasCustomStartDayIndex ? pto.CustomStartDayIndex : null))
				.ToList();
			VideoCreator = new TemplateVideoCreator(infos);

			Uploader.PropertyChanged += UploaderPropertyChanged;
			Searcher.PropertyChanged += SearcherPropertyChanged;

			Searcher.FileFound += FileToUploadOccured;
			Watcher.FileAdded += FileToUploadOccured;

			foreach (var path in Configuration)
			{
				var pi = path.PathInfo;
				Searcher.SearchFilesAsync(pi.Fullname, pi.Filter, pi.SearchRecursively, pi.SearchHidden);
				Watcher.AddWatcher(pi.Fullname, pi.Filter, pi.SearchRecursively);
			}
		}

		private void ProcessWatcherAllProcessesCompleted(object sender, System.EventArgs e)
		{
			if (EndAfterUpload && uploader.State == UploaderState.Waiting && Searcher.State == RunningState.NotRunning)
			{

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
