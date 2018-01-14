using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace STFU.AutoUploader
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

			showBrowserButton.Enabled = !IsRunningOnMono();
		}

		private bool IsRunningOnMono()
		{
			return Type.GetType("Mono.Runtime") != null;
		}

		private void AddAccountFormLoad(object sender, EventArgs e)
		{
			useExternalLinkTextbox.Text = ExternalCodeUrl;
		}

		private void showBrowserButtonClick(object sender, EventArgs e)
		{
			var browserForm = new BrowserForm(LocalHostUrl);

			var result = browserForm.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				AuthToken = browserForm.AuthToken;
				UsedLocalHostRedirect = true;
				DialogResult = DialogResult.OK;
				Close();
			}
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
