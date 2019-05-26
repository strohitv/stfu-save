using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageProcessor;
using STFU.Lib.GUI.Forms;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.GUI.Controls.Queue
{
	public delegate void MoveRequested(JobControl sender);

	public partial class JobControl : UserControl
	{
		private IYoutubeCategoryContainer categoryContainer;
		private IYoutubeLanguageContainer languageContainer;

		public event MoveRequested MoveUpRequested;
		public event MoveRequested MoveDownRequested;

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
					if (job != null)
					{
						job.PropertyChanged -= JobPropertyChanged;
					}

					job = value;
					RefreshContextMenuEnabled();

					RefreshTitleLabel();
					RefreshThumbnail();

					job.PropertyChanged += JobPropertyChanged;
				}
			}
		}

		private void RefreshThumbnail()
		{
			if (File.Exists(Job.Video.ThumbnailPath))
			{
				try
				{
					ImageFactory imageFactory = new ImageFactory().Load(Job.Video.ThumbnailPath);
					thumbnailBox.BackgroundImage = imageFactory.Image;
					thumbnailBox.BackgroundImageLayout = ImageLayout.Zoom;
					thumbnailBox.Visible = true;
				}
				catch (Exception)
				{
					thumbnailBox.Visible = false;
				}
			}
			else
			{
				thumbnailBox.Visible = false;
			}
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
			if (e.PropertyName == nameof(Job.Progress))
			{
				RefreshProgressBar((int)(Job.Progress * 100));
				RefreshDetailFirstLineLabel($"Lade {currentUploadObject} hoch: {Job.Progress:0.00} %");
			}
			else if (e.PropertyName == nameof(Job.CurrentObject))
			{
				switch (Job.CurrentObject)
				{
					case UploadObject.Video:
						currentUploadObject = "Video";
						break;
					case UploadObject.Thumbnail:
						currentUploadObject = "Thumbnail";
						break;
					default:
						currentUploadObject = "nichts";
						break;
				}
			}
			else if (e.PropertyName == nameof(Job.State))
			{
				RefreshControl();
			}
			else if (e.PropertyName == nameof(Job.RemainingDuration) || e.PropertyName == nameof(Job.UploadedDuration))
			{
				RefreshDetailSecondLineLabel($"Bisher benötigt: {Job.UploadedDuration.ToString("hh\\:mm\\:ss")}, verbleibende Zeit: {Job.RemainingDuration.ToString("hh\\:mm\\:ss")}");
			}
			else if (e.PropertyName == nameof(Job.Error))
			{
				RefreshDetailSecondLineLabel(Job.Error.Message);
				if (Job.Error.FailReason == FailureReason.UserUploadLimitExceeded)
				{
					Safe(() => MessageBox.Show(this, $"Youtube hat den Upload weiterer Videos vorerst abgelehnt, da für diesen Account in den letzten Stunden zu viele Videos hochgeladen wurden.{Environment.NewLine}{Environment.NewLine}In der Regel sollte der Upload bald wieder klappen.{Environment.NewLine}Versuche es am besten in ungefähr einer bis ein paar Stunden noch mal.{Environment.NewLine}Solltest du nicht so lange warten wollen, wirst du auf die von Youtube angebotene Upload-Seite im Internet oder auf ein anderes Upload-Programm ausweichen müssen.{Environment.NewLine}{Environment.NewLine}Es handelt sich hierbei nicht um einen Fehler des Programms. Der Upload wird von Youtube direkt abgelehnt.", "Weitere Videos abgelehnt", MessageBoxButtons.OK, MessageBoxIcon.Error), this);
				}
			}
			else if (e.PropertyName == nameof(Job.ShouldBeSkipped))
			{
				if (Job.ShouldBeSkipped)
				{
					RefreshDetailLabel($"Upload wird übersprungen...", string.Empty);
					Safe(() => uploadTitle.Text = $"{Job.Video.Title} (wird übersprungen)");
					RefreshBackColor(Color.FromArgb(180, 180, 180));
				}
				else
				{
					Safe(() => uploadTitle.Text = Job.Video.Title);
					RefreshControl();
				}
			}
		}

		private void RefreshControl()
		{
			Safe(() => refreshUploadBrokenTimer.Enabled = false);

			switch (job.State)
			{
				case UploadProgress.NotRunning:
					RefreshDetailLabel(string.Empty, string.Empty);
					RefreshBackColor(Color.Transparent);

					break;
				case UploadProgress.Running:
					RefreshDetailLabel($"Upload wird gestartet...", string.Empty);
					RefreshBackColor(Color.FromArgb(192, 255, 255));

					break;
				case UploadProgress.CancelPending:
					RefreshDetailLabel($"Upload wird abgebrochen...", string.Empty);
					RefreshBackColor(Color.FromArgb(255, 255, 192));

					break;
				case UploadProgress.Failed:
					RefreshDetailLabel($"Es gab einen Fehler beim Upload.", Job.Error?.Message);
					RefreshBackColor(Color.FromArgb(255, 192, 192));

					break;
				case UploadProgress.Canceled:
					RefreshDetailLabel($"Upload wurde abgebrochen.", string.Empty);
					RefreshBackColor(Color.FromArgb(255, 192, 192));

					break;
				case UploadProgress.PausePending:
					RefreshDetailLabel($"Upload wird pausiert...", string.Empty);
					RefreshBackColor(Color.FromArgb(224, 224, 224));

					break;
				case UploadProgress.Paused:
					RefreshDetailLabel($"Upload ist pausiert...", string.Empty);
					RefreshBackColor(Color.FromArgb(224, 224, 224));

					break;
				case UploadProgress.Successful:
					RefreshDetailLabel($"Upload wurde erfolgreich abgeschlossen.", string.Empty);
					RefreshBackColor(Color.FromArgb(192, 255, 192));

					break;
				case UploadProgress.Broke:
					RefreshDetailLabel($"Upload wurde unerwartet unterbrochen (z. B. fehlende Internetverbindung).", "Warte 01:30 Minuten und versuche es dann erneut...");
					RefreshBackColor(Color.FromArgb(224, 224, 224));
					nextUploadStart = DateTime.Now.AddSeconds(90);
					Safe(() => refreshUploadBrokenTimer.Enabled = true);

					break;
				default:
					throw new ArgumentException("Dieser Status wird nicht unterstützt.");
			}

			RefreshShowUploadState(Job.State.IsStarted() || Job.State.IsCanceled());
			RefreshContextMenuEnabled();
		}

		public void Fill(IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer)
		{
			categoryContainer = catContainer;
			languageContainer = langContainer;
		}

		private void RefreshActionsButtonVisibility(bool visible)
		{
			Safe(() => actionsButton.Visible = visible, actionsButton);
		}

		private void RefreshTitleLabel()
		{
			if (Job.ShouldBeSkipped)
			{
				Safe(() => uploadTitle.Text = $"{Job.Video.Title} (wird übersprungen)");
			}
			else
			{
				Safe(() => uploadTitle.Text = Job.Video.Title, uploadTitle);
			}
		}

		private string firstDetailLine = string.Empty;
		private string secondDetailLine = string.Empty;
		private void RefreshDetailLabel(string firstLine, string secondLine)
		{
			firstDetailLine = firstLine;
			secondDetailLine = secondLine;
			Safe(() => uploadStateLabel.Text = $"{firstLine}{Environment.NewLine}{secondLine}", uploadStateLabel);
		}

		private void RefreshDetailFirstLineLabel(string firstLine)
		{
			firstDetailLine = firstLine;
			Safe(() => uploadStateLabel.Text = $"{firstLine}{Environment.NewLine}{secondDetailLine}", uploadStateLabel);
		}

		private void RefreshDetailSecondLineLabel(string secondLine)
		{
			secondDetailLine = secondLine;
			Safe(() => uploadStateLabel.Text = $"{firstDetailLine}{Environment.NewLine}{secondLine}", uploadStateLabel);
		}

		private void RefreshProgressBar(int progress)
		{
			Safe(() => progressBar.Value = progress, progressBar);
		}

		private void RefreshBackColor(Color backgroundColor)
		{
			Safe(() => BackColor = backgroundColor);
		}

		private void RefreshShowUploadState(bool showIt)
		{
			Safe(() => progressBar.Visible = uploadStateLabel.Visible = showIt, progressBar);
		}

		private void RefreshContextMenuEnabled()
		{
			Safe(() => startenToolStripMenuItem.Enabled = !Job.State.IsStarted() || Job.State.IsFailed() || Job.State.IsCanceled());
			Safe(() => fortsetzenToolStripMenuItem.Enabled = Job.State == UploadProgress.Paused);
			Safe(() => pausierenToolStripMenuItem.Enabled = Job.State.IsStarted() && !Job.State.IsPausingOrPaused());
			Safe(() => abbrechenToolStripMenuItem.Enabled = Job.State.IsStarted() && !Job.State.IsFailed() && !Job.State.IsCanceled());
			Safe(() => überspringenToolStripMenuItem.Enabled = !Job.State.IsStarted());
		}

		public JobControl()
		{
			InitializeComponent();
		}

		private void actionsButton_Click(object sender, EventArgs e)
		{
			Safe(() => actionsContextMenuStrip.Show(actionsButton, 0, 0));
		}

		private void startenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Safe(() => Job.ForceUploadAsync());
		}

		private void pausierenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Safe(() => Job.PauseUploadAsync());
		}

		private void fortsetzenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Safe(() => Job.ResumeUploadAsync());
		}

		private void abbrechenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Safe(() => Job.CancelUploadAsync());
		}

		private void überspringenToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			Safe(() => Job.ShouldBeSkipped = überspringenToolStripMenuItem.Checked);
		}

		private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Safe(() => Job.DeleteAsync());
		}

		private void Safe(Action action)
		{
			Safe(action, this);
		}

		private void Safe(Action action, Control control)
		{
			try
			{
				if (InvokeRequired)
				{
					Invoke(action);
				}
				else
				{
					action();
				}
			}
			catch (Exception)
			{ }
		}

		private void nachObenSchiebenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MoveUpRequested?.Invoke(this);
		}

		private void nachUntenSchiebenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MoveDownRequested?.Invoke(this);
		}

		public override string ToString()
		{
			return Job.ToString();
		}

		private void detailsBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Job.BeginEdit();

			EditVideoForm form = new EditVideoForm(Job.Video.CreateCopy(), categoryContainer, languageContainer);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Job.Video.FillFields(form.Video);

				RefreshTitleLabel();
				RefreshThumbnail();
			}

			Job.FinishEdit();
		}

		private void refreshUploadBrokenTimer_Tick(object sender, EventArgs e)
		{
			RefreshDetailLabel($"Upload wurde unerwartet unterbrochen (z. B. fehlende Internetverbindung).", $"Warte {(nextUploadStart - DateTime.Now).ToString("mm\\:ss")} Minuten und versuche es dann erneut...");
			RefreshBackColor(Color.FromArgb(224, 224, 224));
		}
	}
}
