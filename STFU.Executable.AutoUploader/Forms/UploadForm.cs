using Microsoft.WindowsAPICodePack.Taskbar;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class UploadForm : Form
	{
		IAutomationUploader autoUploader = null;

		string fileText = string.Empty;
		int progress = 0;

		string[] statusTextLines = new[] { "Warte auf Dateien für den Upload...", string.Empty };

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
			chbChoseProcesses.Checked = autoUploader.ProcessContainer.ProcessesToWatch.Count > 0;
			btnChoseProcs.Enabled = chbChoseProcesses.Enabled;

			allowChosingProcs = true;

			DialogResult = DialogResult.Cancel;
		}

		private void OnNewUploadStarted(UploadStartedEventArgs args)
		{
			args.Job.PropertyChanged += CurrentUploadPropertyChanged;
		}

		delegate void action();
		private void CurrentUploadPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var job = (IYoutubeJob)sender;
			var oldtitle = fileText;
			fileText = job.Video.Title;

			if (e.PropertyName == nameof(job.Progress)
				&& (job.State == UploadState.Running || job.State == UploadState.ThumbnailUploading))
			{
				if (job.State == UploadState.ThumbnailUploading)
				{
					statusTextLines[0] = $"Lade Thumbnail hoch: {job.Progress:0.00} %";
				}
				else
				{
					statusTextLines[0] = $"Lade Video hoch: {job.Progress:0.00} %";
				}
				progress = (int)(job.Progress * 100);

				Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle)));
				Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(progress, 10000, Handle)));
			}
			else if (e.PropertyName == nameof(job.State))
			{
				switch (job.State)
				{
					case UploadState.NotStarted:
					case UploadState.Running:
						fileText = job.Video.Title;
						statusTextLines[0] = $"Video-Upload wird gestartet...";
						statusTextLines[1] = string.Empty;
						break;
					case UploadState.ThumbnailUploading:
						statusTextLines[0] = $"Thumbnail-Upload wird gestartet...";
						statusTextLines[1] = string.Empty;
						break;
					case UploadState.CancelPending:
						statusTextLines[0] = $"Upload wird abgebrochen...";
						statusTextLines[1] = string.Empty;
						Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error, Handle)));
						break;
					case UploadState.Error:
						statusTextLines[0] = $"Es gab einen Fehler beim Upload.";
						statusTextLines[1] = string.Empty;
						Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error, Handle)));
						Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(10000, 10000, Handle)));
						break;
					case UploadState.Canceled:
						statusTextLines[0] = $"Upload wurde abgebrochen.";
						statusTextLines[1] = string.Empty;
						Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error, Handle)));
						Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(10000, 10000, Handle)));
						break;
					case UploadState.Successful:
						fileText = oldtitle;
						Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle)));
						Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(10000, 10000, Handle)));
						break;
					default:
						throw new ArgumentException("Dieser Status wird nicht unterstützt.");
				}
			}
			else if (e.PropertyName == nameof(job.RemainingDuration) || e.PropertyName == nameof(job.UploadedDuration))
			{
				statusTextLines[1] = $"Bisher benötigt: {job.UploadedDuration.ToString("hh\\:mm\\:ss")}, verbleibende Zeit: {job.RemainingDuration.ToString("hh\\:mm\\:ss")}";
			}
		}

		private void UploaderPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(autoUploader.Uploader.State) && autoUploader.Uploader.State == UploaderState.Waiting)
			{
				statusTextLines[0] = "Upload abgeschlossen.";
				statusTextLines[1] = "Warte auf Dateien für den Upload...";

				Invoke(new action(() => TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle)));
				Invoke(new action(() => TaskbarManager.Instance.SetProgressValue(10000, 10000, Handle)));
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
			fileLabel.Text = fileText;
			statusLabel.Text = statusTextLines.Aggregate((i, j) => i + Environment.NewLine + j);
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

			autoUploader.ProcessContainer.Stop();

			if (autoUploader != null)
			{
				autoUploader.EndAfterUpload = cmbbxFinishAction.SelectedIndex != 0;
			}

			if (cmbbxFinishAction.SelectedIndex == 0)
			{
				autoUploader?.ProcessContainer.RemoveAllProcesses();
				chbChoseProcesses.Checked = false;
			}
			else
			{
				autoUploader.ProcessContainer.Start();
			}
		}

		private void chbChoseProcessesCheckedChanged(object sender, EventArgs e)
		{
			if (allowChosingProcs)
			{
				btnChoseProcs.Enabled = chbChoseProcesses.Checked;

				if (chbChoseProcesses.Checked)
				{
					ChoseProcesses();
				}
				else
				{
					autoUploader.EndAfterUpload = false;
					autoUploader.ProcessContainer.RemoveAllProcesses();
				}
			}
		}

		private void ChoseProcesses()
		{
			autoUploader.ProcessContainer.Stop();

			ProcessForm processChoser = new ProcessForm(autoUploader.ProcessContainer.ProcessesToWatch);
			processChoser.ShowDialog(this);
			if (processChoser.DialogResult == DialogResult.OK
				&& processChoser.Selected.Count > 0)
			{
				var procs = processChoser.Selected;
				autoUploader.ProcessContainer.RemoveAllProcesses();
				autoUploader.ProcessContainer.AddProcesses(procs);
				autoUploader.EndAfterUpload = true;
			}
			else
			{
				chbChoseProcesses.Checked = false;
			}

			autoUploader.ProcessContainer.Start();
		}

		private void btnChoseProcsClick(object sender, EventArgs e)
		{
			ChoseProcesses();
		}

		private void UploadFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!ended)
			{
				e.Cancel = true;
				btnStopClick(this, e);
			}
		}
	}
}
