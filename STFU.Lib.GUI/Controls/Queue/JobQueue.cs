using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model.Args;

namespace STFU.Lib.GUI.Controls.Queue
{
	public partial class JobQueue : UserControl
	{
		private List<JobControl> jobControls = new List<JobControl>();

		private IYoutubeUploader uploader = null;
		public IYoutubeUploader Uploader
		{
			get
			{
				return uploader;
			}
			set
			{
				if (uploader != value)
				{
					if (uploader != null)
					{
						Uploader.JobQueued -= Uploader_JobQueued;
						Uploader.JobDequeued -= Uploader_JobDequeued;
						Uploader.JobPositionChanged -= Uploader_JobPositionChanged;
					}

					uploader = value;

					Uploader.JobQueued += Uploader_JobQueued;
					Uploader.JobDequeued += Uploader_JobDequeued;
					Uploader.JobPositionChanged += Uploader_JobPositionChanged;

					ClearItems();

					foreach (var entry in uploader.Queue)
					{
						AddItem(new JobControl() { Job = entry, ActionsButtonsVisible = ShowActionsButtons });
					}
				}
			}
		}

		private bool showActionButtons = true;
		public bool ShowActionsButtons
		{
			get
			{
				return showActionButtons;
			}
			set
			{
				if (showActionButtons != value)
				{
					showActionButtons = value;

					foreach (var control in jobControls)
					{
						control.ActionsButtonsVisible = showActionButtons;
					}
				}
			}
		}

		public JobQueue()
		{
			InitializeComponent();
		}

		private void JobQueue_Load(object sender, EventArgs e)
		{

		}

		private void Uploader_JobQueued(object sender, JobQueuedEventArgs e)
		{
			Invoke((Action)delegate
			{
				AddItem(new JobControl() { Job = e.Job, ActionsButtonsVisible = ShowActionsButtons }, e.Position);
			});
		}

		private void Uploader_JobPositionChanged(object sender, JobPositionChangedEventArgs e)
		{
			Invoke((Action)delegate
			{
				var control = jobControls.First(jc => jc.Job == e.Job);

				mainTlp.SuspendLayout();
				RemoveItemFromMainTlp(control, e.OldPosition);
				AddItemToMainTlp(control, e.NewPosition);
				mainTlp.ResumeLayout();
			});
		}

		private void Uploader_JobDequeued(object sender, JobDequeuedEventArgs e)
		{
			try
			{
				Invoke((Action)delegate
				{
					var control = jobControls.First(jc => jc.Job == e.Job);

					jobControls.Remove(control);
					RemoveItemFromMainTlp(control, e.Position);
				});
			}
			catch (Exception)
			{ }
		}

		private void RemoveItemFromMainTlp(JobControl control, int position)
		{
			mainTlp.Controls.Remove(control);
			mainTlp.RowStyles.RemoveAt(position);
		}

		private void AddItem(JobControl control)
		{
			AddItem(control, int.MaxValue);
		}

		private void AddItem(JobControl control, int position)
		{
			if (position < 0)
			{
				position = 0;
			}
			else if (position > mainTlp.RowCount - 1)
			{
				position = mainTlp.RowCount - 1;
			}

			jobControls.Insert(position, control);

			control.Margin = new Padding(0, 0, 0, 0);
			control.Anchor = AnchorStyles.Left | AnchorStyles.Right;

			AddItemToMainTlp(control, position);
		}

		private void AddItemToMainTlp(JobControl control, int position)
		{
			mainTlp.RowStyles.Insert(position, new RowStyle(SizeType.AutoSize));
			mainTlp.Controls.Add(control, 0, position - 1);
		}

		private void ClearItems()
		{
			if (mainTlp.RowStyles.Count > 1)
			{
				Invoke((Action)delegate
				{
					while (mainTlp.RowStyles.Count > 1)
					{
						mainTlp.RowStyles.RemoveAt(0);
					}
				});
			}
		}
	}
}
