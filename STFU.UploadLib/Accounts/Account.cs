using STFU.UploadLib.Playlists;
using System.Collections.ObjectModel;
using System.ComponentModel;
using STFU.UploadLib.Videos;
using System.Runtime.CompilerServices;

namespace STFU.UploadLib.Accounts
{
	public class Account : INotifyPropertyChanged
	{
		#region Fields

		private string id;
		private string title;
		private string region;
		private ObservableCollection<Playlist> playlists;
		private Authentification access;
		private Category[] availableCategories;

		#endregion Fields

		#region Properties

		public string Id { get { return id; } set { id = value; OnPropertyChanged(); } }

		public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }

		public ObservableCollection<Playlist> Playlists { get { return playlists; } set { playlists = value; OnPropertyChanged(); } }

		public Authentification Access { get { return access; } set { access = value; OnPropertyChanged(); } }

		public string Region { get { return region; } set { region = value; OnPropertyChanged(); } }

		public Category[] AvailableCategories { get { return availableCategories; } set { availableCategories = value; OnPropertyChanged(); } }

		#endregion Properties

		#region NotifyProperty

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion NotifyProperty
	}
}
