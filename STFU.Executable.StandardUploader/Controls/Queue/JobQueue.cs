using System;
using System.Windows.Forms;

namespace STFU.Executable.StandardUploader.Controls.Queue
{
	public partial class JobQueue : UserControl
	{
		public JobQueue()
		{
			InitializeComponent();
		}

		private void JobQueue_Load(object sender, EventArgs e)
		{
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
			AddItems(new JobControl());
		}

		private void itemsPanel_ControlAdded(object sender, ControlEventArgs e)
		{
		}

		private void AddItems(JobControl control)
		{
			control.Margin = new Padding(0, 0, 0, 0);
			control.Anchor = AnchorStyles.Left | AnchorStyles.Right;

			mainTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
			mainTlp.RowCount++;
			mainTlp.RowStyles[mainTlp.RowCount - 2].SizeType = SizeType.AutoSize;
			mainTlp.RowStyles[mainTlp.RowCount - 2].Height = 0;
			mainTlp.Controls.Add(control, 0, mainTlp.RowCount - 2);
		}
	}
}
