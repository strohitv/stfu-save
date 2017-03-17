using System;
using System.Windows.Forms;
using STFU.UploadLib.Automation;

namespace STFU.AutoUploader
{
	public partial class UploadForm : Form
	{
		AutomationUploader uploader = null;

		string statusText = "Warte auf Dateien für den Upload...";
		int progress = 0;

		bool aborted = false;
		bool ended = false;

		public UploadForm(AutomationUploader upl)
		{
			InitializeComponent();
			uploader = upl;

			DialogResult = DialogResult.Cancel;
		}

		private void refreshTimerTick(object sender, EventArgs e)
		{
			statusLabel.Text = statusText;
			prgbarProgress.Value = progress;

			if (!ended)
			{
				return;
			}

			refreshTimer.Enabled = false;
			Close();
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
			statusText = $"Lade {e.FileName} hoch: {e.Progress / 100.0:0.00} %";
			progress = (int)e.Progress;
		}

		private delegate void resetStatusAndForm();
		private void UploaderFinished(EventArgs e)
		{
			if (!aborted)
			{
				DialogResult = DialogResult.OK;
			}

			if (InvokeRequired)
			{
				resetStatusAndForm del = ResetStatusAndForm;

				try
				{
					Invoke(del);
				}
				catch (Exception)
				{ }
			}
			else
			{
				ResetStatusAndForm();
			}
		}

		private void ResetStatusAndForm()
		{
			uploader.ProgressChanged -= ChangedProgress;
			uploader.UploadStarted -= UploadStarted;
			uploader.UploadFinished -= UploadFinished;
			uploader.UploaderFinished -= UploaderFinished;

			ended = true;
		}

		private void btnStopClick(object sender, EventArgs e)
		{
			aborted = true;
			uploader.Stop(true);
			ResetStatusAndForm();
		}

		private void UploadFormLoad(object sender, EventArgs e)
		{
			uploader.ProgressChanged += ChangedProgress;
			uploader.UploadStarted += UploadStarted;
			uploader.UploadFinished += UploadFinished;
			uploader.UploaderFinished += UploaderFinished;

			Left = Screen.PrimaryScreen.WorkingArea.Width - 30 - Width;
			Top = Screen.PrimaryScreen.WorkingArea.Height - 30 - Height;

			uploader.Start();
		}
	}
}
