using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Youtube.Persistor.Model;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class ReleaseNotesForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(ReleaseNotesForm));

		private string filename = "ReleaseNotes.rtf";
		private AutoUploaderSettings settings = null;

		public ReleaseNotesForm(AutoUploaderSettings settings)
		{
			LOGGER.Info("Initializing release notes form");

			InitializeComponent();
			this.settings = settings;

			disableNotesCheckbox.Checked = settings.ShowReleaseNotes;
		}

		private void ReleaseNotesFormLoad(object sender, EventArgs e)
		{
			if (File.Exists(filename))
			{
				LOGGER.Info("Loading and showing release notes");

				releaseNotesBox.LoadFile(filename);
			}
			else
			{
				LOGGER.Warn("No release notes found -> close the window immediately");

				Close();
			}
		}

		private void closeButtonClick(object sender, EventArgs e)
		{
			LOGGER.Info("Closing release notes");
			LOGGER.Info($"Should the release notes be showed again next program start: {settings.ShowReleaseNotes}");

			Close();
		}

		private void disableNotesCheckboxCheckedChanged(object sender, EventArgs e)
		{
			settings.ShowReleaseNotes = disableNotesCheckbox.Checked;
			LOGGER.Debug($"Changed show release notes setting to: {settings.ShowReleaseNotes}");
		}

		private void releaseNotesBoxLinkClicked(object sender, LinkClickedEventArgs e)
		{
			LOGGER.Debug($"Link to: '{settings.ShowReleaseNotes}' was clicked");
			Process.Start(e.LinkText);
		}
	}
}
