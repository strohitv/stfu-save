using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using STFU.UploadLib.Accounts;
using STFU.UploadLib.Communication.Youtube;
using STFU.UploadLib.Queue;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Automation
{
	public delegate void UploadStartedEventHandler(AutomationEventArgs e);
	public delegate void UploadFinishedEventHandler(AutomationEventArgs e);
	public delegate void UploadProgressChangedEventHandler(AutomationEventArgs e);
	public delegate void UploaderFinishedEventHandler(EventArgs e);

	public class AutomationUploader
	{
		#region fields
		private PathSettings paths = new PathSettings();
		private Uploader uploader = new Uploader();
		private Account activeAccount = null;
		private Thread uploadThread = null;
		private bool active = false;

		private const string selectedPathsJsonPath = "Paths.json";
		private const string accountJsonPath = "Account.json";
		private const string currentUploadDetailsPath = "CurrentUpload.json";

		public event UploadStartedEventHandler UploadStarted;
		public event UploadFinishedEventHandler UploadFinished;
		public event UploadProgressChangedEventHandler ProgressChanged;
		public event UploaderFinishedEventHandler UploaderFinished;

		private List<string> files = new List<string>();
		#endregion fields

		#region properties
		public string LoggedInAccountUrl { get { return (ActiveAccount != null) ? $"https://youtube.com/channel/{ActiveAccount.Id}" : null; } }
		public string LoggedInAccountTitle { get { return ActiveAccount?.Title; } }

		public PathSettings Paths
		{
			get
			{
				return paths;
			}

			private set
			{
				paths = value;
			}
		}

		public bool IsActive { get { return active; } }

		private Uploader Uploader
		{
			get
			{
				return uploader;
			}

			set
			{
				uploader = value;
			}
		}

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

		public bool IsConnectedToAccount { get { return ActiveAccount != null; } }
		#endregion properties

		public AutomationUploader()
		{
			if (File.Exists(accountJsonPath))
			{
				using (StreamReader reader = new StreamReader(accountJsonPath))
				{
					string savedAccountJson = reader.ReadToEnd();
					var savedAccount = JsonConvert.DeserializeObject<AccountJson>(savedAccountJson);
					ActiveAccount = new Account() { Id = savedAccount.id, Title = savedAccount.title, Access = new Authentification() { RefreshToken = savedAccount.refreshToken } };

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

					paths = new PathSettings();
					File.Delete(selectedPathsJsonPath);
				}
			}
		}

		private void RefreshAccess()
		{
			ActiveAccount = AccountCommunication.RefreshAccess(ActiveAccount);
			//refreshToken = null;

			if (string.IsNullOrWhiteSpace(ActiveAccount.Access.AccessToken))
			{
				ActiveAccount = null;

				if (File.Exists(accountJsonPath))
				{
					File.Delete(accountJsonPath);
				}
			}
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
			Paths = PathSettings.Parse(json); // JsonConvert.DeserializeObject<PathSettings>(json);
		}

		public void Reset()
		{
			Paths = new PathSettings();
		}

		public string GetAuthLoginScreenUrl(bool showAuthToken)
		{
			return AccountCommunication.GetLogoffAndAuthUrl(showAuthToken);
		}

		public bool ConnectToAccount(string authToken)
		{
			ActiveAccount = AccountCommunication.LoadAccountDetails(AccountCommunication.ConnectAccount(authToken));

			if (!string.IsNullOrWhiteSpace(ActiveAccount.Access.RefreshToken))
			{
				WriteAccount();
				return true;
			}

			return false;
		}

		private void WriteAccount()
		{
			var saveAccount = new AccountJson() { id = ActiveAccount.Id, title = ActiveAccount.Title, refreshToken = ActiveAccount.Access.RefreshToken };

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

		public void Remove(string path)
		{
			if (Paths.ContainsPath(path))
			{
				paths.Remove(path);
			}
		}

		public void Start()
		{
			// Es muss sichergestellt sein, dass ein Account verbunden ist.
			if (ActiveAccount == null)
			{
				return;
			}

			active = true;

			uploadThread = new Thread(RunAutomationUploader);
			uploadThread.Name = "AutomationUploaderThread";
			uploadThread.Start();
		}

		public void Stop(bool kill)
		{
			active = false;

			while (kill && uploadThread != null && uploadThread.IsAlive)
			{
				uploadThread.Abort();
			}
		}

		private void RunAutomationUploader()
		{
			Process proc = null;
			var procs = Process.GetProcessesByName("megui");
			if (procs.Length > 0)
			{
				proc = procs[0];
			}

			Job lastJob = LoadLastJob();
			if (lastJob != null)
			{
				UploadJob(lastJob);
			}

			while (active)
			{
				RefreshFiles();

				//if ((proc == null || proc.HasExited) && files.Count == 0)
				//{
				//	break;
				//}

				foreach (var fileName in files)
				{
					UploadVideo(fileName);
				}

				procs = Process.GetProcessesByName("megui");
				if (procs.Length > 0)
				{
					proc = procs[0];
				}
			}

			active = false;
			OnUploaderFinished();

			//var p = new Process();
			//p.StartInfo = new ProcessStartInfo("shutdown.exe", "-s -t 300");
			//p.Start();
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
			while (!UploadCommunication.Upload(ref job))
			{
				job.UploadingAccount = AccountCommunication.RefreshAccess(job.UploadingAccount);
			}

			OnUploadFinished(job.SelectedVideo.snippet.title);

			UploadCommunication.ProgressChanged -= ReactToProgressChanged;
			DeleteLastJobFile();
		}

		private bool WaitForAccessAndThenRenameVideo(string fileName, string newFileName)
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
					File.Move(fileName, newFileName);
					val = true;
				}
				catch (IOException)
				{
					Thread.Sleep(new TimeSpan(0, 3, 0));
				}
			}

			if (!val)
			{
				// Datei existiert nicht mehr.
				return false;
			}

			return true;
		}

		private void UploadVideo(string fileName)
		{
			var videoTitle = Path.GetFileNameWithoutExtension(fileName);
			var newfile = Path.GetDirectoryName(fileName) + "\\_" + Path.GetFileNameWithoutExtension(fileName).Remove(0, 1) + Path.GetExtension(fileName);

			bool renamingResult = WaitForAccessAndThenRenameVideo(fileName, newfile);
			if (!renamingResult)
			{
				// Video ist nicht mehr am Pfad vorzufinden.
				return;
			}

			Video vid = new Video(newfile);
			vid.snippet = new VideoSnippet()
			{
				categoryId = 20,
				description = string.Empty,
				tags = new string[] { },
				title = videoTitle,
				defaultLanguage = "de"
			};
			vid.status = new VideoStatus()
			{
				embeddable = true,
				licence = Licences.Youtube,
				privacyStatus = PrivacyValues.Private,
				publicStatsViewable = false
			};

			OnUploadStarted(vid.snippet.title);

			//Job job = new Job() { SelectedVideo = vid, UploadingAccount = ActiveAccount, Status = new UploadDetails() };

			Job job = UploadCommunication.PrepareUpload(vid, ActiveAccount);

			UploadJob(job);
		}

		private void ReactToProgressChanged(ProgressChangedEventArgs args)
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

		protected virtual void OnUploaderFinished()
		{
			UploaderFinished?.Invoke(new EventArgs());
		}

		private void RefreshFiles()
		{
			files = new List<string>();

			foreach (var pathFilterCombination in Paths)
			{
				string path = pathFilterCombination.Path;
				string[] filters = pathFilterCombination.Filter.Split(';');

				foreach (var filter in filters)
				{
					files.AddRange(Directory.GetFiles(path, filter.Trim(), (pathFilterCombination.SearchRecursively) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(file => !Path.GetFileName(file).StartsWith("_")));
				}
			}

			// Todo: Struktur erweitern, sodass das ganze hier auch einen Sinn hat...
			files = files.GroupBy(file => file).Select(group => group.Key).ToList();
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
	}

	public class AccountJson
	{
		public string id;
		public string title;
		public string refreshToken;
	}
}
