using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace STFU.AutoUploader
{
	public partial class ProcessWindow : Form
	{
		public Process[] SelectedProcesses { get; private set; }
		private Process[] AllProcesses { get; set; }

		public ProcessWindow()
		{
			InitializeComponent();
		}

		private void ProcessWindowLoad(object sender, EventArgs e)
		{
			RefreshAllProcs();
		}

		private void RefreshAllProcs()
		{
			lbAllProcs.Items.Clear();

			AllProcesses = Process.GetProcesses().OrderBy(item => item.ProcessName).ToArray();

			foreach (var item in AllProcesses)
			{
				lbAllProcs.Items.Add(item.ProcessName);
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshAllProcs();
		}
	}
}
