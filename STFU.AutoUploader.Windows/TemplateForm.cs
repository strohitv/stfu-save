using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using STFU.UploadLib.Automation;
using STFU.UploadLib.Templates;
using STFU.UploadLib.Videos;

namespace STFU.AutoUploader
{
	public partial class TemplateForm : Form
	{
		private AutomationUploader uploader;
		private Template current;
		private bool reordering = false;

		public TemplateForm(AutomationUploader upl)
		{
			InitializeComponent();

			addWeekdayCombobox.SelectedIndex = 0;

			uploader = upl;
		}

		private void addPathButtonClick(object sender, EventArgs e)
		{
			Template templ = uploader.CreateTemplate();
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

		private void splitContainerPaint(object sender, PaintEventArgs e)
		{
			var control = sender as SplitContainer;
			//paint the three dots'
			Point[] points = new Point[3];
			var w = control.Width;
			var h = control.Height;
			var d = control.SplitterDistance;
			var sW = control.SplitterWidth;

			//calculate the position of the points'
			if (control.Orientation == Orientation.Horizontal)
			{
				points[0] = new Point((w / 2), d + (sW / 2));
				points[1] = new Point(points[0].X - 10, points[0].Y);
				points[2] = new Point(points[0].X + 10, points[0].Y);
			}
			else
			{
				points[0] = new Point(d + (sW / 2), (h / 2));
				points[1] = new Point(points[0].X, points[0].Y - 10);
				points[2] = new Point(points[0].X, points[0].Y + 10);
			}

			foreach (Point p in points)
			{
				p.Offset(-2, -2);
				e.Graphics.FillEllipse(SystemBrushes.ControlDark,
					new Rectangle(p, new Size(7, 7)));
			}
		}

		private void TemplateFormLoad(object sender, EventArgs e)
		{
			RefillListView();
			//privacyComboBox.SelectedIndex = 2;
		}

		private void deletePathButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedItems.Count == 0 || uploader.Templates[templateListView.SelectedIndices[0]].Id == 0)
			{
				return;
			}

			var confirmation = MessageBox.Show(this, "Möchtest du das ausgewählte Template wirklich löschen? Alle Pfade, die es verwenden, werden auf das Standard-Template umgestellt.", "Wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirmation == DialogResult.Yes)
			{
				var index = templateListView.SelectedIndices[0];
				var templateId = uploader.Templates[index].Id;

				foreach (var path in uploader.Paths.Where(p => p.SelectedTemplateId == templateId))
				{
					path.SelectedTemplateId = 0;
				}

				uploader.WritePaths();
				uploader.Templates.RemoveAt(templateListView.SelectedIndices[0]);

				templateListView.SelectedIndices.Clear();

				RefillListView();
			}
		}

		private void clearButtonClick(object sender, EventArgs e)
		{
			var confirmation = MessageBox.Show(this, "Möchtest du wirklich alle Templates löschen? Das Standard-Template kann nicht entfernt werden. Alle Pfade werden auf das Standard-Template umgestellt.", "Wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirmation == DialogResult.Yes)
			{
				foreach (var path in uploader.Paths)
				{
					path.SelectedTemplateId = 0;
				}

				uploader.WritePaths();

				for (int i = 0; i < uploader.Templates.Count; i++)
				{
					if (uploader.Templates[i].Id != 0)
					{
						uploader.Templates.RemoveAt(i);
						i--;
					}
				}

				templateListView.SelectedIndices.Clear();

				RefillListView();
			}
		}

		private void templateListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!reordering)
			{
				editTemplateTableLayoutPanel.Enabled = templateListView.SelectedIndices.Count > 0;

				if (templateListView.SelectedIndices.Count == 0)
				{
					current = uploader.CreateTemplate();
					ClearEditView();
				}
				else
				{
					var save = uploader.Templates[templateListView.SelectedIndices[0]];
					current = Template.Duplicate(save);

					FillTemplateIntoEditView(current);
				}
			}
		}

		private void ClearEditView()
		{
			templateNameTextbox.Text = string.Empty;
			templateTitleTextbox.Text = string.Empty;
			templateDescriptionTextbox.Text = string.Empty;
			templateTagsTextbox.Text = string.Empty;

			templateValuesTabControl.SelectedIndex = 0;
		}

		private void FillTemplateIntoEditView(Template template)
		{
			templateNameTextbox.Text = template.Name;
			//templateNameTextbox.ReadOnly = template.Name == "Standard";

			templateTitleTextbox.Text = template.Title;
			templateDescriptionTextbox.Text = template.Description;
			templateTagsTextbox.Text = template.Tags;

			privacyComboBox.SelectedIndex = (int)template.Privacy;
			publishAtCheckbox.Checked = template.ShouldPublishAt;

			defaultLanguageCombobox.Items.Clear();
			defaultLanguageCombobox.Items.AddRange(uploader.Languages.Select(lang => lang.Name).ToArray());
			defaultLanguageCombobox.SelectedIndex = uploader.Languages.IndexOf(uploader.Languages.FirstOrDefault(lang => lang.Id == template.DefaultLanguage?.Id));

			categoryCombobox.Items.Clear();
			categoryCombobox.Items.AddRange(uploader.AvailableCategories.Select(cat => cat.Title).ToArray());
			categoryCombobox.SelectedIndex = uploader.AvailableCategories.ToList().IndexOf(uploader.AvailableCategories.FirstOrDefault(c => c.Id == template.Category?.Id));

			licenseCombobox.SelectedIndex = (int)template.License;

			isEmbeddableCheckbox.Checked = template.IsEmbeddable;
			publicStatsViewableCheckbox.Checked = template.PublicStatsViewable;
			notifySubscribersCheckbox.Checked = template.NotifySubscribers;
			autoLevelsCheckbox.Checked = template.AutoLevels;
			stabilizeCheckbox.Checked = template.Stabilize;

			RefillTimesListView();
			RefillVariablesListView();

			if (template.PublishTimes.Count > 0)
			{
				// Ersten markieren.
				timesListView.SelectedIndices.Clear();
				timesListView.SelectedIndices.Add(0);
			}
		}

		private void publishAtCheckboxCheckedChanged(object sender, EventArgs e)
		{
			if (!reordering)
			{
				current.ShouldPublishAt = publishAtCheckbox.Checked;
				enablePublishAtControls();
			}
		}

		private void enablePublishAtControls()
		{
			publishGroupbox.Enabled = publishAtCheckbox.Checked;
		}

		private void privacyComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!reordering)
			{
				publishAtCheckbox.Enabled = privacyComboBox.SelectedIndex == 2;

				if (privacyComboBox.SelectedIndex != 2)
				{
					publishAtCheckbox.Checked = false;
					//enablePublishAtControls();
				}

				switch (privacyComboBox.SelectedIndex)
				{
					case 0:
						current.Privacy = PrivacyStatus.Public;
						break;
					case 1:
						current.Privacy = PrivacyStatus.Unlisted;
						break;
					default:
						current.Privacy = PrivacyStatus.Private;
						break;
				}
			}
		}

		private void resetTemplateButtonClick(object sender, EventArgs e)
		{
			templateListView.SelectedIndices.Clear();
		}

		private void addTimeButtonClick(object sender, EventArgs e)
		{
			if (addWeekdayCombobox.SelectedIndex == 0)
			{
				var time = addTimeTimePicker.Value.TimeOfDay;

				// täglich
				for (int i = 0; i < 7; i++)
				{
					var weekDay = (DayOfWeek)((i + 1) % 7);

					PublishTime publishTime = new PublishTime() { DayOfWeek = weekDay, Time = time };
					current.PublishTimes.Add(publishTime);
				}
			}
			else
			{
				var weekDay = (DayOfWeek)(addWeekdayCombobox.SelectedIndex % 7);
				var time = addTimeTimePicker.Value.TimeOfDay;

				PublishTime publishTime = new PublishTime() { DayOfWeek = weekDay, Time = time };
				current.PublishTimes.Add(publishTime);
			}

			RefillTimesListView();
		}

		private void RefillTimesListView()
		{
			// Selektion merken
			int[] selectedIndices = new int[timesListView.SelectedIndices.Count];
			timesListView.SelectedIndices.CopyTo(selectedIndices, 0);

			timesListView.Items.Clear();
			foreach (var publishTime in current.PublishTimes)
			{
				timesListView.Items.Add(new ListViewItem(new[]
				{
					GetDayString(publishTime.DayOfWeek),
					$"{publishTime.Time.ToString(@"hh\:mm")} Uhr",
					$"{publishTime.SkipDays} Tage"
				}));
			}

			foreach (var index in selectedIndices)
			{
				if (timesListView.Items.Count > index)
				{
					timesListView.SelectedIndices.Add(index);
				}
			}
		}

		private string GetDayString(DayOfWeek day)
		{
			string result = string.Empty;

			switch (day)
			{
				case DayOfWeek.Sunday:
					result = "Sonntag";
					break;
				case DayOfWeek.Monday:
					result = "Montag";
					break;
				case DayOfWeek.Tuesday:
					result = "Dienstag";
					break;
				case DayOfWeek.Wednesday:
					result = "Mittwoch";
					break;
				case DayOfWeek.Thursday:
					result = "Donnerstag";
					break;
				case DayOfWeek.Friday:
					result = "Freitag";
					break;
				case DayOfWeek.Saturday:
					result = "Samstag";
					break;
			}

			return result;
		}

		private void saveTemplateButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedIndices.Count == 1)
			{
				reordering = true;
				var index = templateListView.SelectedIndices[0];
				uploader.Templates[index] = current;
				RefillListView();
				templateListView.SelectedIndices.Add(index);
				templateListView.Select();
				reordering = false;
			}
		}

		private void templateNameTextboxTextChanged(object sender, EventArgs e)
		{
			if (!reordering) // && templateNameTextbox.Text.ToLower() != "standard")
			{
				current.Name = templateNameTextbox.Text;
			}
		}

		private void templateTitleTextboxTextChanged(object sender, EventArgs e)
		{
			maxTitleLengthLabel.Text = $"Länge Titel: {templateTitleTextbox.Text.Length} / {Video.MaxTitleLength} Zeichen";
			if (!reordering)
			{
				current.Title = templateTitleTextbox.Text;
			}
		}

		private void templateDescriptionTextboxTextChanged(object sender, EventArgs e)
		{
			maxDescriptionLengthLabel.Text = $"Länge Beschreibung: {templateDescriptionTextbox.Text.Length} / {Video.MaxDescriptionLength} Zeichen";
			if (!reordering)
			{
				current.Description = templateDescriptionTextbox.Text;
			}
		}

		private void templateTagsTextboxTextChanged(object sender, EventArgs e)
		{
			maxTagsLengthLabel.Text = $"Länge Tags: {templateTagsTextbox.Text.Length} / {Video.MaxTagsLength} Zeichen";
			if (!reordering)
			{
				current.Tags = templateTagsTextbox.Text;
			}
		}

		private void movePathUpButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedIndices.Count == 1)
			{
				var index = templateListView.SelectedIndices[0];
				if (index > 0)
				{
					reordering = true;
					var save = uploader.Templates[index];
					uploader.Templates[index] = uploader.Templates[index - 1];
					uploader.Templates[index - 1] = save;

					RefillListView();

					templateListView.SelectedIndices.Add(index - 1);
					templateListView.Select();
					reordering = false;
				}
			}
		}

		private void movePathDownButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedIndices.Count == 1)
			{
				var index = templateListView.SelectedIndices[0];
				if (index < templateListView.Items.Count - 1)
				{
					reordering = true;
					var save = uploader.Templates[index];
					uploader.Templates[index] = uploader.Templates[index + 1];
					uploader.Templates[index + 1] = save;

					RefillListView();

					templateListView.SelectedIndices.Add(index + 1);
					templateListView.Select();
					reordering = false;
				}
			}
		}

		private void deleteTimeButtonClick(object sender, EventArgs e)
		{
			if (timesListView.SelectedIndices.Count == 0)
			{
				return;
			}

			var timesToRemove = new List<PublishTime>();
			foreach (int index in timesListView.SelectedIndices)
			{
				timesToRemove.Add(current.PublishTimes[index]);
			}

			foreach (var time in timesToRemove)
			{
				current.PublishTimes.Remove(time);
			}

			RefillTimesListView();
		}

		private void clearTimesButtonClick(object sender, EventArgs e)
		{
			current.PublishTimes.Clear();
			RefillTimesListView();
		}

		private void addOneDayButtonClick(object sender, EventArgs e)
		{
			foreach (int index in timesListView.SelectedIndices)
			{
				current.PublishTimes[index].SkipDays++;
			}

			RefillTimesListView();
			timesListView.Select();
		}

		private void substractOneDayButtonClick(object sender, EventArgs e)
		{
			foreach (int index in timesListView.SelectedIndices)
			{
				if (current.PublishTimes[index].SkipDays > 0)
				{
					current.PublishTimes[index].SkipDays--;
				}
			}

			RefillTimesListView();
			timesListView.Select();
		}

		private void addOneWeekButtonClick(object sender, EventArgs e)
		{
			foreach (int index in timesListView.SelectedIndices)
			{
				current.PublishTimes[index].SkipDays += 7;
			}

			RefillTimesListView();
			timesListView.Select();
		}

		private void substractOneWeekButtonClick(object sender, EventArgs e)
		{
			foreach (int index in timesListView.SelectedIndices)
			{
				current.PublishTimes[index].SkipDays -= 7;
				if (current.PublishTimes[index].SkipDays < 0)
				{
					current.PublishTimes[index].SkipDays = 0;
				}
			}

			RefillTimesListView();
			timesListView.Select();
		}

		private void moveTimeUpButtonClick(object sender, EventArgs e)
		{
			timesListView.BeginUpdate();

			bool atLeastOneUpdate = false;
			for (int i = 0; i < current.PublishTimes.Count; i++)
			{
				if (timesListView.SelectedIndices.Contains(i) && i > 0 && !timesListView.SelectedIndices.Contains(i - 1))
				{
					atLeastOneUpdate = true;

					var save = current.PublishTimes[i];
					current.PublishTimes[i] = current.PublishTimes[i - 1];
					current.PublishTimes[i - 1] = save;

					timesListView.SelectedIndices.Remove(i);
					timesListView.SelectedIndices.Add(i - 1);
				}
			}

			timesListView.EndUpdate();

			if (atLeastOneUpdate)
			{
				RefillTimesListView();
				timesListView.Select();
			}
		}

		private void moveTimeDownButtonClick(object sender, EventArgs e)
		{
			timesListView.BeginUpdate();

			bool atLeastOneUpdate = false;
			for (int i = current.PublishTimes.Count - 1; i >= 0; i--)
			{
				if (timesListView.SelectedIndices.Contains(i) && i < current.PublishTimes.Count - 1 && !timesListView.SelectedIndices.Contains(i + 1))
				{
					atLeastOneUpdate = true;

					var save = current.PublishTimes[i];
					current.PublishTimes[i] = current.PublishTimes[i + 1];
					current.PublishTimes[i + 1] = save;

					timesListView.SelectedIndices.Remove(i);
					timesListView.SelectedIndices.Add(i + 1);
				}
			}

			timesListView.EndUpdate();

			if (atLeastOneUpdate)
			{
				RefillTimesListView();
				timesListView.Select();
			}
		}

		private void categoryComboboxSelectedIndexChanged(object sender, EventArgs e)
		{
			current.Category = uploader.AvailableCategories.FirstOrDefault(c => c.Title == categoryCombobox.Text);
		}

		private void defaultLanguageComboboxSelectedIndexChanged(object sender, EventArgs e)
		{
			current.DefaultLanguage = uploader.Languages.FirstOrDefault(lang => lang.Name == defaultLanguageCombobox.Text);
		}

		private void licenseComboboxSelectedIndexChanged(object sender, EventArgs e)
		{
			current.License = (License)licenseCombobox.SelectedIndex;
		}

		private void isEmbeddableCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.IsEmbeddable = isEmbeddableCheckbox.Checked;
		}

		private void publicStatsViewableCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.PublicStatsViewable = publicStatsViewableCheckbox.Checked;
		}

		private void notifySubscribersCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.NotifySubscribers = notifySubscribersCheckbox.Checked;
		}

		private void autoLevelsCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.AutoLevels = autoLevelsCheckbox.Checked;
		}

		private void stabilizeCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.Stabilize = stabilizeCheckbox.Checked;
		}

		private void RefillVariablesListView()
		{
			localVarsListview.SelectedIndices.Clear();
			localVarsListview.Items.Clear();

			foreach (var variable in current.LocalVariables)
			{
				ListViewItem item = new ListViewItem(variable.Key);
				item.SubItems.Add(variable.Value);
				localVarsListview.Items.Add(item);
			}
		}

		private void addVarButtonClick(object sender, EventArgs e)
		{
			current.AddVariable();
			RefillVariablesListView();
		}

		private void removeVarButtonClick(object sender, EventArgs e)
		{
			if (localVarsListview.SelectedIndices.Count == 1)
			{
				string varName = localVarsListview.SelectedItems[0].Text;
				current.RemoveVariable(varName);
			}
		}

		private void clearVarsButtonClick(object sender, EventArgs e)
		{
			current.ClearVariables();
		}

		private void RefillEditVarBox()
		{
			if (localVarsListview.SelectedIndices.Count == 1)
			{
				string varName = localVarsListview.SelectedItems[0].Text;
				varNameTextbox.Text = varName;
				varContentTextbox.Text = current.LocalVariables[varName];
			}
			else
			{
				varNameTextbox.Text = string.Empty;
				varContentTextbox.Text = string.Empty;
			}

			editVarGroupbox.Enabled = localVarsListview.SelectedIndices.Count == 1;
		}

		private void localVarsListviewSelectedIndexChanged(object sender, EventArgs e)
		{
			RefillEditVarBox();
		}

		private void saveVarButtonClick(object sender, EventArgs e)
		{
			if (localVarsListview.SelectedIndices.Count == 1)
			{
				string varName = localVarsListview.SelectedItems[0].Text;
				if (varName != varNameTextbox.Text)
				{
					varName = current.RenameVariable(varName, varNameTextbox.Text);
				}

				current.EditVariable(varName, varContentTextbox.Text);

				RefillVariablesListView();
			}
		}
	}
}
