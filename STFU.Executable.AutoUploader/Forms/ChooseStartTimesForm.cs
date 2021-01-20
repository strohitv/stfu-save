using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Templates;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class ChooseStartTimesForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(ChooseStartTimesForm));

		IPathContainer pathContainer;
		ITemplateContainer templateContainer;
		private IList<IObservationConfiguration> publishSettings = new List<IObservationConfiguration>();

		public ChooseStartTimesForm(IPathContainer pathContainer, ITemplateContainer templateContainer)
		{
			LOGGER.Info($"Initializing new instance of ChooseStartTimesForm");

			InitializeComponent();

			this.pathContainer = pathContainer;
			this.templateContainer = templateContainer;

			foreach (var path in pathContainer.ActivePaths)
			{
				LOGGER.Info($"Adding active path '{path}'");

				publishSettings.Add(new ObservationConfiguration(path, templateContainer.RegisteredTemplates.FirstOrDefault(t => t.Id == path.SelectedTemplateId)));
			}

			chooseCustomTimesControl.AddRange(publishSettings);

			LOGGER.Debug($"Should publish controls be visible: {publishSettings.Any(i => i.Template.ShouldPublishAt)}");
			globalSettingsControl.SetPublishControlsVisibility(publishSettings.Any(i => i.Template.ShouldPublishAt), false);
		}

		public IObservationConfiguration[] GetPublishSettingsArray()
		{
			LOGGER.Info($"Returning publish settings array");

			chooseCustomTimesControl.GetPublishSettingsArray();

			var shouldIgnore = globalSettingsControl.ShouldIgnore;
			var shouldUploadPrivate = globalSettingsControl.ShouldUploadPrivate;

			LOGGER.Info($"Should ignore paths with no specific settings: {shouldIgnore}");
			LOGGER.Info($"Should upload videos private in path with no specific settings: {shouldUploadPrivate}");

			DateTime firstPublishTime = default(DateTime);
			if (globalSettingsControl.ShouldPublishAt)
			{
				firstPublishTime = globalSettingsControl.PublishAt;
				LOGGER.Info($"Paths with no specific settings and publish options in template should be published from the following date on: {firstPublishTime}");
			}

			foreach (var setting in publishSettings)
			{
				if (!setting.IgnorePath && !setting.UploadPrivate && setting.StartDate == default(DateTime))
				{
					setting.IgnorePath = shouldIgnore;
					setting.UploadPrivate = shouldUploadPrivate;
					setting.StartDate = firstPublishTime;

					LOGGER.Info($"Setting specific settings for path: '{setting.PathInfo.Fullname}'");
					LOGGER.Info($"Should ignore this path: {setting.IgnorePath}");
					LOGGER.Info($"Should upload videos private for this path: {setting.UploadPrivate}");
					LOGGER.Info($"Should videos be published from the following date on for this path: {setting.StartDate}");
				}
				else
				{
					LOGGER.Info($"No specific settings were made for path: '{setting.PathInfo.Fullname}'");
				}
			}

			return publishSettings.ToArray();
		}
	}
}
