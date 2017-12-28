using System;
using System.Windows.Forms;
using STFU.UploadLib.Automation;
using STFU.UploadLib.Templates;

namespace STFU.AutoUploader
{
	public partial class TemplateForm : Form
	{
		private AutomationUploader uploader;
		private Template current;

		public TemplateForm(AutomationUploader upl)
		{
			InitializeComponent();

			uploader = upl;
		}

		private void addPathButtonClick(object sender, EventArgs e)
		{
			Template templ = new Template();
			uploader.Templates.Add(templ);

			RefillListView();
		}

		private void RefillListView()
		{
			templateListView.Items.Clear();

			foreach (var template in uploader.Templates)
			{
				templateListView.Items.Add(template.Name);
			}
		}

		private void deletePathButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedItems.Count == 0)
			{
				return;
			}

			int selectedIndex = templateListView.SelectedIndices[0];
			uploader.Templates.RemoveAt(selectedIndex);

			RefillListView();
		}

		private void clearButtonClick(object sender, EventArgs e)
		{
			uploader.Templates.Clear();
			RefillListView();
		}

		private void templateListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			if (templateListView.SelectedIndices.Count == 0)
			{
				ClearEditView();
			}
			else
			{
				current = uploader.Templates[templateListView.SelectedIndices[0]];
				FillTemplateIntoEditView(current);
			}
		}

		private void ClearEditView()
		{

		}

		private void FillTemplateIntoEditView(Template template)
		{
			templateNameTextbox.Text = template.Name;
			templateTitleTextbox.Text = template.Title;
			templateDescriptionTextbox.Text = template.Description;
			templateTagsTextbox.Text = template.Tags;

			privacyComboBox.SelectedIndex = (int)template.Privacy;
			publishAtCheckbox.Checked = template.PublishRule != null;

			if (template.PublishRule != null)
			{
				weekdayListView.SelectedIndices.Clear();
				weekdayListView.SelectedIndices.Add(0);
			}
		}

		private void timeListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			saveTimeButton.Enabled = setTimeDateTimePicker.Enabled = timeListView.SelectedIndices.Count != 0;
		}

		private void publishAtCheckboxCheckedChanged(object sender, EventArgs e)
		{
			enablePublishAtControls();
		}

		private void enablePublishAtControls()
		{
			addTimeButton.Enabled
				= deleteTimeButton.Enabled
				= clearTimesButton.Enabled
				= setTimeDateTimePicker.Enabled
				= saveTimeButton.Enabled
				= publishAtCheckbox.Checked;
		}

		private void privacyComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			publishAtCheckbox.Enabled = privacyComboBox.SelectedIndex == 2;

			if (privacyComboBox.SelectedIndex != 2)
			{
				publishAtCheckbox.Checked = false;
				enablePublishAtControls();
			}
		}
	}
}
