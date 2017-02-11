using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
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
		private string refreshToken = null;
		private Thread uploadThread = null;
		private bool active = false;

		private string jsonPath = "Paths.json";

		public event UploadStartedEventHandler UploadStarted;
		public event UploadFinishedEventHandler UploadFinished;
		public event UploadProgressChangedEventHandler ProgressChanged;

		private List<string> files = new List<string>();

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

		public AutomationUploader()
		{
			if (File.Exists("rt"))
			{
				using (StreamReader reader = new StreamReader("rt"))
				{
					refreshToken = reader.ReadToEnd();
				}
			}
			if (File.Exists(jsonPath))
			{
				try
				{
					ReadXml();
				}
				catch (Exception ex)
				{
					Debug.Write(ex.Message);

					paths = new SerializableDictionary<string, string>();
					File.Delete(jsonPath);
				}
			}
		}

		public void WriteXml()
		{
			var serialized = JsonConvert.SerializeObject(Paths);

			using (StreamWriter fileWriter = new StreamWriter(jsonPath, false))
			{
				fileWriter.Write(serialized);
			}
		}

		public void ReadXml()
		{
			string json;
			using (StreamReader fileReader = new StreamReader(jsonPath))
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
			refreshToken = null;
			ActiveAccount = AccountCommunication.AddAccount(authToken);

			if (!string.IsNullOrWhiteSpace(ActiveAccount.Access.RefreshToken))
			{
				using (StreamWriter writer = new StreamWriter("rt", false))
				{
					writer.Write(ActiveAccount.Access.RefreshToken);
				}
				return true;
			}

			return false;
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
			if (!string.IsNullOrWhiteSpace(refreshToken))
			{
				ActiveAccount = AccountCommunication.RefreshAccess(new Account() { Access = new Authentification() { RefreshToken = refreshToken } });
				refreshToken = null;
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
					OnUploadStarted(fileName);

					UploadVideo(fileName);

					OnUploadFinished(fileName);
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
			vid.snippet = new VideoSnippet() { categoryId = 20, description = string.Empty, tags = new string[] { }, title = vid.Name.Remove(0,1), defaultLanguage = "de" };
			vid.status = new VideoStatus() { embeddable = true, licence = Licences.Youtube, privacyStatus = PrivacyValues.Private, publicStatsViewable = false };

			Job job = new Job() { SelectedVideo = vid, UploadingAccount = ActiveAccount, Status = new UploadDetails() };

			UploadCommunication.ProgressChanged += ReactToProgressChanged;
			while (!UploadCommunication.Upload(ref job))
			{
				ActiveAccount = AccountCommunication.RefreshAccess(ActiveAccount);
			}
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
			args.Progress = 100;

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
}
