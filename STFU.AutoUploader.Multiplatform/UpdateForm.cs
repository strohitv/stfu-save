using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using STFU.Lib.Updater;

namespace STFU.AutoUploader
{
	public partial class UpdateForm : Form
	{
		private IUpdater updater;
		private bool updateAvailable;

		public FileInfo Executable { get; private set; }

		private string status = $"Es wird nach Updates gesucht.{Environment.NewLine}Bitte warten...";

		public UpdateForm()
		{
			InitializeComponent();
			DialogResult = DialogResult.No;

			updater = new Updater(ProductVersion);
			searchUpdateBgw.RunWorkerAsync();
		}

		private void refreshStatusTextTimerTick(object sender, EventArgs e)
		{
			statusLabel.Text = status;
		}

		private void searchUpdateBgwDoWork(object sender, DoWorkEventArgs e)
		{
			updateAvailable = updater.UpdateAvailable;
		}

		private void searchUpdateBgwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (updateAvailable)
			{
				var installUpdate = MessageBox.Show(this, $"Ein Update auf Version {updater.NewVersion} ist nun verfügbar.{Environment.NewLine}{Environment.NewLine}Soll es heruntergeladen und installiert werden?", "Update verfügbar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (installUpdate == DialogResult.Yes)
				{
					downloadUpdateBgw.RunWorkerAsync();
				}
				else
				{
					Close();
				}
			}
			else
			{
				Close();
			}
		}

		private void downloadUpdateBgwDoWork(object sender, DoWorkEventArgs e)
		{
			status = $"Update wird heruntergeladen.{Environment.NewLine}Bitte warten...";
			updater.DownloadUpdate();
			status = $"Updater wird extrahiert. Programm startet anschließend neu.{Environment.NewLine}Bitte warten...";
			Executable = updater.ExtractUpdateExe();
		}

		private void downloadUpdateBgwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			refreshStatusTextTimer.Enabled = false;

			if (Executable != null && Executable.Exists)
			{
				DialogResult = DialogResult.Yes;

				var app = Path.GetFullPath(Assembly.GetEntryAssembly().Location);
				ProcessStartInfo info = new ProcessStartInfo(Executable.FullName, $"\"{updater.UpdateFile.FullName}\" \"{app}\"");
				Process.Start(info);
			}
			else
			{
				MessageBox.Show(this, $"Es gab leider einen Fehler beim Herunterladen des Updates, daher kann es nicht installiert werden.", "Fehler beim Download!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			Close();
		}
	}
}
