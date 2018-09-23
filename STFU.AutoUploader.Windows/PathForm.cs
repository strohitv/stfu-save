using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces;

namespace STFU.AutoUploader
{
	public partial class PathForm : Form
	{
		IPathContainer pathContainer = null;
		ITemplateContainer templateContainer = null;

		public PathForm(IPathContainer pathContainer, ITemplateContainer templateContainer)
		{
			InitializeComponent();

			this.pathContainer = pathContainer;
			this.templateContainer = templateContainer;
		}

		private void lvSelectedPathsKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete && ItemSelected())
			{
				pathContainer.UnregisterPathAt(lvPaths.SelectedIndices[0]);
				RefillListView();
				ClearEditBox();
			}
		}

		private void RefillListView()
		{
			lvPaths.Items.Clear();

			foreach (var entry in pathContainer.RegisteredPaths)
			{
				var newItem = lvPaths.Items.Add(entry.Fullname);
				newItem.SubItems.Add(entry.Filter);

				string templateName = templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == entry.SelectedTemplateId)?.Name;
				if (string.IsNullOrWhiteSpace(templateName))
				{
					templateName = templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == 0).Name;
				}
				newItem.SubItems.Add(templateName);

				newItem.SubItems.Add(entry.SearchRecursively ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.SearchHidden ? "Ja" : "Nein");
				newItem.SubItems.Add(entry.Inactive ? "Ja" : "Nein");
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

			var selectedItem = pathContainer.RegisteredPaths.ElementAt(index);

			txtbxAddPath.Text = selectedItem.Fullname;
			txtbxAddFilter.Text = selectedItem.Filter;
			chbHidden.Checked = selectedItem.SearchHidden;
			chbRecursive.Checked = selectedItem.SearchRecursively;
			chbHidden.Enabled = chbRecursive.Checked;
			deactivateCheckbox.Checked = selectedItem.Inactive;

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
			tlpEditPaths.Enabled = false;
			txtbxAddPath.Text = string.Empty;
			txtbxAddFilter.Text = string.Empty;
			chbRecursive.Checked = false;
			chbHidden.Checked = false;
			chbHidden.Enabled = false;
			deactivateCheckbox.Checked = false;
		}

		private void PathFormLoad(object sender, EventArgs e)
		{
			foreach (var template in templateContainer.RegisteredTemplates)
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

					pathContainer.RegisterPath(newPath);
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
			var result = folderBrowserDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				if (Directory.Exists(folderBrowserDialog.SelectedPath)
					&& (!pathContainer.RegisteredPaths.Any(path => path.Fullname == folderBrowserDialog.SelectedPath)
					|| folderBrowserDialog.SelectedPath == pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0]).Fullname))
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

			pathContainer.ShiftPathPositionsAt(index, index - 1);

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

			pathContainer.ShiftPathPositionsAt(index, index + 1);

			RefillListView();
			lvPaths.SelectedIndices.Clear();
			lvPaths.SelectedIndices.Add(index + 1);
		}

		private void clearButtonClick(object sender, EventArgs e)
		{
			pathContainer.UnregisterAllPaths();
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

		private void txtbxAddFilter_MouseEnter(object sender, EventArgs e)
		{
			var tooltipText = @"Hiermit kannst du die Dateien, die du finden möchtest, durch Strichpunkt getrennt filltern.
Platzhalter: ? für ein beliebiges Zeichen, * für beliebig viele beliebige Zeichen

Beispielhafte Filter: 
*.mp4  findet alle mp4-Dateien. 
video*.mp4 findet alle mp4-Dateien, die mit 'video' beginnen. 
video?.mp4 findet video1.mp4, aber nicht video12.mp4, da das Fragezeichen nur ein Zeichen ersetzen kann.
video *.mp4 findet auch video.mp4, da der *auch für kein Zeichen stehen kann.
* mp4; *mkv findet alle mp4 - und alle mkv-Dateien.";
			toolTip.Show(tooltipText, txtbxAddFilter, 60000);
		}

		private void btnMarkAsReadClick(object sender, EventArgs e)
		{
			chosePathTlp.Enabled = false;
			pathContainer.MarkAllFilesAsRead(pathContainer.RegisteredPaths.ElementAt(lvPaths.SelectedIndices[0]));
			MessageBox.Show(this, "Die Videos, die durch diesen Pfad gefunden werden können, wurden erfolgreich als bereits hochgeladen markiert. Der Uploader wird sie nun nicht mehr finden. Um das zu ändern, einfach die Videodatei wieder umbenennen, sodass sie nicht mehr mit einem Unterstrich _ startet.", "Videos erfolgreich als hochgeladen markiert", MessageBoxButtons.OK, MessageBoxIcon.Information);
			chosePathTlp.Enabled = true;
		}
	}
}
