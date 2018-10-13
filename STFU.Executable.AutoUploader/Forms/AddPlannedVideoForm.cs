using System;
using System.Windows.Forms;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class AddPlannedVideoForm : Form
	{
		public string Filename { get; private set; }

		public AddPlannedVideoForm()
		{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
		}

		private void saveButtonClick(object sender, EventArgs e)
		{
			Filename = filenameBox.Text;
			DialogResult = DialogResult.OK;

			Close();
		}

		private void cancelButtonClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
