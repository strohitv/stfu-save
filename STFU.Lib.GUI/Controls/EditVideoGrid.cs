using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Playlistservice;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.GUI.Controls
{
	public partial class EditVideoGrid : UserControl
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(EditVideoGrid));

		private IYoutubeCategoryContainer categoryContainer;
		private IYoutubeLanguageContainer languageContainer;
		private IYoutubePlaylistContainer playlistContainer;
		private IPlaylistServiceConnectionContainer pscContainer;
		private bool isNewUpload = false;

		private IYoutubeVideo video;
		public IYoutubeVideo Video
		{
			get
			{
				LOGGER.Info($"Returning Video");
				LOGGER.Info(video);

				return video;
			}
			private set
			{
				LOGGER.Info($"Receiving video to edit");

				video = value;
				RefreshView();
			}
		}

		private INotificationSettings notificationSettings;
		public INotificationSettings NotificationSettings
		{
			get
			{
				return notificationSettings;
			}
			private set
			{
				notificationSettings = value;
				RefreshNotificationSettings();
			}
		}
		public bool HasMailPrivilegue { get; private set; }

		public bool IsNewUpload
		{
			get
			{
				return isNewUpload;
			}
			set
			{
				isNewUpload = value;
				RefreshCheckboxesVisibility();
			}
		}

		public IPlaylistServiceConnectionContainer PscContainer
		{
			get
			{
				return pscContainer;
			}
			set
			{
				pscContainer = value;
				RefreshPlaylistServiceControls();
			}
		}

		private void RefreshCheckboxesVisibility()
		{
			notifySubscribersCheckbox.Visible = autoLevelsCheckbox.Visible = stabilizeCheckbox.Visible = IsNewUpload;
		}

		public EditVideoGrid()
		{
			LOGGER.Info($"Initializing new EditVideoGrid");

			InitializeComponent();
		}

		public void Fill(IYoutubeVideo video, INotificationSettings notificationSettings, bool hasMailPrivilegue, IYoutubeCategoryContainer catContainer,
			IYoutubeLanguageContainer langContainer, IYoutubePlaylistContainer plContainer, IPlaylistServiceConnectionContainer pscContainer)
		{
			LOGGER.Info($"Filling video '{video.Title}' and containers into this control");

			categoryContainer = catContainer;
			RefreshCategories();

			languageContainer = langContainer;
			RefreshLanguages();

			playlistContainer = plContainer;
			RefreshPlaylists();

			HasMailPrivilegue = hasMailPrivilegue;
			Video = video;
			NotificationSettings = notificationSettings;

			PscContainer = pscContainer;
		}

		private void RefreshPlaylists()
		{
			LOGGER.Debug($"Refreshing playlists");

			playlistsCombobox.Items.Clear();

			foreach (var playlist in playlistContainer.RegisteredPlaylists)
			{
				playlistsCombobox.Items.Add(playlist.Title);
				choosePlaylistCombobox.Items.Add(playlist.Title);
			}
		}

		private void RefreshLanguages()
		{
			LOGGER.Debug($"Refreshing languages");

			defaultLanguageCombobox.Items.Clear();

			foreach (var lang in languageContainer.RegisteredLanguages)
			{
				defaultLanguageCombobox.Items.Add(lang.Name);
			}
		}

		private void RefreshCategories()
		{
			LOGGER.Debug($"Refreshing categories");

			categoryCombobox.Items.Clear();

			foreach (var cat in categoryContainer.RegisteredCategories)
			{
				categoryCombobox.Items.Add(cat.Title);
			}
		}

		private void RefreshView()
		{
			LOGGER.Debug($"Refreshing view");

			titleTextbox.Text = video.Title;
			descriptionTextbox.Text = video.Description;
			tagsTextbox.Text = string.Join(", ", video.Tags);
			thumbnailTextbox.Text = video.ThumbnailPath;

			switch (video.Privacy)
			{
				case PrivacyStatus.Public:
					privacyCombobox.SelectedIndex = 0;
					break;
				case PrivacyStatus.Unlisted:
					privacyCombobox.SelectedIndex = 1;
					break;
				case PrivacyStatus.Private:
					privacyCombobox.SelectedIndex = 2;
					break;
			}

			if (video.PublishAt.HasValue)
			{
				publishAtDatetimepicker.Value = video.PublishAt.Value;
			}

			publishAtCheckbox.Enabled = video.Privacy == PrivacyStatus.Private;
			publishAtCheckbox.Checked = video.PublishAt.HasValue && (video.Privacy == PrivacyStatus.Private);
			publishAtDatetimepicker.Enabled = publishAtCheckbox.Checked;

			if (video.Category != null && categoryCombobox.Items.Contains(video.Category.Title))
			{
				categoryCombobox.SelectedIndex = categoryCombobox.Items.IndexOf(video.Category.Title);
			}

			if (video.DefaultLanguage != null && defaultLanguageCombobox.Items.Contains(video.DefaultLanguage.Name))
			{
				defaultLanguageCombobox.SelectedIndex = defaultLanguageCombobox.Items.IndexOf(video.DefaultLanguage.Name);
			}

			licenseCombobox.SelectedIndex = video.License == License.Youtube ? 0 : 1;

			isEmbeddableCheckbox.Checked = video.IsEmbeddable;
			publicStatsViewableCheckbox.Checked = video.PublicStatsViewable;
			notifySubscribersCheckbox.Checked = video.NotifySubscribers;
			autoLevelsCheckbox.Checked = video.AutoLevels;
			stabilizeCheckbox.Checked = video.Stabilize;

			addToPlaylistCheckbox.Checked = playlistsCombobox.Enabled = video.AddToPlaylist;
			var pl = playlistContainer.RegisteredPlaylists.FirstOrDefault(p => p.Id == video.PlaylistId);
			if (pl != null)
			{
				playlistsCombobox.SelectedIndex = playlistContainer.RegisteredPlaylists.ToList().IndexOf(pl);
			}
			else if (playlistsCombobox.Items.Count > 0)
			{
				playlistsCombobox.SelectedIndex = 0;
			}

			var maxTitleLength = YoutubeVideo.MaxTitleLength;
			titleCharacterCountLabel.Text = $"Zeichen vergeben: {titleTextbox.Text.Length} von {maxTitleLength}. Übrig: {maxTitleLength - titleTextbox.Text.Length} Zeichen";
			titleCharacterCountLabel.ForeColor = titleTextbox.Text.Length > maxTitleLength ? Color.Red : Color.Black;

			var maxDescriptionLength = YoutubeVideo.MaxDescriptionLength;
			descriptionCharacterCountLabel.Text = $"Zeichen vergeben: {descriptionTextbox.Text.Length} von {maxDescriptionLength}. Übrig: {maxDescriptionLength - descriptionTextbox.Text.Length} Zeichen";
			titleCharacterCountLabel.ForeColor = descriptionTextbox.Text.Length > maxDescriptionLength ? Color.Red : Color.Black;

			var tags = tagsTextbox.Text
				.Replace(Environment.NewLine, string.Empty)
				.Split(',')
				.Select(t => t.Trim())
				.ToArray();

			RefreshTagsCharacterCountLabel(tags);
		}

		private void RefreshNotificationSettings()
		{
			LOGGER.Debug($"Refreshing notification settings");

			desktopNotificationVideoFoundCheckbox.Checked = NotificationSettings.NotifyOnVideoFoundDesktop;
			desktopNotificationUploadStartedCheckbox.Checked = NotificationSettings.NotifyOnVideoUploadStartedDesktop;
			desktopNotificationUploadSuccesfulCheckbox.Checked = NotificationSettings.NotifyOnVideoUploadFinishedDesktop;
			desktopNotificationUploadFailedCheckbox.Checked = NotificationSettings.NotifyOnVideoUploadFailedDesktop;

			mailNotificationsGroupBox.Enabled = HasMailPrivilegue;
			mailNofiticationWarningLabel.Visible = !HasMailPrivilegue;

			mailReceiverTextbox.Text = NotificationSettings.MailReceiver;
			mailNotificationVideoFoundCheckbox.Checked = NotificationSettings.NotifyOnVideoFoundMail;
			mailNotificationUploadStartedCheckbox.Checked = NotificationSettings.NotifyOnVideoUploadStartedMail;
			mailNotificationUploadSuccesfulCheckbox.Checked = NotificationSettings.NotifyOnVideoUploadFinishedMail;
			mailNotificationUploadFailedCheckbox.Checked = NotificationSettings.NotifyOnVideoUploadFailedMail;
		}

		private void titleTextbox_TextChanged(object sender, EventArgs e)
		{
			var maxLength = YoutubeVideo.MaxTitleLength;
			titleCharacterCountLabel.Text = $"Zeichen vergeben: {titleTextbox.Text.Length} von {maxLength}. Übrig: {maxLength - titleTextbox.Text.Length} Zeichen";
			titleCharacterCountLabel.ForeColor = titleTextbox.Text.Length > maxLength ? Color.Red : Color.Black;

			Video.Title = titleTextbox.Text;
		}

		private void descriptionTextbox_TextChanged(object sender, EventArgs e)
		{
			var maxLength = YoutubeVideo.MaxDescriptionLength;
			descriptionCharacterCountLabel.Text = $"Zeichen vergeben: {descriptionTextbox.Text.Length} von {maxLength}. Übrig: {maxLength - descriptionTextbox.Text.Length} Zeichen";
			descriptionCharacterCountLabel.ForeColor = descriptionTextbox.Text.Length > maxLength ? Color.Red : Color.Black;

			Video.Description = descriptionTextbox.Text;
		}

		private void tagsTextbox_TextChanged(object sender, EventArgs e)
		{
			var tags = tagsTextbox.Text
				.Replace(Environment.NewLine, string.Empty)
				.Split(',')
				.Select(t => t.Trim())
				.ToArray();

			RefreshTagsCharacterCountLabel(tags);

			Video.Tags.Clear();
			foreach (var tag in tags)
			{
				Video.Tags.Add(tag);
			}
		}

		private void RefreshTagsCharacterCountLabel(string[] tags)
		{
			var maxSingleTagLength = YoutubeVideo.MaxSingleTagLength;
			var maxCompleteLength = YoutubeVideo.MaxTagsLength;

			string allTagsString = Aggregate(tags.ToArray());

			tagsCharacterCountLabel.Text = $"Zeichen vergeben: {allTagsString.Length} von {maxCompleteLength}. Übrig: {maxCompleteLength - allTagsString.Length} Zeichen";

			bool hasIllegalTags = tags.Any(t => t.Length > maxSingleTagLength);
			if (hasIllegalTags)
			{
				var invalidTagsString = Aggregate(tags.Where(t => t.Length > maxSingleTagLength).ToArray());
				tagsCharacterCountLabel.Text += $"{Environment.NewLine}Folgende Tags überschreiten die Maximallänge von {maxSingleTagLength} Zeichen: {invalidTagsString}";

				var onlyValidTagsString = Aggregate(tags.Where(t => t.Length <= maxSingleTagLength).ToArray());
				tagsCharacterCountLabel.Text += $"{Environment.NewLine}Zeichen vergeben (nur gültige Tags): {onlyValidTagsString.Length} von {maxCompleteLength}. Übrig: {maxCompleteLength - onlyValidTagsString.Length} Zeichen";
			}

			tagsCharacterCountLabel.ForeColor = allTagsString.Length > maxCompleteLength || hasIllegalTags ? Color.Red : Color.Black;
		}

		private string Aggregate(string[] list)
		{
			string aggregated = string.Empty;

			if (list != null && list.Length >= 1)
			{
				if (list.Length > 1)
				{
					aggregated = list.Aggregate((a, b) => $"{a},{b}");
				}
				else
				{
					aggregated = list.First();
				}
			}

			return aggregated;
		}

		private void thumbnailTextbox_TextChanged(object sender, EventArgs e)
		{
			Video.ThumbnailPath = thumbnailTextbox.Text;
		}

		private void privacyCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			publishAtCheckbox.Enabled = privacyCombobox.SelectedIndex == 2;

			if (privacyCombobox.SelectedIndex != 2)
			{
				publishAtCheckbox.Checked = false;
			}

			switch (privacyCombobox.SelectedIndex)
			{
				case 0:
					Video.Privacy = PrivacyStatus.Public;
					break;
				case 1:
					Video.Privacy = PrivacyStatus.Unlisted;
					break;
				default:
					Video.Privacy = PrivacyStatus.Private;
					break;
			}
		}

		private void publishAtCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			publishAtDatetimepicker.Enabled = publishAtCheckbox.Checked;
			Video.PublishAt = publishAtCheckbox.Checked ? (DateTime?)publishAtDatetimepicker.Value : null;
		}

		private void publishAtDatetimepicker_ValueChanged(object sender, EventArgs e)
		{
			Video.PublishAt = (DateTime?)publishAtDatetimepicker.Value;
		}

		private void categoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Video.Category = categoryContainer.RegisteredCategories.ElementAt(categoryCombobox.SelectedIndex);
		}

		private void defaultLanguageCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Video.DefaultLanguage = languageContainer.RegisteredLanguages.ElementAt(defaultLanguageCombobox.SelectedIndex);
		}

		private void licenseCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Video.License = (License)licenseCombobox.SelectedIndex;
		}

		private void isEmbeddableCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Video.IsEmbeddable = isEmbeddableCheckbox.Checked;
		}

		private void publicStatsViewableCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Video.PublicStatsViewable = publicStatsViewableCheckbox.Checked;
		}

		private void notifySubscribersCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Video.NotifySubscribers = notifySubscribersCheckbox.Checked;
		}

		private void autoLevelsCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Video.AutoLevels = autoLevelsCheckbox.Checked;
		}

		private void stabilizeCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Video.Stabilize = stabilizeCheckbox.Checked;
		}

		private void thumbnailButton_Click(object sender, EventArgs e)
		{
			if (selectThumbnailDialog.ShowDialog(this) == DialogResult.OK)
			{
				thumbnailTextbox.Text = selectThumbnailDialog.FileName;
			}
		}

		private void addToPlaylistCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Video.AddToPlaylist = playlistsCombobox.Enabled = addToPlaylistCheckbox.Checked;
		}

		private void playlistsCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Video.PlaylistId = playlistContainer.RegisteredPlaylists.ElementAt(playlistsCombobox.SelectedIndex).Id;
		}

		private void RefreshPlaylistServiceControls()
		{
			chooseAccountCombobox.Items.Clear();

			if (pscContainer != null && pscContainer.Connection != null)
			{
				Video.PlaylistServiceSettings.Host = pscContainer.Connection.Host;
				Video.PlaylistServiceSettings.Port = pscContainer.Connection.Port;
				Video.PlaylistServiceSettings.Username = pscContainer.Connection.Username;
				Video.PlaylistServiceSettings.Password = pscContainer.Connection.Password;

				sendToPlaylistserviceCheckbox.Checked = Video.PlaylistServiceSettings.ShouldSend;

				if (pscContainer.Connection.Accounts != null)
				{
					addPlaylistViaServiceGroupbox.Enabled = true;
					foreach (var account in pscContainer.Connection.Accounts)
					{
						chooseAccountCombobox.Items.Add($"{account.id}: {account.title}, {account.channelId}");
					}

					if (pscContainer.Connection.Accounts.Any(a => a.id == Video.PlaylistServiceSettings.AccountId))
					{
						chooseAccountCombobox.SelectedIndex = pscContainer.Connection.Accounts.ToList()
							.IndexOf(pscContainer.Connection.Accounts.First(a => a.id == Video.PlaylistServiceSettings.AccountId));
					}
					else if (pscContainer.Connection.Accounts.Length > 0)
					{
						chooseAccountCombobox.SelectedIndex = 0;
					}

					if (playlistContainer.RegisteredPlaylists.Count > 0)
					{
						if (Video.PlaylistServiceSettings != null
							&& playlistContainer.RegisteredPlaylists.Any(
								pl => pl.Id == Video.PlaylistServiceSettings.PlaylistId && pl.Title == Video.PlaylistServiceSettings.PlaylistTitle
							))
						{
							var playlist = playlistContainer.RegisteredPlaylists.First(
								pl => pl.Id == Video.PlaylistServiceSettings.PlaylistId && pl.Title == Video.PlaylistServiceSettings.PlaylistTitle);

							choosePlaylistCombobox.SelectedIndex = playlistContainer.RegisteredPlaylists.ToList().IndexOf(playlist);
							usePlaylistFromAccountRadiobutton.Checked = true;
						}
						else
						{
							if (playlistContainer.RegisteredPlaylists.Count > 0)
							{
								choosePlaylistCombobox.SelectedIndex = 0;
							}

							enterPlaylistIdManuallyRadiobutton.Checked = true;
							useCustomPlaylistIdTextbox.Text = Video.PlaylistServiceSettings.PlaylistId;
							useCustomPlaylistTitleTextbox.Text = Video.PlaylistServiceSettings.PlaylistTitle;
						}
					}
				}
			}
		}

		private void sendToPlaylistserviceCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			Video.PlaylistServiceSettings.ShouldSend
				= chooseAccountCombobox.Enabled
				= enterPlaylistIdManuallyRadiobutton.Enabled
				= useCustomPlaylistIdTextbox.Enabled
				= useCustomPlaylistTitleTextbox.Enabled
				= usePlaylistFromAccountRadiobutton.Enabled
				= choosePlaylistCombobox.Enabled
				= sendToPlaylistserviceCheckbox.Checked;

			useCustomPlaylistIdTextbox.Enabled
				&= enterPlaylistIdManuallyRadiobutton.Checked;

			useCustomPlaylistTitleTextbox.Enabled
				&= enterPlaylistIdManuallyRadiobutton.Checked;

			choosePlaylistCombobox.Enabled &= usePlaylistFromAccountRadiobutton.Checked;
		}

		private void chooseAccountCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Video.PlaylistServiceSettings.AccountId = pscContainer.Connection.Accounts[chooseAccountCombobox.SelectedIndex].id;
		}

		private void enterPlaylistIdManuallyRadiobutton_CheckedChanged(object sender, EventArgs e)
		{
			useCustomPlaylistIdTextbox.Enabled = useCustomPlaylistTitleTextbox.Enabled = enterPlaylistIdManuallyRadiobutton.Checked && sendToPlaylistserviceCheckbox.Checked;

			if (enterPlaylistIdManuallyRadiobutton.Checked)
			{
				Video.PlaylistServiceSettings.PlaylistId = useCustomPlaylistIdTextbox.Text;
				Video.PlaylistServiceSettings.PlaylistTitle = useCustomPlaylistTitleTextbox.Text;
			}
		}

		private void useCustomPlaylistIdTextbox_TextChanged(object sender, EventArgs e)
		{
			Video.PlaylistServiceSettings.PlaylistId = useCustomPlaylistIdTextbox.Text;
		}

		private void useCustomPlaylistTitleTextbox_TextChanged(object sender, EventArgs e)
		{
			Video.PlaylistServiceSettings.PlaylistTitle = useCustomPlaylistTitleTextbox.Text;
		}

		private void usePlaylistFromAccountRadiobutton_CheckedChanged(object sender, EventArgs e)
		{
			choosePlaylistCombobox.Enabled = usePlaylistFromAccountRadiobutton.Checked && sendToPlaylistserviceCheckbox.Checked;

			if (usePlaylistFromAccountRadiobutton.Checked)
			{
				Video.PlaylistServiceSettings.PlaylistId = playlistContainer.RegisteredPlaylists.ElementAt(choosePlaylistCombobox.SelectedIndex).Id;
				Video.PlaylistServiceSettings.PlaylistTitle = playlistContainer.RegisteredPlaylists.ElementAt(choosePlaylistCombobox.SelectedIndex).Title;
			}
		}

		private void choosePlaylistCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Video.PlaylistServiceSettings.PlaylistId = playlistContainer.RegisteredPlaylists.ElementAt(choosePlaylistCombobox.SelectedIndex).Id;
			Video.PlaylistServiceSettings.PlaylistTitle = playlistContainer.RegisteredPlaylists.ElementAt(choosePlaylistCombobox.SelectedIndex).Title;
		}
	}
}
