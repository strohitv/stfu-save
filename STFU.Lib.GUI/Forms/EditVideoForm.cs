using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.GUI.Forms
{
	public partial class EditVideoForm : Form
	{
		public IYoutubeVideo Video { get; set; }
		public INotificationSettings NotificationSettings { get; set; }

		protected EditVideoForm()
		{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
		}

		public EditVideoForm(IYoutubeVideo video, INotificationSettings notificationSettings, bool hasMailPrivilegue, IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer)
			: this()
		{
			Video = video;
			NotificationSettings = notificationSettings;

			uploadGrid.IsNewUpload = false;
			uploadGrid.Fill(video, notificationSettings, hasMailPrivilegue, catContainer, langContainer);
		}

		private void submitButton_Click(object sender, System.EventArgs e)
		{
			Video.FillFields(uploadGrid.Video);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
