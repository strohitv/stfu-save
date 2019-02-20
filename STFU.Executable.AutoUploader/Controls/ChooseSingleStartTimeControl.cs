using System;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Executable.AutoUploader.Controls
{
	public partial class ChooseSingleStartTimeControl : UserControl
	{
		private IObservationConfiguration publishSettings;

		public ChooseSingleStartTimeControl()
		{
			InitializeComponent();
		}

		public bool ShouldIgnore => dontObservePathCheckbox.Checked;
		public bool ShouldUploadPrivate => uploadVideosPrivateCheckbox.Checked;
		public bool ShouldPublishAt => shouldOverridePublishAtCheckbox.Checked;
		public DateTime PublishAt => overrideDateTimePicker.Value;

		public ChooseSingleStartTimeControl(IObservationConfiguration settings)
			: this()
		{
			publishSettings = settings;

			SetPublishControlsVisibility(settings.Template.ShouldPublishAt, settings.Template.ShouldPublishAt);

			shouldOverridePublishAtCheckbox.Checked = settings.Template.ShouldPublishAt;

			explanationTextbox.Visible = false;
		}

		private void ChooseSingleStartTimeControlLoad(object sender, EventArgs e)
		{
			overrideDateTimePicker.Value = publishSettings?.StartDate ?? DateTime.Now.Date.AddHours(DateTime.Now.TimeOfDay.Hours + 1);

			if (publishSettings != null)
			{
				mainGroupbox.Text = publishSettings.PathInfo.Fullname;

				for (int i = 0; i < publishSettings.Template.PublishTimes.Count; i++)
				{
					customStartPointCombobox.Items.Add($"{i}: {publishSettings.Template.PublishTimes[i].ToString()}");
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

				if (publishSettings == null)
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
			else if (publishSettings == null)
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

		public IObservationConfiguration GetPublishSettings()
		{
			publishSettings.IgnorePath = dontObservePathCheckbox.Checked;
			publishSettings.UploadPrivate = uploadVideosPrivateCheckbox.Checked;

			if (shouldOverridePublishAtCheckbox.Checked || !mainTlp.Contains(shouldOverridePublishAtCheckbox))
			{
				publishSettings.StartDate = overrideDateTimePicker.Value;
			}

			if (customStartPointCheckbox.Checked && publishSettings != null)
			{
				publishSettings.CustomStartDayIndex = customStartPointCombobox.SelectedIndex;
			}

			return publishSettings;
		}
	}
}
