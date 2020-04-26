using System;
using System.ComponentModel;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Executable.AutoUploader.Controls
{
	public partial class UploaderControl : UserControl
	{
		bool changed = false;

		private IYoutubeUploader uploader = null;
		public IYoutubeUploader Uploader
		{
			get
			{
				return uploader;
			}
			set
			{
				if (uploader != null)
				{
					uploader.PropertyChanged -= Uploader_PropertyChanged;
				}

				uploader = value;

				if (uploader != null)
				{
					uploader.PropertyChanged += Uploader_PropertyChanged;
				}
			}
		}

		private IAutomationUploader queueFiller = null;
		public IAutomationUploader QueueFiller
		{
			get
			{
				return queueFiller;
			}
			set
			{
				if (queueFiller != null)
				{
					queueFiller.PropertyChanged -= QueueFiller_PropertyChanged;
				}

				queueFiller = value;

				if (queueFiller != null)
				{
					queueFiller.PropertyChanged += QueueFiller_PropertyChanged;
				}
			}
		}

		public UploaderControl()
		{
			InitializeComponent();
		}

		private void Uploader_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Uploader.State))
			{
				changed = true;
			}
		}

		private void QueueFiller_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(QueueFiller.State))
			{
				changed = true;
			}
		}

		private void refreshTimer_Tick(object sender, EventArgs e)
		{
			if (changed)
			{
				queueStatusButton.Enabled = Uploader.State != UploaderState.CancelPending;
				startAutouploaderbutton.Enabled = QueueFiller.State != RunningState.CancelPending;

				if (Uploader.State == UploaderState.NotRunning)
				{
					queueStatusLabel.Text = "Die Warteschlange ist gestoppt";
					queueStatusButton.Text = "Start!";
				}
				else
				{
					queueStatusLabel.Text = "Die Warteschlange wird abgearbeitet";
					queueStatusButton.Text = "Abbrechen!";
				}

				if (QueueFiller.State == RunningState.NotRunning)
				{
					autoUploaderStateLabel.Text = "Es werden keine Videos automatisch hinzugefügt";
					startAutouploaderbutton.Text = "Start!";
				}
				else
				{
					autoUploaderStateLabel.Text = "Videos werden automatisch hinzugefügt";
					startAutouploaderbutton.Text = "Abbrechen!";
				}

				changed = false;
			}
		}

		private void queueStatusButton_Click(object sender, EventArgs e)
		{
			if (Uploader.State == UploaderState.NotRunning)
			{
				Uploader.StartUploader();
			}
			else
			{
				Uploader.CancelAll();
			}
		}

		private void startAutouploaderbutton_Click(object sender, EventArgs e)
		{
			if (QueueFiller.State == RunningState.NotRunning)
			{
				QueueFiller.StartAsync();
			}
			else
			{
				QueueFiller.Cancel(true);
			}
		}
	}
}
