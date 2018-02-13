using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using STFU.UploadLib.Automation;

namespace STFU.AutoUploader
{
	public partial class PathForm : Form
	{
		AutomationUploader uploader = null;

		public PathForm(AutomationUploader upl)
		{
			InitializeComponent();

			uploader = upl;
		}

		private void lvSelectedPathsKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete && !NoItemSelected())
			{
				uploader.RemovePath(lvPaths.SelectedItems[0].Text);
				RefillListView();
				ClearEditBox();
			}
		}

		private void RefillListView()
		{
			lvPaths.Items.Clear();

			foreach (var entry in uploader.Paths)
			{
				var newItem = lvPaths.Items.Add(entry.Path);
				newItem.SubItems.Add(entry.Filter);

				string templateName = uploader.Templates.FirstOrDefault(t => t.Id == entry.SelectedTemplateId)?.Name;
				if (string.IsNullOrWhiteSpace(templateName))
				{
					templateName = uploader.Templates.FirstOrDefault(t => t.Id == 0).Name;
				}
				newItem.SubItems.Add(templateName);

				newItem.SubItems.Add(entry.SearchRecursively ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.SearchHidden ? "Ja" : "Nein");
			}

			lvPaths.SelectedIndices.Clear();
		}

		private void RefillEditBox()
		{
			if (NoItemSelected())
			{
				ClearEditBox();
				return;
			}

			tlpEditPaths.Enabled = true;
			int index = lvPaths.SelectedIndices[0];

			var selectedItem = uploader.Paths[index];

			txtbxAddPath.Text = selectedItem.Path;
			txtbxAddFilter.Text = selectedItem.Filter;
			chbHidden.Checked = selectedItem.SearchHidden;
			chbRecursive.Checked = selectedItem.SearchRecursively;
			chbHidden.Enabled = chbRecursive.Checked;

			if (uploader.Templates.Any(t => t.Id == selectedItem.SelectedTemplateId))
			{
				cobSelectedTemplate.SelectedIndex = uploader.Templates.IndexOf(uploader.Templates.First(t => t.Id == selectedItem.SelectedTemplateId));
			}
			else
			{
				cobSelectedTemplate.SelectedIndex = uploader.Templates.IndexOf(uploader.Templates.First(t => t.Id == 0));
			}
		}

		private void ClearEditBox()
		{
			tlpEditPaths.Enabled = false;
			txtbxAddPath.Text = string.Empty;
			txtbxAddFilter.Text = string.Empty;
			chbRecursive.Checked = false;
			chbHidden.Checked = false;
			chbHidden.Enabled = false;
		}

		private void PathFormLoad(object sender, EventArgs e)
		{
			foreach (var template in uploader.Templates)
			{
				cobSelectedTemplate.Items.Add(template.Name);
			}

			RefillListView();
		}

		private void AddPathButtonClick(object sender, EventArgs e)
		{
			var result = folderBrowserDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				if (Directory.Exists(folderBrowserDialog.SelectedPath) && !uploader.Paths.Any(path => path.Path == folderBrowserDialog.SelectedPath))
				{
					var newPath = new PathInformation()
					{
						Path = folderBrowserDialog.SelectedPath,
						Filter = "*.mp4;*.mkv",
						SelectedTemplateId = 0,
						SearchRecursively = false
					};

					uploader.Paths.Add(newPath);
					RefillListView();
					lvPaths.SelectedIndices.Add(lvPaths.Items.Count - 1);
				}
			}
		}

		private void deletePathButtonClick(object sender, EventArgs e)
		{
			if (NoItemSelected())
			{
				return;
			}

			uploader.Paths.RemoveAt(lvPaths.SelectedIndices[0]);
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
				return;
			}

			int index = lvPaths.SelectedIndices[0];

			var selectedItem = uploader.Paths[index];

			selectedItem.Path = txtbxAddPath.Text;
			selectedItem.Filter = txtbxAddFilter.Text;
			selectedItem.SearchHidden = chbHidden.Checked;
			selectedItem.SearchRecursively = chbRecursive.Checked;
			selectedItem.SelectedTemplateId = uploader.Templates[cobSelectedTemplate.SelectedIndex]?.Id ?? 0;

			ClearEditBox();
			RefillListView();
		}

		private bool NoItemSelected()
		{
			return lvPaths.SelectedItems.Count == 0;
		}

		private void btnSelectPathClick(object sender, EventArgs e)
		{
			var result = folderBrowserDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				if (Directory.Exists(folderBrowserDialog.SelectedPath)
					&& (!uploader.Paths.Any(path => path.Path == folderBrowserDialog.SelectedPath)
					|| folderBrowserDialog.SelectedPath == uploader.Paths[lvPaths.SelectedIndices[0]].Path))
				{
					txtbxAddPath.Text = folderBrowserDialog.SelectedPath;
				}
			}
		}

		private void movePathUpButtonClick(object sender, EventArgs e)
		{
			if (NoItemSelected())
			{
				return;
			}

			var index = lvPaths.SelectedIndices[0];
			if (index == 0)
			{
				return;
			}

			var currentItem = uploader.Paths[index];
			uploader.Paths.RemoveAt(index);
			uploader.Paths.InsertAt(index - 1, currentItem);

			RefillListView();
			lvPaths.SelectedIndices.Clear();
			lvPaths.SelectedIndices.Add(index - 1);
		}

		private void movePathDownButtonClick(object sender, EventArgs e)
		{
			if (NoItemSelected())
			{
				return;
			}

			var index = lvPaths.SelectedIndices[0];
			if (index == uploader.Paths.Count - 1)
			{
				return;
			}

			var currentItem = uploader.Paths[index];
			uploader.Paths.RemoveAt(index);
			uploader.Paths.InsertAt(index + 1, currentItem);

			RefillListView();
			lvPaths.SelectedIndices.Clear();
			lvPaths.SelectedIndices.Add(index + 1);
		}

		private void clearButtonClick(object sender, EventArgs e)
		{
			uploader.Paths.Clear();
			RefillListView();
			ClearEditBox();
		}

		private void btnCancelClick(object sender, EventArgs e)
		{
			ClearEditBox();
			lvPaths.SelectedIndices.Clear();
		}

		private void chbRecursiveCheckedChanged(object sender, EventArgs e)
		{
			chbHidden.Enabled = chbRecursive.Checked;

			if (!chbRecursive.Checked)
			{
				chbHidden.Checked = false;
			}
		}
	}
}
