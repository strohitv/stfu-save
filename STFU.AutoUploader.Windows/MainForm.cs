using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Persistor;

namespace STFU.AutoUploader
{
	public partial class MainForm : Form
	{
		IPathContainer pathContainer = new PathContainer();
		ITemplateContainer templateContainer = new TemplateContainer();
		IYoutubeClientContainer clientContainer = new YoutubeClientContainer();
		IYoutubeAccountContainer accountContainer = new YoutubeAccountContainer();
		IYoutubeCategoryContainer categoryContainer = new YoutubeCategoryContainer();
		IYoutubeLanguageContainer languageContainer = new YoutubeLanguageContainer();
		IYoutubeAccountCommunicator accountCommunicator = new YoutubeAccountCommunicator();
		IAutomationUploader autoUploader = new AutomationUploader();
		IProcessContainer processContainer = new ProcessContainer();

		PathPersistor pathPersistor = null;
		TemplatePersistor templatePersistor = null;
		AccountPersistor accountPersistor = null;
		CategoryPersistor categoryPersistor = null;
		LanguagePersistor languagePersistor = null;

		public MainForm()
		{
			InitializeComponent();

			IYoutubeClient client = new YoutubeClient("812042275170-db6cf7ujravcq2l7vhu7gb7oodgii3e4.apps.googleusercontent.com",
				"cKUCRQz0sE4UUmvUHW6qckbP",
				"Strohis Toolset Für Uploads", false);
			clientContainer.RegisterClient(client);

			if (!Directory.Exists("./settings"))
			{
				Directory.CreateDirectory("./settings");
			}

			pathPersistor = new PathPersistor(pathContainer, "./settings/paths.json");
			pathPersistor.Load();

			templatePersistor = new TemplatePersistor(templateContainer, "./settings/templates.json");
			templatePersistor.Load();

			accountPersistor = new AccountPersistor(accountContainer, "./settings/accounts.json", clientContainer);
			accountPersistor.Load();

			categoryPersistor = new CategoryPersistor(categoryContainer, "./settings/categories.json");
			categoryPersistor.Load();

			languagePersistor = new LanguagePersistor(languageContainer, "./settings/languages.json");
			languagePersistor.Load();

			RefillListView();
			ActivateAccountLink();
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
			if (accountContainer.RegisteredAccounts.Count > 0)
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

			var client = clientContainer.RegisteredClients.FirstOrDefault();

			var addForm = new AddAccountForm();
			addForm.ExternalCodeUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, YoutubeScope.Manage).AbsoluteUri;
			addForm.LocalHostUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Localhost, YoutubeScope.Manage).AbsoluteUri;

			var result = addForm.ShowDialog(this);
			IYoutubeAccount account = null;
			if (result == DialogResult.OK
				&& (account = accountCommunicator.ConnectToAccount(addForm.AuthToken, client, YoutubeRedirectUri.Code)) != null)
			{
				accountContainer.RegisterAccount(account);

				var loader = new LanguageCategoryLoader(accountContainer);
				var categories = loader.Categories;

				categoryContainer.UnregisterAllCategories();
				foreach (var category in categories)
				{
					categoryContainer.RegisterCategory(category);
				}

				var languages = loader.Languages;

				languageContainer.UnregisterAllLanguages();
				foreach (var language in languages)
				{
					languageContainer.RegisterLanguage(language);
				}

				// Account speichern! Und so!
				accountPersistor.Save();
				categoryPersistor.Save();
				languagePersistor.Save();

				MessageBox.Show(this, "Der Uploader wurde erfolgreich mit dem Account verbunden!", "Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Information);

				ActivateAccountLink();
			}

			tlpSettings.Enabled = true;
		}

		private void ActivateAccountLink()
		{
			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountContainer.RegisteredAccounts.Count > 0;
			RefreshToolstripButtonsEnabled();
			lnklblCurrentLoggedIn.Text = accountContainer.RegisteredAccounts.SingleOrDefault()?.Title;
			btnStart.Enabled = true;
		}

		private void btnStartClick(object sender, EventArgs e)
		{
			if (accountContainer.RegisteredAccounts.Count == 0)
			{
				MessageBox.Show(this, "Es wurde keine Verbindung zu einem Account hergestellt. Bitte zuerst bei einem Youtube-Konto anmelden!", "Kein Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (pathContainer.ActivePaths.Count == 0)
			{
				MessageBox.Show(this, "Es wurden keine Pfade hinzugefügt, die der Uploader überwachen soll und die auf aktiv gesetzt sind. Er würde deshalb nichts hochladen. Bitte zuerst Pfade hinzufügen.", "Keine Pfade vorhanden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Visible = false;
			ShowInTaskbar = false;

			ChooseStartTimesForm cstForm = new ChooseStartTimesForm(pathContainer, templateContainer);

			if (cstForm.ShowDialog(this) == DialogResult.OK)
			{
				var publishSettings = cstForm.GetPublishSettingsArray();
				var account = accountContainer.RegisteredAccounts.First();
				var uploader = new YoutubeUploader();
				uploader.StopAfterCompleting = false;

				autoUploader = new AutomationUploader(uploader, account, publishSettings);
				autoUploader.ProcessContainer = processContainer;

				UploadForm uploadForm = new UploadForm(autoUploader, cmbbxFinishAction.SelectedIndex);
				if (uploadForm.ShowDialog(this) == DialogResult.OK)
				{
					cmbbxFinishAction.SelectedIndex = uploadForm.UploadEndedActionIndex;

					// Upload wurde regulär beendet.
					switch (cmbbxFinishAction.SelectedIndex)
					{
						case 2:
							Close();
							return;
						case 3:
							Process.Start("shutdown.exe", "-s -t 60");
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
			pathPersistor.Save();
			templatePersistor.Save();
		}

		private void RevokeAccess()
		{
			tlpSettings.Enabled = false;
			accountCommunicator.RevokeAccount(accountContainer, accountContainer.RegisteredAccounts.Single());
			accountPersistor.Save();

			MessageBox.Show(this, "Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			btnStart.Enabled = false;

			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountContainer.RegisteredAccounts.Count > 0;
			RefreshToolstripButtonsEnabled();
			tlpSettings.Enabled = true;
		}

		private void RefreshToolstripButtonsEnabled()
		{
			verbindenToolStripMenuItem1.Enabled = accountContainer.RegisteredAccounts.Count == 0;
			verbindungLösenToolStripMenuItem.Enabled = templatesToolStripMenuItem1.Enabled = pfadeToolStripMenuItem1.Enabled = accountContainer.RegisteredAccounts.Count > 0;
		}

		private void bgwCreateUploaderDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			//uploader = new AutomationUploader();
		}

		private void bgwCreateUploaderRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountContainer.RegisteredAccounts.Count > 0;
			RefreshToolstripButtonsEnabled();
			if (accountContainer.RegisteredAccounts.Count > 0)
			{
				lnklblCurrentLoggedIn.Text = accountContainer.RegisteredAccounts.SingleOrDefault()?.Title;
			}

			unvollständigerUploadToolStripMenuItem.Enabled = false; // uploader.HasUnfinishedJob;

			tlpSettings.Enabled = true;

			btnStart.Enabled = accountContainer.RegisteredAccounts.Count > 0;

			RefillListView();
		}

		private void lnklblCurrentLoggedInLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (accountContainer.RegisteredAccounts.Count == 0)
			{
				return;
			}

			Process p = new Process();
			p.StartInfo = new ProcessStartInfo(accountContainer.RegisteredAccounts.Single().Uri.AbsolutePath);
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
				processContainer.RemoveAllProcesses();
			}
		}

		private void ChoseProcesses()
		{
			ProcessForm processChoser = new ProcessForm(processContainer.ProcessesToWatch);
			processChoser.ShowDialog(this);
			if (processChoser.DialogResult == DialogResult.OK
				&& processChoser.Selected.Count > 0)
			{
				var procs = processChoser.Selected;
				processContainer.RemoveAllProcesses();
				processContainer.AddProcesses(procs);
			}
			else
			{
				chbChoseProcesses.Checked = false;
			}
		}

		private void cmbbxFinishActionSelectedIndexChanged(object sender, EventArgs e)
		{
			chbChoseProcesses.Enabled = cmbbxFinishAction.SelectedIndex != 0;

			//if (uploader != null)
			//{
			//	uploader.EndAfterUpload = cmbbxFinishAction.SelectedIndex != 0;
			//}

			if (cmbbxFinishAction.SelectedIndex == 0)
			{
				processContainer.RemoveAllProcesses();
				chbChoseProcesses.Checked = false;
			}
		}

		private void btnChoseProcsClick(object sender, EventArgs e)
		{
			ChoseProcesses();
		}

		private void templatesToolStripMenuItem1Click(object sender, EventArgs e)
		{
			TemplateForm tf = new TemplateForm(templateContainer, categoryContainer, languageContainer);
			tf.ShowDialog(this);
			templatePersistor.Save();

			RefillListView();
		}

		private void pfadeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			PathForm pf = new PathForm(pathContainer, templateContainer);
			pf.ShowDialog(this);
			pathPersistor.Save();

			RefillListView();
		}

		private void verbindenToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ConnectToYoutube();
			RefreshToolstripButtonsEnabled();
		}

		private void verbindungLösenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RevokeAccess();
			RefreshToolstripButtonsEnabled();
		}

		private void unvollständigerUploadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Nicht löschen, sondern anzeigen!
			// uploader.DeleteLastJobFile();
		}

		private void threadImLPFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://letsplayforum.de/thread/175111-beta-strohis-toolset-f%C3%BCr-uploads-automatisch-videos-hochladen/");
		}

		private void strohiAufTwitterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://twitter.com/strohkoenig");
		}

		private void discordServerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/pDcw6rQ");
		}
	}
}
