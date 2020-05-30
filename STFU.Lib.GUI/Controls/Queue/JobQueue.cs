using System;
using System.Collections.Concurrent;
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

		private BlockingCollection<JobChangedArgs> Actions { get; } = new BlockingCollection<JobChangedArgs>();

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
						Uploader.NewUploadStarted -= Uploader_NewUploadStarted;
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
						Actions.Add(new JobChangedArgs(JobChangedType.Added, new JobQueuedEventArgs(entry, int.MaxValue)));
					}
				}
			}
		}

		private void Uploader_NewUploadStarted(UploadStartedEventArgs args)
		{
			Actions.Add(new JobChangedArgs(JobChangedType.Started, args));
		}

		private void OnNewUploadStarted(UploadStartedEventArgs args)
		{
			var control = jobControls.First(jc => jc.Job == args.Job);
			mainTlp.ScrollControlIntoView(control);
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

		private void Uploader_JobQueued(object sender, JobQueuedEventArgs e)
		{
			Actions.Add(new JobChangedArgs(JobChangedType.Added, e));
		}

		private void OnJobQueued(JobQueuedEventArgs e)
		{
			var control = new JobControl() { Job = e.Job, ActionsButtonsVisible = ShowActionsButtons };
			control.Fill(categoryContainer, languageContainer);

			AddItem(control, e.Position);
		}

		private void Uploader_JobPositionChanged(object sender, JobPositionChangedEventArgs e)
		{
			Actions.Add(new JobChangedArgs(JobChangedType.PositionChanged, e));
		}

		private void OnJobPositionChanged(JobPositionChangedEventArgs e)
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

			RefreshMoveButtonsEnabled();
		}

		private void Uploader_JobDequeued(object sender, JobDequeuedEventArgs e)
		{
			Actions.Add(new JobChangedArgs(JobChangedType.Removed, e));
		}

		private void OnJobDequeued(JobDequeuedEventArgs e)
		{
			try
			{
				var control = jobControls.First(jc => jc.Job == e.Job);

				jobControls.Remove(control);
				RemoveItemFromMainTlp(control, e.Position);

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
			AddItem(control, int.MaxValue, refreshButtons);
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
			if (jobControls.Count > 0)
			{
				for (int i = 0; i < jobControls.Count; i++)
				{
					jobControls[i].CanBeMovedUp = true;
					jobControls[i].CanBeMovedDown = true;
				}

				if (jobControls.Any(jc => jc.Job == uploader.Queue.First()))
				{
					jobControls.SingleOrDefault(jc => jc.Job == uploader.Queue.First()).CanBeMovedUp = false;
				}

				if (jobControls.Any(jc => jc.Job == uploader.Queue.Last()))
				{
					jobControls.SingleOrDefault(jc => jc.Job == uploader.Queue.Last()).CanBeMovedDown = false;
				}
			}
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
				while (mainTlp.RowStyles.Count > 1)
				{
					mainTlp.RowStyles.RemoveAt(0);
				}
			}
		}

		private void refreshControlsTimerTick(object sender, EventArgs e)
		{
			foreach (var control in jobControls)
			{
				control.RefreshJobControl();
			}
		}

		private void handleActionsTimer_Tick(object sender, EventArgs e)
		{
			while (Actions.Count > 0)
			{
				var action = Actions.Take();
				switch (action.Type)
				{
					case JobChangedType.Added:
						OnJobQueued((JobQueuedEventArgs)action.Args);
						break;
					case JobChangedType.Removed:
						OnJobDequeued((JobDequeuedEventArgs)action.Args);
						break;
					case JobChangedType.PositionChanged:
						OnJobPositionChanged((JobPositionChangedEventArgs)action.Args);
						break;
					case JobChangedType.Started:
						OnNewUploadStarted((UploadStartedEventArgs)action.Args);
						break;
				}
			}

			foreach (var control in jobControls)
			{
				control.HandleActions();
			}
		}

		private void JobQueue_Resize(object sender, EventArgs e)
		{
			mainTlp.Width = borderPanel.Width = Width;
			borderPanel.Height = Height;
		}
	}
}
