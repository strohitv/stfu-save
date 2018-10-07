using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STFU.AutoUploader
{
	public partial class ReleaseNotesForm : Form
	{
		private string filename = "ReleaseNotes.rtf";

		public ReleaseNotesForm()
		{
			InitializeComponent();
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
	}
}
