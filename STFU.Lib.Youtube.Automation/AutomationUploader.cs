﻿using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Internal;
using STFU.Lib.Youtube.Automation.Internal.Templates;
using STFU.Lib.Youtube.Automation.Internal.Watcher;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
		public IList<IObservationConfiguration> Configuration { get; } = new List<IObservationConfiguration>();

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
		public IProcessContainer ProcessContainer
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

		public bool EndAfterUpload { get; set; }

		private DirectoryWatcher DirectoryWatcher { get; set; } = new DirectoryWatcher();
		private FileSearcher Searcher { get; set; } = new FileSearcher();

		private TemplateVideoCreator VideoCreator { get; set; }

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
				DirectoryWatcher.Cancel();
				Uploader.CancelAll();

				RefreshState();
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
			if (Account == null || Uploader == null)
			{
				return;
			}

			State = RunningState.Running;

			ProcessContainer.AllProcessesCompleted += ProcessContainerAllProcessesCompleted;

			//ReloadProcesses();

			var infos = Configuration
				.Where(c => !c.IgnorePath)
				.Select(pto => new PublishTimeCalculator(
					pto.PathInfo,
					pto.StartDate,
					pto.Template,
					pto.HasCustomStartDayIndex ? pto.CustomStartDayIndex : null)
				{
					UploadPrivate = pto.UploadPrivate
				})
				.ToList();
			VideoCreator = new TemplateVideoCreator(infos);

			Uploader.PropertyChanged += UploaderPropertyChanged;
			Searcher.PropertyChanged += SearcherPropertyChanged;

			Searcher.FileFound += FileToUploadOccured;
			DirectoryWatcher.FileAdded += FileToUploadOccured;

			foreach (var path in Configuration.Where(c => !c.IgnorePath))
			{
				var pi = path.PathInfo;
				Searcher.SearchFilesAsync(pi.Fullname, pi.Filter, pi.SearchRecursively, pi.SearchHidden);
				DirectoryWatcher.AddWatcher(pi.Fullname, pi.Filter, pi.SearchRecursively);
			}
		}

		private void ProcessContainerAllProcessesCompleted(object sender, System.EventArgs e)
		{
			if (EndAfterUpload && uploader.State != UploaderState.Uploading && uploader.State != UploaderState.CancelPending && Searcher.State == RunningState.NotRunning)
			{
				if (uploader.State == UploaderState.Waiting)
				{
					uploader.CancelAll();
				}

				if (DirectoryWatcher.State == RunningState.Running)
				{
					DirectoryWatcher.Cancel();
				}

				RefreshState();
			}
		}

		private void WatcherPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (DirectoryWatcher.State == RunningState.NotRunning)
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
			if (e.PropertyName == nameof(Uploader.State))
			{
				if (Uploader.State == UploaderState.Waiting && EndAfterUpload && ProcessContainer.ShouldEnd)
				{
					Uploader.CancelAll();
				}

				if (DirectoryWatcher.State == RunningState.Running && Uploader.State == UploaderState.NotRunning && EndAfterUpload && ProcessContainer.ShouldEnd)
				{
					DirectoryWatcher.Cancel();
				}

				RefreshState();
			}
		}

		private void RefreshState()
		{
			if (Searcher.State == RunningState.NotRunning
				&& DirectoryWatcher.State == RunningState.NotRunning
				&& Uploader.State == UploaderState.NotRunning)
			{
				State = RunningState.NotRunning;
			}
		}

		private void FileToUploadOccured(FileSystemEventArgs e)
		{
			if (!e.Name.StartsWith("_") && !Uploader.Queue.Any(job => job.Video.File.FullName.ToLower() == e.FullPath.ToLower()))
			{
				Uploader.QueueUpload(VideoCreator.CreateVideo(e.FullPath), Account);
				Uploader.StartUploader();
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