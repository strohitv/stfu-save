using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using STFU.Lib.Interfaces;

namespace STFU.UploadLib
{
	public class Uploader : IUploader, INotifyPropertyChanged
	{
		private ObservableCollection<Account> accounts;

		List<string[]> filters = new List<string[]>();

		public ObservableCollection<Account> Accounts { get { return accounts; } set { accounts = value; OnPropertyChanged("Accounts"); } }

		public void GetVideoIdsForPlaylist(string rToken, string playlistId)
		{
			var acc = AccountCommunication.RefreshAccess(new Account() { Access = new Authentification() { RefreshToken = rToken } });
			var videoIdList = WebService.GetPlaylistItems(acc.Access.AccessToken, playlistId);

			foreach (var videoId in videoIdList)
			{
				Trace.WriteLine(videoId);
			}
		}

		public void Test(string rToken)
		{
			//var acc = AccountCommunication.RefreshAccess(new Account() { Access = new Authentification() { RefreshToken = rToken } });

			//Process proc = null;
			//var procs = Process.GetProcessesByName("megui");
			//if (procs.Length > 0)
			//{
			//	proc = procs[0];
			//}

			//List<string> files = GetFiles(filters);

			//while ((proc != null && !proc.HasExited) || files.Count > 0)
			//{
			//	foreach (var file in files)
			//	{
			//		var newfile = Path.GetDirectoryName(file) + "\\_" + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file);

			//		bool val = false;
			//		while (!val)
			//		{
			//			if (!File.Exists(file))
			//			{
			//				break;
			//			}

			//			try
			//			{
			//				File.Move(file, newfile);
			//				val = true;
			//			}
			//			catch (IOException)
			//			{
			//				Thread.Sleep(new TimeSpan(0, 3, 0));
			//			}
			//		}

			//		if (!val)
			//		{
			//			// Datei existiert nicht mehr.
			//			continue;
			//		}

			//		Video vid = new Video(newfile)
			//		{
			//			//Category = 20,
			//			Description = string.Empty,
			//			Title = Path.GetFileName(newfile),
			//			//DefaultLanguage = "de",
			//			IsEmbeddable = true,
			//			License = Videos.License.Youtube,
			//			Privacy = PrivacyStatus.Private,
			//			PublicStatsViewable = false
			//		};
			//		//vid.snippet = new VideoSnippet() { categoryId = 20, description = string.Empty, tags = new string[] { }, title = vid.Name, defaultLanguage = "de" };
			//		//vid.status = new VideoStatus() { embeddable = true, licence = Licences.Youtube, privacyStatus = PrivacyValues.Private, publicStatsViewable = false };

			//		Trace.WriteLine(string.Format("Lade Datei '{0}' hoch", vid.Title));

			//		Job job = new Job() { SelectedVideo = vid, UploadingAccount = acc, Status = new UploadDetails() };
			//		while (!UploadCommunication.Upload(ref job))
			//		{
			//			acc = AccountCommunication.RefreshAccess(acc);
			//		}
			//	}

			//	files = GetFiles(filters);

			//	procs = Process.GetProcessesByName("megui");
			//	if (procs.Length > 0)
			//	{
			//		proc = procs[0];
			//	}
			//}

			//var p = new Process();
			//p.StartInfo = new ProcessStartInfo("shutdown.exe", "-s -t 300");
			//p.Start();
		}

		private List<string> GetFiles(List<string[]> filters)
		{
			filters.Clear();
			filters.Add(new[] { @"V:\kodiert\ZZZ_Other", "*.mkv" });
			filters.Add(new[] { @"V:\kodiert\018_CM", "CM_*.mkv" });
			filters.Add(new[] { @"V:\kodiert\020_OoT", "ZOoT_*.mkv" });
			filters.Add(new[] { @"V:\kodiert\014_Pokemon_FR_LPT\", "Pkmn_FR_*.mkv" });
			filters.Add(new[] { @"V:\kodiert\021_MKDD", "MKDD_*.mkv" });
			filters.Add(new[] { @"V:\kodiert\AAA_Zelda_ALttP", "ZALttP_*.mkv" });

			List<string> files = new List<string>();

			foreach (var item in filters)
			{
				files.AddRange(Directory.GetFiles(item[0], item[1]).Where(file => !Path.GetFileName(file).StartsWith("_")));
			}

			return files;
		}

		#region NotifyProperty

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion NotifyProperty
	}
}
