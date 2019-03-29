using System;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

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

		public void Fill(IYoutubeVideo video, IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer)
		{
			categoryContainer = catContainer;
			RefreshCategories();

			languageContainer = langContainer;
			RefreshLanguages();

			Video = video;
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

			publishAtCheckbox.Enabled = video.Privacy == PrivacyStatus.Private;
			publishAtCheckbox.Checked = video.PublishAt.HasValue && (video.Privacy == PrivacyStatus.Private);
			publishAtDatetimepicker.Enabled = publishAtCheckbox.Checked;

			if (video.PublishAt.HasValue)
			{
				publishAtDatetimepicker.Value = video.PublishAt.Value;
			}

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
		}

		private void titleTextbox_TextChanged(object sender, EventArgs e)
		{
			Video.Title = titleTextbox.Text;
		}

		private void descriptionTextbox_TextChanged(object sender, EventArgs e)
		{
			Video.Description = descriptionTextbox.Text;
		}

		private void tagsTextbox_TextChanged(object sender, EventArgs e)
		{
			var tags = tagsTextbox.Text
				.Replace(Environment.NewLine, string.Empty)
				.Split(',')
				.Select(t => t.Trim());

			Video.Tags.Clear();
			foreach (var tag in tags)
			{
				Video.Tags.Add(tag);
			}
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
