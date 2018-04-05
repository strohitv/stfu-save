using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Automation.Internal;
using STFU.Lib.Youtube.Automation.Internal.Templates;
using STFU.Lib.Youtube.Automation.Internal.Watcher;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation
{
	public class AutomationUploader : INotifyPropertyChanged
	{
		public IYoutubeUploader Uploader { get; }

		private bool isActive = false;
		public bool IsActive
		{
			get
			{
				return isActive;
			}
			private set
			{
				if (isActive != value)
				{
					isActive = value;
					OnPropertyChaged();
				}
			}
		}

		private FileWatcher Watcher { get; set; } = new FileWatcher();
		private FileSearcher Searcher { get; set; } = new FileSearcher();

		public IYoutubeAccount Account { get; }

		private TemplateVideoCreator VideoCreator { get; set; }

		public AutomationUploader(IYoutubeUploader uploader, IYoutubeAccount account)
		{
			Uploader = uploader;
			Account = account;
		}

		public async void StartAsync(DateTime standardStartTime, ObservationConfiguration[] pathsToObserve)
		{
			if (!IsActive)
			{
				await Task.Run(() => Start(standardStartTime, pathsToObserve));
			}
		}

		private void Start(DateTime standardStartTime, ObservationConfiguration[] pathsToObserve)
		{
			IsActive = true;

			var infos = pathsToObserve
				.Select(pto => new PublishTimeCalculator(
					pto.PathInfo,
					pto.HasCustomStartDate ? pto.StartDate : standardStartTime,
					pto.Template,
					pto.HasCustomStartDayIndex ? pto.CustomStartDayIndex : null))
				.ToList();
			VideoCreator = new TemplateVideoCreator(infos);

			Searcher.FileFound += FileToUploadOccured;
			Watcher.FileAdded += FileToUploadOccured;

			foreach (var path in pathsToObserve)
			{
				Searcher.SearchFilesAsync(path.PathInfo.Fullname, path.PathInfo.Filter, path.PathInfo.SearchRecursively, path.PathInfo.SearchHidden);
				Watcher.AddWatcher(path.PathInfo.Fullname, path.PathInfo.Filter, path.PathInfo.SearchRecursively);
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
