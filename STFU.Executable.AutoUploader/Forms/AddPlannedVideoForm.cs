using System;
using System.Windows.Forms;
using log4net;

namespace STFU.Executable.AutoUploader.Forms
{
	public partial class AddPlannedVideoForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(AddPlannedVideoForm));

		public string Filename { get; private set; }

		public AddPlannedVideoForm()
		{
			LOGGER.Info($"Initializing new instance of AddPlannedVideoForm");

			InitializeComponent();
			DialogResult = DialogResult.Cancel;
		}

		private void saveButtonClick(object sender, EventArgs e)
		{
			Filename = filenameBox.Text;
			DialogResult = DialogResult.OK;

			LOGGER.Info($"User chose to add the following planned video: '{Filename}'");

			Close();
		}

		private void cancelButtonClick(object sender, EventArgs e)
		{
			LOGGER.Info($"User chose to cancel AddPlannedVideoForm");

			Close();
		}
	}
}
