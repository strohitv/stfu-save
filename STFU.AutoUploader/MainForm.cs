using System;
using System.Diagnostics;
using System.Windows.Forms;
using STFU.UploadLib.Automation;

namespace STFU.AutoUploader
{
	public partial class MainForm : Form
	{
		AutomationUploader uploader;

		public MainForm()
		{
			InitializeComponent();
		}

		private void RefillListView()
		{
			lvSelectedPaths.Items.Clear();

			foreach (var entry in uploader.Paths)
			{
				var newItem = lvSelectedPaths.Items.Add(entry.Path);
				newItem.SubItems.Add(entry.Filter);
				newItem.SubItems.Add(entry.SearchRecursively ? "Ja" : "Nein");
			}
		}

		private void btnConnectYoutubeAccountClick(object sender, EventArgs e)
		{
			if (uploader.IsConnectedToAccount)
			{
				RevokeAccess();
			}
			else
			{
				ConnectToYoutube();
			}
		}

		private void ConnectToYoutube()
		{
			tlpSettings.Enabled = false;
			var connectionLink = uploader.GetAuthLoginScreenUrl(false);
			var browserForm = new BrowserForm(connectionLink);

			var result = browserForm.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				if (uploader.ConnectToAccount(browserForm.AuthToken))
				{
					MessageBox.Show(this, "Der Uploader wurde erfolgreich mit dem Account verbunden!", "Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Information);

					lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = uploader.IsConnectedToAccount;
					RefreshConnectionToolstripButtonsEnabled();
					lnklblCurrentLoggedIn.Text = uploader.LoggedInAccountTitle;
					btnStart.Enabled = true;
				}
			}
			tlpSettings.Enabled = true;
		}

		private void btnStartClick(object sender, EventArgs e)
		{
			if (uploader.Paths.Count == 0)
			{
				MessageBox.Show(this, "Es wurden keine Pfade hinzugefügt, die der Uploader überwachen soll. Er würde deshalb nichts hochladen. Bitte zuerst Pfade hinzufügen.", "Keine Pfade vorhanden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Visible = false;
			ShowInTaskbar = false;

			UploadForm uploadForm = new UploadForm(uploader);
			if (uploadForm.ShowDialog(this) == DialogResult.OK)
			{
				// Upload wurde regulär beendet.
				// => Jetzt evtl. runterfahren oder so.
				switch (cmbbxFinishAction.SelectedIndex)
				{
					case 1:
						Close();
						return;
					case 2:
						Process.Start("shutdown.exe", "-s -t 5");
						Close();
						return;
					default:
						break;
				}
			}

			// Upload wurde vom Benutzer abgebrochen
			// => Einfach das Fenster wieder anzeigen.
			ShowInTaskbar = true;
			Visible = true;
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			cmbbxFinishAction.SelectedIndex = 0;
			bgwCreateUploader.RunWorkerAsync();
		}

		private void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			uploader?.Stop(true);
			uploader?.WritePaths();
		}

		private void RevokeAccess()
		{
			tlpSettings.Enabled = false;
			if (uploader.RevokeAccess())
			{
				MessageBox.Show(this, "Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButtons.OK, MessageBoxIcon.Information);

				btnStart.Enabled = false;
			}

			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = uploader.IsConnectedToAccount;
			RefreshConnectionToolstripButtonsEnabled();
			tlpSettings.Enabled = true;
		}

		private void RefreshConnectionToolstripButtonsEnabled()
		{
			verbindenToolStripMenuItem.Enabled = !uploader.IsConnectedToAccount;
			verbindungTrennenToolStripMenuItem.Enabled = uploader.IsConnectedToAccount;
		}

		private void bgwCreateUploaderDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			uploader = new AutomationUploader();
		}

		private void bgwCreateUploaderRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = uploader.IsConnectedToAccount;
			RefreshConnectionToolstripButtonsEnabled();
			if (uploader.IsConnectedToAccount)
			{
				lnklblCurrentLoggedIn.Text = uploader.LoggedInAccountTitle;
			}

			tlpSettings.Enabled = true;

			btnStart.Enabled = uploader.IsConnectedToAccount;

			RefillListView();
		}

		private void lnklblCurrentLoggedInLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!uploader.IsConnectedToAccount)
			{
				return;
			}

			Process p = new Process();
			p.StartInfo = new ProcessStartInfo(uploader.LoggedInAccountUrl);
			p.Start();
		}

		private void beendenToolStripMenuItemClick(object sender, EventArgs e)
		{
			uploader?.Stop(true);
			uploader?.WritePaths();
			Close();
		}

		private void allePfadeLöschenToolStripMenuItemClick(object sender, EventArgs e)
		{
			uploader.Paths.Clear();
			RefillListView();
		}

		private void pfadeVerwaltenToolStripMenuItemClick(object sender, EventArgs e)
		{
			PathForm pf = new PathForm(uploader);
			pf.ShowDialog(this);

			RefillListView();
		}

		private void abgebrochenenUploadLöschenToolStripMenuItemClick(object sender, EventArgs e)
		{
			uploader.DeleteLastJobFile();
		}

		private void abgebrochenenUploadAnzeigenToolStripMenuItemClick(object sender, EventArgs e)
		{

		}

		private void verbindenToolStripMenuItemClick(object sender, EventArgs e)
		{
			ConnectToYoutube();
			RefreshConnectionToolstripButtonsEnabled();
		}

		private void verbindungTrennenToolStripMenuItemClick(object sender, EventArgs e)
		{
			RevokeAccess();
			RefreshConnectionToolstripButtonsEnabled();
		}

		private void chbChoseProcessesCheckedChanged(object sender, EventArgs e)
		{
			btnChoseProcs.Enabled = chbChoseProcesses.Checked;

			if (chbChoseProcesses.Checked)
			{
				//ProcessForm processChoser = new ProcessForm();
				//processChoser.ShowDialog(this);
				ChoseProcesses();
			}
			else
			{
				uploader.ClearProcessesToWatch();
			}
		}

		private void ChoseProcesses()
		{
			ProcessForm processChoser = new ProcessForm(uploader.ProcessesToWatch);
			processChoser.ShowDialog(this);
			if (processChoser.DialogResult == DialogResult.OK
				&& processChoser.Selected.Count > 0)
			{
				var procs = processChoser.Selected;
				uploader.ClearProcessesToWatch();
				uploader.AddProcessesToWatch(procs);
			}
			else
			{
				chbChoseProcesses.Checked = false;
			}
		}

		private void cmbbxFinishActionSelectedIndexChanged(object sender, EventArgs e)
		{
			chbChoseProcesses.Enabled = cmbbxFinishAction.SelectedIndex != 0;

			if (cmbbxFinishAction.SelectedIndex == 0)
			{
				uploader?.ClearProcessesToWatch();
				chbChoseProcesses.Checked = false;
			}
		}

		private void btnChoseProcsClick(object sender, EventArgs e)
		{
			ChoseProcesses();
		}

		private void lblCurrentLoggedIn_Click(object sender, EventArgs e)
		{
			TemplateForm f1 = new TemplateForm(uploader);
			f1.Show(this);
		}
	}
}
