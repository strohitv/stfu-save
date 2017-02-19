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

	public class AutomationUploader
	{
		private Dictionary<string, string> paths = new Dictionary<string, string>();
		private Uploader uploader = new Uploader();
		private Account activeAccount = null;
		private Thread uploadThread = null;
		private bool active = false;

		private const string selectedPathsJsonPath = "Paths.json";
		private const string accountJsonPath = "Account.json";

		public event UploadStartedEventHandler UploadStarted;
		public event UploadFinishedEventHandler UploadFinished;
		public event UploadProgressChangedEventHandler ProgressChanged;

		private List<string> files = new List<string>();

		public string LoggedInAccountUrl { get { return (ActiveAccount != null) ? $"https://youtube.com/channel/{ActiveAccount.Id}" : null; } }
		public string LoggedInAccountTitle { get { return ActiveAccount?.Title; } }

		public Dictionary<string, string> Paths
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

					paths = new SerializableDictionary<string, string>();
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
			Paths = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		}

		public void Reset()
		{
			Paths = new SerializableDictionary<string, string>();
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
			var saveAccount = new AccountJson() { id = ActiveAccount.Id, title = ActiveAccount.Title, refreshToken= ActiveAccount.Access.RefreshToken };

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

			return result;
		}

		public void Remove(string path)
		{
			if (Paths.ContainsKey(path))
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

			if (kill && uploadThread != null && uploadThread.IsAlive)
			{
				uploadThread.Abort();
			}
		}

		private void RunAutomationUploader()
		{
			while (active)
			{
				RefreshFiles();

				foreach (var fileName in files)
				{
					UploadVideo(fileName);
				}
			}
		}

		private void UploadVideo(string fileName)
		{
			var newfile = Path.GetDirectoryName(fileName) + "\\_" + Path.GetFileNameWithoutExtension(fileName) + Path.GetExtension(fileName);

			bool val = false;
			while (!val)
			{
				if (!File.Exists(fileName))
				{
					break;
				}

				try
				{
					File.Move(fileName, newfile);
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
				return;
			}

			Video vid = new Video(newfile);
			vid.snippet = new VideoSnippet() { categoryId = 20, description = string.Empty, tags = new string[] { }, title = vid.Name.Remove(0, 1), defaultLanguage = "de" };
			vid.status = new VideoStatus() { embeddable = true, licence = Licences.Youtube, privacyStatus = PrivacyValues.Private, publicStatsViewable = false };

			OnUploadStarted(vid.snippet.title);

			Job job = new Job() { SelectedVideo = vid, UploadingAccount = ActiveAccount, Status = new UploadDetails() };

			UploadCommunication.ProgressChanged += ReactToProgressChanged;
			while (!UploadCommunication.Upload(ref job))
			{
				ActiveAccount = AccountCommunication.RefreshAccess(ActiveAccount);
			}

			OnUploadFinished(vid.snippet.title);

			UploadCommunication.ProgressChanged -= ReactToProgressChanged;
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

		private void RefreshFiles()
		{
			files = new List<string>();

			foreach (var pathFilterCombination in Paths)
			{
				string path = pathFilterCombination.Key;
				string[] filters = pathFilterCombination.Value.Split(';');

				foreach (var filter in filters)
				{
					files.AddRange(Directory.GetFiles(path, filter.Trim()).Where(file => !Path.GetFileName(file).StartsWith("_")));
				}
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
