﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.GUI.Controls.Queue
{
	public partial class JobControl : UserControl
	{
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
					RefreshTitleLabel(job.Video.Title);
					job.PropertyChanged += JobPropertyChanged;
				}
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
			if (e.PropertyName == nameof(Job.IsUploading))
			{
				RefreshShowUploadState(Job.State.IsRunningOrInitializing() || Job.State.IsCanceled());
			}
			else if (e.PropertyName == nameof(Job.Progress))
			{
				RefreshProgressBar((int)(Job.Progress * 100));

				if (Job.State == UploadState.ThumbnailUploading
					&& (Job.State == UploadState.VideoUploading || Job.State == UploadState.ThumbnailUploading))
				{
					RefreshDetailFirstLineLabel($"Lade Thumbnail hoch: {Job.Progress:0.00} %");
				}
				else if (Job.State == UploadState.VideoUploading)
				{
					RefreshDetailFirstLineLabel($"Lade Video hoch: {Job.Progress:0.00} %");
				}
			}
			else if (e.PropertyName == nameof(Job.State))
			{
				switch (job.State)
				{
					case UploadState.NotStarted:
						RefreshDetailLabel(string.Empty, string.Empty);
						RefreshBackColor(SystemColors.Control);

						break;
					case UploadState.VideoInitializing:
					case UploadState.VideoUploading:
						RefreshDetailLabel($"Video-Upload wird gestartet...", string.Empty);
						RefreshBackColor(Color.LightBlue);

						break;
					case UploadState.VideoUploaded:
					case UploadState.ThumbnailUploading:
						RefreshDetailLabel($"Thumbnail-Upload wird gestartet...", string.Empty);
						RefreshBackColor(Color.LightBlue);

						break;
					case UploadState.CancelPending:
						RefreshDetailLabel($"Upload wird abgebrochen...", string.Empty);
						RefreshBackColor(Color.LightYellow);

						break;
					case UploadState.VideoError:
					case UploadState.ThumbnailError:
						RefreshDetailLabel($"Es gab einen Fehler beim Upload.", string.Empty);
						RefreshBackColor(Color.IndianRed);

						break;
					case UploadState.Canceled:
						RefreshDetailLabel($"Upload wurde abgebrochen.", string.Empty);
						RefreshBackColor(Color.IndianRed);

						break;
					case UploadState.PausePending:
						RefreshDetailLabel($"Upload wird pausiert...", string.Empty);
						RefreshBackColor(Color.LightGray);

						break;
					case UploadState.Paused:
						RefreshDetailLabel($"Upload ist pausiert...", string.Empty);
						RefreshBackColor(Color.LightGray);

						break;
					case UploadState.Successful:
						RefreshDetailLabel($"Upload wurde erfolgreich abgeschlossen.", string.Empty);
						RefreshBackColor(Color.LightGreen);

						break;
					default:
						throw new ArgumentException("Dieser Status wird nicht unterstützt.");
				}

				RefreshContextMenuEnabled();
			}
			else if (e.PropertyName == nameof(Job.RemainingDuration) || e.PropertyName == nameof(Job.UploadedDuration))
			{
				RefreshDetailSecondLineLabel($"Bisher benötigt: {Job.UploadedDuration.ToString("hh\\:mm\\:ss")}, verbleibende Zeit: {Job.RemainingDuration.ToString("hh\\:mm\\:ss")}");
			}
		}

		private void RefreshActionsButtonVisibility(bool visible)
		{
			Safe(() => actionsButton.Visible = visible, actionsButton);
		}

		private void RefreshTitleLabel(string title)
		{
			Safe(() => uploadTitle.Text = title, uploadTitle);
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
			Safe(() => startenToolStripMenuItem.Enabled = !Job.State.IsStarted());
			Safe(() => fortsetzenToolStripMenuItem.Enabled = Job.State == UploadState.Paused);
			Safe(() => pausierenToolStripMenuItem.Enabled = Job.State.IsStarted());
			Safe(() => abbrechenToolStripMenuItem.Enabled = Job.State.IsStarted());
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
			if (InvokeRequired)
			{
				Invoke(action);
			}
			else
			{
				action();
			}
		}
	}
}
