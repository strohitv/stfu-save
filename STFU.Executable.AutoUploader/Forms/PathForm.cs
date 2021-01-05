using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class PathForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(PathForm));

		IPathContainer pathContainer = null;
		ITemplateContainer templateContainer = null;
		IYoutubeJobContainer queueContainer = null;
		IYoutubeJobContainer archiveContainer = null;
		IYoutubeAccountContainer accountContainer = null;

		public PathForm(IPathContainer pathContainer, ITemplateContainer templateContainer, IYoutubeJobContainer queueContainer, IYoutubeJobContainer archiveContainer, IYoutubeAccountContainer accountContainer)
		{
			LOGGER.Info($"Initializing new instance of PathForm");

			InitializeComponent();

			this.pathContainer = pathContainer;
			this.templateContainer = templateContainer;

			this.queueContainer = queueContainer;
			this.archiveContainer = archiveContainer;
			this.accountContainer = accountContainer;
		}

		private void lvSelectedPathsKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete && ItemSelected())
			{
				LOGGER.Info($"Deleting path on position {lvPaths.SelectedIndices[0]} via delete key");
				LOGGER.Info($"Path to delete: '{pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0])}'");

				pathContainer.UnregisterPathAt(lvPaths.SelectedIndices[0]);
				RefillListView();
				ClearEditBox();
			}
		}

		private void RefillListView()
		{
			LOGGER.Info($"Refilling list view");

			lvPaths.Items.Clear();

			foreach (var entry in pathContainer.RegisteredPaths)
			{
				var newItem = lvPaths.Items.Add(entry.Fullname);
				newItem.SubItems.Add(entry.Filter);

				LOGGER.Debug($"Adding entry for path: '{entry.ToString()}'");

				string templateName = templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == entry.SelectedTemplateId)?.Name;
				if (string.IsNullOrWhiteSpace(templateName))
				{
					templateName = templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == 0).Name;
				}
				newItem.SubItems.Add(templateName);

				newItem.SubItems.Add(entry.SearchRecursively ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.SearchHidden ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.Inactive ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.MoveAfterUpload ? "Ja" : "Nein");
			}

			lvPaths.SelectedIndices.Clear();
		}

		private void RefillEditBox()
		{
			LOGGER.Debug($"Refilling edit box");

			if (NoItemSelected())
			{
				LOGGER.Debug($"No item selected => will only clear the edit box");

				ClearEditBox();
				return;
			}

			tlpEditPaths.Enabled = true;
			int index = lvPaths.SelectedIndices[0];

			var selectedItem = pathContainer.RegisteredPaths.ElementAt(index);

			LOGGER.Debug($"Path to fill into edit box: {selectedItem.ToString()}");

			txtbxAddPath.Text = selectedItem.Fullname;
			txtbxAddFilter.Text = selectedItem.Filter;
			chbHidden.Checked = selectedItem.SearchHidden;
			chbRecursive.Checked = selectedItem.SearchRecursively;
			chbHidden.Enabled = chbRecursive.Checked;
			deactivateCheckbox.Checked = selectedItem.Inactive;
			moveAfterUploadCheckbox.Checked = selectedItem.MoveAfterUpload;
			moveAfterUploadTextbox.Text = selectedItem.MoveDirectoryPath;

			searchOrderCombobox.SelectedIndex = (int)selectedItem.SearchOrder;

			if (templateContainer.RegisteredTemplates.Any(t => t.Id == selectedItem.SelectedTemplateId))
			{
				cobSelectedTemplate.SelectedIndex = templateContainer.RegisteredTemplates.ToList().IndexOf(templateContainer.RegisteredTemplates.First(t => t.Id == selectedItem.SelectedTemplateId));
			}
			else
			{
				cobSelectedTemplate.SelectedIndex = templateContainer.RegisteredTemplates.ToList().IndexOf(templateContainer.RegisteredTemplates.First(t => t.Id == 0));
			}
		}

		private void ClearEditBox()
		{
			LOGGER.Debug($"Clearing edit box");

			tlpEditPaths.Enabled = false;
			txtbxAddPath.Text = string.Empty;
			txtbxAddFilter.Text = string.Empty;
			chbRecursive.Checked = false;
			chbHidden.Checked = false;
			chbHidden.Enabled = false;
			deactivateCheckbox.Checked = false;
			moveAfterUploadCheckbox.Checked = false;
			moveAfterUploadTextbox.Text = "";
			searchOrderCombobox.SelectedIndex = 0;
		}

		private void PathFormLoad(object sender, EventArgs e)
		{
			LOGGER.Info($"Loading path form");

			foreach (var template in templateContainer.RegisteredTemplates)
			{
				string templateName = string.IsNullOrWhiteSpace(template.Name) ? "<namenloses Template>" : template.Name;
				LOGGER.Info($"Adding template into template combobox: '{templateName}'");
				cobSelectedTemplate.Items.Add(templateName);
			}

			RefillListView();
		}

		private void AddPathButtonClick(object sender, EventArgs e)
		{
			LOGGER.Debug($"User pressed button to add a new path");

			var result = folderBrowserDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				LOGGER.Info($"Trying to add a new path");

				if (Directory.Exists(folderBrowserDialog.SelectedPath) && !pathContainer.RegisteredPaths.Any(path => path.Fullname == folderBrowserDialog.SelectedPath))
				{
					var newPath = new Lib.Youtube.Automation.Paths.Path()
					{
						Fullname = folderBrowserDialog.SelectedPath,
						Filter = "*.mp4;*.mkv",
						SelectedTemplateId = 0,
						SearchRecursively = false,
						Inactive = false,
						SearchHidden = false
					};

					LOGGER.Info($"Adding newly created path: '{newPath.ToString()}'");

					pathContainer.RegisterPath(newPath);
					RefillListView();
					lvPaths.SelectedIndices.Add(lvPaths.Items.Count - 1);
				}
				else
				{
					LOGGER.Error($"Could not add path '{folderBrowserDialog.SelectedPath}': either it doesn't exist or it's already part of the path array.");
				}
			}
		}

		private void deletePathButtonClick(object sender, EventArgs e)
		{
			if (NoItemSelected())
			{
				LOGGER.Error($"No path was selected => can't delete any path");

				return;
			}

			LOGGER.Info($"Deleting path on position {lvPaths.SelectedIndices[0]} via delete button");
			LOGGER.Info($"Path to delete: '{pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0])}'");

			pathContainer.UnregisterPathAt(lvPaths.SelectedIndices[0]);
			RefillListView();
			ClearEditBox();
		}

		private void lvSelectedPathsSelectedIndexChanged(object sender, EventArgs e)
		{
			RefillEditBox();
		}

		private void btnSaveClick(object sender, EventArgs e)
		{
			if (NoItemSelected())
			{
				LOGGER.Error($"No path was selected => can't save any path");

				return;
			}

			int index = lvPaths.SelectedIndices[0];

			var selectedItem = pathContainer.RegisteredPaths.ElementAt(index);

			selectedItem.Fullname = txtbxAddPath.Text;
			selectedItem.Filter = txtbxAddFilter.Text;
			selectedItem.SearchHidden = chbHidden.Checked;
			selectedItem.SearchRecursively = chbRecursive.Checked;
			selectedItem.SelectedTemplateId = templateContainer.RegisteredTemplates.ElementAt(cobSelectedTemplate.SelectedIndex)?.Id ?? 0;
			selectedItem.Inactive = deactivateCheckbox.Checked;
			selectedItem.MoveAfterUpload = moveAfterUploadCheckbox.Checked;
			selectedItem.MoveDirectoryPath = moveAfterUploadTextbox.Text;
			selectedItem.SearchOrder = (FoundFilesOrderByFilter)searchOrderCombobox.SelectedIndex;

			LOGGER.Info($"Saving edited path: {selectedItem.ToString()}");

			ClearEditBox();
			RefillListView();
		}

		private bool NoItemSelected()
		{
			return lvPaths.SelectedItems.Count == 0;
		}

		private bool ItemSelected()
		{
			return lvPaths.SelectedItems.Count > 0;
		}

		private void btnSelectPathClick(object sender, EventArgs e)
		{
			LOGGER.Debug($"User wants to change directory, which is currently: '{txtbxAddPath.Text}'");

			var result = folderBrowserDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				if (Directory.Exists(folderBrowserDialog.SelectedPath)
					&& (!pathContainer.RegisteredPaths.Any(path => path.Fullname == folderBrowserDialog.SelectedPath)
					|| folderBrowserDialog.SelectedPath == pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0]).Fullname))
				{
					LOGGER.Info($"Changing directory of the path from: '{txtbxAddPath.Text}' to: '{folderBrowserDialog.SelectedPath}'");

					txtbxAddPath.Text = folderBrowserDialog.SelectedPath;
				}
			}
		}

		private void movePathUpButtonClick(object sender, EventArgs e)
		{
			LOGGER.Debug($"User wants move a path upwards");

			if (NoItemSelected())
			{
				LOGGER.Error($"There was no path selected. Can't move one upwards!");

				return;
			}

			var index = lvPaths.SelectedIndices[0];

			pathContainer.ShiftPathPositionsAt(index, index - 1);

			RefillListView();
			lvPaths.SelectedIndices.Clear();
			lvPaths.SelectedIndices.Add(index - 1);
		}

		private void movePathDownButtonClick(object sender, EventArgs e)
		{
			LOGGER.Debug($"User wants move a path downwards");

			if (NoItemSelected())
			{
				LOGGER.Error($"There was no path selected. Can't move one downwards!");

				return;
			}

			var index = lvPaths.SelectedIndices[0];

			pathContainer.ShiftPathPositionsAt(index, index + 1);

			RefillListView();
			lvPaths.SelectedIndices.Clear();
			lvPaths.SelectedIndices.Add(index + 1);
		}

		private void clearButtonClick(object sender, EventArgs e)
		{
			LOGGER.Info($"User wants to clear all paths");

			pathContainer.UnregisterAllPaths();
			RefillListView();
			ClearEditBox();
		}

		private void btnCancelClick(object sender, EventArgs e)
		{
			LOGGER.Info($"User wants to discard his changes of the current path");

			ClearEditBox();
			lvPaths.SelectedIndices.Clear();
		}

		private void chbRecursiveCheckedChanged(object sender, EventArgs e)
		{
			chbHidden.Enabled = chbRecursive.Checked;

			LOGGER.Info($"User wants to mark all videos in path '{pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0]).Fullname}' as read.");

			if (!chbRecursive.Checked)
			{
				chbHidden.Checked = false;
			}
		}

		private void btnMarkAsReadClick(object sender, EventArgs e)
		{
			LOGGER.Info($"User wants to mark all videos in path '{pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0]).Fullname}' as read.");

			chosePathTlp.Enabled = false;
			pathContainer.MarkAllFilesAsRead(pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0]), queueContainer, archiveContainer, accountContainer);
			MessageBox.Show(this, "Die Videos, die durch diesen Pfad gefunden werden können und nicht schon in der Warteschlange sind, wurden erfolgreich als bereits hochgeladen markiert. Dazu wurden sie ins Archiv aufgenommen. Der Autouploader wird sie nun nicht mehr finden. Um das zu ändern, einfach die Videodatei wieder aus dem Archiv löschen.", "Videos erfolgreich als hochgeladen markiert", MessageBoxButtons.OK, MessageBoxIcon.Information);
			chosePathTlp.Enabled = true;
		}

		private void moveAfterUploadCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			LOGGER.Info($"User wants to change move videos after upload value in path: '{pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0]).Fullname}'. New value: {moveAfterUploadCheckbox.Checked}");

			moveAfterUploadTextbox.Enabled = moveAfterUploadButton.Enabled = moveAfterUploadCheckbox.Checked;
		}

		private void moveAfterUploadButton_Click(object sender, EventArgs e)
		{
			var path = txtbxAddPath.Text;
			if (Directory.Exists(path))
			{
				selectMovePathDialog.SelectedPath = path;
			}

			var result = selectMovePathDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				moveAfterUploadTextbox.Text = selectMovePathDialog.SelectedPath;
			}
		}
	}
}
