using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.AutoUploader
{
	public partial class UploadForm : Form
	{
		IAutomationUploader autoUploader = null;

		string statusText = "Warte auf Dateien für den Upload...";
		int progress = 0;

		bool aborted = false;
		bool ended = false;
		bool allowChosingProcs = false;

		public int UploadEndedActionIndex { get; set; }

		public UploadForm(IAutomationUploader upl, int uploadEndedIndex)
		{
			InitializeComponent();
			autoUploader = upl;

			autoUploader.PropertyChanged += AutoUploaderPropertyChanged;
			autoUploader.Uploader.PropertyChanged += UploaderPropertyChanged;
			autoUploader.Uploader.NewUploadStarted += OnNewUploadStarted;

			cmbbxFinishAction.SelectedIndex = UploadEndedActionIndex = uploadEndedIndex;
			chbChoseProcesses.Checked = autoUploader.ShouldWaitForProcs;
			btnChoseProcs.Enabled = chbChoseProcesses.Enabled;

			allowChosingProcs = true;

			DialogResult = DialogResult.Cancel;
		}

		private void OnNewUploadStarted(EventArgs args)
		{
			var currentUpload = autoUploader.Uploader.Queue.Single(job => job.State != UploadState.NotStarted);
			currentUpload.PropertyChanged += CurrentUploadPropertyChanged;
		}

		private void CurrentUploadPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var job = (IYoutubeJob)sender;

			if (e.PropertyName == nameof(job.Progress) 
				&& (job.State == UploadState.Running || job.State == UploadState.ThumbnailUploading))
			{
				if (job.State == UploadState.ThumbnailUploading)
				{
					statusText = $"Lade Thumbnail für {job.Video.Title} hoch: {job.Progress / 100.0:0.00} %";
				}
				else
				{
					statusText = $"Lade {job.Video.Title} hoch: {job.Progress / 100.0:0.00} %";
				}
				progress = (int)job.Progress;
			}
			else if (e.PropertyName == nameof(job.State))
			{
				switch (job.State)
				{
					case UploadState.NotStarted:
						statusText = $"Starte Upload von {job.Video.Title}...";
						break;
					case UploadState.Running:
						statusText = $"Upload von {job.Video.Title} läuft...";
						break;
					case UploadState.ThumbnailUploading:
						statusText = $"Thumbnail-Upload von {job.Video.Title} läuft...";
						break;
					case UploadState.CancelPending:
						statusText = $"Upload von {job.Video.Title} wird abgebrochen...";
						break;
					case UploadState.Successful:
						statusText = $"{job.Video.Title} wurde erfolgreich hochgeladen.";
						break;
					case UploadState.Error:
						statusText = $"Es gab einen Fehler beim Upload von {job.Video.Title}.";
						break;
					case UploadState.Canceled:
						statusText = $"Upload von {job.Video.Title} wurde abgebrochen.";
						break;
					default:
						throw new ArgumentException("Dieser Status wird nicht unterstützt.");
				}
			}
		}

		private void UploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(autoUploader.Uploader.State))
			{
				// ... Was könnte hier kommen?
			}
		}

		private void AutoUploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(autoUploader.State) 
				&& autoUploader.State == RunningState.NotRunning)
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

		private void ResetStatusAndForm()
		{
			autoUploader.PropertyChanged -= AutoUploaderPropertyChanged;
			autoUploader.Uploader.PropertyChanged -= UploaderPropertyChanged;
			autoUploader.Uploader.NewUploadStarted -= OnNewUploadStarted;
			autoUploader.PropertyChanged -= AutoUploaderPropertyChanged;

			ended = true;
		}

		private void btnStopClick(object sender, EventArgs e)
		{
			aborted = true;
			autoUploader.Cancel();
		}

		private void UploadFormLoad(object sender, EventArgs e)
		{
			Left = Screen.PrimaryScreen.WorkingArea.Width - 30 - Width;
			Top = Screen.PrimaryScreen.WorkingArea.Height - 30 - Height;

			autoUploader.StartAsync();
		}

		private void cmbbxFinishActionSelectedIndexChanged(object sender, EventArgs e)
		{
			UploadEndedActionIndex = cmbbxFinishAction.SelectedIndex;
			chbChoseProcesses.Enabled = cmbbxFinishAction.SelectedIndex != 0;

			autoUploader.SuspendProcessWatcher();

			if (autoUploader != null)
			{
				autoUploader.EndAfterUpload = cmbbxFinishAction.SelectedIndex != 0;
			}

			if (cmbbxFinishAction.SelectedIndex == 0)
			{
				autoUploader?.ClearProcessesToWatch();
				chbChoseProcesses.Checked = false;
			}

			autoUploader.ResumeProcessWatcher();
		}

		private void chbChoseProcessesCheckedChanged(object sender, EventArgs e)
		{
			if (allowChosingProcs)
			{
				btnChoseProcs.Enabled = chbChoseProcesses.Checked;

				autoUploader.SuspendProcessWatcher();

				if (chbChoseProcesses.Checked)
				{
					ChoseProcesses();
				}
				else
				{
					autoUploader.ShouldWaitForProcs = false;
					autoUploader.ClearProcessesToWatch();
				}

				autoUploader.ResumeProcessWatcher();
			}
		}

		private void ChoseProcesses()
		{
			ProcessForm processChoser = new ProcessForm(autoUploader.ProcessesToWatch);
			processChoser.ShowDialog(this);
			if (processChoser.DialogResult == DialogResult.OK
				&& processChoser.Selected.Count > 0)
			{
				var procs = processChoser.Selected;
				autoUploader.ClearProcessesToWatch();
				autoUploader.AddProcessesToWatch(procs);
				autoUploader.ShouldWaitForProcs = true;
			}
			else
			{
				chbChoseProcesses.Checked = false;
				autoUploader.ShouldWaitForProcs = false;
			}
		}

		private void btnChoseProcsClick(object sender, EventArgs e)
		{
			autoUploader.SuspendProcessWatcher();
			ChoseProcesses();
			autoUploader.ResumeProcessWatcher();
		}
	}
}
