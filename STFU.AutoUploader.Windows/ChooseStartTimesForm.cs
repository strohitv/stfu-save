using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using STFU.UploadLib.Automation;
using STFU.UploadLib.Templates;

namespace STFU.AutoUploader
{
	public partial class ChooseStartTimesForm : Form
	{
		AutomationUploader uploader;
		private PublishInformation[] publishInformation;

		public ChooseStartTimesForm(AutomationUploader upl)
		{
			InitializeComponent();

			uploader = upl;

			publishInformation = uploader.GetPublishInformation();
			chooseCustomTimesControl.AddRange(publishInformation);

			globalSettingsControl.SetPublishControlsVisibility(publishInformation.Any(i => i.Template.ShouldPublishAt), false);
		}

		public PublishInformation[] GetPublishInformation()
		{
			chooseCustomTimesControl.GetPublishInformation();

			var shouldIgnore = globalSettingsControl.ShouldIgnore;
			var shouldUploadPrivate = globalSettingsControl.ShouldUploadPrivate;

			DateTime? firstPublishTime = null;
			if (globalSettingsControl.ShouldPublishAt)
			{
				firstPublishTime = globalSettingsControl.PublishAt;
			}

			foreach (var info in publishInformation)
			{
				if (!info.IgnorePath && !info.UploadPrivate && info.StartDate == null)
				{
					info.IgnorePath = shouldIgnore;
					info.UploadPrivate = shouldUploadPrivate;
					info.StartDate = firstPublishTime;
				}
			}

			return publishInformation;
		}
	}
}
