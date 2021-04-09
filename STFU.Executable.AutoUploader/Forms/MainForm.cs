using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using log4net;
using Microsoft.WindowsAPICodePack.Taskbar;
using STFU.Lib.GUI.Forms;
using STFU.Lib.Playlistservice;
using STFU.Lib.Twitter;
using STFU.Lib.Twitter.Model;
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
using STFU.Lib.Youtube.Upload;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class MainForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(MainForm));

		IPathContainer pathContainer = new PathContainer();
		ITemplateContainer templateContainer = new TemplateContainer();
		IYoutubeClientContainer clientContainer = new YoutubeClientContainer();
		IYoutubeAccountContainer accountContainer = new YoutubeAccountContainer();
		IYoutubeCategoryContainer categoryContainer = new YoutubeCategoryContainer();
		IYoutubeLanguageContainer languageContainer = new YoutubeLanguageContainer();
		IYoutubeJobContainer queueContainer = new YoutubeJobContainer();
		IYoutubeJobContainer archiveContainer = new YoutubeJobContainer();

		IYoutubePlaylistContainer playlistContainer = new YoutubePlaylistContainer();
		IPlaylistServiceConnectionContainer playlistServiceConnectionContainer = new PlaylistServiceConnectionContainer();

		ITwitterAccountContainer twitterAccountContainer = new TwitterAccountContainer();

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
		JobPersistor queuePersistor = null;
		JobPersistor archivePersistor = null;

		PlaylistPersistor playlistPersistor = null;
		PlaylistServiceConnectionPersistor playlistServiceConnectionPersistor = null;

		TwitterAccountPersistor twitterAccountPersistor = null;

		private bool showReleaseNotes = false;
		bool ended = false;
		bool canceled = false;

		int progress = 0;

		public MainForm(bool showReleaseNotes)
		{
			LOGGER.Info("Initializing main form");

			InitializeComponent();

			this.showReleaseNotes = showReleaseNotes;

			Text = $"Strohis Toolset Für Uploads - AutoUploader v{ProductVersion} [BETA]";
		}

		private void RefillArchiveView()
		{
			LOGGER.Info("Refilling archive listview");

			archiveListView.Items.Clear();

			foreach (var job in archiveContainer.RegisteredJobs)
			{
				ListViewItem item = new ListViewItem(job.Video.Title);
				item.SubItems.Add(job.Video.Path);
				archiveListView.Items.Add(item);

				LOGGER.Debug($"Added entry for job for video '{job.Video.Title}'");
			}
		}

		private void UploaderNewUploadStarted(UploadStartedEventArgs args)
		{
			LOGGER.Info($"Received event that a new upload was started - Video: '{args.Job.Video.Title}'");

			args.Job.PropertyChanged += Job_PropertyChanged;

			if (args.Job.NotificationSettings.NotifyOnVideoUploadStartedDesktop)
			{
				LOGGER.Info($"Informing via balloon tip");

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
			LOGGER.Debug($"Received a job property changed event - Property: '{e.PropertyName}'");
			LOGGER.Debug($"Sender was job with video: '{((IYoutubeJob)sender).Video.Title}'");

			if (e.PropertyName == nameof(IYoutubeJob.State))
			{
				var job = (IYoutubeJob)sender;

				LOGGER.Info($"Received new State '{job.State}' for job with video: '{job.Video.Title}'");

				if (job.State == JobState.Successful)
				{
					LOGGER.Info($"Informing via balloon tip");

					if (job.NotificationSettings.NotifyOnVideoUploadFinishedDesktop)
					{
						notifyIcon.ShowBalloonTip(
							10000,
							"Upload abgeschlossen!",
							$"Das Video '{job.Video.Title}' wurde erfolgreich hochgeladen.",
							ToolTipIcon.Info
						);
					}
				}
				else if (job.State == JobState.Error)
				{
					if (job.NotificationSettings.NotifyOnVideoUploadFailedDesktop)
					{
						LOGGER.Info($"Informing via balloon tip");

						notifyIcon.ShowBalloonTip(
							10000,
							"Upload fehlgeschlagen.",
							$"Das Video '{job.Video.Title}' konnte aufgrund eines Fehlers nicht hochgeladen werden.",
							ToolTipIcon.Info
						);
					}
				}

				if (job.State == JobState.NotStarted
					|| job.State == JobState.Canceled
					|| job.State == JobState.Error
					|| job.State == JobState.Successful)
				{
					LOGGER.Debug($"Removing listener for job with video: '{job.Video.Title}'");
					job.PropertyChanged -= Job_PropertyChanged;
				}
			}
		}

		private void RefillSelectedPathsListView()
		{
			LOGGER.Info("Refilling selected paths listview");

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
				newItem.SubItems.Add(entry.MoveAfterUpload ? "Ja" : "Nein");

				LOGGER.Debug($"Added entry for path '{entry.Fullname}'");
			}
		}

		private void AutoUploader_FileToUploadOccured(object sender, JobEventArgs e)
		{
			LOGGER.Info($"Received information about a newly found video '{e.Job.Video.Title}' from autouploader");

			if (e.Job.NotificationSettings.NotifyOnVideoFoundDesktop)
			{
				LOGGER.Info($"Informing via balloon tip");

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

		private void ConnectToYoutube()
		{
			LOGGER.Debug($"Youtube account connection method was called");

			tlpSettings.Enabled = false;
			  
			var client = clientContainer.RegisteredClients.FirstOrDefault();

			var addForm = new AddYoutubeAccountForm();
			addForm.ExternalCodeUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, GoogleScope.Manage).AbsoluteUri;
			addForm.SendMailAuthUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, GoogleScope.Manage | GoogleScope.SendMail).AbsoluteUri;

			var result = addForm.ShowDialog(this);
			IYoutubeAccount account = null;
			try
			{
				if (result == DialogResult.OK)
				{
					LOGGER.Info($"Trying to connect a new youtube account");

					if ((account = accountCommunicator.ConnectToAccount(addForm.AuthToken, addForm.MailsRequested, client, YoutubeRedirectUri.Code)) != null)
					{
						LOGGER.Info($"Could connect to account");

						accountContainer.RegisterAccount(account);

						LOGGER.Info($"Reloading categories to match up with that account");

						var loader = new LanguageCategoryLoader(accountContainer);
						var categories = loader.Categories;

						categoryContainer.UnregisterAllCategories();
						foreach (var category in categories)
						{
							LOGGER.Info($"Adding category '{category.Title}'");
							categoryContainer.RegisterCategory(category);
						}

						LOGGER.Info($"Reloading languages");

						var languages = loader.Languages;

						languageContainer.UnregisterAllLanguages();
						foreach (var language in languages)
						{
							LOGGER.Info($"Adding language '{language.Name}'");
							languageContainer.RegisterLanguage(language);
						}

						// Account speichern! Und so!
						accountPersistor.Save();
						categoryPersistor.Save();
						languagePersistor.Save();

						LOGGER.Info($"Youtube account was added successfully");

						MessageBox.Show(this, "Der Uploader wurde erfolgreich mit dem Account verbunden!", "Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Information);

						ActivateAccountLink();
					}
				}
			}
			catch (QuotaErrorException ex)
			{
				LOGGER.Error($"Could not connect to account because max quota was reached", ex);

				MessageBox.Show(this, $"Die Verbindung mit dem Account konnte nicht hergestellt werden. Das liegt daran, dass Youtube die Anzahl der Aufrufe, die Programme machen dürfen, beschränkt. Für dieses Programm wurden heute alle Aufrufe ausgeschöpft, daher geht es heute nicht mehr.{Environment.NewLine}{Environment.NewLine}Bitte versuche es morgen wieder.", "Account kann heute nicht verbunden werden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			tlpSettings.Enabled = true;
		}

		private void ActivateAccountLink()
		{
			LOGGER.Info("Activating account link and start buttons");

			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = addVideosToQueueButton.Enabled = clearVideosButton.Enabled = accountContainer.RegisteredAccounts.Count > 0;
			RefreshToolstripButtonsEnabled();
			lnklblCurrentLoggedIn.Text = accountContainer.RegisteredAccounts.SingleOrDefault()?.Title ?? "Kanaltitel unbekannt";
			btnStart.Enabled = true;
			queueStatusButton.Enabled = true;
		}

		private void btnStartClick(object sender, EventArgs e)
		{
			LOGGER.Debug($"Start autouploader button was clicked");

			if (autoUploader.State == RunningState.NotRunning && ConditionsForStartAreFullfilled())
			{
				LOGGER.Info($"Starting autouploader");

				var publishSettings = pathContainer.ActivePaths
					.Select(path => new ObservationConfiguration(path, templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == path.SelectedTemplateId)))
					.ToArray();

				SetUpAutoUploaderAndQueue(publishSettings);

				autoUploader.StartAsync();
			}
			else
			{
				LOGGER.Info($"Cancelling autouploader");

				canceled = true;
				autoUploader.Cancel(true);
				autoUploader.Uploader.CancelAll();
			}
		}

		private void zeitenFestlegenUndAutouploaderStartenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"Start autouploader with extended settings button was clicked");

			if (autoUploader.State == RunningState.NotRunning && ConditionsForStartAreFullfilled())
			{
				LOGGER.Info($"Starting autouploader with extended settings");

				ChooseStartTimesForm cstForm = new ChooseStartTimesForm(pathContainer, templateContainer);
				var shouldStartUpload = cstForm.ShowDialog(this);

				if (shouldStartUpload == DialogResult.OK)
				{
					LOGGER.Info($"Starting autouploader (via extended settings button)");

					SetUpAutoUploaderAndQueue(cstForm.GetPublishSettingsArray());
					autoUploader.StartWithExtraConfigAsync();
				}
			}
			else
			{
				LOGGER.Info($"Cancelling autouploader (via extended settings button)");

				canceled = true;
				autoUploader.Cancel(true);
				autoUploader.Uploader.CancelAll();
			}
		}

		private void SetUpAutoUploaderAndQueue(IObservationConfiguration[] publishSettings)
		{
			LOGGER.Info($"Setting up autouploader and youtube queue");

			autoUploader.Account = accountContainer.RegisteredAccounts.First();

			autoUploader.Configuration.Clear();
			foreach (var setting in publishSettings)
			{
				LOGGER.Info($"Using settings for path '{setting.PathInfo.Fullname}'");
				LOGGER.Info($"Template to use: {setting.Template.Id} '{setting.Template.Name}'");
				LOGGER.Info($"Startdate for video publishes: '{setting.StartDate}'");
				LOGGER.Info($"Should upload videos private '{setting.UploadPrivate}'");

				autoUploader.Configuration.Add(setting);
			}

			jobQueue.Fill(categoryContainer, languageContainer, playlistContainer, playlistServiceConnectionContainer);

			jobQueue.ShowActionsButtons = true;
			jobQueue.Uploader = autoUploader.Uploader;
		}

		private bool ConditionsForStartAreFullfilled()
		{
			LOGGER.Debug($"Checking if conditions for running the autouploader are fulfilled");

			if (accountContainer.RegisteredAccounts.Count == 0)
			{
				LOGGER.Error($"Autouploader can't be started without a registered youtube account!");

				MessageBox.Show(this, "Es wurde keine Verbindung zu einem Account hergestellt. Bitte zuerst bei einem Youtube-Konto anmelden!", "Kein Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (pathContainer.ActivePaths.Count == 0)
			{
				LOGGER.Error($"Autouploader can't be started without a path to watch!");

				MessageBox.Show(this, "Es wurden keine Pfade hinzugefügt, die der Uploader überwachen soll und die auf aktiv gesetzt sind. Er würde deshalb nichts hochladen. Bitte zuerst Pfade hinzufügen.", "Keine Pfade vorhanden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		delegate void action();
		private void UploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			LOGGER.Debug($"Received uploader property changed event from youtube uploader. Property: '{e.PropertyName}'");

			if (e.PropertyName == nameof(IYoutubeUploader.State))
			{
				LOGGER.Info($"Youtube uploader state has changed to: '{autoUploader.Uploader.State}'");

				if (autoUploader.Uploader.State == UploaderState.Waiting)
				{
					LOGGER.Debug($"Refreshing progress bar");

					Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle)));
					Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(10000, 10000, Handle)));
				}

				if (autoUploader.State == RunningState.NotRunning && autoUploader.Uploader.State == UploaderState.Waiting
					&& autoUploader.Uploader.Queue.All(j => j.State == JobState.Canceled || j.State == JobState.Error || j.State == JobState.Successful))
				{
					LOGGER.Info($"Should end now");

					ended = true;
				}

				if (autoUploader.Uploader.State == UploaderState.NotRunning)
				{
					LOGGER.Info($"Uploader was stopped => should end now");

					ended = true;
					Invoke(new action(() => queueStatusLabel.Text = "Die Warteschlange ist gestoppt"));
				}
				else
				{
					LOGGER.Info($"Uploader was started");

					Invoke(new action(() => queueStatusLabel.Text = "Die Warteschlange wird abgearbeitet"));
				}

				RenameStartButton();
			}
			else if (e.PropertyName == nameof(IYoutubeUploader.Progress))
			{
				progress = autoUploader.Uploader.Progress;

				LOGGER.Debug($"Refreshing progress in taskbar to: '{progress}'");

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
				LOGGER.Debug($"Renaming autouploader start button text to 'Sofort starten!'");

				Invoke(new action(() => btnStart.Text = "Sofort starten!"));
				Invoke(new action(() => zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Enabled = true));
			}
			else
			{
				LOGGER.Debug($"Renaming autouploader start button text to 'Abbrechen!'");

				Invoke(new action(() => btnStart.Text = "Abbrechen!"));
				Invoke(new action(() => zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Enabled = false));
			}

			if (autoUploader.Uploader.State == UploaderState.NotRunning)
			{
				LOGGER.Debug($"Renaming youtube uploader start button text to 'Start!'");

				Invoke(new action(() => queueStatusButton.Text = "Start!"));
			}
			else
			{
				LOGGER.Debug($"Renaming youtube uploader start button text to 'Abbrechen!'");

				Invoke(new action(() => queueStatusButton.Text = "Abbrechen!"));
			}
		}

		private void AutoUploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			LOGGER.Debug($"Received autouploader property changed event. Property: '{e.PropertyName}'");

			if (e.PropertyName == nameof(autoUploader.State))
			{
				if (autoUploader.State == RunningState.NotRunning)
				{
					LOGGER.Info($"Autouploader was stopped => should end now");

					ended = true;
					Invoke(new action(() => autoUploaderStateLabel.Text = "Der AutoUploader ist gestoppt"));
				}
				else
				{
					LOGGER.Info($"Autouploader was started");

					Invoke(new action(() => autoUploaderStateLabel.Text = "Der AutoUploader läuft und fügt gefundene Videos automatisch hinzu"));
				}

				RenameStartButton();
			}
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			LOGGER.Debug($"Mainform is loading => running background worker");

			bgwCreateUploader.RunWorkerAsync();
		}

		private void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			LOGGER.Info($"Attempting to stop the program");

			if (autoUploader.Uploader.State == UploaderState.Uploading)
			{
				LOGGER.Warn($"Uploader is running => asking if the program really should exit");

				var result = MessageBox.Show(this, $"Aktuell werden Videos hochgeladen! Das Hochladen wird abgebrochen und kann beim nächsten Start des Programms fortgesetzt werden.{Environment.NewLine}{Environment.NewLine}Möchtest du das Programm wirklich schließen?", "Schließen bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.No)
				{
					LOGGER.Info($"User decided to not exit the program");

					e.Cancel = true;
					return;
				}
			}

			autoUploader.PropertyChanged -= AutoUploaderPropertyChanged;
			autoUploader.Uploader.PropertyChanged -= UploaderPropertyChanged;

			LOGGER.Info($"Cancelling autouploader");

			autoUploader?.Cancel(false);
			pathPersistor.Save();
			templatePersistor.Save();

			for (int i = 0; i < queueContainer.RegisteredJobs.Count; i++)
			{
				var job = queueContainer.RegisteredJobs.ElementAt(i);
				if (job.State == JobState.Successful)
				{
					LOGGER.Info($"Job for video '{job.Video.Title}' was successful => moving to archive");

					queueContainer.UnregisterJobAt(i);
					archiveContainer.RegisterJob(job);
					i--;
				}
				else if (job.State == JobState.Running)
				{
					LOGGER.Info($"Job for video '{job.Video.Title}' was still running => resetting job to run again on next program execution");

					job.Reset();
				}
			}

			LOGGER.Info($"Saving queue and archive");

			queuePersistor.Save();

			YoutubeJob.SimplifyLogging = true;
			archivePersistor.Save();
			YoutubeJob.SimplifyLogging = false;

			LOGGER.Info($"Stopping program");
		}

		private void RevokeAccess()
		{
			LOGGER.Info($"Revoke access to youtube account");

			tlpSettings.Enabled = false;
			accountCommunicator.RevokeAccount(accountContainer, accountContainer.RegisteredAccounts.Single());
			accountPersistor.Save();

			LOGGER.Info($"Revokation was successful");

			MessageBox.Show(this, "Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButtons.OK, MessageBoxIcon.Information);

			btnStart.Enabled = false;
			queueStatusButton.Enabled = false;

			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountContainer.RegisteredAccounts.Count > 0;
			RefreshToolstripButtonsEnabled();
			tlpSettings.Enabled = true;
		}

		private void RefreshToolstripButtonsEnabled()
		{
			LOGGER.Info("Refreshing tool strip buttons enabled state");

			verbindenToolStripMenuItem.Enabled = accountContainer.RegisteredAccounts.Count == 0;
			verbindungLösenToolStripMenuItem.Enabled = templatesToolStripMenuItem1.Enabled = pfadeToolStripMenuItem1.Enabled = playlistsToolStripMenuItem.Enabled = accountContainer.RegisteredAccounts.Count > 0;
		}

		private void bgwCreateUploaderDoWork(object sender, DoWorkEventArgs e)
		{
			LOGGER.Info("Loading application settings...");

			clientContainer.RegisterClient(YoutubeClientData.Client);

			if (!Directory.Exists("./settings"))
			{
				LOGGER.Info("Creating settings directory");
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

			queuePersistor = new JobPersistor(queueContainer, "./settings/queue.json");
			queuePersistor.Load();

			YoutubeJob.SimplifyLogging = true;
			archivePersistor = new JobPersistor(archiveContainer, "./settings/archive.json");
			archivePersistor.Load();
			YoutubeJob.SimplifyLogging = false;

			playlistPersistor = new PlaylistPersistor(playlistContainer, "./settings/playlists.json");
			playlistPersistor.Load();

			playlistServiceConnectionPersistor = new PlaylistServiceConnectionPersistor(playlistServiceConnectionContainer, "./settings/playlistservice.json");
			playlistServiceConnectionPersistor.Load();

			if (playlistServiceConnectionContainer.Connection != null && playlistServiceConnectionContainer.Connection.Accounts.Length > 0)
			{
				bool somethingChanged = false;

				foreach (var template in templateContainer.RegisteredTemplates)
				{
					var firstId = playlistServiceConnectionContainer.Connection.Accounts.FirstOrDefault(a => a.id >= 0)?.id ?? -1;

					if (template.AccountId == -1 && firstId > -1)
					{
						LOGGER.Info($"Fix: setting account id for playlist service connection of template '{template.Title}' from -1 to {firstId}");
						template.AccountId = firstId;
						somethingChanged = true;
					}
				}

				if (somethingChanged)
				{
					templatePersistor.Save();
				}
			}

			twitterAccountPersistor = new TwitterAccountPersistor(twitterAccountContainer, "./settings/twitter-account.json");
			twitterAccountPersistor.Load();

			foreach (var item in queueContainer.RegisteredJobs)
			{
				item.Account = accountContainer.RegisteredAccounts.FirstOrDefault(a => a.Id == item.Account.Id);

				if (item.Account == null)
				{
					var account = accountContainer.RegisteredAccounts.FirstOrDefault();
					LOGGER.Info($"Fix: saved account for job with video '{item.Video.Title}' could not be found. Using account '{account.Title}' instead.");
					item.Account = account;
				}
			}

			LOGGER.Info("Creating youtube uploader...");
			var uploader = new YoutubeUploader(queueContainer);
			uploader.StopAfterCompleting = false;
			uploader.RemoveCompletedJobs = false;

			LOGGER.Info("Creating automation uploader...");
			autoUploader = new AutomationUploader(uploader, archiveContainer, playlistServiceConnectionContainer);
			autoUploader.WatchedProcesses = processes;

			autoUploader.PropertyChanged += AutoUploaderPropertyChanged;
			autoUploader.Uploader.PropertyChanged += UploaderPropertyChanged;
			autoUploader.Uploader.NewUploadStarted += UploaderNewUploadStarted;
			autoUploader.FileToUploadOccured += AutoUploader_FileToUploadOccured;

			LOGGER.Info("Filling job queue...");
			jobQueue.Fill(categoryContainer, languageContainer, playlistContainer, playlistServiceConnectionContainer);
			jobQueue.Uploader = autoUploader.Uploader;

			LOGGER.Info("Finished loading application settings...");
		}

		private void bgwCreateUploaderRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			cmbbxFinishAction.SelectedIndex = 0;

			limitUploadSpeedCombobox.SelectedIndex = 1;

			RefillSelectedPathsListView();
			RefillArchiveView();
			ActivateAccountLink();
			ActivateAccountLinkTwitter();

			if (File.Exists("stfu-updater.exe"))
			{
				try
				{
					LOGGER.Info("Found updater executable from last update, will attempt to remove it");

					File.Delete("stfu-updater.exe");
				}
				catch (Exception ex)
				{
					LOGGER.Info("Updater executable could not be deleted", ex);
				}
			}

			if (showReleaseNotes || autoUploaderSettings.ShowReleaseNotes)
			{
				LOGGER.Info("Showing release notes");

				var releaseNotesForm = new ReleaseNotesForm(autoUploaderSettings);
				releaseNotesForm.ShowDialog(this);

				settingsPersistor.Save();
			}

			var updateForm = new UpdateForm();
			if (updateForm.ShowDialog(this) == DialogResult.Yes)
			{
				LOGGER.Info("Update triggered, closing application so that it can be updated");

				Close();
				return;
			}

			lnklblCurrentLoggedIn.Visible = lblCurrentLoggedIn.Visible = accountContainer.RegisteredAccounts.Count > 0;
			RefreshToolstripButtonsEnabled();

			if (accountContainer.RegisteredAccounts.Count > 0)
			{
				LOGGER.Info($"Currently logged in: {accountContainer.RegisteredAccounts.SingleOrDefault()?.Title}");
				lnklblCurrentLoggedIn.Text = accountContainer.RegisteredAccounts.SingleOrDefault()?.Title;
			}

			tlpSettings.Enabled = true;

			btnStart.Enabled = queueStatusButton.Enabled = accountContainer.RegisteredAccounts.Count > 0;

			LOGGER.Info("Application started successfully");
		}

		private void lnklblCurrentLoggedInLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (accountContainer.RegisteredAccounts.Count == 0)
			{
				LOGGER.Error("Link to currently logged in account was clicked but there is NONE");
				return;
			}

			Process p = new Process();
			p.StartInfo = new ProcessStartInfo(accountContainer.RegisteredAccounts.Single().Uri.AbsoluteUri);
			p.Start();

			LOGGER.Info($"Link to currently logged in account was clicked. Opening URL: '{accountContainer.RegisteredAccounts.Single().Uri.AbsoluteUri}'");
		}

		private void beendenToolStripMenuItemClick(object sender, EventArgs e)
		{
			LOGGER.Info($"Closing application via main menu strip");
			Close();
		}

		private void chbChoseProcessesCheckedChanged(object sender, EventArgs e)
		{
			btnChoseProcs.Enabled = chbChoseProcesses.Checked;

			if (chbChoseProcesses.Checked)
			{
				LOGGER.Info($"Selected the option to wait for processes to finish");
				ChoseProcesses();
			}
			else
			{
				LOGGER.Info($"Unselected the option to wait for processes to finish");
				processes.Clear();
			}
		}

		private void ChoseProcesses()
		{
			LOGGER.Debug($"Choosing processes to wait for before finishing");

			ProcessForm processChoser = new ProcessForm(processes.Where(p => !p.HasExited).ToList());
			processChoser.ShowDialog(this);

			if (processChoser.DialogResult == DialogResult.OK
				&& processChoser.Selected.Count > 0)
			{
				var procs = processChoser.Selected;
				processes.Clear();
				processes.AddRange(procs);

				LOGGER.Info($"Chose {procs.Count} processes to wait for before finishing");

				foreach (var proc in procs)
				{
					try
					{
						LOGGER.Debug($"Added process: '{proc.ProcessName}'");
					}
					catch (Exception)
					{
						// I do not care
					}
				}
			}
			else
			{
				LOGGER.Info($"No processes to watch were chosen -> unselecting watch for processes checkbox");

				chbChoseProcesses.Checked = false;
			}
		}

		private void cmbbxFinishActionSelectedIndexChanged(object sender, EventArgs e)
		{
			autoUploader.EndAfterUpload = chbChoseProcesses.Enabled = cmbbxFinishAction.SelectedIndex > 0;

			LOGGER.Info($"Action after uploading combobox index was set to: {cmbbxFinishAction.SelectedIndex}");

			if (cmbbxFinishAction.SelectedIndex == 0)
			{
				LOGGER.Info($"Action was set to nothing -> clearing processes if available");
				processes.Clear();
				chbChoseProcesses.Checked = false;
			}
		}

		private void btnChoseProcsClick(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to choose processes was clicked");
			ChoseProcesses();
		}

		private void templatesToolStripMenuItem1Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to manage templates was clicked");

			TemplateForm tf = new TemplateForm(templatePersistor,
				categoryContainer,
				languageContainer,
				playlistContainer,
				playlistServiceConnectionContainer,
				accountContainer.RegisteredAccounts.FirstOrDefault()?.Access.FirstOrDefault()?.HasSendMailPrivilegue ?? false);
			tf.ShowDialog(this);

			templatePersistor.Save();

			RefillSelectedPathsListView();
		}

		private void pfadeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to manage paths was clicked");

			PathForm pf = new PathForm(pathContainer, templateContainer, queueContainer, archiveContainer, accountContainer);
			pf.ShowDialog(this);

			pathPersistor.Save();
			archivePersistor.Save();

			RefillSelectedPathsListView();
			RefillArchiveView();
		}

		private void verbindenToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to connect a youtube account was clicked");

			ConnectToYoutube();
			RefreshToolstripButtonsEnabled();
		}

		private void verbindungLösenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to revoke the youtube account was clicked");

			RevokeAccess();
			RefreshToolstripButtonsEnabled();
		}

		private void threadImLPFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to open the lpf support link was clicked");

			Process.Start("https://letsplayforum.de/thread/175111-beta-strohis-toolset-f%C3%BCr-uploads-automatisch-videos-hochladen/");
		}

		private void strohiAufTwitterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to open the twitter support link was clicked");

			Process.Start("https://twitter.com/strohkoenig");
		}

		private void discordServerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to open the discord support link was clicked");

			Process.Start("https://discord.gg/pDcw6rQ");
		}

		private void downloadSeiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to open the download page link was clicked");

			Process.Start("https://drive.google.com/drive/folders/1kCRPLg-95PjbQKjEpj-HW7tjvzmZ87RI");
		}

		private void threadImYTFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to open the ytf support link was clicked");

			Process.Start("https://ytforum.de/index.php/Thread/19543-BETA-Strohis-Toolset-Für-Uploads-v0-1-1-Videos-automatisch-hochladen/");
		}

		private void neueFunktionenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to show the release notes was clicked");

			var releaseNotesForm = new ReleaseNotesForm(autoUploaderSettings);
			releaseNotesForm.ShowDialog(this);

			settingsPersistor.Save();
		}

		private void logverzeichnisÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists("logs"))
			{
				LOGGER.Info($"Creating logs directory before showing it");

				Directory.CreateDirectory("logs");
			}

			Process.Start("explorer.exe", "logs");
		}

		private void watchingTimer_Tick(object sender, EventArgs e)
		{
			if (ended)
			{
				LOGGER.Debug($"Timer for watching if the program should end: ended was true");

				if (!canceled)
				{
					LOGGER.Info($"Uploads ended and were not canceled");

					// Upload wurde regulär beendet.
					switch (cmbbxFinishAction.SelectedIndex)
					{
						case 1:
							LOGGER.Info($"Closing the program");
							Close();
							return;
						case 2:
							LOGGER.Info($"Shutting down the computer");

							Process.Start("shutdown.exe", "-s -t 60");
							Close();
							return;
						default:
							LOGGER.Info($"No special action was requested after ending");
							break;
					}
				}

				LOGGER.Debug($"resetting ended and canceled flags to false");

				ended = false;
				canceled = false;
			}
		}

		private void queueStatusButton_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"Button to start or stop youtube uploader was clicked");

			var uploader = autoUploader.Uploader;

			if (uploader.State == UploaderState.NotRunning)
			{
				if (accountContainer.RegisteredAccounts.Count == 0)
				{
					LOGGER.Error($"Could not start youtube uploader - there's no account to upload the videos to");

					MessageBox.Show(this, "Es wurde keine Verbindung zu einem Account hergestellt. Bitte zuerst bei einem Youtube-Konto anmelden!", "Kein Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				LOGGER.Info($"Starting youtube uploader");

				jobQueue.Fill(categoryContainer, languageContainer, playlistContainer, playlistServiceConnectionContainer);

				jobQueue.ShowActionsButtons = true;
				jobQueue.Uploader = autoUploader.Uploader;

				uploader.StartUploader();
			}
			else
			{
				LOGGER.Info($"Stopping youtube uploader");

				canceled = true;
				autoUploader.Uploader.CancelAll();
			}
		}

		private void archiveRemoveJobButton_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to remove jobs from archive was clicked");

			RemoveSelectedArchiveJobs();
		}

		private void RemoveSelectedArchiveJobs()
		{
			for (int i = archiveListView.Items.Count - 1; i >= 0; i--)
			{
				bool isSelected = archiveListView.SelectedIndices.Contains(i);
				if (isSelected)
				{
					LOGGER.Debug($"Unregistering job for video '{archiveContainer.RegisteredJobs.ElementAt(i).Video.Title}'");

					archiveContainer.UnregisterJobAt(i);
					archiveListView.Items.RemoveAt(i);
				}
			}

			archivePersistor.Save();
		}

		private void videotutorialPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to open tutorial youtube playlist was clicked");

			Process.Start("https://www.youtube.com/playlist?list=PLm5B9FzOsaWfrn-MeuU_zf7pwooPdPCts");
		}

		private void archiveAddButton_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to videos to archive was clicked");

			var result = openFileDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				var files = openFileDialog.FileNames;
				LOGGER.Info($"Adding {files.Length} files to archive");

				foreach (var file in files)
				{
					LOGGER.Debug($"Adding video '{file}' to archive");
					archiveContainer.RegisterJob(new YoutubeJob(new YoutubeVideo(file) { Title = file }, accountContainer.RegisteredAccounts.FirstOrDefault(), new UploadStatus()));
					archiveListView.Items.Add(file);
				}
			}

			archivePersistor.Save();
		}

		private void archiveListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			moveBackToQueueButton.Enabled = archiveRemoveJobButton.Enabled = archiveListView.SelectedIndices.Count > 0;
		}

		private void moveBackToQueueButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < archiveListView.SelectedIndices.Count; i++)
			{
				var job = archiveContainer.RegisteredJobs.ElementAt(archiveListView.SelectedIndices[i]);

				LOGGER.Info($"Moving '{job.Video.Title}' from archive back to queue");

				job.Reset(true);
				job.Account = accountContainer.RegisteredAccounts.First();
				autoUploader.Uploader.QueueUpload(job);
			}

			RemoveSelectedArchiveJobs();
		}

		private void limitUploadSpeedCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			autoUploader.Uploader.LimitUploadSpeed = limitUploadSpeedCheckbox.Checked;
			LOGGER.Info($"Checkbox to limit upload speed was ticked and is now: {limitUploadSpeedCheckbox.Checked}");
		}

		private void limitUploadSpeedNud_ValueChanged(object sender, EventArgs e)
		{
			LOGGER.Info($"New upload speed limit: {limitUploadSpeedNud.Value} {limitUploadSpeedCombobox.Text}");
			SetNewUploadSpeedLimit();
		}

		private void limitUploadSpeedCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LOGGER.Info($"New upload speed limit: {limitUploadSpeedNud.Value} {limitUploadSpeedCombobox.Text}");
			SetNewUploadSpeedLimit();
		}

		private void SetNewUploadSpeedLimit()
		{
			long value = (long)limitUploadSpeedNud.Value;
			long factor = (long)Math.Pow(1000, limitUploadSpeedCombobox.SelectedIndex + 1);

			LOGGER.Info($"Setting new upload speed limit: {value * factor} kByte/s");

			autoUploader.Uploader.UploadLimitKByte = value * factor;
		}

		private void addVideosToQueueButton_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button to add jobs to the queue manually was clicked");
			AddVideosForm form = new AddVideosForm(templateContainer.RegisteredTemplates.ToArray(), pathContainer.RegisteredPaths.ToArray(), categoryContainer, languageContainer, playlistContainer, playlistServiceConnectionContainer, accountContainer.RegisteredAccounts.First());

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				LOGGER.Info($"Adding {form.Videos.Count} jobs to uploader queue manually");
				templatePersistor.Save();

				foreach (var videoAndEvaluator in form.Videos)
				{
					LOGGER.Info($"Adding job for video '{videoAndEvaluator.Video.Title}' to uploader queue manually");

					var video = videoAndEvaluator.Video;
					var evaluator = videoAndEvaluator.Evaluator;
					var notificationSettings = videoAndEvaluator.NotificationSettings;

					var job = autoUploader.Uploader.QueueUpload(video, accountContainer.RegisteredAccounts.First(), notificationSettings);
					var path = form.TemplateVideoCreator.FindNearestPath(video.File.FullName);

					job.UploadCompletedAction += (args) => evaluator.CleanUp().Wait();

					if (path != null && path.MoveAfterUpload)
					{
						LOGGER.Info($"Adding move after upload action to job");

						job.UploadCompletedAction += (args) => autoUploader.MoveVideo(args.Job, path.MoveDirectoryPath);
					}
				}
			}
		}

		private void clearVideosButton_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Button clear queue was clicked");
			var result = MessageBox.Show(this, $"Hiermit wird die Warteschlange vollständig geleert, alle laufenden Uploads werden abgebrochen.{Environment.NewLine}{Environment.NewLine}Möchtest du das wirklich tun?", "Warteschlange wirklich leeren?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				LOGGER.Info($"Clearing job queue");

				autoUploader.Uploader.CancelAll();

				while (autoUploader.Uploader.Queue.Count > 0)
				{
					LOGGER.Info($"Removing job for video '{autoUploader.Uploader.Queue.ElementAt(0).Video.Title}' from queue");

					autoUploader.Uploader.RemoveFromQueue(autoUploader.Uploader.Queue.ElementAt(0));
				}
			}
		}

		private void verbindenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info("This shit won't get logged");

			ConnectToTwitter();
		}

		private void ConnectToTwitter()
		{
			LOGGER.Info("This shit won't get logged");

			tlpSettings.Enabled = false;

			var oauthCommunicator = new TwitterAccountConnector();
			var addForm = new AddTwitterAccountForm()
			{
				Communicator = oauthCommunicator
			};

			var result = addForm.ShowDialog(this);
			ITwitterAccount account = null;
			try
			{
				if (result == DialogResult.OK && (account = oauthCommunicator.ConnectAccount(addForm.AuthPIN)) != null)
				{
					twitterAccountContainer.Account = account;
					twitterAccountPersistor.Save();

					MessageBox.Show(this, "Der Uploader wurde erfolgreich mit dem Account verbunden!", "Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Information);

					ActivateAccountLinkTwitter();
				}
			}
			catch (QuotaErrorException)
			{
				MessageBox.Show(this, $"Die Verbindung mit dem Account konnte nicht hergestellt werden. Das liegt daran, dass Youtube die Anzahl der Aufrufe, die Programme machen dürfen, beschränkt. Für dieses Programm wurden heute alle Aufrufe ausgeschöpft, daher geht es heute nicht mehr.{Environment.NewLine}{Environment.NewLine}Bitte versuche es morgen wieder.", "Account kann heute nicht verbunden werden!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			tlpSettings.Enabled = true;
		}

		private void ActivateAccountLinkTwitter()
		{
			LOGGER.Info("This shit won't get logged");

			twitterAccountLinkLabel.Visible = twitterAccountLabel.Visible = twitterAccountVerbindungLösenToolStripMenuItem.Enabled = twitterAccountContainer.Account != null;
			twitterAccountVerbindenToolStripMenuItem.Enabled = twitterAccountContainer.Account == null;

			if (twitterAccountContainer.Account != null)
			{
				twitterAccountLinkLabel.Text = twitterAccountContainer.Account.ScreenName;
			}
		}

		private void twitterAccountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LOGGER.Info("This shit won't get logged");

			if (twitterAccountContainer.Account == null)
			{
				return;
			}

			Process p = new Process();
			p.StartInfo = new ProcessStartInfo($"https://twitter.com/i/user/{twitterAccountContainer.Account.UserId}");
			p.Start();
		}

		private void twitterAccountVerbindungLösenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info("This shit won't get logged");

			CoreTweetTest.Tweet(twitterAccountContainer.Account);
			if (twitterAccountContainer.Account != null && TwitterAccountConnector.ScheduleTweet(twitterAccountContainer.Account))
			{
				twitterAccountContainer.Account = null;
				twitterAccountPersistor.Save();

				ActivateAccountLinkTwitter();
			}
		}

		private void playlistsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Opening playlists form");
			new RefreshPlaylistsForm(playlistPersistor, accountContainer.RegisteredAccounts.First()).Show(this);
		}

		private void playlistserviceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Debug($"Opening playlist service form");
			PlaylistServiceForm form = new PlaylistServiceForm(playlistServiceConnectionContainer, clientContainer.RegisteredClients.FirstOrDefault());
			form.ShowDialog(this);

			playlistServiceConnectionPersistor.Save();
		}
	}
}
