using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.GUI.Forms
{
	public partial class EditVideoForm : Form
	{
		public IYoutubeVideo Video { get; set; }

		protected EditVideoForm()
		{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
		}

		public EditVideoForm(IYoutubeVideo video, IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer)
			: this()
		{
			Video = video;
			uploadGrid.Fill(video, catContainer, langContainer);
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
