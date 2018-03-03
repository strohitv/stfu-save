using System;
using System.Windows.Forms;
using STFU.UploadLib.Templates;

namespace STFU.AutoUploader
{
	public partial class ChooseSingleStartTimeControl : UserControl
	{
		private PublishInformation information;

		public ChooseSingleStartTimeControl()
		{
			InitializeComponent();
		}

		public bool ShouldIgnore => dontObservePathCheckbox.Checked;
		public bool ShouldUploadPrivate => uploadVideosPrivateCheckbox.Checked;
		public bool ShouldPublishAt => shouldOverridePublishAtCheckbox.Checked;
		public DateTime PublishAt => overrideDateTimePicker.Value;

		public ChooseSingleStartTimeControl(PublishInformation info)
			: this()
		{
			information = info;

			SetPublishControlsVisibility(info.Template.ShouldPublishAt, info.Template.ShouldPublishAt);

			shouldOverridePublishAtCheckbox.Checked = false;

			explanationTextbox.Visible = false;
		}

		private void ChooseSingleStartTimeControlLoad(object sender, EventArgs e)
		{
			DateTime publishDt = DateTime.Now.Date.AddHours(DateTime.Now.TimeOfDay.Hours + 1);
			overrideDateTimePicker.Value = publishDt;

			if (information != null)
			{
				mainGroupbox.Text = information.PathInfo.Path;

				for (int i = 0; i < information.Template.PublishTimes.Count; i++)
				{
					customStartPointCombobox.Items.Add($"{i}: {information.Template.PublishTimes[i].ToString()}");
				}

				if (customStartPointCombobox.Items.Count > 0)
				{
					customStartPointCombobox.SelectedIndex = 0;
				}
			}

			ReenableControls();
		}

		private void shouldOverridePublishAtCheckboxCheckedChanged(object sender, EventArgs e)
		{
			if (!shouldOverridePublishAtCheckbox.Checked)
			{
				customStartPointCheckbox.Checked = false;

				if (information == null)
				{
					uploadVideosPrivateCheckbox.Checked = true;
				}
			}

			ReenableControls();
		}

		private void customStartPointCheckboxCheckedChanged(object sender, EventArgs e)
		{
			ReenableControls();
		}

		private void dontObservePathCheckboxCheckedChanged(object sender, EventArgs e)
		{
			if (dontObservePathCheckbox.Checked)
			{
				uploadVideosPrivateCheckbox.Checked
					= shouldOverridePublishAtCheckbox.Checked
					= customStartPointCheckbox.Checked
					= false;
			}

			ReenableControls();
		}

		private void uploadVideosPrivateCheckboxCheckedChanged(object sender, EventArgs e)
		{
			if (uploadVideosPrivateCheckbox.Checked)
			{
				shouldOverridePublishAtCheckbox.Checked
					= customStartPointCheckbox.Checked
					= false;
			}
			else if (information == null)
			{
				shouldOverridePublishAtCheckbox.Checked = true;
			}

			ReenableControls();
		}

		private void ReenableControls()
		{
			uploadVideosPrivateCheckbox.Enabled = !dontObservePathCheckbox.Checked;
			shouldOverridePublishAtCheckbox.Enabled = !dontObservePathCheckbox.Checked && !uploadVideosPrivateCheckbox.Checked;
			overrideDateTimePicker.Enabled = customStartPointCheckbox.Enabled = shouldOverridePublishAtCheckbox.Checked;
			customStartPointCombobox.Enabled = customStartPointCheckbox.Checked;
		}

		public void SetPublishControlsVisibility(bool showShouldPublishAtControls, bool showCustomStartPointControls)
		{
			shouldOverridePublishAtCheckbox.Visible
				= overrideDateTimePicker.Visible
				= showShouldPublishAtControls;

			customStartPointCheckbox.Visible
				= customStartPointCombobox.Visible
				= showCustomStartPointControls;
		}

		public PublishInformation GetPublishInformation()
		{
			information.IgnorePath = dontObservePathCheckbox.Checked;
			information.PublishPrivate = uploadVideosPrivateCheckbox.Checked;

			if (shouldOverridePublishAtCheckbox.Checked || !mainTlp.Contains(shouldOverridePublishAtCheckbox))
			{
				information.StartDate = overrideDateTimePicker.Value;
			}

			if (customStartPointCheckbox.Checked && information != null)
			{
				information.CustomStartDayIndex = customStartPointCombobox.SelectedIndex;
			}

			return information;
		}
	}
}
