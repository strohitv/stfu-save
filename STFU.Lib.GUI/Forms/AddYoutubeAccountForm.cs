using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace STFU.Lib.GUI.Forms
{
	public partial class AddYoutubeAccountForm : Form
	{
		public string AuthToken { get; private set; }
		public string ExternalCodeUrl { get; set; }
		public string SendMailAuthUrl { get; set; } = string.Empty;
		public bool MailsRequested { get; set; } = false;

		private string BrowseUrl => allowMailingCheckbox.Checked
			? SendMailAuthUrl
			: ExternalCodeUrl;

		public AddYoutubeAccountForm() : this(true) { }

		public AddYoutubeAccountForm(bool showMailCheckbox)
		{
			InitializeComponent();
			allowMailingCheckbox.Visible = showMailCheckbox;
		}

		private void AddAccountFormLoad(object sender, EventArgs e)
		{
			useExternalLinkTextbox.Text = BrowseUrl;
		}

		private void useExternalLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(BrowseUrl);
		}

		private void signInButtonClick(object sender, EventArgs e)
		{
			AuthToken = useExternalCodeTextbox.Text;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void allowMailingCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			useExternalLinkTextbox.Text = BrowseUrl;
			MailsRequested = allowMailingCheckbox.Checked;
		}
	}
}
