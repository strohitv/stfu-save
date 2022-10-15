using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;
using STFU.Lib.GUI.Tools;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Model.Helpers;

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

		private bool finished = false;

		public AddYoutubeAccountForm() : this(true) { }

		Thread thread;

		public AddYoutubeAccountForm(bool showMailCheckbox)
		{
			InitializeComponent();
			allowMailingCheckbox.Visible = showMailCheckbox;

			thread = new Thread(() =>
			{
				AuthToken = HttpServer.ListenForRedirect(new[] { $"{YoutubeRedirectUri.Localhost.GetAttribute<EnumMemberAttribute>().Value}/" });
				finished = AuthToken != null;
			});
			thread.Start();
		}

		private void AddAccountFormLoad(object sender, EventArgs e)
		{
			useExternalLinkTextbox.Text = BrowseUrl;
		}

		private void useExternalLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(BrowseUrl);
		}

		private void allowMailingCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			useExternalLinkTextbox.Text = BrowseUrl;
			MailsRequested = allowMailingCheckbox.Checked;
		}

		private void checkLoginTimer_Tick(object sender, EventArgs e)
		{
			if (finished)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void AddYoutubeAccountForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			HttpServer.StopListening();
		}
	}
}
