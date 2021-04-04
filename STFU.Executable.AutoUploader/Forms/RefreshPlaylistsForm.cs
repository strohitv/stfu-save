using System;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Persistor;
using STFU.Lib.Youtube.Services;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class RefreshPlaylistsForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(RefreshPlaylistsForm));

		private PlaylistPersistor PlaylistPersistor { get; set; }
		private IYoutubeAccount Account { get; set; }

		public RefreshPlaylistsForm(PlaylistPersistor playlistPersistor, IYoutubeAccount account)
		{
			LOGGER.Info($"Initializing new instance of RefreshPlaylistsForm");

			InitializeComponent();

			PlaylistPersistor = playlistPersistor;
			Account = account;

			RefreshListView();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"Refreshing playlists of the youtube account");

			Enabled = false;

			PlaylistPersistor.Container.UnregisterAllPlaylists();

			var playlists = new YoutubePlaylistCommunicator().LoadPlaylists(Account);
			foreach (var playlist in playlists)
			{
				LOGGER.Info($"Found playlist '{playlist.Title}'");
				PlaylistPersistor.Container.RegisterPlaylist(playlist);
			}

			PlaylistPersistor.Save();

			RefreshListView();

			Enabled = true;
		}

		private void RefreshListView()
		{
			LOGGER.Debug($"Refilling the playlists list view");

			playlistsListView.Items.Clear();

			foreach (var playlist in PlaylistPersistor.Container.RegisteredPlaylists)
			{
				LOGGER.Debug($"Adding playlist '{playlist.Title}' to list view");

				ListViewItem item = new ListViewItem(playlist.Title);
				item.SubItems.Add(playlist.Id);
				item.SubItems.Add(playlist.PublishedAt.ToString("dd.MM.yyyy HH:mm"));

				playlistsListView.Items.Add(item);
			}
		}
	}
}
