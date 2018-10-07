using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace STFU.Executable.Updater
{
	public partial class UpdateForm : Form
	{
		private string zipFile;
		private string executableFile;

		private Updater updater = new Updater();

		public UpdateForm(string zipFile, string executableFile)
		{
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

			while (procs.Any(p => !p.HasExited))
			{
				Thread.Sleep(100);
			}

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

				if (File.Exists(executableFile))
				{
					Process.Start(executableFile, "showReleaseNotes");
				}

				Close();
			}
		}
	}
}
