using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STFU.Executable.StandardUploader.Controls.Queue
{
	public partial class JobControl : UserControl
	{
		public JobControl()
		{
			InitializeComponent();
		}

		private void actionsButton_Click(object sender, EventArgs e)
		{
			actionsContextMenuStrip.Show(actionsButton, 0, 0);
		}
	}
}
