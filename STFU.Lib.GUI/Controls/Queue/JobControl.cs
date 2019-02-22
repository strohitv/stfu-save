using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.GUI.Controls.Queue
{
	public partial class JobControl : UserControl
	{
		delegate void EnableDelegate();

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
					uploadTitle.Text = job.Video.Title;
					job.PropertyChanged += JobPropertyChanged;
				}
			}
		}

		private string[] Messages { get; set; } = new string[2];
		public string Message => Messages.Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");
		public int Progress { get; private set; }
		private string VideoTitle { get; set; }
		private bool DisableTimer { get; set; } = false;
		private Color BackgroundColor { get; set; } = SystemColors.Control;

		private EnableDelegate EnableTimer;

		private void JobPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Job.IsUploading))
			{
				RunningInformationShown = Job.IsUploading;
			}
			else if (e.PropertyName == nameof(Job.Progress))
			{
				Progress = (int)(Job.Progress * 100);

				if (Job.State == UploadState.ThumbnailUploading
					&& (Job.State == UploadState.VideoUploading || Job.State == UploadState.ThumbnailUploading))
				{
					Messages[0] = $"Lade Thumbnail hoch: {Job.Progress:0.00} %";
				}
				else if (Job.State == UploadState.VideoUploading)
				{
					Messages[0] = $"Lade Video hoch: {Job.Progress:0.00} %";
				}
			}
			else if (e.PropertyName == nameof(Job.State))
			{
				switch (job.State)
				{
					case UploadState.NotStarted:
						Messages[0] = string.Empty;
						Messages[1] = string.Empty;
						BackgroundColor = SystemColors.Control;

						break;
					case UploadState.VideoUploading:
						VideoTitle = job.Video.Title;
						Messages[0] = $"Video-Upload wird gestartet...";
						Messages[1] = string.Empty;
						BackgroundColor = Color.LightBlue;

						Invoke(EnableTimer);
						break;
					case UploadState.ThumbnailUploading:
						Messages[0] = $"Thumbnail-Upload wird gestartet...";
						Messages[1] = string.Empty;
						BackgroundColor = Color.LightBlue;

						Invoke(EnableTimer);
						break;
					case UploadState.CancelPending:
						Messages[0] = $"Upload wird abgebrochen...";
						Messages[1] = string.Empty;
						BackgroundColor = Color.LightYellow;

						break;
					case UploadState.VideoError:
					case UploadState.ThumbnailError:
						Messages[0] = $"Es gab einen Fehler beim Upload.";
						Messages[1] = string.Empty;
						BackgroundColor = Color.IndianRed;

						DisableTimer = true;
						break;
					case UploadState.Canceled:
						Messages[0] = $"Upload wurde abgebrochen.";
						Messages[1] = string.Empty;
						BackgroundColor = Color.IndianRed;

						DisableTimer = true;
						break;
					case UploadState.Successful:
						Messages[0] = $"Upload wurde erfolgreich abgeschlossen.";
						Messages[1] = string.Empty;
						BackgroundColor = Color.LightGreen;

						DisableTimer = true;
						break;
					default:
						throw new ArgumentException("Dieser Status wird nicht unterstützt.");
				}

				refreshUploadStateTimer.Enabled = true;
			}
			else if (e.PropertyName == nameof(Job.RemainingDuration) || e.PropertyName == nameof(Job.UploadedDuration))
			{
				Messages[1] = $"Bisher benötigt: {Job.UploadedDuration.ToString("hh\\:mm\\:ss")}, verbleibende Zeit: {Job.RemainingDuration.ToString("hh\\:mm\\:ss")}";
			}
		}

		public bool RunningInformationShown
		{
			get
			{
				return progressBar.Visible;
			}
			private set
			{
				progressBar.Visible = uploadStateLabel.Visible = value;
			}
		}

		public JobControl()
		{
			InitializeComponent();

			EnableTimer = new EnableDelegate(() => refreshUploadStateTimer.Enabled = true);
		}

		private void actionsButton_Click(object sender, EventArgs e)
		{
			actionsContextMenuStrip.Show(actionsButton, 0, 0);
		}

		private void refreshUploadStateTimer_Tick(object sender, EventArgs e)
		{
			uploadStateLabel.Text = Message;
			progressBar.Value = Progress;
			BackColor = BackgroundColor;

			if (DisableTimer)
			{
				refreshUploadStateTimer.Enabled = false;
			}
		}

		private void startenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Job.ForceUploadAsync();
		}

		private void pausierenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Job.PauseUploadAsync();
		}

		private void fortsetzenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Job.ResumeUploadAsync();
		}

		private void abbrechenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Job.CancelUploadAsync();
		}

		private void überspringenToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			Job.ShouldBeSkipped = überspringenToolStripMenuItem.Checked;
		}

		private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Job.DeleteAsync();
		}
	}
}
