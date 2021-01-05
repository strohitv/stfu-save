using System;
using System.Linq;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Playlistservice.Model;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class AddOrUpdateTaskForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(AddOrUpdateTaskForm));

		public Task Task { get; private set; }

		public AddOrUpdateTaskForm(Task task)
		{
			LOGGER.Info($"Initializing new instance of AddOrUpdateTaskForm");

			InitializeComponent();

			Task = task;
			LOGGER.Debug($"Task to handle: {Task.ToString()}");
		}

		private void AddOrUpdateTaskForm_Load(object sender, EventArgs e)
		{
			LOGGER.Info($"Loading form");

			if (Task != null)
			{
				LOGGER.Info($"Form was created to edit a task. Task to edit: '{Task.ToString()}'");

				idLabel.Text = Task.id.ToString();

				playlistIdTextbox.Text = Task.playlistId;
				videoIdTextbox.Text = Task.videoId;
				addDtp.Value = Task.addAt;

				playlistTitleTextbox.Text = Task.playlistTitle;
				videoTitleTextbox.Text = Task.videoTitle;

				reopenWarningLabel.Visible = Task.state == TaskState.Done;
			}
			else
			{
				LOGGER.Info($"Form was created to add a new task");

				addDtp.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1);
				Task = new Task();
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User canceled the form");

			Close();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			LOGGER.Info($"User finished the form");

			DialogResult = DialogResult.OK;

			Task.playlistId = GetId(playlistIdTextbox.Text, "list");
			Task.videoId = GetId(videoIdTextbox.Text, "v");
			Task.addAt = addDtp.Value;

			Task.playlistTitle = playlistTitleTextbox.Text;
			Task.videoTitle = videoTitleTextbox.Text;

			LOGGER.Info($"Resulting task: '{Task.ToString()}'");

			Close();
		}

		private string GetId(string text, string queryParameter)
		{
			Uri uri = null;
			if ((text.ToLower().Contains("youtube") || text.ToLower().Contains("youtu.be")) && Uri.TryCreate(text, UriKind.RelativeOrAbsolute, out uri))
			{
				string queryString = uri.Query;
				var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);
				if (queryDictionary.AllKeys.Any(k => k == queryParameter))
				{
					text = queryDictionary[queryParameter];
				}
			}

			return text;
		}
	}
}
