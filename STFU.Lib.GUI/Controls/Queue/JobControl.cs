using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Common;
using STFU.Lib.GUI.Forms;
using STFU.Lib.Playlistservice;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Upload.Steps;

namespace STFU.Lib.GUI.Controls.Queue
{
	public delegate void MoveRequested(JobControl sender);

	public partial class JobControl : UserControl
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(JobControl));

		private IYoutubeCategoryContainer categoryContainer;
		private IYoutubeLanguageContainer languageContainer;
		private IYoutubePlaylistContainer playlistContainer;
		private IPlaylistServiceConnectionContainer pscContainer;

		public event MoveRequested MoveUpRequested;
		public event MoveRequested MoveDownRequested;

		private BlockingCollection<JobChangedArgs> Actions { get; } = new BlockingCollection<JobChangedArgs>();

		public bool CanBeMovedUp { get => nachObenSchiebenToolStripMenuItem.Enabled; set => nachObenSchiebenToolStripMenuItem.Enabled = value; }
		public bool CanBeMovedDown { get => nachUntenSchiebenToolStripMenuItem.Enabled; set => nachUntenSchiebenToolStripMenuItem.Enabled = value; }

		private string currentUploadObject = "nichts";

		private DateTime nextUploadStart = DateTime.Now;

		private IYoutubeJob job = null;
		public IYoutubeJob Job
		{
			get
			{
				return job;
			}
			set
			{
				if (job != value)
				{
					LOGGER.Info($"Changing job from '{job}' to new job '{value}'");

					if (job != null)
					{
						job.PropertyChanged -= JobPropertyChanged;
						job.UploadStatus.PropertyChanged -= UploadStatusPropertyChanged;
					}

					job = value;

					RefreshTitleLabel();
					RefreshThumbnail();
					RefreshControl();
					RefreshTitleLabel();
					RefreshContextMenuEnabled();

					job.PropertyChanged += JobPropertyChanged;
					job.UploadStatus.PropertyChanged += UploadStatusPropertyChanged;
				}
			}
		}

		private void UploadStatusPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			LOGGER.Debug($"Job upload status property changed: '{e.PropertyName}'");
			Actions.Add(new JobChangedArgs(JobChangedType.UploadStatusPropertyChanged, e));
		}

		private void OnUploadStatusPropertyChanged(PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(UploadStatus.CurrentStep))
			{
				if (Job.UploadStatus.CurrentStep is RetryingUploadStep<VideoUploadStep>)
				{
					currentUploadObject = "Video";
				}
				else if (Job.UploadStatus.CurrentStep is RetryingUploadStep<ThumbnailUploadStep>)
				{
					currentUploadObject = "Thumbnail";
				}
				else if (Job.UploadStatus.CurrentStep is RetryingUploadStep<ChangeVideoDetailsStep>)
				{
					currentUploadObject = "Details";
				}
				else if (Job.UploadStatus.CurrentStep is RetryingUploadStep<AddToPlaylistStep>)
				{
					currentUploadObject = "Playlist";
				}
				else
				{
					currentUploadObject = "nichts";
				}

				LOGGER.Info($"Current upload object was set to '{currentUploadObject}' from OnUploadStatusPropertyChanged");
			}
		}

		private void RefreshThumbnail()
		{
			LOGGER.Debug($"Refreshing thumbnail to path '{Job.Video.ThumbnailPath}'");

			thumbnailBox.BackgroundImage = ThumbnailLoader.Load(Job.Video.ThumbnailPath);
			thumbnailBox.BackgroundImageLayout = ImageLayout.Zoom;
			thumbnailBox.Visible = true;
		}

		private bool actionsButtonVisible = true;
		public bool ActionsButtonsVisible
		{
			get
			{
				return actionsButtonVisible;
			}
			set
			{
				if (actionsButtonVisible != value)
				{
					actionsButtonVisible = value;
					RefreshActionsButtonVisibility(ActionsButtonsVisible);
				}
			}
		}

		private void JobPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			LOGGER.Info($"Job property changed: '{e.PropertyName}'");

			Actions.Add(new JobChangedArgs(JobChangedType.PropertyChanged, e));
		}

		private void OnJobPropertyChanged(PropertyChangedEventArgs e)
		{
			if (currentUploadObject == "nichts")
			{
				if (Job.UploadStatus.CurrentStep is RetryingUploadStep<VideoUploadStep>)
				{
					currentUploadObject = "Video";
				}
				else if (Job.UploadStatus.CurrentStep is RetryingUploadStep<ThumbnailUploadStep>)
				{
					currentUploadObject = "Thumbnail";
				}
				else if (Job.UploadStatus.CurrentStep is RetryingUploadStep<ChangeVideoDetailsStep>)
				{
					currentUploadObject = "Details";
				}
				else if (Job.UploadStatus.CurrentStep is RetryingUploadStep<AddToPlaylistStep>)
				{
					currentUploadObject = "Playlist";
				}
				else
				{
					currentUploadObject = "nichts";
				}

				LOGGER.Info($"Current upload object was set to '{currentUploadObject}' from OnJobPropertyChanged");
			}

			if (e.PropertyName == nameof(Job.State))
			{
				RefreshControl();
			}
			else if (e.PropertyName == nameof(Job.Error))
			{
				RefreshDetailSecondLineLabel(Job.Error.Message);

				LOGGER.Error($"Upload Failed because of reason '{Job.Error.FailReason}' with message: '{Job.Error.Message}'");

				if (Job.Error.FailReason == FailureReason.UserUploadLimitExceeded)
				{
					MessageBox.Show(this, $"Youtube hat den Upload weiterer Videos vorerst abgelehnt, da für diesen Account in den letzten Stunden zu viele Videos hochgeladen wurden.{Environment.NewLine}{Environment.NewLine}In der Regel sollte der Upload bald wieder klappen.{Environment.NewLine}Versuche es am besten in ungefähr einer bis ein paar Stunden noch mal.{Environment.NewLine}Solltest du nicht so lange warten wollen, wirst du auf die von Youtube angebotene Upload-Seite im Internet oder auf ein anderes Upload-Programm ausweichen müssen.{Environment.NewLine}{Environment.NewLine}Es handelt sich hierbei nicht um einen Fehler des Programms. Der Upload wird von Youtube direkt abgelehnt.", "Weitere Videos abgelehnt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (e.PropertyName == nameof(Job.ShouldBeSkipped))
			{
				LOGGER.Debug($"Refreshing skipped state. New value: {Job.ShouldBeSkipped}");

				if (Job.ShouldBeSkipped)
				{
					RefreshDetailLabel($"Upload wird übersprungen...", string.Empty);
					uploadTitle.Text = $"{Job.Video.Title} (wird übersprungen)";
					RefreshBackColor(Color.FromArgb(180, 180, 180));
				}
				else
				{
					uploadTitle.Text = Job.Video.Title;
					RefreshControl();
				}
			}
		}

		private void RefreshControl()
		{
			refreshUploadBrokenTimer.Enabled = false;

			if (!job.ShouldBeSkipped)
			{
				LOGGER.Info($"Refreshing job control for state {Job.ShouldBeSkipped}");

				switch (job.State)
				{
					case JobState.NotStarted:
						RefreshDetailLabel(string.Empty, string.Empty);
						RefreshBackColor(Color.Transparent);

						break;
					case JobState.Running:
						RefreshDetailLabel($"Upload wird gestartet...", string.Empty);
						RefreshBackColor(Color.FromArgb(192, 255, 255));

						break;
					case JobState.Error:
						RefreshDetailLabel($"Es gab einen Fehler beim Upload.", Job.Error?.Message);
						RefreshBackColor(Color.FromArgb(255, 192, 192));

						break;
					case JobState.Canceled:
						RefreshDetailLabel($"Upload wurde abgebrochen.", string.Empty);
						RefreshBackColor(Color.FromArgb(255, 192, 192));

						break;
					case JobState.Paused:
						RefreshDetailLabel($"Upload ist pausiert...", string.Empty);
						RefreshBackColor(Color.FromArgb(224, 224, 224));

						break;
					case JobState.Successful:
						RefreshDetailLabel($"Upload wurde erfolgreich abgeschlossen.", string.Empty);
						RefreshBackColor(Color.FromArgb(192, 255, 192));

						break;
					case JobState.Broke:
						RefreshDetailLabel($"Upload wurde unerwartet unterbrochen (z. B. fehlende Internetverbindung).", "Warte 01:30 Minuten und versuche es dann erneut...");
						RefreshBackColor(Color.FromArgb(224, 224, 224));
						nextUploadStart = DateTime.Now.AddSeconds(90);
						refreshUploadBrokenTimer.Enabled = true;

						break;
					case JobState.QuotaReached:
						RefreshDetailLabel($"Der Uploader darf von Youtube aus heute nicht weiter Videos hochladen.", "Warte bis morgen (24:00:00 Stunden) und versuche es dann erneut...");
						RefreshBackColor(Color.FromArgb(224, 224, 224));
						nextUploadStart = DateTime.Now.Add(job.UploadStatus.WaitTime);
						refreshUploadBrokenTimer.Enabled = true;

						break;
					default:
						throw new ArgumentException("Dieser Status wird nicht unterstützt.");
				}
			}
			else
			{
				LOGGER.Info($"Setting control to should be skipped state");

				RefreshDetailLabel($"Upload wird übersprungen...", string.Empty);
				uploadTitle.Text = $"{Job.Video.Title} (wird übersprungen)";
				überspringenToolStripMenuItem.Checked = true;
				RefreshBackColor(Color.FromArgb(180, 180, 180));
			}

			RefreshShowUploadState(Job.State.IsStarted() || Job.State.IsCanceled());
			RefreshContextMenuEnabled();
		}

		public void Fill(IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer, IYoutubePlaylistContainer plContainer, IPlaylistServiceConnectionContainer pscContainer)
		{
			LOGGER.Info($"Filling container into this control");

			categoryContainer = catContainer;
			languageContainer = langContainer;
			playlistContainer = plContainer;
			this.pscContainer = pscContainer;
		}

		private void RefreshActionsButtonVisibility(bool visible)
		{
			actionsButton.Visible = visible;
		}

		private void RefreshTitleLabel()
		{
			if (Job.ShouldBeSkipped)
			{
				uploadTitle.Text = $"{Job.Video.Title} (wird übersprungen)";
			}
			else
			{
				uploadTitle.Text = Job.Video.Title;
			}
		}

		private string firstDetailLine = string.Empty;
		private string secondDetailLine = string.Empty;
		private void RefreshDetailLabel(string firstLine, string secondLine)
		{
			firstDetailLine = firstLine;
			secondDetailLine = secondLine;
			uploadStateLabel.Text = $"{firstLine}{Environment.NewLine}{secondLine}";
		}

		private void RefreshDetailFirstLineLabel(string firstLine)
		{
			firstDetailLine = firstLine;
			uploadStateLabel.Text = $"{firstLine}{Environment.NewLine}{secondDetailLine}";
		}

		private void RefreshDetailSecondLineLabel(string secondLine)
		{
			secondDetailLine = secondLine;
			uploadStateLabel.Text = $"{firstDetailLine}{Environment.NewLine}{secondLine}";
		}

		private void RefreshProgressBar(int progress)
		{
			progressBar.Value = progress;
		}

		private void RefreshBackColor(Color backgroundColor)
		{
			BackColor = backgroundColor;
		}

		private void RefreshShowUploadState(bool showIt)
		{
			progressBar.Visible = uploadStateLabel.Visible = showIt;
		}

		private void RefreshContextMenuEnabled()
		{
			startenToolStripMenuItem.Enabled = !Job.State.IsStarted() || Job.State.IsFailed() || Job.State.IsCanceled();
			fortsetzenToolStripMenuItem.Enabled = Job.State == JobState.Paused;
			pausierenToolStripMenuItem.Enabled = Job.State.IsStarted() && !Job.State.IsPausingOrPaused();
			abbrechenToolStripMenuItem.Enabled = Job.State.IsStarted() && !Job.State.IsFailed() && !Job.State.IsCanceled();
			überspringenToolStripMenuItem.Enabled = !Job.State.IsStarted();
		}

		public JobControl()
		{
			LOGGER.Info($"Creating new JobControl");

			InitializeComponent();
		}

		private void actionsButton_Click(object sender, EventArgs e)
		{
			actionsContextMenuStrip.Show(actionsButton, 0, 0);
		}

		private void startenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked start job tool strip menu entry");

			Job.Reset();
			Job.Run();
		}

		private void pausierenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked pause job tool strip menu entry");

			RefreshDetailLabel($"Upload wird pausiert...", string.Empty);
			RefreshBackColor(Color.FromArgb(224, 224, 224));

			Job.Pause();
		}

		private void fortsetzenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked resume job tool strip menu entry");

			Job.Resume();
		}

		private void abbrechenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked cancel job tool strip menu entry");

			RefreshDetailLabel($"Upload wird abgebrochen...", string.Empty);
			RefreshBackColor(Color.FromArgb(255, 255, 192));

			Job.Cancel();
		}

		private void überspringenToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked skip job tool strip menu entry");

			Job.ShouldBeSkipped = überspringenToolStripMenuItem.Checked;
		}

		private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked delete job tool strip menu entry");

			Job.Delete();
		}

		private void nachObenSchiebenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked move job up tool strip menu entry");

			MoveUpRequested?.Invoke(this);
		}

		private void nachUntenSchiebenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked move job down tool strip menu entry");

			MoveDownRequested?.Invoke(this);
		}

		public override string ToString()
		{
			return Job.ToString();
		}

		private void detailsBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User clicked edit job details tool strip menu entry");

			EditVideoForm form = new EditVideoForm(Job.Video.CreateCopy(), Job.NotificationSettings.CreateCopy(), Job.Account.Access.First().HasSendMailPrivilegue, categoryContainer, languageContainer, playlistContainer, pscContainer);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Job.Video.FillFields(form.Video);
				Job.NotificationSettings = form.NotificationSettings;

				RefreshTitleLabel();
				RefreshThumbnail();
			}
		}

		private void refreshUploadBrokenTimer_Tick(object sender, EventArgs e)
		{
			if (job.UploadStatus.QuotaReached)
			{
				RefreshDetailLabel($"Der Uploader darf von Youtube aus heute nicht weiter Videos hochladen.", $"Warte bis morgen ({(nextUploadStart - DateTime.Now).ToString("h\\:mm\\:ss")} Stunden) und versuche es dann erneut...");
			}
			else
			{
				RefreshDetailLabel($"Upload wurde unerwartet unterbrochen (z. B. fehlende Internetverbindung).", $"Warte {(nextUploadStart - DateTime.Now).ToString("mm\\:ss")} Minuten und versuche es dann erneut...");
			}
			RefreshBackColor(Color.FromArgb(224, 224, 224));
		}

		public void RefreshJobControl()
		{
			if (Job.State == JobState.Running)
			{
				Job.RefreshDurationAndSpeed();

				RefreshProgressBar((int)(Job.UploadStatus.Progress * 100));
				if (currentUploadObject == "Details")
				{
					RefreshDetailFirstLineLabel($"Editiere das Video...");
				}
				else
				{
					RefreshDetailFirstLineLabel($"Lade {currentUploadObject} hoch: {Job.UploadStatus.Progress:0.00} %");
				}
				RefreshDetailSecondLineLabel($"Bisher benötigt: {Job.UploadStatus.UploadedDuration.ToString("hh\\:mm\\:ss")}, verbleibende Zeit: {Job.UploadStatus.RemainingDuration.ToString("hh\\:mm\\:ss")}, Geschwindigkeit: {CalculateAverageSpeed(Job.UploadStatus.CurrentSpeed)}");
			}
		}

		private int logOffset = 0;
		string[] dataUnits = new[] { "B/s", "kB/s", "MB/s", "GB/s", "TB/s" };
		private string CalculateAverageSpeed(double size)
		{
			int unitIndex = 0;
			while (size > 1000)
			{
				size /= 1000;
				unitIndex++;
			}

			string result = $"{size:0.00} {dataUnits[unitIndex]}";

			if (logOffset == 0)
			{
				LOGGER.Info($"Current average speed: '{result}'");
			}
			else
			{
				LOGGER.Debug($"Current average speed: '{result}'");
			}
			logOffset = (logOffset + 1) % 20;

			return result;
		}

		public void HandleActions()
		{
			while (Actions.Count > 0)
			{
				var action = Actions.Take();
				PropertyChangedEventArgs args = (PropertyChangedEventArgs)action.Args;

				switch (action.Type)
				{
					case JobChangedType.PropertyChanged:
						OnJobPropertyChanged(args);
						break;
					case JobChangedType.UploadStatusPropertyChanged:
						OnUploadStatusPropertyChanged(args);
						break;
				}
			}
		}
	}
}
