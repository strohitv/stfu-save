using System;
using System.Linq;
using System.Windows.Forms;
using STFU.UploadLib.Automation;
using STFU.UploadLib.Templates;

namespace STFU.AutoUploader
{
	public partial class ChooseStartTimesForm : Form
	{
		AutomationUploader uploader;
		private PublishSettings[] publishSettings;

		public ChooseStartTimesForm(AutomationUploader upl)
		{
			InitializeComponent();

			uploader = upl;

			publishSettings = uploader.GetPublishInformation();
			chooseCustomTimesControl.AddRange(publishSettings);

			globalSettingsControl.SetPublishControlsVisibility(publishSettings.Any(i => i.Template.ShouldPublishAt), false);
		}

		public PublishSettings[] GetPublishSettingsArray()
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

			return publishSettings;
		}
	}
}
