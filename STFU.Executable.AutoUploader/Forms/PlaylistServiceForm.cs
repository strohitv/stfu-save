using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using STFU.Lib.GUI.Forms;
using STFU.Lib.Playlistservice;
using STFU.Lib.Playlistservice.Model;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model.Helpers;
using STFU.Lib.Youtube.Services;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class PlaylistServiceForm : Form
	{
		private IYoutubeClient Client { get; set; }

		private IPlaylistServiceConnectionContainer Container { get; set; }

		private string Host { get; set; }
		private string Port { get; set; }
		private string Username { get; set; }
		private string Password { get; set; }
		private bool IsConnected { get; set; }

		private AccountClient AccountClient { get; set; }
		private TaskClient TaskClient { get; set; }

		private List<Account> Accounts { get; } = new List<Account>();
		private List<Task> FoundTasks { get; } = new List<Task>();

		public PlaylistServiceForm(IPlaylistServiceConnectionContainer container, IYoutubeClient client)
		{
			Client = client;
			Container = container;

			InitializeComponent();
		}

		private void connectServiceButton_Click(object sender, EventArgs e)
		{
			ConnectToService();
		}

		private void ConnectToService()
		{
			if (!string.IsNullOrWhiteSpace(hostTextbox.Text) && !string.IsNullOrWhiteSpace(portTextbox.Text) && portTextbox.Text.All(c => "0123456789".Contains(c)))
			{
				VersionClient client = new VersionClient(new Uri($"http://{hostTextbox.Text}:{portTextbox.Text}"));
				if (!string.IsNullOrWhiteSpace(usernameTextbox.Text) && !string.IsNullOrWhiteSpace(passwordTextbox.Text))
				{
					client = new VersionClient(new Uri($"http://{hostTextbox.Text}:{portTextbox.Text}"), usernameTextbox.Text, passwordTextbox.Text);
				}

				IsConnected = client.IsAvailable();
				if (IsConnected)
				{
					connectionStatusLabel.BackColor = Color.LightGreen;
					connectionStatusLabel.ForeColor = Color.DarkGreen;
					connectionStatusLabel.Text = "Erfolgreich verbunden";

					Host = hostTextbox.Text;
					Port = portTextbox.Text;
					Username = usernameTextbox.Text;
					Password = passwordTextbox.Text;

					AccountClient = new AccountClient(new Uri($"http://{Host}:{Port}"));
					if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
					{
						AccountClient = new AccountClient(new Uri($"http://{Host}:{Port}"), Username, Password);
					}

					TaskClient = new TaskClient(new Uri($"http://{Host}:{Port}"));
					if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
					{
						TaskClient = new TaskClient(new Uri($"http://{Host}:{Port}"), Username, Password);
					}

					ReloadAccounts();
				}
				else
				{
					connectionStatusLabel.BackColor = Color.FromArgb(255, 192, 192);
					connectionStatusLabel.ForeColor = Color.DarkRed;
					connectionStatusLabel.Text = "Verbindung fehlgeschlagen";
				}

				mainSplitContainer.Enabled = IsConnected;
			}
			else
			{
				MessageBox.Show(this, "Bitte einen gültigen Host und Port angeben!");
			}
		}

		private void ReloadAccounts()
		{
			Account[] accounts = AccountClient.GetAllAccounts();

			Accounts.Clear();
			Accounts.AddRange(accounts);

			clearAccountsButton.Enabled = Accounts.Count > 0;

			RefillAccountsListView();

			accountsListView.SelectedIndices.Clear();
			if (accountsListView.Items.Count > 0)
			{
				accountsListView.SelectedIndices.Add(0);
			}

			removeAccountButton.Enabled = accountsListView.SelectedIndices.Count > 0;
		}

		private void RefillAccountsListView()
		{
			accountsListView.Items.Clear();

			foreach (var account in Accounts)
			{
				accountsListView.Items.Add(new ListViewItem(account.title));
			}

			clearAccountsButton.Enabled = Accounts.Count > 0;
		}

		private void connectAccountButton_Click(object sender, EventArgs e)
		{
			AddYoutubeAccountForm form = new AddYoutubeAccountForm(false);
			form.ExternalCodeUrl = new YoutubeAccountCommunicator().CreateAuthUri(Client, YoutubeRedirectUri.Code, GoogleScope.Manage).AbsoluteUri;

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Account account = AccountClient.AddAccount(new AuthCode()
				{
					clientId = Client.Id,
					clientSecret = Client.Secret,
					redirectUri = YoutubeRedirectUri.Code.GetAttribute<EnumMemberAttribute>().Value,
					code = form.AuthToken
				});

				Accounts.Add(account);
				accountsListView.Items.Add(new ListViewItem(account.title));
				accountsListView.SelectedIndices.Clear();
				accountsListView.SelectedIndices.Add(Accounts.Count - 1);

				clearAccountsButton.Enabled = true;
			}
		}

		private void accountsListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool selected = accountsListView.SelectedIndices.Count == 1;

			removeAccountButton.Enabled = accountDetailsTlp.Enabled = selected;

			if (selected)
			{
				Account account = Accounts[accountsListView.SelectedIndices[0]];
				accountIdLabel.Text = account.id.ToString();
				channelTitleLabel.Text = account.title;
				channelUrlLinkLabel.Text = $"https://youtube.com/channel/{account.channelId}";

				ResetTaskFilters();
			}
		}

		private void ResetTaskFilters()
		{
			filterIdTextbox.Text = "";

			filterTaskdateAfterDtp.Value = DateTime.Now.Date;
			filterTaskdateBeforeDtp.Value = DateTime.Now.AddMonths(1).Date;

			filterAttemptCountTextbox.Text = "";
			filterMinAttemptCountTextbox.Text = "";
			filterMaxAttemptCountTextbox.Text = "";

			filterPlaylistIdTextbox.Text = "";
			filterPlaylistTitleTextbox.Text = "";

			filterVideoIdTextbox.Text = "";
			filterVideoTitleTextbox.Text = "";

			sortByCombobox.SelectedIndex = 0;
			sortOrderCombobox.SelectedIndex = 0;

			showOpenTasksCheckbox.Checked = true;
			showDoneTasksCheckbox.Checked = false;
			showFailedTasksCheckbox.Checked = false;

			RefreshTasks();
		}

		private void RefreshTasks()
		{
			FoundTasks.Clear();

			long[] ids = new string(filterIdTextbox.Text.Replace(',', ';').Where(c => ";0123456789".Contains(c)).ToArray())
				.Split(';')
				.Where(c => !string.IsNullOrEmpty(c))
				.Select(c => Convert.ToInt64(c))
				.ToArray();

			int? attemptCount = null;
			int? minAttemptCount = null;
			int? maxAttemptCount = null;

			List<TaskState> states = new List<TaskState>();
			if (showOpenTasksCheckbox.Checked) states.Add(TaskState.Open);
			if (showDoneTasksCheckbox.Checked) states.Add(TaskState.Done);
			if (showFailedTasksCheckbox.Checked) states.Add(TaskState.Failed);

			FoundTasks.AddRange(TaskClient.GetTasks(Accounts[accountsListView.SelectedIndices[0]].id, ids, filterTaskdateAfterDtp.Value,
				filterTaskdateBeforeDtp.Value, attemptCount, minAttemptCount, maxAttemptCount, filterPlaylistIdTextbox.Text,
				filterPlaylistTitleTextbox.Text, filterVideoIdTextbox.Text, filterVideoTitleTextbox.Text, states.ToArray(), (TaskOrder)sortByCombobox.SelectedIndex,
				(TaskOrderDirection)sortOrderCombobox.SelectedIndex));

			RefillTasksListView();
		}

		private void RefillTasksListView()
		{
			tasksListView.Items.Clear();

			foreach (var task in FoundTasks)
			{
				string state = "Offen";
				if (task.state == TaskState.Done) state = "Erledigt";
				if (task.state == TaskState.Failed) state = "Gescheitert";

				ListViewItem item = new ListViewItem(task.id.ToString());
				item.SubItems.Add(task.playlistTitle);
				item.SubItems.Add(task.videoTitle);
				item.SubItems.Add(task.addAt.ToString("yyyy-MM-dd HH\\:mm"));
				item.SubItems.Add(state);
				item.SubItems.Add(task.attemptCount.ToString());

				tasksListView.Items.Add(item);
			}

			clearTasksButton.Enabled = FoundTasks.Count > 0;
		}

		private void removeAccountButton_Click(object sender, EventArgs e)
		{
			Account account = Accounts[accountsListView.SelectedIndices[0]];
			AccountClient.DeleteAccount(account);

			ReloadAccounts();
		}

		private void clearAccountsButton_Click(object sender, EventArgs e)
		{
			AccountClient.DeleteAllAccounts();

			ReloadAccounts();
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			RefreshTasks();
		}

		private void channelUrlLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(channelUrlLinkLabel.Text);
		}

		private void addTaskButton_Click(object sender, EventArgs e)
		{
			AddOrUpdateTaskForm form = new AddOrUpdateTaskForm(null);
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Task created = TaskClient.CreateTask(Accounts[accountsListView.SelectedIndices[0]].id, form.Task);
				
				RefreshTasks();

				if (FoundTasks.Any(t => t.id == created.id))
				{
					tasksListView.SelectedIndices.Clear();
					tasksListView.SelectedIndices.Add(FoundTasks.IndexOf(FoundTasks.First(t => t.id == created.id)));
				}
			}
		}

		private void tasksListView_DoubleClick(object sender, EventArgs e)
		{
			if (tasksListView.SelectedIndices.Count == 1)
			{
				AddOrUpdateTaskForm form = new AddOrUpdateTaskForm(FoundTasks[tasksListView.SelectedIndices[0]]);
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					Task updated = TaskClient.UpdateTask(Accounts[accountsListView.SelectedIndices[0]].id, form.Task);
					
					RefreshTasks();

					if (FoundTasks.Any(t => t.id == updated.id))
					{
						tasksListView.SelectedIndices.Clear();
						tasksListView.SelectedIndices.Add(FoundTasks.IndexOf(FoundTasks.First(t => t.id == updated.id)));
					}
				}
			}
		}

		private void removeTaskButton_Click(object sender, EventArgs e)
		{
			if (tasksListView.SelectedIndices.Count == 1)
			{
				var index = tasksListView.SelectedIndices[0];
				var selectedTask = FoundTasks[index];
				if (TaskClient.DeleteTask(Accounts[accountsListView.SelectedIndices[0]].id, selectedTask.id))
				{
					FoundTasks.RemoveAt(index);
					tasksListView.Items.RemoveAt(index);
				}
			}
		}

		private void clearTasksButton_Click(object sender, EventArgs e)
		{
			for (int index = 0; index < FoundTasks.Count; index++)
			{
				var selectedTask = FoundTasks[index];
				if (TaskClient.DeleteTask(Accounts[accountsListView.SelectedIndices[0]].id, selectedTask.id))
				{
					FoundTasks.RemoveAt(index);
					tasksListView.Items.RemoveAt(index);
					index--;
				}
			}
		}

		private void tasksListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			removeTaskButton.Enabled = tasksListView.SelectedIndices.Count == 1;
		}

		private void PlaylistServiceForm_Load(object sender, EventArgs e)
		{
			if (Container.Connection != null)
			{
				hostTextbox.Text = Container.Connection.Host;
				portTextbox.Text = Container.Connection.Port;
				usernameTextbox.Text = Container.Connection.Username;
				passwordTextbox.Text = Container.Connection.Password;

				ConnectToService();
			}
		}

		private void PlaylistServiceForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (IsConnected)
			{
				Container.Connection = new PlaylistServiceConnection()
				{
					Host = Host,
					Port = Port,
					Username = Username,
					Password = Password,
					Accounts = Accounts.ToArray()
				};
			}
			else
			{
				Container.Connection = null;
			}
		}
	}
}
