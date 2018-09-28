using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Templates;

namespace STFU.AutoUploader
{
	public partial class ChooseStartTimesForm : Form
	{
		IPathContainer pathContainer;
		ITemplateContainer templateContainer;
		private IList<IObservationConfiguration> publishSettings = new List<IObservationConfiguration>();

		public ChooseStartTimesForm(IPathContainer pathContainer, ITemplateContainer templateContainer)
		{
			InitializeComponent();

			this.pathContainer = pathContainer;
			this.templateContainer = templateContainer;

			foreach (var path in pathContainer.ActivePaths)
			{
				publishSettings.Add(new ObservationConfiguration(path, templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == path.SelectedTemplateId)));
			}

			chooseCustomTimesControl.AddRange(publishSettings);

			globalSettingsControl.SetPublishControlsVisibility(publishSettings.Any(i => i.Template.ShouldPublishAt), false);
		}

		public IObservationConfiguration[] GetPublishSettingsArray()
		{
			chooseCustomTimesControl.GetPublishSettingsArray();

			var shouldIgnore = globalSettingsControl.ShouldIgnore;
			var shouldUploadPrivate = globalSettingsControl.ShouldUploadPrivate;

			DateTime firstPublishTime = default(DateTime);
			if (globalSettingsControl.ShouldPublishAt)
			{
				firstPublishTime = globalSettingsControl.PublishAt;
			}

			foreach (var setting in publishSettings)
			{
				if (!setting.IgnorePath && !setting.UploadPrivate && setting.StartDate == default(DateTime))
				{
					setting.IgnorePath = shouldIgnore;
					setting.UploadPrivate = shouldUploadPrivate;
					setting.StartDate = firstPublishTime;
				}
			}

			return publishSettings.ToArray();
		}
	}
}
