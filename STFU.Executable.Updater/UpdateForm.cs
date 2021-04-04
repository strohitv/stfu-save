using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using log4net;

namespace STFU.Executable.Updater
{
	public partial class UpdateForm : Form
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(UpdateForm));

		private string zipFile;
		private string executableFile;

		private Updater updater = new Updater();

		public UpdateForm(string zipFile, string executableFile)
		{
			LOGGER.Info("Initializing update form");

			InitializeComponent();

			this.zipFile = zipFile;
			this.executableFile = executableFile;

			installUpdateBgw.RunWorkerAsync();
		}

		private void refreshStatusTextTimerTick(object sender, EventArgs e)
		{
			statusLabel.Text = updater.Message;
		}

		private void installUpdateBgwDoWork(object sender, DoWorkEventArgs e)
		{
			var procs = Process.GetProcesses().Where(p => ProcessBlocksExe(p)).ToArray();

			LOGGER.Info("Waiting for blocking processes to exit");

			while (procs.Any(p => !p.HasExited))
			{
				Thread.Sleep(100);
			}

			LOGGER.Info("All processes exited -> extracting zip");

			updater.ExtractUpdate(zipFile);
		}

		private bool ProcessBlocksExe(Process p)
		{
			var result = false;

			try
			{
				string fullPath = p.MainModule.FileName;
				if (Path.GetFullPath(fullPath).ToLower() == Path.GetFullPath(executableFile).ToLower())
				{
					LOGGER.Info($"Found blocking process '{p.ProcessName}'");

					result = true;
				}
			}
			catch (Exception)
			{}

			return result;
		}

		private void installUpdateBgwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (updater.Successfull)
			{
				refreshStatusTextTimer.Enabled = false;

				LOGGER.Info("Updater finished sucessfully");

				if (File.Exists(executableFile))
				{
					LOGGER.Info($"Starting executable '{executableFile}'");

					Process.Start(executableFile, "showReleaseNotes");
				}

				LOGGER.Info("Closing the form");
				Close();
			}
			else
			{
				LOGGER.Info("Updater did not finish sucessfully!");
			}
		}
	}
}
