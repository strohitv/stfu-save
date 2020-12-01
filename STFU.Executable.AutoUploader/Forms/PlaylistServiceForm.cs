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

		private string Host { get; set; }
		private string Port { get; set; }
		private string Username { get; set; }
		private string Password { get; set; }
		private bool IsConnected { get; set; }

		private AccountClient AccountClient { get; set; }
		private TaskClient TaskClient { get; set; }

		private List<Account> Accounts { get; } = new List<Account>();
		private List<Task> Tasks { get; } = new List<Task>();

		public PlaylistServiceForm(IYoutubeClient client)
		{
			Client = client;

			InitializeComponent();
		}

		private void connectServiceButton_Click(object sender, EventArgs e)
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
			Tasks.Clear();

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

			Tasks.AddRange(TaskClient.GetTasks(Accounts[accountsListView.SelectedIndices[0]].id, ids, filterTaskdateAfterDtp.Value.ToUniversalTime(),
				filterTaskdateBeforeDtp.Value.ToUniversalTime(), attemptCount, minAttemptCount, maxAttemptCount, filterPlaylistIdTextbox.Text,
				filterPlaylistTitleTextbox.Text, filterVideoIdTextbox.Text, filterVideoTitleTextbox.Text, states.ToArray(), (TaskOrder)sortByCombobox.SelectedIndex,
				(TaskOrderDirection)sortOrderCombobox.SelectedIndex));

			RefillTasksListView();
		}

		private void RefillTasksListView()
		{
			tasksListView.Items.Clear();

			foreach (var task in Tasks)
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
	}
}
