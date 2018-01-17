using System;
using System.Collections.Generic;
using System.Drawing;
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
			for (int i = 0; i < uploader.Templates.Count; i++)
			{
				if (uploader.Templates[i].Name.ToLower() != "standard")
				{
					uploader.Templates.RemoveAt(i);
					i--;
				}
			}

			RefillListView();
		}

		private void templateListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!reordering)
			{
				editTemplateTableLayoutPanel.Enabled = templateListView.SelectedIndices.Count > 0;

				if (templateListView.SelectedIndices.Count == 0)
				{
					current = new Template();
					ClearEditView();
				}
				else
				{
					var save = uploader.Templates[templateListView.SelectedIndices[0]];
					current = new Template()
					{
						Name = save.Name,
						CategoryId = save.CategoryId,
						DefaultLanguage = save.DefaultLanguage,
						Description = save.Description,
						IsEmbeddable = save.IsEmbeddable,
						License = save.License,
						Privacy = save.Privacy,
						PublicStatsViewable = save.PublicStatsViewable,
						PublishTimes = new List<PublishTime>(save.PublishTimes),
						ShouldPublishAt = save.ShouldPublishAt,
						Tags = save.Tags,
						Title = save.Title
					};

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
			templateNameTextbox.ReadOnly = template.Name == "Standard";

			templateTitleTextbox.Text = template.Title;
			templateDescriptionTextbox.Text = template.Description;
			templateTagsTextbox.Text = template.Tags;

			privacyComboBox.SelectedIndex = (int)template.Privacy;
			publishAtCheckbox.Checked = template.ShouldPublishAt;

			RefillTimesListView();

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
			reordering = true;
			var index = templateListView.SelectedIndices[0];
			uploader.Templates[index] = current;
			RefillListView();
			templateListView.SelectedIndices.Add(index);
			templateListView.Select();
			reordering = false;
		}

		private void templateNameTextboxTextChanged(object sender, EventArgs e)
		{
			if (!reordering && templateNameTextbox.Text.ToLower() != "standard")
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
	}
}
