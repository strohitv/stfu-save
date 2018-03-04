using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.UploadLib.Accounts;
using STFU.UploadLib.Communication.Youtube;
using STFU.UploadLib.Operations;
using STFU.UploadLib.Queue;
using STFU.UploadLib.Templates;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Automation
{
	public delegate void UploadStartedEventHandler(AutomationEventArgs e);
	public delegate void UploadFinishedEventHandler(AutomationEventArgs e);
	public delegate void UploadProgressChangedEventHandler(AutomationEventArgs e);

	public class AutomationUploader : INotifyPropertyChanged
	{
		#region fields
		private PathSettings paths = new PathSettings();
		private Uploader uploader = new Uploader();
		private Account activeAccount = null;
		private bool active = false;
		private ProcessWatcher watcher = new ProcessWatcher();
		private List<Template> templates = new List<Template>();
		private List<Language> languages = new List<Language>();

		private const string selectedPathsJsonPath = @"settings\paths.json";
		private const string accountJsonPath = @"settings\account.json";
		private const string currentUploadDetailsPath = @"settings\currentUpload.json";
		private const string templatesPath = @"settings\templates.json";
		private const string languagesPath = @"settings\languages.json";

		public event UploadStartedEventHandler UploadStarted;
		public event UploadFinishedEventHandler UploadFinished;
		public event UploadProgressChangedEventHandler ProgressChanged;
		public event PropertyChangedEventHandler PropertyChanged;

		private List<string> files = new List<string>();

		private string message;
		private double progress;

		private List<FileSystemWatcher> watchers;

		private TemplateVideoCreator creator;

		private bool uploaderRunning = false;
		private bool uploaderSearching = false;
		private object lockobject = new object();

		private Job unfinishedJob;
		private bool shouldCancel = false;
		#endregion fields

		#region properties
		public string LoggedInAccountUrl => (ActiveAccount != null) ? $"https://youtube.com/channel/{ActiveAccount.Id}" : null;

		public string LoggedInAccountTitle => ActiveAccount?.Title;

		public bool HasUnfinishedJob => File.Exists(currentUploadDetailsPath);

		public PathSettings Paths
		{
			get
			{
				return paths;
			}

			private set
			{
				paths = value;
				OnPropertyChaged();
			}
		}

		public bool IsActive
		{
			get { return active; }
			private set
			{
				active = value;
				OnPropertyChaged();
			}
		}

		public bool EndAfterUpload { get; set; }

		private Account ActiveAccount
		{
			get
			{
				return activeAccount;
			}

			set
			{
				activeAccount = value;
			}
		}

		public Category[] AvailableCategories => ActiveAccount?.AvailableCategories ?? new Category[] { Category.Default };

		public bool IsConnectedToAccount { get { return ActiveAccount != null; } }

		private ProcessWatcher ProcessWatcher
		{
			get
			{
				return watcher;
			}

			set
			{
				watcher = value;
			}
		}

		public ReadOnlyCollection<Process> ProcessesToWatch { get { return ProcessWatcher.Processes; } }
		public bool ShouldWaitForProcs { get { return ProcessWatcher.ShouldWaitForProcs; } set { ProcessWatcher.ShouldWaitForProcs = value; } }

		public IReadOnlyList<Template> Templates
		{
			get
			{
				return templates.AsReadOnly();
			}
			private set
			{
				templates = value.ToList();
				OnPropertyChaged();
			}
		}

		public List<Language> Languages
		{
			get
			{
				return languages;
			}

			set
			{
				languages = value;
				OnPropertyChaged();
			}
		}

		public string Message
		{
			get
			{
				return message;
			}

			set
			{
				message = value;
				OnPropertyChaged();
			}
		}

		public double Progress
		{
			get
			{
				return progress;
			}

			set
			{
				progress = value;
				OnPropertyChaged();
			}
		}

		private List<FileSystemWatcher> Watchers
		{
			get
			{
				if (watchers == null)
				{
					watchers = new List<FileSystemWatcher>();
				}

				return watchers;
			}
		}

		private List<string> Files
		{
			get
			{
				if (files == null)
				{
					files = new List<string>();
				}

				return files;
			}
		}

		public Job UnfinishedJob
		{
			get
			{
				return unfinishedJob;
			}

			set
			{
				unfinishedJob = value;
				OnPropertyChaged();
			}
		}

		#endregion properties

		public AutomationUploader()
		{
			if (!Directory.Exists("settings"))
			{
				Directory.CreateDirectory("settings");
			}

			if (File.Exists(templatesPath))
			{
				ReadTemplates();
				EnsureTemplateIdsAreUnique();
				EnsureTemplatesHaveCategory();
				EnsureTemplatesHaveLanguage();
			}

			EnsureStandardTemplateExists();

			if (File.Exists(accountJsonPath))
			{
				using (StreamReader reader = new StreamReader(accountJsonPath))
				{
					string savedAccountJson = reader.ReadToEnd();
					var savedAccount = JsonConvert.DeserializeObject<AccountJson>(savedAccountJson);

					var categories = savedAccount.categories?.Select(c => new Category(c.id, c.title)).ToArray();
					if (categories == null)
					{
						categories = new[] { Category.Default };
					}

					var region = savedAccount.region;
					if (region == null)
					{
						region = "DE";
					}

					ActiveAccount = new Account() { Id = savedAccount.id, Title = savedAccount.title, Access = new Authentification() { RefreshToken = savedAccount.refreshToken }, Region = savedAccount.region, AvailableCategories = categories };

					if (string.IsNullOrWhiteSpace(ActiveAccount?.Access?.AccessToken))
					{
						RefreshAccess();
					}
				}
			}

			if (File.Exists(selectedPathsJsonPath))
			{
				try
				{
					ReadPaths();
				}
				catch (Exception ex)
				{
					Debug.Write(ex.Message);

					Paths = new PathSettings();
					File.Delete(selectedPathsJsonPath);
				}
			}

			if (File.Exists(languagesPath))
			{
				try
				{
					ReadLanguages();
				}
				catch (Exception ex)
				{
					Debug.Write(ex.Message);

					Languages = new List<Language>(new Language[] { Language.Default });
					File.Delete(languagesPath);
				}
			}
			else if (ActiveAccount != null && ActiveAccount.Access != null && ActiveAccount.Access.AccessToken != null)
			{
				Languages = AccountCommunication.LoadYoutubeLanguages(ActiveAccount.Access.AccessToken).ToList();

				WriteLanguages();
			}

			foreach (var path in Paths)
			{
				if (!Templates.Any(t => t.Id == path.SelectedTemplateId))
				{
					path.SelectedTemplateId = 0;
				}
			}

			UnfinishedJob = LoadLastJob();
		}

		private void EnsureTemplatesHaveLanguage()
		{
			bool needsSave = false;
			foreach (var template in Templates)
			{
				if (template.DefaultLanguage == null)
				{
					template.DefaultLanguage = new Language() { Name = "Deutsch", Hl = "DE", Id = "DE" };
					needsSave = true;
				}
			}

			if (needsSave)
			{
				WriteTemplates();
			}
		}

		private void EnsureTemplatesHaveCategory()
		{
			bool needsSave = false;
			foreach (var template in Templates)
			{
				if (template.Category == null)
				{
					template.Category = new Category(20, "Gaming");
					needsSave = true;
				}
			}

			if (needsSave)
			{
				WriteTemplates();
			}
		}

		public Template CreateTemplate()
		{
			return CreateTemplate("neues Template", Languages.FirstOrDefault(lang => lang.Id.ToLower() == "de"), AvailableCategories.FirstOrDefault(c => c.Id == 20));
		}

		public Template CreateTemplate(string name, Language lang, Category cat)
		{
			return new Template(Templates.Select(t => t.Id).Max() + 1, name, lang, cat);
		}

		private void EnsureStandardTemplateExists()
		{
			if (!Templates.Any(t => t.Id == 0))
			{
				templates.Add(new Template(0, "Standard", Languages.FirstOrDefault(lang => lang.Id.ToUpper() == "DE"), ActiveAccount?.AvailableCategories.FirstOrDefault(c => c.Id == 20)));
				WriteTemplates();
			}
		}

		private void EnsureTemplateIdsAreUnique()
		{
			bool write = false;

			var ids = new List<int>();
			foreach (var template in Templates)
			{
				if (ids.Contains(template.Id))
				{
					write = true;
					template.Id = ids.Max() + 1;
				}
				ids.Add(template.Id);
			}

			if (write)
			{
				WriteTemplates();
			}
		}

		private void RefreshAccess()
		{
			ActiveAccount = AccountCommunication.RefreshAccess(ActiveAccount);
		}

		public void WritePaths()
		{
			var serialized = JsonConvert.SerializeObject(Paths);

			using (StreamWriter fileWriter = new StreamWriter(selectedPathsJsonPath, false))
			{
				fileWriter.Write(serialized);
			}
		}

		public void ReadPaths()
		{
			string json;
			using (StreamReader fileReader = new StreamReader(selectedPathsJsonPath))
			{
				json = fileReader.ReadToEnd();
			}
			Paths = PathSettings.Parse(json, Templates);
		}

		public void WriteLanguages()
		{
			var serialized = JsonConvert.SerializeObject(Languages);

			using (StreamWriter fileWriter = new StreamWriter(languagesPath, false))
			{
				fileWriter.Write(serialized);
			}
		}

		public void ReadLanguages()
		{
			string json;
			using (StreamReader fileReader = new StreamReader(languagesPath))
			{
				json = fileReader.ReadToEnd();
			}
			Languages = JsonConvert.DeserializeObject<List<Language>>(json);
		}

		public void WriteTemplates()
		{
			var serialized = JsonConvert.SerializeObject(Templates);

			using (StreamWriter fileWriter = new StreamWriter(templatesPath, false))
			{
				fileWriter.Write(serialized);
			}
		}

		public void ReadTemplates()
		{
			string json;
			using (StreamReader fileReader = new StreamReader(templatesPath))
			{
				json = fileReader.ReadToEnd();
			}
			Templates = new Collection<Template>(Template.ParseList(json));
		}

		public string GetAuthLoginScreenUrl(bool showAuthToken, bool logout = false)
		{
			return AccountCommunication.GetLogoffAndAuthUrl(showAuthToken, logout);
		}

		public bool ConnectToAccount(string authToken, bool useLocalHostRedirect = true)
		{
			ActiveAccount = AccountCommunication.LoadAccountDetails(AccountCommunication.ConnectAccount(authToken, useLocalHostRedirect));

			if (!string.IsNullOrWhiteSpace(ActiveAccount.Access.RefreshToken))
			{
				// Account wurde erfolgreich verbunden -> Kategorien laden.
				ActiveAccount = AccountCommunication.FillAccountWithAvailableVideoCategories(ActiveAccount);
				WriteAccount();

				Languages = AccountCommunication.LoadYoutubeLanguages(ActiveAccount.Access.AccessToken).ToList();
				WriteLanguages();
				return true;
			}

			return false;
		}

		public void AddTemplate(Template template)
		{
			templates.Add(template);
			EnsureTemplateIdsAreUnique();
		}

		public void UpdateTemplate(Template current)
		{
			var index = templates.IndexOf(templates.Single(t => t.Id == current.Id));
			templates[index] = current;
		}

		public void RemoveTemplateAt(int index)
		{
			var template = Templates[index];
			foreach (var path in Paths.Where(p => p.SelectedTemplateId == template.Id))
			{
				path.SelectedTemplateId = 0;
			}

			WritePaths();

			templates.RemoveAt(index);
			EnsureStandardTemplateExists();

			WriteTemplates();
		}

		public void RemoveAllTemplates()
		{
			foreach (var path in Paths)
			{
				path.SelectedTemplateId = 0;
			}

			WritePaths();

			EnsureStandardTemplateExists();
			var standardTemplate = Templates.Single(t => t.Id == 0);

			templates.Clear();
			templates.Add(standardTemplate);

			WriteTemplates();
		}

		public void ShiftTemplatePositions(Template first, Template second)
		{
			Template firstToChange = null;
			Template secondToChange = null;
			if (first != null 
				&& second != null 
				&& (firstToChange = Templates.FirstOrDefault(t => t.Id == first.Id)) != null 
				&& (secondToChange = Templates.FirstOrDefault(t => t.Id == second.Id)) != null)
			{
				ShiftTemplatePositionsAt(templates.IndexOf(firstToChange), templates.IndexOf(secondToChange));
			}
		}

		public void ShiftTemplatePositionsAt (int firstIndex, int secondIndex)
		{
			if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < Templates.Count && secondIndex < Templates.Count)
			{
				var save = templates[firstIndex];
				templates[firstIndex] = templates[secondIndex];
				templates[secondIndex] = save;
			}
		}

		private void WriteAccount()
		{
			var saveAccount = new AccountJson() { id = ActiveAccount.Id, title = ActiveAccount.Title, refreshToken = ActiveAccount.Access.RefreshToken, region = ActiveAccount.Region, categories = ActiveAccount.AvailableCategories.Select(c => new CategoriesJson() { id = c.Id, title = c.Title }).ToArray() };

			string json = JsonConvert.SerializeObject(saveAccount);

			using (StreamWriter writer = new StreamWriter(accountJsonPath, false))
			{
				writer.Write(json);
			}
		}

		public bool RevokeAccess()
		{
			var result = AccountCommunication.RevokeAccess(ActiveAccount);
			ActiveAccount = null;

			if (File.Exists(accountJsonPath))
			{
				File.Delete(accountJsonPath);
			}

			DeleteLastJobFile();

			return result;
		}

		public void RemovePath(string path)
		{
			if (Paths.ContainsPath(path))
			{
				paths.Remove(path);
			}
		}

		public PublishSettings[] GetPublishInformation()
		{
			return Paths.Where(p => !p.Inactive).Select(p => new PublishSettings(p, Templates.First(t => t.Id == p.SelectedTemplateId))).ToArray();
		}

		public async void StartAsync(PublishSettings[] infos)
		{
			await Task.Run(() => Start(infos));
		}

		private void Start(PublishSettings[] settings)
		{
			IsActive = true;

			ProcessWatcher.AllProcessesCompleted += AllProcessesCompleted;

			Files.Clear();
			Watchers.Clear();

			var publishInfos = new List<PublishInformation>();

			foreach (var pathSetting in settings)
			{
				var newInfo = new PublishInformation(pathSetting.PathInfo, pathSetting.StartDate, pathSetting.Template, pathSetting.CustomStartDayIndex);
				newInfo.IgnorePath = pathSetting.IgnorePath;
				newInfo.UploadPrivate = pathSetting.UploadPrivate;

				publishInfos.Add(newInfo);
			}

			creator = new TemplateVideoCreator(publishInfos);

			TryConnectAccount();
			if (ActiveAccount.Access?.AccessToken == null)
			{
				Message = "FEHLER: Verbindung zum Youtube-Account konnte nicht hergestellt werden.";
				Progress = 0;
				return;
			}

			UnfinishedJob = LoadLastJob();
			UploadFilesAsync();

			CreateWatchers(publishInfos.ToArray());

			SearchExistingVideos(publishInfos.ToArray());
		}

		public void SuspendProcessWatcher()
		{
			ProcessWatcher.Pause = true;
		}

		public void ResumeProcessWatcher()
		{
			ProcessWatcher.Pause = false;
		}

		private void AllProcessesCompleted(object sender, EventArgs e)
		{
			lock (lockobject)
			{
				if (EndAfterUpload && !uploaderRunning && !uploaderSearching)
				{
					EndUpload();
				}
			}
		}

		private void CreateWatchers(PublishInformation[] infos)
		{
			foreach (var pathFilterCombination in infos.Where(i => !i.IgnorePath).Select(i => i.PathInfo))
			{
				string path = pathFilterCombination.Path;
				string[] filters = pathFilterCombination.Filter.Split(';');

				foreach (var filter in filters)
				{
					watchers.Add(CreateWatcher(path, filter.Trim(), pathFilterCombination.SearchRecursively));
				}
			}
		}

		private void SearchExistingVideos(PublishInformation[] infos)
		{
			uploaderSearching = true;

			foreach (var pathFilterCombination in infos.Where(i => !i.IgnorePath).Select(i => i.PathInfo))
			{
				string path = pathFilterCombination.Path;
				string[] filters = pathFilterCombination.Filter.Split(';');

				foreach (var filter in filters)
				{
					try
					{
						AddFiles(path, filter.Trim(), pathFilterCombination.SearchRecursively, pathFilterCombination.SearchHidden);
					}
					catch (UnauthorizedAccessException)
					{ }
				}
			}

			uploaderSearching = false;

			if (!uploaderRunning)
			{
				Message = "Warte auf Dateien zum Upload...";
				UploadFilesAsync();
			}
		}

		private async void UploadFilesAsync()
		{
			await Task.Run(() => UploadFiles());
		}

		private void UploadFiles()
		{
			lock (lockobject)
			{
				if (uploaderRunning)
				{
					return;
				}

				uploaderRunning = true;
			}

			if (UnfinishedJob != null)
			{
				UploadJob(UnfinishedJob);
			}

			while (Files.Count > 0 && IsActive)
			{
				if (File.Exists(files.First()))
				{
					UploadVideo(files.First(), creator);
				}

				files.RemoveAt(0);
			}

			if (EndAfterUpload && !uploaderSearching && !ProcessWatcher.Pause && (!ProcessWatcher.ShouldWaitForProcs || ProcessWatcher.ShouldEnd))
			{
				// Fertig. Alle Dateien hochgeladen und alle überwachten Prozesse (falls vorhanden) beendet.
				EndUpload();
			}

			lock (lockobject)
			{
				uploaderRunning = false;
			}
		}

		private void EndUpload()
		{
			IsActive = false;

			while (Watchers.Count > 0)
			{
				Watchers.First().Created -= ReactOnFileChanges;
				Watchers.First().Changed -= ReactOnFileChanges;
				Watchers.First().Renamed -= ReactOnFileChanges;

				Watchers.First().Dispose();
				Watchers.RemoveAt(0);
			}

			ProcessWatcher.AllProcessesCompleted -= AllProcessesCompleted;
		}

		private void TryConnectAccount()
		{
			// Es muss sichergestellt sein, dass ein Account verbunden ist.
			for (int i = 0; i < 3 && ActiveAccount.Access?.AccessToken == null; i++)
			{
				for (int j = 0; j < 30 && i > 0; j++)
				{
					Message = $"Verbindung zum Youtube-Account konnte nicht hergestellt werden. Erneuter Versuch in {30 - j} Sekunden...";
					Thread.Sleep(1000);
				}

				Message = $"Stelle Verbindung zum Youtube-Account her - Versuch {i + 1} von 3...";
				ActiveAccount = AccountCommunication.RefreshAccess(ActiveAccount);
			}
		}

		public void Stop()
		{
			shouldCancel = true;
			EndUpload();
		}

		private FileSystemWatcher CreateWatcher(string path, string filter, bool searchRecursively)
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

			return watcher;
		}

		private void ReactOnFileChanges(object sender, FileSystemEventArgs e)
		{
			if (!Files.Contains(e.FullPath) && !Path.GetFileName(e.FullPath).StartsWith("_"))
			{
				AddFile(e.FullPath);
			}
		}

		private void UploadJob(Job job)
		{
			if (!File.Exists(job.SelectedVideo.Path))
			{
				DeleteLastJobFile();
				return;
			}

			SaveCurrentJob(job);

			UploadCommunication.ProgressChanged += ReactToProgressChanged;
			while (!UploadCommunication.Upload(ref job, ref shouldCancel))
			{
				job.UploadingAccount = AccountCommunication.RefreshAccess(job.UploadingAccount);
			}

			UploadCommunication.ProgressChanged -= ReactToProgressChanged;

			if (!shouldCancel)
			{
				OnUploadFinished(job.SelectedVideo.Title);
				DeleteLastJobFile();

				// Datei umbenennen, damit der Uploader nicht erneut versucht, sie hochzuladen.
				var movedPath = Path.GetDirectoryName(job.SelectedVideo.Path)
					+ "\\_" + Path.GetFileNameWithoutExtension(job.SelectedVideo.Path).Remove(0, 1)
					+ Path.GetExtension(job.SelectedVideo.Path);

				try
				{
					File.Move(job.SelectedVideo.Path, movedPath);
				}
				catch (IOException)
				{
				}
			}
		}

		private bool WaitForAccess(string fileName)
		{
			bool val = false;
			while (!val)
			{
				if (!File.Exists(fileName))
				{
					break;
				}

				try
				{
					using (StreamWriter writer = new StreamWriter(fileName, true))
					{
						val = true;
					}
				}
				catch (IOException)
				{
					Thread.Sleep(new TimeSpan(0, 0, 1));
				}
			}

			return val;
		}

		private void UploadVideo(string fileName, TemplateVideoCreator creator)
		{
			Video vid = creator.CreateVideo(fileName);

			bool waitResult = WaitForAccess(fileName);
			if (!waitResult)
			{
				// Video wurde gelöscht.
				return;
			}

			OnUploadStarted(vid.Title);

			Job job = null;
			while (job == null)
			{
				RefreshAccess();
				job = UploadCommunication.PrepareUpload(vid, ActiveAccount);
			}

			UploadJob(job);
		}

		private void ReactToProgressChanged(Communication.Youtube.ProgressChangedEventArgs args)
		{
			OnProgressChanged(args.FileName, args.Progress);
		}

		protected virtual void OnUploadStarted(string fileName)
		{
			AutomationEventArgs args = new AutomationEventArgs();
			args.FileName = fileName;
			args.Progress = 0;

			UploadStarted?.Invoke(args);
		}

		protected virtual void OnUploadFinished(string fileName)
		{
			AutomationEventArgs args = new AutomationEventArgs();
			args.FileName = fileName;
			args.Progress = 10000;

			UploadFinished?.Invoke(args);
		}

		protected virtual void OnProgressChanged(string fileName, double progress)
		{
			AutomationEventArgs args = new AutomationEventArgs();
			args.FileName = fileName;
			args.Progress = progress;

			ProgressChanged?.Invoke(args);
		}

		private void AddFiles(string path, string filters, bool searchRecursively, bool searchHidden)
		{
			try
			{
				if (!searchHidden && new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.Hidden))
				{
					return;
				}

				lock (lockobject)
				{
					if (!uploaderRunning)
					{
						Message = $"Durchsuche Verzeichnis nach Videodateien: {path}";
					}
				}

				string[] singleFilters = filters.Split(';');

				foreach (var filter in singleFilters)
				{
					var files = Directory.GetFiles(path, filter)
						.ToList();

					foreach (var file in files)
					{
						AddFile(file);
					}
				}

				if (searchRecursively)
				{
					Directory.GetDirectories(path)
						.ToList()
						.ForEach(s => AddFiles(s, filters, true, searchHidden));
				}
			}
			catch (UnauthorizedAccessException)
			{
			}
			catch (ThreadAbortException)
			{
			}
		}

		private void AddFile(string path)
		{
			if (!new FileInfo(path).Name.StartsWith("_") && !Files.Contains(path))
			{
				Files.Add(path);
				UploadFilesAsync();
			}
		}

		private Job LoadLastJob()
		{
			if (!File.Exists(currentUploadDetailsPath))
			{
				return null;
			}

			using (StreamReader reader = new StreamReader(currentUploadDetailsPath))
			{
				Job job = JsonConvert.DeserializeObject<Job>(reader.ReadToEnd());
				return job;
			}
		}

		private void SaveCurrentJob(Job job)
		{
			using (StreamWriter writer = new StreamWriter(currentUploadDetailsPath, false))
			{
				writer.Write(JsonConvert.SerializeObject(job));
			}
		}

		public void DeleteLastJobFile()
		{
			if (File.Exists(currentUploadDetailsPath))
			{
				File.Delete(currentUploadDetailsPath);
			}
		}

		public void AddProcessesToWatch(IEnumerable<Process> procs)
		{
			foreach (var proc in procs)
			{
				ProcessWatcher.Add(proc);
			}
		}

		public void ClearProcessesToWatch()
		{
			ProcessWatcher.Clear();
		}

		private void OnPropertyChaged([CallerMemberName] string caller = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
		}
	}

	public class AccountJson
	{
		public string id;
		public string title;
		public string refreshToken;
		public string region;
		public CategoriesJson[] categories;
	}

	public class CategoriesJson
	{
		public int id;
		public string title;
	}
}
