using System.Collections.Generic;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.GUI.Forms
{
	public partial class SelectTemplateDialog : Form
	{
		public IList<ITemplate> Templates { get; set; } = new List<ITemplate>();

		public ITemplate SelectedTemplate { get; private set; }

		public SelectTemplateDialog()
		{
			InitializeComponent();
		}

		private void SelectTemplateDialog_Load(object sender, System.EventArgs e)
		{
			foreach (var template in Templates)
			{
				templatesCombobox.Items.Add(template.Name);
			}

			if (templatesCombobox.Items.Count > 0)
			{
				templatesCombobox.SelectedIndex = 0;
			}
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void saveButton_Click(object sender, System.EventArgs e)
		{
			SelectedTemplate = Templates[templatesCombobox.SelectedIndex];
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
