using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Programming;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Persistor;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class TemplateForm : Form
	{
		private ITemplateContainer templateContainer;
		private IYoutubeCategoryContainer categoryContainer;
		private IYoutubeLanguageContainer languageContainer;
		private IYoutubePlaylistContainer playlistContainer;
		private TemplatePersistor templatePersistor;
		private ITemplate current;

		private bool reordering = false;
		private bool isDirty = false;
		private bool skipDirtyManipulation = false;

		private bool IsDirty
		{
			get
			{
				return isDirty;
			}
			set
			{
				if (!skipDirtyManipulation)
				{
					isDirty = value;
					saveTemplateButton.Enabled = isDirty;
					resetTemplateButton.Enabled = isDirty;
				}
			}
		}

		public TemplateForm(TemplatePersistor persistor,
			IYoutubeCategoryContainer categoryContainer,
			IYoutubeLanguageContainer languageContainer,
			IYoutubePlaylistContainer playlistContainer,
			bool accountHasMailEnabled)
		{
			InitializeComponent();

			addWeekdayCombobox.SelectedIndex = 0;

			templatePersistor = persistor;
			templateContainer = persistor.Container;
			this.categoryContainer = categoryContainer;
			this.languageContainer = languageContainer;
			this.playlistContainer = playlistContainer;

			if (templateValuesTabControl.TabPages.Contains(cSharpTabPage))
			{
				templateValuesTabControl.TabPages.Remove(cSharpTabPage);
			}

			if (accountHasMailEnabled)
			{
				connectMailNotificationLabel.Visible = false;

				newVideoMNCheckbox.Enabled = true;
				uploadStartedMNCheckbox.Enabled = true;
				uploadFinishedMNCheckbox.Enabled = true;
				uploadFailedMNCheckbox.Enabled = true;

				mailRecipientTextbox.Enabled = true;
			}
			else
			{
				connectMailNotificationLabel.Visible = true;

				newVideoMNCheckbox.Enabled = false;
				uploadStartedMNCheckbox.Enabled = false;
				uploadFinishedMNCheckbox.Enabled = false;
				uploadFailedMNCheckbox.Enabled = false;

				mailRecipientTextbox.Enabled = false;
			}

			foreach (var playlist in playlistContainer.RegisteredPlaylists)
			{
				playlistCombobox.Items.Add(playlist.Title);
			}
		}

		private void addTemplateButtonClick(object sender, EventArgs e)
		{
			ITemplate templ = new Template();
			templateContainer.RegisterTemplate(templ);

			RefillListView();
		}

		private void RefillListView()
		{
			templateListView.Items.Clear();

			foreach (var template in templateContainer.RegisteredTemplates)
			{
				var name = template.Name;
				if (string.IsNullOrWhiteSpace(name))
				{
					name = "<Template ohne Namen>";
				}

				templateListView.Items.Add(name);
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

			cSharpSystemFunctionsFctb.Text = StandardFunctions.GlobalFunctions.Aggregate((a, b) => $"{a}{Environment.NewLine}{Environment.NewLine}{b}");
			cSharpScriptingTabControl.SelectedIndex = 2;
		}

		private void deleteTemplateButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedItems.Count == 0 || templateContainer.RegisteredTemplates.ElementAt(templateListView.SelectedIndices[0]).Id == 0)
			{
				return;
			}

			var confirmation = MessageBox.Show(this, "Möchtest du das ausgewählte Template wirklich löschen? Alle Pfade, die es verwenden, werden auf das Standard-Template umgestellt.", "Wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirmation == DialogResult.Yes)
			{
				templateContainer.UnregisterTemplateAt(templateListView.SelectedIndices[0]);

				templateListView.SelectedIndices.Clear();

				RefillListView();
			}
		}

		private void clearTemplatesButtonClick(object sender, EventArgs e)
		{
			var confirmation = MessageBox.Show(this, "Möchtest du wirklich alle Templates löschen? Das Standard-Template kann nicht entfernt werden. Alle Pfade werden auf das Standard-Template umgestellt.", "Wirklich löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirmation == DialogResult.Yes)
			{
				templateContainer.UnregisterAllTemplates();

				templateListView.SelectedIndices.Clear();

				RefillListView();
			}
		}

		private void templateListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!reordering)
			{
				AskForSaveIfIsDirty();

				skipDirtyManipulation = true;

				editTemplateTableLayoutPanel.Enabled = templateListView.SelectedIndices.Count > 0;
				deleteTemplateButton.Enabled = templateListView.SelectedIndices.Count > 0 && templateContainer.RegisteredTemplates.ElementAt(templateListView.SelectedIndices[0]).Id != 0;

				if (templateListView.SelectedIndices.Count == 0)
				{
					current = new Template();
					ClearEditView();
				}
				else
				{
					var save = templateContainer.RegisteredTemplates.ElementAt(templateListView.SelectedIndices[0]);
					current = Template.Duplicate(save);

					FillTemplateIntoEditView(current);
				}

				skipDirtyManipulation = false;
			}
		}

		private void ClearEditView()
		{
			templateNameTextbox.Text = string.Empty;
			templateTitleTextbox.Text = string.Empty;
			templateDescriptionTextbox.Text = string.Empty;
			templateTagsTextbox.Text = string.Empty;

			templateValuesTabControl.SelectedIndex = 0;

			if (templateValuesTabControl.TabPages.Contains(cSharpTabPage))
			{
				templateValuesTabControl.TabPages.Remove(cSharpTabPage);
			}

			RefillPlannedVideosListView();
		}

		private void FillTemplateIntoEditView(ITemplate template)
		{
			skipDirtyManipulation = true;

			templateNameTextbox.Text = template.Name;

			templateTitleTextbox.Text = template.Title;
			templateDescriptionTextbox.Text = template.Description;
			templateTagsTextbox.Text = template.Tags;

			privacyComboBox.SelectedIndex = (int)template.Privacy;
			publishAtCheckbox.Checked = template.ShouldPublishAt;

			defaultLanguageCombobox.Items.Clear();
			defaultLanguageCombobox.Items.AddRange(languageContainer.RegisteredLanguages.Select(lang => lang.Name).ToArray());
			defaultLanguageCombobox.SelectedIndex = languageContainer.RegisteredLanguages.ToList().IndexOf(languageContainer.RegisteredLanguages.FirstOrDefault(lang => lang.Id == template.DefaultLanguage?.Id));

			categoryCombobox.Items.Clear();
			categoryCombobox.Items.AddRange(categoryContainer.RegisteredCategories.Select(cat => cat.Title).ToArray());
			categoryCombobox.SelectedIndex = categoryContainer.RegisteredCategories.ToList().IndexOf(categoryContainer.RegisteredCategories.FirstOrDefault(c => c.Id == template.Category?.Id));

			licenseCombobox.SelectedIndex = (int)template.License;

			isEmbeddableCheckbox.Checked = template.IsEmbeddable;
			publicStatsViewableCheckbox.Checked = template.PublicStatsViewable;
			notifySubscribersCheckbox.Checked = template.NotifySubscribers;
			autoLevelsCheckbox.Checked = template.AutoLevels;
			stabilizeCheckbox.Checked = template.Stabilize;

			thumbnailTextbox.Text = template.ThumbnailPath;

			useExpertmodeCheckbox.Checked = template.EnableExpertMode;
			if (template.EnableExpertMode && !templateValuesTabControl.TabPages.Contains(cSharpTabPage))
			{
				templateValuesTabControl.TabPages.Add(cSharpTabPage);
			}
			else if (!template.EnableExpertMode && templateValuesTabControl.TabPages.Contains(cSharpTabPage))
			{
				templateValuesTabControl.TabPages.Remove(cSharpTabPage);
			}

			cSharpPrepareFctb.Text = template.CSharpPreparationScript;
			cSharpCleanupFctb.Text = template.CSharpCleanUpScript;
			assemblyReferencesFctb.Text = template.ReferencedAssembliesText;

			RefillTimesListView();

			if (template.PublishTimes.Count > 0)
			{
				// Ersten markieren.
				timesListView.SelectedIndices.Clear();
				timesListView.SelectedIndices.Add(0);
			}

			nextPublishTimeDtp.Value = template.NextUploadSuggestion;

			mailRecipientTextbox.Text = template.MailTo;

			newVideoDNCheckbox.Checked = template.NewVideoDesktopNotification;
			newVideoMNCheckbox.Checked = template.NewVideoMailNotification;
			uploadStartedDNCheckbox.Checked = template.UploadStartedDesktopNotification;
			uploadStartedMNCheckbox.Checked = template.UploadStartedMailNotification;
			uploadFinishedDNCheckbox.Checked = template.UploadFinishedDesktopNotification;
			uploadFinishedMNCheckbox.Checked = template.UploadFinishedMailNotification;
			uploadFailedDNCheckbox.Checked = template.UploadFailedDesktopNotification;
			uploadFailedMNCheckbox.Checked = template.UploadFailedMailNotification;

			addToPlaylistCheckbox.Checked = playlistCombobox.Enabled = template.AddToPlaylist;
			var pl = playlistContainer.RegisteredPlaylists.FirstOrDefault(p => p.Id == template.PlaylistId);
			if (pl != null)
			{
				playlistCombobox.SelectedIndex = playlistContainer.RegisteredPlaylists.ToList().IndexOf(pl);
			}
			else if (playlistCombobox.Items.Count > 0)
			{
				playlistCombobox.SelectedIndex = 0;
			}

			skipDirtyManipulation = false;
		}

		private void publishAtCheckboxCheckedChanged(object sender, EventArgs e)
		{
			if (!reordering)
			{
				current.ShouldPublishAt = publishAtCheckbox.Checked;
				enablePublishAtControls();
				IsDirty = true;
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

				IsDirty = true;
			}
		}

		private void AskForSaveIfIsDirty()
		{
			if (IsDirty)
			{
				var result = MessageBox.Show(this, "Das Template wurde bearbeitet. Speichern?", "Das Template wurde bearbeitet, aber nicht abgespeichert. Soll es jetzt gespeichert werden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					templateContainer.UpdateTemplate(current);
					templatePersistor.Save();

					for (int i = 0; i < templateListView.Items.Count; i++)
					{
						var template = templateContainer.RegisteredTemplates.ElementAt(i);
						templateListView.Items[i].Text = !string.IsNullOrWhiteSpace(template.Name) ? template.Name : "<Template ohne Namen>";
					}
				}

				IsDirty = false;
			}
		}

		private void resetTemplateButtonClick(object sender, EventArgs e)
		{
			if (resetTemplateButton.Enabled)
			{
				IsDirty = false;
				templateListViewSelectedIndexChanged(sender, e);
				RefillPlannedVideosListView();
				RefillFillFieldsListView();
			}
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
			IsDirty = true;
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
			if (saveTemplateButton.Enabled && templateListView.SelectedIndices.Count == 1)
			{
				if (ScriptsAreValid())
				{
					reordering = true;
					templateContainer.UpdateTemplate(current);
					templatePersistor.Save();

					IsDirty = false;

					templateListView.Items[templateListView.SelectedIndices[0]].Text
						= !string.IsNullOrWhiteSpace(current.Name) ? current.Name : "<Template ohne Namen>";
					reordering = false;

					templateListViewSelectedIndexChanged(sender, e);
				}
				else
				{
					MessageBox.Show(this, $"Änderungen konnten nicht gespeichert werden.{Environment.NewLine}Bitte überprüfe folgende Felder: {invalidFields.Aggregate((a, b) => $"{a}, {b}")}.{Environment.NewLine}{Environment.NewLine}Darin ist ein Script nicht mit > oder >>> korrekt geschlossen, sodass ein Feld fehlerhaft ist.", "Scripts nicht korrekt abgeschlossen", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private IList<string> invalidFields = new List<string>();

		private bool ScriptsAreValid()
		{
			var titleValid = ExpressionEvaluator.IsValid(current.Title);
			var descriptionValid = ExpressionEvaluator.IsValid(current.Description);
			var tagsValid = ExpressionEvaluator.IsValid(current.Tags);
			var thumbnailPathValid = ExpressionEvaluator.IsValid(current.ThumbnailPath);

			invalidFields.Clear();

			if (!titleValid)
			{
				invalidFields.Add("Titel");
			}

			if (!descriptionValid)
			{
				invalidFields.Add("Beschreibung");
			}

			if (!tagsValid)
			{
				invalidFields.Add("Tags");
			}

			if (!thumbnailPathValid)
			{
				invalidFields.Add("Thumbnailpfad");
			}

			return titleValid && descriptionValid && tagsValid && thumbnailPathValid;
		}

		private void templateNameTextboxTextChanged(object sender, EventArgs e)
		{
			if (!reordering)
			{
				current.Name = templateNameTextbox.Text;
				IsDirty = true;
			}
		}

		private void templateTitleTextboxTextChanged(object sender, EventArgs e)
		{
			maxTitleLengthLabel.Text = $"Länge Titel: {templateTitleTextbox.Text.Length} / {YoutubeVideo.MaxTitleLength} Zeichen";
			if (!reordering && current != null)
			{
				current.Title = templateTitleTextbox.Text;
				IsDirty = true;
			}
		}

		private void templateDescriptionTextboxTextChanged(object sender, EventArgs e)
		{
			maxDescriptionLengthLabel.Text = $"Länge Beschreibung: {templateDescriptionTextbox.Text.Length} / {YoutubeVideo.MaxDescriptionLength} Zeichen";
			if (!reordering && current != null)
			{
				current.Description = templateDescriptionTextbox.Text;
				IsDirty = true;
			}
		}

		private void templateTagsTextboxTextChanged(object sender, EventArgs e)
		{
			maxTagsLengthLabel.Text = $"Länge Tags: {templateTagsTextbox.Text.Length} / {YoutubeVideo.MaxTagsLength} Zeichen";
			if (!reordering && current != null)
			{
				current.Tags = templateTagsTextbox.Text;
				IsDirty = true;
			}
		}

		private void moveTemplateUpButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedIndices.Count == 1)
			{
				var index = templateListView.SelectedIndices[0];

				reordering = true;
				templateContainer.ShiftTemplatePositionsAt(index, index - 1);

				RefillListView();

				templateListView.SelectedIndices.Add((index - 1 >= 0) ? index - 1 : 0);
				templateListView.Select();
				reordering = false;
			}
		}

		private void moveTemplateDownButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedIndices.Count == 1)
			{
				var index = templateListView.SelectedIndices[0];

				reordering = true;
				templateContainer.ShiftTemplatePositionsAt(index, index + 1);

				RefillListView();

				templateListView.SelectedIndices.Add((index + 1 < templateContainer.RegisteredTemplates.Count) ? index + 1 : templateContainer.RegisteredTemplates.Count - 1);
				templateListView.Select();
				reordering = false;
			}
		}

		private void deleteTimeButtonClick(object sender, EventArgs e)
		{
			if (timesListView.SelectedIndices.Count == 0)
			{
				return;
			}

			var timesToRemove = new List<IPublishTime>();
			foreach (int index in timesListView.SelectedIndices)
			{
				timesToRemove.Add(current.PublishTimes[index]);
			}

			foreach (var time in timesToRemove)
			{
				current.PublishTimes.Remove(time);
			}

			RefillTimesListView();
			IsDirty = true;
		}

		private void clearTimesButtonClick(object sender, EventArgs e)
		{
			current.PublishTimes.Clear();
			RefillTimesListView();
			IsDirty = true;
		}

		private void addOneDayButtonClick(object sender, EventArgs e)
		{
			foreach (int index in timesListView.SelectedIndices)
			{
				current.PublishTimes[index].SkipDays++;
			}

			RefillTimesListView();
			IsDirty = true;
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
			IsDirty = true;
			timesListView.Select();
		}

		private void addOneWeekButtonClick(object sender, EventArgs e)
		{
			foreach (int index in timesListView.SelectedIndices)
			{
				current.PublishTimes[index].SkipDays += 7;
			}

			RefillTimesListView();
			IsDirty = true;
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
			IsDirty = true;
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
				IsDirty = true;
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
				IsDirty = true;
			}
		}

		private void categoryComboboxSelectedIndexChanged(object sender, EventArgs e)
		{
			current.Category = categoryContainer.RegisteredCategories.FirstOrDefault(c => c.Title == categoryCombobox.Text);
			IsDirty = true;
		}

		private void defaultLanguageComboboxSelectedIndexChanged(object sender, EventArgs e)
		{
			current.DefaultLanguage = languageContainer.RegisteredLanguages.FirstOrDefault(lang => lang.Name == defaultLanguageCombobox.Text);
			IsDirty = true;
		}

		private void licenseComboboxSelectedIndexChanged(object sender, EventArgs e)
		{
			current.License = (License)licenseCombobox.SelectedIndex;
			IsDirty = true;
		}

		private void isEmbeddableCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.IsEmbeddable = isEmbeddableCheckbox.Checked;
			IsDirty = true;
		}

		private void publicStatsViewableCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.PublicStatsViewable = publicStatsViewableCheckbox.Checked;
			IsDirty = true;
		}

		private void notifySubscribersCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.NotifySubscribers = notifySubscribersCheckbox.Checked;
			IsDirty = true;
		}

		private void autoLevelsCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.AutoLevels = autoLevelsCheckbox.Checked;
			IsDirty = true;
		}

		private void stabilizeCheckboxCheckedChanged(object sender, EventArgs e)
		{
			current.Stabilize = stabilizeCheckbox.Checked;
			IsDirty = true;
		}

		private void duplicateTemplateButtonClick(object sender, EventArgs e)
		{
			if (templateListView.SelectedItems.Count == 0)
			{
				return;
			}

			var index = templateListView.SelectedIndices[0];
			var template = Template.Duplicate(templateContainer.RegisteredTemplates.ElementAt(index));

			template.Name += " (Kopie)";

			templateContainer.RegisterTemplate(template);
			RefillListView();

			templateListView.SelectedIndices.Add(index);
			templateListView.Focus();
		}

		private void thumbnailTextboxTextChanged(object sender, EventArgs e)
		{
			if (current != null)
			{
				current.ThumbnailPath = thumbnailTextbox.Text;
				IsDirty = true;
			}
		}

		private void chooseThumbnailPathButtonClick(object sender, EventArgs e)
		{
			var result = openThumbnailDialog.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				thumbnailTextbox.Text = openThumbnailDialog.FileName;
			}
		}

		private void templateDescriptionTextboxTextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
		{
			if (current != null)
			{
				current.Description = templateDescriptionTextbox.Text;
				IsDirty = true;
			}
		}

		private void cSharpPrepareFctbTextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
		{
			if (current != null)
			{
				current.CSharpPreparationScript = cSharpPrepareFctb.Text;
				IsDirty = true;
			}
		}

		private void cSharpCleanupFctbTextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
		{
			if (current != null)
			{
				current.CSharpCleanUpScript = cSharpCleanupFctb.Text;
				IsDirty = true;
			}
		}

		private void planVideosTabpageEntered(object sender, EventArgs e)
		{
			RefreshFieldNames();
			RefillPlannedVideosListView();
		}

		private void RefreshFieldNames()
		{
			// Refresh der Feldnamen
			var fieldNames = ExpressionEvaluator.GetFieldNames(current);

			foreach (var plannedVid in current.PlannedVideos)
			{
				var fieldsDict = fieldNames.ToDictionary(name => name, name => string.Empty);

				foreach (var name in fieldNames)
				{
					if (plannedVid.Fields.ContainsKey(name))
					{
						fieldsDict[name] = plannedVid.Fields[name];
					}
				}

				plannedVid.Fields = fieldsDict;
			}
		}

		private void RefillPlannedVideosListView()
		{
			filenamesListView.SelectedIndices.Clear();
			filenamesListView.Items.Clear();

			foreach (var plannedVid in current.PlannedVideos)
			{
				ListViewItem item = new ListViewItem(plannedVid.Name);
				item.SubItems.Add(plannedVid.Fields.All(field => !string.IsNullOrEmpty(field.Value)) ? "Ja" : "Nein");

				filenamesListView.Items.Add(item);
			}
		}

		private void RefillFillFieldsListView()
		{
			fillFieldsListView.Items.Clear();
			fieldNameTxbx.Text = string.Empty;
			fieldValueTxbx.Text = string.Empty;
			fieldValueTxbx.Enabled = false;

			if (filenamesListView.SelectedIndices.Count == 1)
			{
				foreach (var field in current.PlannedVideos[filenamesListView.SelectedIndices[0]].Fields)
				{
					ListViewItem item = new ListViewItem(field.Key);
					item.SubItems.Add(field.Value);

					fillFieldsListView.Items.Add(item);
				}
			}
		}

		private void filenamesListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			fillFieldsGroupbox.Enabled = removeFilenameButton.Enabled = filenamesListView.SelectedIndices.Count == 1;

			RefillFillFieldsListView();
		}

		private void addFilenameButtonClick(object sender, EventArgs e)
		{
			AddPlannedVideoForm addForm = new AddPlannedVideoForm();
			var result = addForm.ShowDialog();

			if (result == DialogResult.OK
				&& current.PlannedVideos.All(v => v.Name.ToLower() != addForm.Filename.ToLower())
				&& !string.IsNullOrWhiteSpace(addForm.Filename))
			{
				IPlannedVideo video = new PlannedVideo();
				video.Name = addForm.Filename.ToLower();
				current.PlannedVideos.Add(video);

				RefreshFieldNames();

				RefillPlannedVideosListView();

				filenamesListView.SelectedIndices.Clear();
				filenamesListView.SelectedIndices.Add(filenamesListView.Items.Count - 1);
				IsDirty = true;
			}
		}

		private void fillFieldsListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			fieldValueTxbx.Enabled = fillFieldsListView.SelectedIndices.Count == 1;

			if (fillFieldsListView.SelectedIndices.Count == 1)
			{
				fieldNameTxbx.Text = fillFieldsListView.SelectedItems[0].Text;

				var multiline = ExpressionEvaluator.IsFieldOnlyInDescription(fieldNameTxbx.Text, current);
				fieldValueTxbx.Multiline = multiline;

				if (multiline)
				{
					fieldValueTxbx.Dock = DockStyle.Fill;
				}
				else
				{
					fieldValueTxbx.Dock = DockStyle.None;
					fieldValueTxbx.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
				}

				skipDirtyManipulation = true;

				fieldValueTxbx.Text = current
					.PlannedVideos[filenamesListView.SelectedIndices[0]]
					.Fields[fillFieldsListView.SelectedItems[0].Text];

				skipDirtyManipulation = false;
			}
			else
			{
				fieldNameTxbx.Text = string.Empty;
				fieldValueTxbx.Text = string.Empty;
			}
		}

		private void RefreshFieldValue()
		{
			fillFieldsListView.SelectedItems[0].SubItems[1].Text = fieldValueTxbx.Text;
		}

		private void RefreshFilenamesAllFilled()
		{
			filenamesListView.SelectedItems[0].SubItems[1].Text
				= current.PlannedVideos[filenamesListView.SelectedIndices[0]]
				.Fields
				.All(field => !string.IsNullOrEmpty(field.Value)) ? "Ja" : "Nein";
		}

		private void TemplateFormFormClosing(object sender, FormClosingEventArgs e)
		{
			AskForSaveIfIsDirty();
		}

		private void fieldValueTxbxTextChanged(object sender, EventArgs e)
		{
			if (fillFieldsListView.SelectedIndices.Count == 1)
			{
				current
					.PlannedVideos[filenamesListView.SelectedIndices[0]]
					.Fields[fillFieldsListView.SelectedItems[0].Text]
					= fieldValueTxbx.Text;

				RefreshFieldValue();
				RefreshFilenamesAllFilled();
				IsDirty = true;
			}
		}

		private void removeFilenameButtonClick(object sender, EventArgs e)
		{
			if (filenamesListView.SelectedIndices.Count == 1)
			{
				current.PlannedVideos.RemoveAt(filenamesListView.SelectedIndices[0]);
				IsDirty = true;
				RefillPlannedVideosListView();
				RefillFillFieldsListView();
			}
		}

		private void clearFilenamesButtonClick(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show(this, "Willst du wirklich alle geplanten Videos löschen? Dieser Schritt kann nach dem Speichern nicht mehr rückgängig gemacht werden!", "Bitte bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
				current.PlannedVideos.Clear();
				IsDirty = true;
				RefillPlannedVideosListView();
				RefillFillFieldsListView();
			}
		}

		private void useExpertmodeCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null)
			{
				current.EnableExpertMode = useExpertmodeCheckbox.Checked;
				if (current.EnableExpertMode && !templateValuesTabControl.TabPages.Contains(cSharpTabPage))
				{
					templateValuesTabControl.TabPages.Add(cSharpTabPage);
				}
				else if (!current.EnableExpertMode && templateValuesTabControl.TabPages.Contains(cSharpTabPage))
				{
					templateValuesTabControl.TabPages.Remove(cSharpTabPage);
				}

				IsDirty = true;
			}
		}

		private void assemblyReferencesFctb_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
		{
			if (current != null)
			{
				current.ReferencedAssembliesText = assemblyReferencesFctb.Text;
				IsDirty = true;
			}
		}

		private void mailRecipientTextbox_TextChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.MailTo = mailRecipientTextbox.Text;
				IsDirty = true;
			}
		}

		private void newVideoDNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.NewVideoDesktopNotification = newVideoDNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void newVideoMNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.NewVideoMailNotification = newVideoMNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void uploadStartedDNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.UploadStartedDesktopNotification = uploadStartedDNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void uploadStartedMNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.UploadStartedMailNotification = uploadStartedMNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void uploadFinishedDNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.UploadFinishedDesktopNotification = uploadFinishedDNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void uploadFinishedMNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.UploadFinishedMailNotification = uploadFinishedMNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void uploadFailedDNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.UploadFailedDesktopNotification = uploadFailedDNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void uploadFailedMNCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.UploadFailedMailNotification = uploadFailedMNCheckbox.Checked;
				IsDirty = true;
			}
		}

		private void nextPublishTimeDtp_ValueChanged(object sender, EventArgs e)
		{
			if (current != null && !skipDirtyManipulation)
			{
				current.NextUploadSuggestion = nextPublishTimeDtp.Value;
				IsDirty = true;
			}
		}

		private void addToPlaylistCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			current.AddToPlaylist = playlistCombobox.Enabled = addToPlaylistCheckbox.Checked;
			IsDirty = true;
		}

		private void playlistCombobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			current.PlaylistId = playlistContainer.RegisteredPlaylists.ElementAt(playlistCombobox.SelectedIndex).Id;
			IsDirty = true;
		}
	}
}
