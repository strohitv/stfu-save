using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using STFU.Lib.GUI.Forms;
using STFU.Lib.Youtube;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Interfaces.Model.Args;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Persistor;
using STFU.Lib.Youtube.Persistor.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Executable.AutoUploader.Forms
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
		IAutomationUploader autoUploader;
		ProcessList processes = new ProcessList();

		AutoUploaderSettings autoUploaderSettings = new AutoUploaderSettings();

		PathPersistor pathPersistor = null;
		TemplatePersistor templatePersistor = null;
		AccountPersistor accountPersistor = null;
		CategoryPersistor categoryPersistor = null;
		LanguagePersistor languagePersistor = null;
		AutoUploaderSettingsPersistor settingsPersistor = null;

		private bool showReleaseNotes = false;
		bool ended = false;
		bool canceled = false;

		int progress = 0;

		public MainForm(bool showReleaseNotes)
		{
			InitializeComponent();

			this.showReleaseNotes = showReleaseNotes;

			Text = $"Strohis Toolset Für Uploads - AutoUploader v{ProductVersion} [BETA]";

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

			settingsPersistor = new AutoUploaderSettingsPersistor(autoUploaderSettings, "./settings/autouploader.json");
			settingsPersistor.Load();

			var uploader = new YoutubeUploader();
			uploader.StopAfterCompleting = false;
			uploader.RemoveCompletedJobs = false;

			autoUploader = new AutomationUploader(uploader);
			autoUploader.WatchedProcesses = processes;

			autoUploader.PropertyChanged += AutoUploaderPropertyChanged;
			autoUploader.Uploader.PropertyChanged += UploaderPropertyChanged;
			autoUploader.Uploader.NewUploadStarted += UploaderNewUploadStarted;
			autoUploader.FileToUploadOccured += AutoUploader_FileToUploadOccured;

			RefillListView();
			ActivateAccountLink();
		}

		private void UploaderNewUploadStarted(UploadStartedEventArgs args)
		{
			args.Job.PropertyChanged += Job_PropertyChanged;

			if (args.Job.Video.NotificationSettings.NotifyOnVideoUploadStartedDesktop)
			{
				notifyIcon.ShowBalloonTip(
					10000,
					"Upload wurde gestartet",
					$"Das Video '{args.Job.Video.Title}' wird nun hochgeladen.",
					ToolTipIcon.Info
				);
			}
		}

		private void Job_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(IYoutubeJob.State))
			{
				var job = (IYoutubeJob)sender;

				if (job.State == UploadProgress.Successful)
				{
					if (job.Video.NotificationSettings.NotifyOnVideoUploadFinishedDesktop)
					{
						notifyIcon.ShowBalloonTip(
							10000,
							"Upload abgeschlossen!",
							$"Das Video '{job.Video.Title}' wurde erfolgreich hochgeladen.",
							ToolTipIcon.Info
						);
					}
				}
				else if (job.State == UploadProgress.Failed)
				{
					if (job.Video.NotificationSettings.NotifyOnVideoUploadFailedDesktop)
					{
						notifyIcon.ShowBalloonTip(
							10000,
							"Upload fehlgeschlagen.",
							$"Das Video '{job.Video.Title}' konnte aufgrund eines Fehlers nicht hochgeladen werden.",
							ToolTipIcon.Info
						);
					}
				}

				if (job.State == UploadProgress.NotRunning
					|| job.State == UploadProgress.Canceled
					|| job.State == UploadProgress.Failed
					|| job.State == UploadProgress.Successful)
				{
					job.PropertyChanged -= Job_PropertyChanged;
				}
			}
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
		private void AutoUploader_FileToUploadOccured(object sender, JobEventArgs e)
		{
			if (e.Job.Video.NotificationSettings.NotifyOnVideoFoundDesktop)
			{
				notifyIcon.ShowBalloonTip(
					10000,
					"Neues Video in der Warteschlange",
					$"Das Video '{e.Job.Video.Title}' wurde in die Warteschlange aufgenommen.",
					ToolTipIcon.Info
				);
			}

			// Aktualisiertes Hochladedatum im Template speichern
			templatePersistor.Save();
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
			addForm.ExternalCodeUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, GoogleScope.Manage).AbsoluteUri;
			addForm.SendMailAuthUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, GoogleScope.Manage | GoogleScope.SendMail).AbsoluteUri;

			var result = addForm.ShowDialog(this);
			IYoutubeAccount account = null;
			if (result == DialogResult.OK
				&& (account = accountCommunicator.ConnectToAccount(addForm.AuthToken, addForm.MailsRequested, client, YoutubeRedirectUri.Code)) != null)
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
			queueStatusButton.Enabled = true;
		}

		private void btnStartClick(object sender, EventArgs e)
		{
			if (autoUploader.State == RunningState.NotRunning && ConditionsForStartAreFullfilled())
			{
				var publishSettings = pathContainer.ActivePaths
					.Select(path => new ObservationConfiguration(path, templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == path.SelectedTemplateId)))
					.ToArray();

				SetUpAutoUploaderAndQueue(publishSettings);

				autoUploader.StartAsync();
			}
			else
			{
				canceled = true;
				autoUploader.Cancel();
				autoUploader.Uploader.CancelAll();
			}
		}

		private void zeitenFestlegenUndAutouploaderStartenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (autoUploader.State == RunningState.NotRunning && ConditionsForStartAreFullfilled())
			{
				ChooseStartTimesForm cstForm = new ChooseStartTimesForm(pathContainer, templateContainer);
				var shouldStartUpload = cstForm.ShowDialog(this);

				if (shouldStartUpload == DialogResult.OK)
				{
					SetUpAutoUploaderAndQueue(cstForm.GetPublishSettingsArray());
					autoUploader.StartWithExtraConfigAsync();
				}
			}
			else
			{
				canceled = true;
				autoUploader.Cancel();
				autoUploader.Uploader.CancelAll();
			}
		}

		private void SetUpAutoUploaderAndQueue(IObservationConfiguration[] publishSettings)
		{
			autoUploader.Account = accountContainer.RegisteredAccounts.First();

			autoUploader.Configuration.Clear();
			foreach (var setting in publishSettings)
			{
				autoUploader.Configuration.Add(setting);
			}

			jobQueue.Fill(categoryContainer, languageContainer);

			jobQueue.ShowActionsButtons = true;
			jobQueue.Uploader = autoUploader.Uploader;
		}

		private bool ConditionsForStartAreFullfilled()
		{
			if (accountContainer.RegisteredAccounts.Count == 0)
			{
				MessageBox.Show(this, "Es wurde keine Verbindung zu einem Account hergestellt. Bitte zuerst bei einem Youtube-Konto anmelden!", "Kein Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (pathContainer.ActivePaths.Count == 0)
			{
				MessageBox.Show(this, "Es wurden keine Pfade hinzugefügt, die der Uploader überwachen soll und die auf aktiv gesetzt sind. Er würde deshalb nichts hochladen. Bitte zuerst Pfade hinzufügen.", "Keine Pfade vorhanden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		delegate void action();
		private void UploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(IYoutubeUploader.State))
			{
				if (autoUploader.Uploader.State == UploaderState.Waiting)
				{
					Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle)));
					Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(10000, 10000, Handle)));
				}

				if (autoUploader.Uploader.State == UploaderState.NotRunning)
				{
					ended = true;
					Invoke(new action(() => queueStatusLabel.Text = "Die Warteschlange ist gestoppt"));
				}
				else
				{
					Invoke(new action(() => queueStatusLabel.Text = "Die Warteschlange wird abgearbeitet"));
				}

				RenameStartButton();
			}
			else if (e.PropertyName == nameof(IYoutubeUploader.Progress))
			{
				progress = autoUploader.Uploader.Progress;

				try
				{
					Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle)));
					Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(progress, 10000, Handle)));
				}
				catch (InvalidOperationException)
				{ }
			}
		}

		private void RenameStartButton()
		{
			if (autoUploader.State == RunningState.NotRunning)
			{
				Invoke(new action(() => btnStart.Text = "Sofort starten!"));
				Invoke(new action(() => zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Enabled = true));
			}
			else
			{
				Invoke(new action(() => btnStart.Text = "Abbrechen!"));
				Invoke(new action(() => zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Enabled = false));
			}

			if (autoUploader.Uploader.State == UploaderState.NotRunning)
			{
				Invoke(new action(() => queueStatusButton.Text = "Start!"));
			}
			else
			{
				Invoke(new action(() => queueStatusButton.Text = "Abbrechen!"));
			}
		}

		private void AutoUploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(autoUploader.State))
			{
				if (autoUploader.State == RunningState.NotRunning)
				{
					ended = true;
					Invoke(new action(() => autoUploaderStateLabel.Text = "Der AutoUploader ist gestoppt"));
				}
				else
				{
					Invoke(new action(() => autoUploaderStateLabel.Text = "Der AutoUploader läuft und fügt gefundene Videos automatisch hinzu"));
				}

				RenameStartButton();
			}
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			cmbbxFinishAction.SelectedIndex = 0;
			bgwCreateUploader.RunWorkerAsync();
		}

		private void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			autoUploader.PropertyChanged -= AutoUploaderPropertyChanged;
			autoUploader.Uploader.PropertyChanged -= UploaderPropertyChanged;

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
			queueStatusButton.Enabled = false;

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
			if (File.Exists("stfu-updater.exe"))
			{
				try
				{
					File.Delete("stfu-updater.exe");
				}
				catch (Exception)
				{
				}
			}

			if (showReleaseNotes || autoUploaderSettings.ShowReleaseNotes)
			{
				var releaseNotesForm = new ReleaseNotesForm(autoUploaderSettings);
				releaseNotesForm.ShowDialog(this);

				settingsPersistor.Save();
			}

			var updateForm = new UpdateForm();
			if (updateForm.ShowDialog(this) == DialogResult.Yes)
			{
				Close();
				return;
			}

			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountContainer.RegisteredAccounts.Count > 0;
			RefreshToolstripButtonsEnabled();
			if (accountContainer.RegisteredAccounts.Count > 0)
			{
				lnklblCurrentLoggedIn.Text = accountContainer.RegisteredAccounts.SingleOrDefault()?.Title;
			}

			unvollständigerUploadToolStripMenuItem.Enabled = false; // uploader.HasUnfinishedJob;

			tlpSettings.Enabled = true;

			btnStart.Enabled = queueStatusButton.Enabled = accountContainer.RegisteredAccounts.Count > 0;

			RefillListView();
		}

		private void lnklblCurrentLoggedInLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (accountContainer.RegisteredAccounts.Count == 0)
			{
				return;
			}

			Process p = new Process();
			p.StartInfo = new ProcessStartInfo(accountContainer.RegisteredAccounts.Single().Uri.AbsoluteUri);
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
				processes.Clear();
			}
		}

		private void ChoseProcesses()
		{
			ProcessForm processChoser = new ProcessForm(processes.Where(p => !p.HasExited).ToList());
			processChoser.ShowDialog(this);
			if (processChoser.DialogResult == DialogResult.OK
				&& processChoser.Selected.Count > 0)
			{
				var procs = processChoser.Selected;
				processes.Clear();
				processes.AddRange(procs);
			}
			else
			{
				chbChoseProcesses.Checked = false;
			}
		}

		private void cmbbxFinishActionSelectedIndexChanged(object sender, EventArgs e)
		{
			autoUploader.EndAfterUpload = chbChoseProcesses.Enabled = cmbbxFinishAction.SelectedIndex > 0;

			if (cmbbxFinishAction.SelectedIndex == 0)
			{
				processes.Clear();
				chbChoseProcesses.Checked = false;
			}
		}

		private void btnChoseProcsClick(object sender, EventArgs e)
		{
			ChoseProcesses();
		}

		private void templatesToolStripMenuItem1Click(object sender, EventArgs e)
		{
			TemplateForm tf = new TemplateForm(templatePersistor,
				categoryContainer,
				languageContainer,
				accountContainer.RegisteredAccounts.FirstOrDefault()?.Access.FirstOrDefault()?.HasSendMailPrivilegue ?? false);
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

		private void downloadSeiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://drive.google.com/drive/folders/1kCRPLg-95PjbQKjEpj-HW7tjvzmZ87RI");
		}

		private void tutorialVideoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=XjYvy36BrNo");
		}

		private void threadImYTFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://ytforum.de/index.php/Thread/19543-BETA-Strohis-Toolset-Für-Uploads-v0-1-1-Videos-automatisch-hochladen/");
		}

		private void neueFunktionenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var releaseNotesForm = new ReleaseNotesForm(autoUploaderSettings);
			releaseNotesForm.ShowDialog(this);

			settingsPersistor.Save();
		}

		private void fehlerverzeichnisÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists("errors"))
			{
				Directory.CreateDirectory("errors");
			}

			Process.Start("explorer.exe", "errors");
		}

		private void watchingTimer_Tick(object sender, EventArgs e)
		{
			if (ended)
			{
				if (!canceled)
				{
					// Upload wurde regulär beendet.
					switch (cmbbxFinishAction.SelectedIndex)
					{
						case 1:
							Close();
							return;
						case 2:
							Process.Start("shutdown.exe", "-s -t 60");
							Close();
							return;
						default:
							break;
					}
				}

				ended = false;
				canceled = false;
			}
		}

		private void queueStatusButton_Click(object sender, EventArgs e)
		{
			var uploader = autoUploader.Uploader;

			if (uploader.State == UploaderState.NotRunning)
			{
				if (accountContainer.RegisteredAccounts.Count == 0)
				{
					MessageBox.Show(this, "Es wurde keine Verbindung zu einem Account hergestellt. Bitte zuerst bei einem Youtube-Konto anmelden!", "Kein Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				jobQueue.Fill(categoryContainer, languageContainer);

				jobQueue.ShowActionsButtons = true;
				jobQueue.Uploader = autoUploader.Uploader;

				uploader.StartUploader();
			}
			else
			{
				canceled = true;
				autoUploader.Uploader.CancelAll();
			}
		}
	}
}
