using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Interfaces.Model.Args;
using STFU.Lib.Youtube.Automation.Interfaces.Model.Events;
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

		private IProcessList watchedProcesses = new ProcessList();
		public IProcessList WatchedProcesses
		{
			get
			{
				return watchedProcesses;
			}
			set
			{
				if (watchedProcesses != value && value != null)
				{
					watchedProcesses = value;
					OnPropertyChaged();
				}
			}
		}

		public bool EndAfterUpload { get; set; }

		private DirectoryWatcher DirectoryWatcher { get; set; } = new DirectoryWatcher();
		private FileSearcher Searcher { get; set; } = new FileSearcher();

		private TemplateVideoCreator VideoCreator { get; set; }
		public ITemplateContainer Templates
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}
		public IPathContainer Paths
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

		public AutomationUploader(IYoutubeUploader uploader)
		{
			Uploader = uploader;
		}

		public AutomationUploader(IYoutubeUploader uploader, IYoutubeAccount account, IEnumerable<IObservationConfiguration> configurationsToAdd)
		{
			Uploader = uploader;
			Account = account;

			foreach (var config in configurationsToAdd)
			{
				Configuration.Add(config);
			}
		}

		public event FileToUploadPlannedEventHandler FileToUploadOccured;

		public void Cancel()
		{
			if (State == RunningState.Running)
			{
				State = RunningState.CancelPending;
				Uploader.StopAfterCompleting = true;
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

			WatchedProcesses.ProcessesCompleted += OnProcessesCompleted;

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
			Uploader.StopAfterCompleting = false;

			Searcher.FileFound += OnFileToUploadOccured;
			DirectoryWatcher.FileAdded += OnFileToUploadOccured;

			foreach (var path in Configuration.Where(c => !c.IgnorePath))
			{
				var pi = path.PathInfo;
				Searcher.SearchFilesAsync(pi.Fullname, pi.Filter, pi.SearchRecursively, pi.SearchHidden);
				DirectoryWatcher.AddWatcher(pi.Fullname, pi.Filter, pi.SearchRecursively);
			}
		}

		private void OnProcessesCompleted(object sender, System.EventArgs e)
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
				if (Uploader.State == UploaderState.Waiting)
				{
					WatchedProcesses.ProcessesCompleted += ProcessesCompleted;
					EndIfShouldEnd();
				}
				else if (Uploader.State == UploaderState.Uploading)
				{
					WatchedProcesses.ProcessesCompleted -= ProcessesCompleted;
				}
				else if (Uploader.State == UploaderState.NotRunning)
				{
					DirectoryWatcher.Cancel();
					EndIfShouldEnd();
				}
			}
		}

		private void EndIfShouldEnd()
		{
			if (EndAfterUpload
				&& WatchedProcesses.AllProcessesCompleted
				&& Uploader.State != UploaderState.Uploading
				&& (Uploader.State != UploaderState.Waiting || !Uploader.Queue.Any(u => u.State == UploadProgress.NotRunning && !u.ShouldBeSkipped))
				&& Searcher.State != RunningState.Running)
			{
				Uploader.CancelAll();
				DirectoryWatcher.Cancel();
				RefreshState();
			}
		}

		private void ProcessesCompleted(object sender, System.EventArgs e)
		{
			EndIfShouldEnd();
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

		private void OnFileToUploadOccured(FileSystemEventArgs e)
		{
			if (!e.Name.StartsWith("_")
				&& Uploader.Queue
					.Where(job
						=> job.Video.File.FullName.ToLower() == e.FullPath.ToLower())
					.All(job
						=> job.State == UploadProgress.Successful
						|| job.State == UploadProgress.Failed
						|| job.State == UploadProgress.Canceled))
			{
				var videoAndEvaluator = VideoCreator.CreateVideo(e.FullPath);
				var video = videoAndEvaluator.Item1;
				var evaluator = videoAndEvaluator.Item2;
				var job = Uploader.QueueUpload(video, Account);
				FileToUploadOccured?.Invoke(this, new JobEventArgs(job));

				job.UploadCompletedAction += (args) => evaluator.CleanUp().Wait();
				job.UploadCompletedAction += (args) => RenameVideo(args.Job);

				Uploader.StartUploader();
			}
		}

		private void RenameVideo(IYoutubeJob job)
		{
			if (File.Exists(job.Video.Path))
			{
				var movedPath = Path.GetDirectoryName(job.Video.File.FullName)
					   + "\\_" + Path.GetFileNameWithoutExtension(job.Video.File.FullName).Remove(0, 1)
					   + Path.GetExtension(job.Video.File.FullName);

				int number = 1;
				while (File.Exists(movedPath))
				{
					movedPath = Path.GetDirectoryName(movedPath)
						+ "\\" + Path.GetFileNameWithoutExtension(movedPath) + number
						+ Path.GetExtension(movedPath);
				}

				File.Move(job.Video.File.FullName, movedPath);
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
