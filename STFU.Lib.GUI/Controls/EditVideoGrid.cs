using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.GUI.Controls
{
	public partial class EditVideoGrid : UserControl
	{
		private IYoutubeCategoryContainer categoryContainer;
		private IYoutubeLanguageContainer languageContainer;
		private bool isNewUpload = false;

		private IYoutubeVideo video;
		public IYoutubeVideo Video
		{
			get
			{
				return video;
			}
			private set
			{
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

		private void RefreshCheckboxesVisibility()
		{
			notifySubscribersCheckbox.Visible = autoLevelsCheckbox.Visible = stabilizeCheckbox.Visible = IsNewUpload;
		}

		public EditVideoGrid()
		{
			InitializeComponent();
		}

		public void Fill(IYoutubeVideo video, INotificationSettings notificationSettings, bool hasMailPrivilegue, IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer)
		{
			categoryContainer = catContainer;
			RefreshCategories();

			languageContainer = langContainer;
			RefreshLanguages();

			HasMailPrivilegue = hasMailPrivilegue;
			Video = video;
			NotificationSettings = notificationSettings;
		}

		private void RefreshLanguages()
		{
			defaultLanguageCombobox.Items.Clear();

			foreach (var lang in languageContainer.RegisteredLanguages)
			{
				defaultLanguageCombobox.Items.Add(lang.Name);
			}
		}

		private void RefreshCategories()
		{
			categoryCombobox.Items.Clear();

			foreach (var cat in categoryContainer.RegisteredCategories)
			{
				categoryCombobox.Items.Add(cat.Title);
			}
		}

		private void RefreshView()
		{
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
	}
}
