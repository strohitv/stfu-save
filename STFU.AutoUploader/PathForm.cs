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
				uploader.Remove(lvSelectedPaths.SelectedItems[0].Text);
				RefillListView();
				ClearEditBox();
			}
		}

		private void RefillListView()
		{
			lvSelectedPaths.Items.Clear();

			foreach (var entry in uploader.Paths)
			{
				var newItem = lvSelectedPaths.Items.Add(entry.Path);
				newItem.SubItems.Add(entry.Filter);
				newItem.SubItems.Add(entry.SearchRecursively ? "Ja" : "Nein");
			}

			lvSelectedPaths.SelectedIndices.Clear();
		}

		private void RefillEditBox()
		{
			if (NoItemSelected())
			{
				ClearEditBox();
				return;
			}

			tlpEditPaths.Enabled = true;
			int index = lvSelectedPaths.SelectedIndices[0];

			var selectedItem = uploader.Paths[index];

			txtbxAddPath.Text = selectedItem.Path;
			txtbxAddFilter.Text = selectedItem.Filter;
			chbRecursive.Checked = selectedItem.SearchRecursively;
		}

		private void ClearEditBox()
		{
			tlpEditPaths.Enabled = false;
			txtbxAddPath.Text = string.Empty;
			txtbxAddFilter.Text = string.Empty;
			chbRecursive.Checked = false;
		}

		private void PathFormLoad(object sender, EventArgs e)
		{
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
						Filter = "*.mp4;*.mkv"
					};

					uploader.Paths.Add(newPath);
					RefillListView();
					lvSelectedPaths.SelectedIndices.Add(lvSelectedPaths.Items.Count - 1);
				}
			}
		}

		private void deletePathButtonClick(object sender, EventArgs e)
		{
			if (NoItemSelected())
			{
				return;
			}

			uploader.Paths.RemoveAt(lvSelectedPaths.SelectedIndices[0]);
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

			int index = lvSelectedPaths.SelectedIndices[0];

			var selectedItem = uploader.Paths[index];

			selectedItem.Path = txtbxAddPath.Text;
			selectedItem.Filter = txtbxAddFilter.Text;
			selectedItem.SearchRecursively = chbRecursive.Checked;

			ClearEditBox();
			RefillListView();
		}

		private bool NoItemSelected()
		{
			return lvSelectedPaths.SelectedItems.Count == 0;
		}

		private void btnSelectPathClick(object sender, EventArgs e)
		{
			var result = folderBrowserDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				if (Directory.Exists(folderBrowserDialog.SelectedPath)
					&& (!uploader.Paths.Any(path => path.Path == folderBrowserDialog.SelectedPath)
					|| folderBrowserDialog.SelectedPath == uploader.Paths[lvSelectedPaths.SelectedIndices[0]].Path))
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

			var index = lvSelectedPaths.SelectedIndices[0];
			if (index == 0)
			{
				return;
			}

			var currentItem = uploader.Paths[index];
			uploader.Paths.RemoveAt(index);
			uploader.Paths.InsertAt(index - 1, currentItem);

			RefillListView();
			lvSelectedPaths.SelectedIndices.Clear();
			lvSelectedPaths.SelectedIndices.Add(index - 1);
		}

		private void movePathDownButtonClick(object sender, EventArgs e)
		{
			if (NoItemSelected())
			{
				return;
			}

			var index = lvSelectedPaths.SelectedIndices[0];
			if (index == uploader.Paths.Count - 1)
			{
				return;
			}

			var currentItem = uploader.Paths[index];
			uploader.Paths.RemoveAt(index);
			uploader.Paths.InsertAt(index + 1, currentItem);

			RefillListView();
			lvSelectedPaths.SelectedIndices.Clear();
			lvSelectedPaths.SelectedIndices.Add(index + 1);
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
			lvSelectedPaths.SelectedIndices.Clear();
		}
	}
}
