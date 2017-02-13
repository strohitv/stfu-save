using System;
using System.IO;
using System.Windows.Forms;
using STFU.UploadLib.Automation;

namespace STFU.AutoUploader
{
	public partial class MainForm : Form
	{
		AutomationUploader uploader;

		string statusText = string.Empty;
		int progress = 0;

		public MainForm()
		{
			InitializeComponent();
		}

		private void btnSelectPathClick(object sender, EventArgs e)
		{
			var result = folderBrowserDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				if (Directory.Exists(folderBrowserDialog.SelectedPath))
				{
					txtbxAddPath.Text = folderBrowserDialog.SelectedPath;
					txtbxAddFilter.Text = "*.mp4;*.mkv";
				}
			}
		}

		private void btnAddPathToWatchClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtbxAddPath.Text))
			{
				MessageBox.Show(this, "Bitte einen Pfad eingeben!", "Pfad benötigt", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			if (string.IsNullOrWhiteSpace(txtbxAddFilter.Text))
			{
				MessageBox.Show(this, "Bitte einen Filter eingeben!", "Filter benötigt", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			uploader.Paths.Add(txtbxAddPath.Text, txtbxAddFilter.Text);
			RefillListView();
		}

		private void RefillListView()
		{
			lvSelectedPaths.Items.Clear();

			foreach (var entry in uploader.Paths)
			{
				var newItem = lvSelectedPaths.Items.Add(entry.Key);
				newItem.SubItems.Add(entry.Value);
			}
		}

		private void btnConnectYoutubeAccountClick(object sender, EventArgs e)
		{
			var connectionLink = uploader.GetAuthLoginScreenUrl(false);
			var browserForm = new Browser(connectionLink);

			var result = browserForm.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				if (uploader.ConnectToAccount(browserForm.AuthToken))
				{
					MessageBox.Show(this, "Der Account wurde erfolgreich hinzugefügt!", "Account hinzugefügt!", MessageBoxButtons.OK, MessageBoxIcon.Information);

					btnRevokeAccess.Visible = uploader.IsConnectedToAccount;
					btnStart.Enabled = true;
				}
			}
		}

		private void btnStartClick(object sender, EventArgs e)
		{
			uploader.ProgressChanged += ChangedProgress;
			uploader.UploadStarted += UploadStarted;
			uploader.UploadFinished += UploadFinished;

			refreshTimer.Enabled = true;

			uploader.Start();

			UndockTlp(tlpSettings);
			DockTlp(tlpRunning);

			SetCornerPosition();

			ChangeControlBoxActivation(false);
		}

		private void UploadFinished(AutomationEventArgs e)
		{
			statusText = $"Upload von {e.FileName} beendet. - Suche Dateien zum Upload...";
			progress = (int)e.Progress;
		}

		private void UploadStarted(AutomationEventArgs e)
		{
			statusText = $"Upload von {e.FileName} gestartet.";
			progress = (int)e.Progress;
		}

		private void ChangedProgress(AutomationEventArgs e)
		{
			statusText = $"Lade {e.FileName} hoch: {e.Progress / 100.0} %";
			progress = (int)e.Progress;
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			bgwCreateUploader.RunWorkerAsync();

			UndockTlp(tlpRunning);
			DockTlp(tlpSettings);
		}

		private void DockTlp(TableLayoutPanel tlp)
		{
			tlp.Visible = true;
			tlp.Dock = DockStyle.Fill;
		}

		private void UndockTlp(TableLayoutPanel tlp)
		{
			tlp.Visible = false;
			tlp.Dock = DockStyle.None;
		}

		private void ChangeControlBoxActivation(bool setActive)
		{
			ControlBox = setActive;
			MinimizeBox = setActive;
			MaximizeBox = setActive;
		}

		private void SetCornerPosition()
		{
			Left = Screen.PrimaryScreen.WorkingArea.Width - 10 - Width;
			Top = Screen.PrimaryScreen.WorkingArea.Height - 10 - Height;
		}

		private void btnStopClick(object sender, EventArgs e)
		{
			uploader.Stop(true);

			uploader.ProgressChanged -= ChangedProgress;
			uploader.UploadStarted -= UploadStarted;
			uploader.UploadFinished -= UploadFinished;

			refreshTimer.Enabled = false;

			UndockTlp(tlpRunning);
			DockTlp(tlpSettings);

			CenterToScreen();

			ChangeControlBoxActivation(true);
		}

		private void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			uploader?.Stop(true);
			uploader?.WriteJson();
		}

		private void refreshTimerTick(object sender, EventArgs e)
		{
			statusLabel.Text = statusText;
			prgbarProgress.Value = progress;
		}

		private void lvSelectedPathsKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
			{
				uploader.Remove(lvSelectedPaths.SelectedItems[0].Text);
				RefillListView();
			}
		}

		private void btnRevokeAccessClick(object sender, EventArgs e)
		{
			if (uploader.RevokeAccess())
			{
				MessageBox.Show(this, "Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButtons.OK, MessageBoxIcon.Information);

				btnStart.Enabled = false;
			}

			btnRevokeAccess.Visible = uploader.IsConnectedToAccount;
		}

		private void bgwCreateUploaderDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			uploader = new AutomationUploader();
		}

		private void bgwCreateUploaderRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			btnRevokeAccess.Visible = uploader.IsConnectedToAccount;
			tlpSettings.Enabled = true;

			btnStart.Enabled = uploader.IsConnectedToAccount;

			RefillListView();
		}
	}
}
