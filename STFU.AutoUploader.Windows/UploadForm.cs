using System;
using System.ComponentModel;
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
		bool allowChosingProcs = false;

		public int UploadEndedActionIndex { get; set; }

		public UploadForm(AutomationUploader upl, int uploadEndedIndex)
		{
			InitializeComponent();
			uploader = upl;

			uploader.PropertyChanged += UploaderPropertyChanged;

			cmbbxFinishAction.SelectedIndex = UploadEndedActionIndex = uploadEndedIndex;
			chbChoseProcesses.Checked = uploader.ShouldWaitForProcs;
			btnChoseProcs.Enabled = chbChoseProcesses.Enabled;

			allowChosingProcs = true;

			DialogResult = DialogResult.Cancel;
		}

		private void UploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(uploader.Message))
			{
				statusText = uploader.Message;
			}
			else if (e.PropertyName == nameof(uploader.Progress))
			{
				progress = (int)(uploader.Progress * 100);
			}
			else if (e.PropertyName == nameof(uploader.IsActive) && !uploader.IsActive)
			{
				if (!aborted)
				{
					DialogResult = DialogResult.OK;
				}

				ResetStatusAndForm();
			}
		}

		private void refreshTimerTick(object sender, EventArgs e)
		{
			statusLabel.Text = statusText;
			prgbarProgress.Value = progress;

			if (ended)
			{
				refreshTimer.Enabled = false;
				Close();
			}
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

		private void ResetStatusAndForm()
		{
			uploader.ProgressChanged -= ChangedProgress;
			uploader.UploadStarted -= UploadStarted;
			uploader.UploadFinished -= UploadFinished;
			uploader.PropertyChanged -= UploaderPropertyChanged;

			ended = true;
		}

		private void btnStopClick(object sender, EventArgs e)
		{
			aborted = true;
			uploader.Stop();
		}

		private void UploadFormLoad(object sender, EventArgs e)
		{
			uploader.ProgressChanged += ChangedProgress;
			uploader.UploadStarted += UploadStarted;
			uploader.UploadFinished += UploadFinished;

			Left = Screen.PrimaryScreen.WorkingArea.Width - 30 - Width;
			Top = Screen.PrimaryScreen.WorkingArea.Height - 30 - Height;

			uploader.StartAsync();
		}

		private void cmbbxFinishActionSelectedIndexChanged(object sender, EventArgs e)
		{
			UploadEndedActionIndex = cmbbxFinishAction.SelectedIndex;
			chbChoseProcesses.Enabled = cmbbxFinishAction.SelectedIndex != 0;

			uploader.SuspendProcessWatcher();

			if (uploader != null)
			{
				uploader.EndAfterUpload = cmbbxFinishAction.SelectedIndex != 0;
			}

			if (cmbbxFinishAction.SelectedIndex == 0)
			{
				uploader?.ClearProcessesToWatch();
				chbChoseProcesses.Checked = false;
			}

			uploader.ResumeProcessWatcher();
		}

		private void chbChoseProcessesCheckedChanged(object sender, EventArgs e)
		{
			if (allowChosingProcs)
			{
				btnChoseProcs.Enabled = chbChoseProcesses.Checked;

				uploader.SuspendProcessWatcher();

				if (chbChoseProcesses.Checked)
				{
					ChoseProcesses();
				}
				else
				{
					uploader.ShouldWaitForProcs = false;
					uploader.ClearProcessesToWatch();
				}

				uploader.ResumeProcessWatcher();
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

		private void btnChoseProcsClick(object sender, EventArgs e)
		{
			uploader.SuspendProcessWatcher();
			ChoseProcesses();
			uploader.ResumeProcessWatcher();
		}
	}
}
