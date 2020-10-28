using System;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Persistor;
using STFU.Lib.Youtube.Services;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class RefreshPlaylistsForm : Form
	{
		private PlaylistPersistor PlaylistPersistor { get; set; }
		private IYoutubeAccount Account { get; set; }

		public RefreshPlaylistsForm(PlaylistPersistor playlistPersistor, IYoutubeAccount account)
		{
			InitializeComponent();

			PlaylistPersistor = playlistPersistor;
			Account = account;

			RefreshListView();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			Enabled = false;

			PlaylistPersistor.Container.UnregisterAllPlaylists();

			var playlists = new YoutubePlaylistCommunicator().LoadPlaylists(Account);
			foreach (var playlist in playlists)
			{
				PlaylistPersistor.Container.RegisterPlaylist(playlist);
			}

			PlaylistPersistor.Save();

			RefreshListView();

			Enabled = true;
		}

		private void RefreshListView()
		{
			playlistsListView.Items.Clear();

			foreach (var playlist in PlaylistPersistor.Container.RegisteredPlaylists)
			{
				ListViewItem item = new ListViewItem(playlist.Title);
				item.SubItems.Add(playlist.Id);
				item.SubItems.Add(playlist.PublishedAt.ToString("dd.MM.yyyy HH:mm"));

				playlistsListView.Items.Add(item);
			}
		}
	}
}
