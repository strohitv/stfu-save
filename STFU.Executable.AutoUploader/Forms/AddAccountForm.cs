using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class AddAccountForm : Form
	{
		public string AuthToken { get; private set; }
		public bool UsedLocalHostRedirect { get; private set; }
		public string LocalHostUrl { get; set; }
		public string ExternalCodeUrl { get; set; }

		public AddAccountForm()
		{
			InitializeComponent();
		}

		private void AddAccountFormLoad(object sender, EventArgs e)
		{
			useExternalLinkTextbox.Text = ExternalCodeUrl;
		}

		private void useExternalLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(ExternalCodeUrl);
		}

		private void signInButtonClick(object sender, EventArgs e)
		{
			AuthToken = useExternalCodeTextbox.Text;
			UsedLocalHostRedirect = false;
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
