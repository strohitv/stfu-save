using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Playlistservice;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Args;

namespace STFU.Lib.GUI.Controls.Queue
{
	public partial class JobQueue : UserControl
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(JobQueue));

		private IYoutubeCategoryContainer categoryContainer;
		private IYoutubeLanguageContainer languageContainer;
		private IYoutubePlaylistContainer playlistContainer;
		private IPlaylistServiceConnectionContainer pscContainer;

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
					LOGGER.Info($"Changing the uploader!");

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

					SuspendLayout();
					ClearItems();

					foreach (var entry in uploader.Queue)
					{
						Actions.Add(new JobChangedArgs(JobChangedType.Added, new JobQueuedEventArgs(entry, int.MaxValue)));
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
			LOGGER.Info($"Initializing new JobQueue");

			InitializeComponent();
		}

		public void Fill(IYoutubeCategoryContainer catContainer, IYoutubeLanguageContainer langContainer, IYoutubePlaylistContainer plContainer, IPlaylistServiceConnectionContainer pscContainer)
		{
			LOGGER.Info($"Filling the JobQueue with containers");

			categoryContainer = catContainer;
			languageContainer = langContainer;
			playlistContainer = plContainer;
			this.pscContainer = pscContainer;
		}

		private void Uploader_JobQueued(object sender, JobQueuedEventArgs e)
		{
			LOGGER.Debug($"Received a Uploader job queued event");

			Actions.Add(new JobChangedArgs(JobChangedType.Added, e));
		}

		private void OnJobQueued(JobQueuedEventArgs e)
		{
			LOGGER.Info($"Constructing a new job control");

			var control = new JobControl() { Job = e.Job, ActionsButtonsVisible = ShowActionsButtons };
			control.Fill(categoryContainer, languageContainer, playlistContainer, pscContainer);

			AddItem(control, e.Position);
		}

		private void Uploader_JobPositionChanged(object sender, JobPositionChangedEventArgs e)
		{
			LOGGER.Debug($"Received a Uploader job position changed event");

			Actions.Add(new JobChangedArgs(JobChangedType.PositionChanged, e));
		}

		private void OnJobPositionChanged(JobPositionChangedEventArgs e)
		{
			var control = jobControls[e.OldPosition];

			LOGGER.Info($"Moving JobControl for job '{control.Job.Video.Title}' from position {e.OldPosition} to position {e.NewPosition}");

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
			LOGGER.Debug($"Received a Uploader job dequeued event");

			Actions.Add(new JobChangedArgs(JobChangedType.Removed, e));
		}

		private void OnJobDequeued(JobDequeuedEventArgs e)
		{
			try
			{
				var control = jobControls.First(jc => jc.Job == e.Job);

				LOGGER.Info($"Removing JobControl of job '{control.Job.Video.Title}' from position {e.Position}");

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

			LOGGER.Info($"Adding JobControl for job '{control.Job.Video.Title}' to position {position}");

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
			LOGGER.Debug($"Received a JobControl move up event");

			uploader.ChangePosition(sender.Job, jobControls.IndexOf(sender) - 1);
		}

		private void Control_MoveDownRequested(JobControl sender)
		{
			LOGGER.Debug($"Received a JobControl move down event");

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
		}

		private void ClearItems()
		{
			LOGGER.Debug($"Clearing all Items");

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
					default:
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
