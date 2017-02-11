using STFU.UploadLib.Playlists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.UploadLib.Accounts
{
	public class Account : INotifyPropertyChanged
	{
		#region Fields

		private string id;
		private string title;
		private ObservableCollection<Playlist> playlists;
		private Authentification access;

		#endregion Fields

		#region Properties

		public string Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
		public string Title { get { return title; } set { title = value; OnPropertyChanged("Title"); } }
		public ObservableCollection<Playlist> Playlists { get { return playlists; } set { playlists = value; OnPropertyChanged("Playlists"); } }
		internal Authentification Access { get { return access; } set { access = value; OnPropertyChanged("Access"); } }

		#endregion Properties

		#region NotifyProperty

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		#endregion NotifyProperty
	}
}
