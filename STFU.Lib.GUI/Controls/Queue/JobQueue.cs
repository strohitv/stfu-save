using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;

namespace STFU.Lib.GUI.Controls.Queue
{
	public partial class JobQueue : UserControl
	{
		private IYoutubeCategoryContainer categoryContainer;
		private IYoutubeLanguageContainer languageContainer;

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
					Uploader.NewUploadStarted += Uploader_NewUploadStarted;

					SuspendLayout();
					ClearItems();

					foreach (var entry in uploader.Queue)
					{
						var control = new JobControl() { Job = entry, ActionsButtonsVisible = ShowActionsButtons };
						control.Fill(categoryContainer, languageContainer);

						AddItem(control, false);
					}
					RefreshMoveButtonsEnabled();
					ResumeLayout();
				}
			}
		}

		private void Uploader_NewUploadStarted(UploadStartedEventArgs args)
		{
			Invoke((Action)delegate
			{
				var control = jobControls.First(jc => jc.Job == args.Job);
				mainTlp.ScrollControlIntoView(control);
			});
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

		public void Fill(IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer)
		{
			categoryContainer = catContainer;
			languageContainer = langContainer;
		}

		private void JobQueue_Load(object sender, EventArgs e)
		{

		}

		private void Uploader_JobQueued(object sender, JobQueuedEventArgs e)
		{
			Invoke((Action)delegate
			{
				var control = new JobControl() { Job = e.Job, ActionsButtonsVisible = ShowActionsButtons };
				control.Fill(categoryContainer, languageContainer);

				AddItem(control, e.Position);
			});
		}

		private void Uploader_JobPositionChanged(object sender, JobPositionChangedEventArgs e)
		{
			Invoke((Action)delegate
			{
				var control = jobControls[e.OldPosition];
				jobControls.RemoveAt(e.OldPosition);
				jobControls.Insert(e.NewPosition, control);

				mainTlp.SuspendLayout();

				while (mainTlp.RowStyles.Count > 1)
				{
					RemoveItemFromMainTlp(mainTlp.Controls[0] as JobControl, 0);
				}

				int position = 0;
				foreach (var entry in uploader.Queue)
				{
					AddItemToMainTlp(position, jobControls.Single(jc => jc.Job == entry));
					position++;
				}

				mainTlp.ResumeLayout();
			});

			RefreshMoveButtonsEnabled();
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

				RefreshMoveButtonsEnabled();
			}
			catch (Exception)
			{ }
		}

		private void RemoveItemFromMainTlp(JobControl control, int position)
		{
			mainTlp.Controls.Remove(control);
			mainTlp.RowStyles.RemoveAt(position);
		}

		private void AddItem(JobControl control, bool refreshButtons = true)
		{
			if (InvokeRequired)
			{
				Invoke((Action)delegate { AddItem(control, int.MaxValue, refreshButtons); });
			}
		}

		private void AddItem(JobControl control, int position, bool refreshButtons = true)
		{
			if (position < 0)
			{
				position = 0;
			}
			else if (position > jobControls.Count)
			{
				position = jobControls.Count;
			}

			jobControls.Insert(position, control);

			if (refreshButtons)
			{
				RefreshMoveButtonsEnabled();
			}

			control.MoveUpRequested += Control_MoveUpRequested;
			control.MoveDownRequested += Control_MoveDownRequested;

			control.Margin = new Padding(0, 0, 0, 0);
			control.Dock = DockStyle.Fill;

			AddItemToMainTlp(position, control);
		}

		private void Control_MoveUpRequested(JobControl sender)
		{
			uploader.ChangePosition(sender.Job, jobControls.IndexOf(sender) - 1);
		}

		private void Control_MoveDownRequested(JobControl sender)
		{
			uploader.ChangePosition(sender.Job, jobControls.IndexOf(sender) + 1);
		}

		private void RefreshMoveButtonsEnabled()
		{
			Invoke((Action)delegate
			{
				if (jobControls.Count > 0)
				{
					for (int i = 0; i < jobControls.Count; i++)
					{
						jobControls[i].CanBeMovedUp = true;
						jobControls[i].CanBeMovedDown = true;
					}

					jobControls.SingleOrDefault(jc => jc.Job == uploader.Queue.First()).CanBeMovedUp = false;
					jobControls.SingleOrDefault(jc => jc.Job == uploader.Queue.Last()).CanBeMovedDown = false;
				}
			});
		}

		private void AddItemToMainTlp(int position, JobControl control)
		{
			if (position < 0)
			{
				position = 0;
			}
			else if (position > mainTlp.RowStyles.Count)
			{
				position = mainTlp.RowStyles.Count;
			}

			mainTlp.RowStyles.Insert(position, new RowStyle(SizeType.AutoSize));
			mainTlp.Controls.Add(control, 0, position);
			mainTlp.ScrollControlIntoView(control);
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

		private void refreshControlsTimerTick(object sender, EventArgs e)
		{
			foreach (var control in jobControls)
			{
				control.RefreshJobControl();
			}
		}
	}
}
