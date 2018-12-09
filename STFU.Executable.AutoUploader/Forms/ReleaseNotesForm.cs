using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using STFU.Lib.Youtube.Persistor.Model;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class ReleaseNotesForm : Form
	{
		private string filename = "ReleaseNotes.rtf";
		private AutoUploaderSettings settings = null;

		public ReleaseNotesForm(AutoUploaderSettings settings)
		{
			InitializeComponent();
			this.settings = settings;

			disableNotesCheckbox.Checked = settings.ShowReleaseNotes;
		}

		private void ReleaseNotesFormLoad(object sender, EventArgs e)
		{
			if (File.Exists(filename))
			{
				releaseNotesBox.LoadFile(filename);
			}
		}

		private void closeButtonClick(object sender, EventArgs e)
		{
			Close();
		}

		private void disableNotesCheckboxCheckedChanged(object sender, EventArgs e)
		{
			settings.ShowReleaseNotes = disableNotesCheckbox.Checked;
		}

		private void releaseNotesBoxLinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}
	}
}
