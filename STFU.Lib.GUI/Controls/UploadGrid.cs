using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.GUI.Controls
{
	public partial class UploadGrid : UserControl
	{
		private IYoutubeVideo video;
		public IYoutubeVideo Video
		{
			get
			{
				return video;
			}
			set
			{
				video = value;
				RefreshView();
			}
		}

		public IYoutubeAccount Account { get; set; }

		public UploadGrid()
		{
			InitializeComponent();
			Video = new YoutubeVideo() { Privacy = PrivacyStatus.Private };
		}

		private void RefreshView()
		{
			filePathTextbox.Text = video.Path;
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
	}
}
