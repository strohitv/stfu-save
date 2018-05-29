using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;

namespace STFU.AutoUploader
{
	public partial class MainForm : Form
	{
		IPathContainer pathContainer;
		ITemplateContainer templateContainer;
		IYoutubeClientCommunicator clientCommunicator;
		IYoutubeAccountCommunicator accountCommunicator;
		IAutomationUploader autoUploader = new AutomationUploader();

		public MainForm()
		{
			InitializeComponent();

			clientCommunicator = new YoutubeClientCommunicator();
			clientCommunicator.AddClient("812042275170-db6cf7ujravcq2l7vhu7gb7oodgii3e4.apps.googleusercontent.com",
				"cKUCRQz0sE4UUmvUHW6qckbP",
				"Strohis Toolset Für Uploads");

			accountCommunicator = new YoutubeAccountCommunicator();
		}

		private void RefillListView()
		{
			lvSelectedPaths.Items.Clear();

			foreach (var entry in pathContainer.RegisteredPaths)
			{
				var newItem = lvSelectedPaths.Items.Add(entry.Fullname);
				newItem.SubItems.Add(entry.Filter);

				string templateName = templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == entry.SelectedTemplateId)?.Name;
				if (string.IsNullOrWhiteSpace(templateName))
				{
					templateName = templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == 0).Name;
				}
				newItem.SubItems.Add(templateName);

				newItem.SubItems.Add(entry.SearchRecursively ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.SearchHidden ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.Inactive ? "Ja" : "Nein");
			}
		}

		private void btnConnectYoutubeAccountClick(object sender, EventArgs e)
		{
			if (accountCommunicator.HasAtLeastOneAccount)
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

			var client = clientCommunicator.Clients.FirstOrDefault();

			var addForm = new AddAccountForm();
			addForm.ExternalCodeUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, YoutubeScope.View | YoutubeScope.Upload).AbsolutePath;
			addForm.LocalHostUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Localhost, YoutubeScope.Manage | YoutubeScope.Upload).AbsolutePath;

			var result = addForm.ShowDialog(this);
			if (result == DialogResult.OK 
				&& accountCommunicator.ConnectToAccount(addForm.AuthToken, client, YoutubeRedirectUri.Code) != null)
			{
				MessageBox.Show(this, "Der Uploader wurde erfolgreich mit dem Account verbunden!", "Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Information);

				lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountCommunicator.HasAtLeastOneAccount;
				RefreshConnectionToolstripButtonsEnabled();
				lnklblCurrentLoggedIn.Text = accountCommunicator.ConnectedAccounts.SingleOrDefault()?.Title;
				btnStart.Enabled = true;
			}

			tlpSettings.Enabled = true;
		}

		private void btnStartClick(object sender, EventArgs e)
		{
			if (!accountCommunicator.HasAtLeastOneAccount)
			{
				MessageBox.Show(this, "Es wurde keine Verbindung zu einem Account hergestellt. Bitte zuerst bei einem Youtube-Konto anmelden!", "Kein Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (pathContainer.RegisteredPaths.Count == 0)
			{
				MessageBox.Show(this, "Es wurden keine Pfade hinzugefügt, die der Uploader überwachen soll. Er würde deshalb nichts hochladen. Bitte zuerst Pfade hinzufügen.", "Keine Pfade vorhanden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Visible = false;
			ShowInTaskbar = false;

			ChooseStartTimesForm cstForm = new ChooseStartTimesForm(pathContainer, templateContainer);

			if (cstForm.ShowDialog(this) == DialogResult.OK)
			{
				var publishSettings = cstForm.GetPublishSettingsArray();
				var account = accountCommunicator.ConnectedAccounts.First();
				var uploader = new YoutubeUploader();
				uploader.StopAfterCompleting = false;

				autoUploader = new AutomationUploader(uploader, account, publishSettings);

				UploadForm uploadForm = new UploadForm(autoUploader, cmbbxFinishAction.SelectedIndex);
				if (uploadForm.ShowDialog(this) == DialogResult.OK)
				{
					cmbbxFinishAction.SelectedIndex = uploadForm.UploadEndedActionIndex;

					// Upload wurde regulär beendet.
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
			}

			// Fenster wieder anzeigen.
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
			autoUploader?.Cancel();
			uploader?.WritePaths();
			uploader?.WriteTemplates();
		}

		private void RevokeAccess()
		{
			tlpSettings.Enabled = false;
			accountCommunicator.RevokeAccount(accountCommunicator.ConnectedAccounts.Single());

			MessageBox.Show(this, "Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			btnStart.Enabled = false;

			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountCommunicator.ConnectedAccounts.Count > 0;
			RefreshConnectionToolstripButtonsEnabled();
			tlpSettings.Enabled = true;
		}

		private void RefreshConnectionToolstripButtonsEnabled()
		{
			verbindenToolStripMenuItem1.Enabled = !accountCommunicator.HasAtLeastOneAccount;
			verbindungLösenToolStripMenuItem.Enabled = accountCommunicator.HasAtLeastOneAccount;
		}

		private void bgwCreateUploaderDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			//uploader = new AutomationUploader();
		}

		private void bgwCreateUploaderRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountCommunicator.HasAtLeastOneAccount;
			RefreshConnectionToolstripButtonsEnabled();
			if (accountCommunicator.HasAtLeastOneAccount)
			{
				lnklblCurrentLoggedIn.Text = accountCommunicator.ConnectedAccounts.SingleOrDefault()?.Title;
			}

			unvollständigerUploadToolStripMenuItem.Enabled = uploader.HasUnfinishedJob;

			tlpSettings.Enabled = true;

			btnStart.Enabled = accountCommunicator.HasAtLeastOneAccount;

			RefillListView();
		}

		private void lnklblCurrentLoggedInLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!accountCommunicator.HasAtLeastOneAccount)
			{
				return;
			}

			Process p = new Process();
			p.StartInfo = new ProcessStartInfo(accountCommunicator.ConnectedAccounts.Single().Uri.AbsolutePath);
			p.Start();
		}

		private void beendenToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void chbChoseProcessesCheckedChanged(object sender, EventArgs e)
		{
			btnChoseProcs.Enabled = chbChoseProcesses.Checked;

			if (chbChoseProcesses.Checked)
			{
				ChoseProcesses();
			}
			else
			{
				uploader.ShouldWaitForProcs = false;
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
				uploader.ShouldWaitForProcs = true;
			}
			else
			{
				chbChoseProcesses.Checked = false;
				uploader.ShouldWaitForProcs = false;
			}
		}

		private void cmbbxFinishActionSelectedIndexChanged(object sender, EventArgs e)
		{
			chbChoseProcesses.Enabled = cmbbxFinishAction.SelectedIndex != 0;

			if (uploader != null)
			{
				uploader.EndAfterUpload = cmbbxFinishAction.SelectedIndex != 0;
			}

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

		private void templatesToolStripMenuItem1Click(object sender, EventArgs e)
		{
			TemplateForm tf = new TemplateForm(templateContainer);
			tf.ShowDialog(this);
			uploader.WriteTemplates();

			RefillListView();
		}

		private void pfadeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			PathForm pf = new PathForm(pathContainer, templateContainer);
			pf.ShowDialog(this);
			uploader.WritePaths();

			RefillListView();
		}

		private void verbindenToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ConnectToYoutube();
			RefreshConnectionToolstripButtonsEnabled();
		}

		private void verbindungLösenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RevokeAccess();
			RefreshConnectionToolstripButtonsEnabled();
		}

		private void unvollständigerUploadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Nicht löschen, sondern anzeigen!
			// uploader.DeleteLastJobFile();
		}
	}
}
