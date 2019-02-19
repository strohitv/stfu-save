using System;
using System.Windows.Forms;
using STFU.Lib.Youtube.Interfaces;

namespace STFU.Executable.StandardUploader.Controls.Queue
{
	public partial class JobQueue : UserControl
	{
		private IYoutubeUploader uploader = null;
		public IYoutubeUploader Uploader
		{
			get
			{
				return uploader;
			}
			set
			{
				if (uploader != value)
				{
					uploader = value;

					ClearItems();

					foreach (var entry in uploader.Queue)
					{
						AddItem(new JobControl() { Job = entry });
					}
				}
			}
		}

		public JobQueue()
		{
			InitializeComponent();
		}

		private void JobQueue_Load(object sender, EventArgs e)
		{

		}

		private void AddItem(JobControl control)
		{
			control.Margin = new Padding(0, 0, 0, 0);
			control.Anchor = AnchorStyles.Left | AnchorStyles.Right;

			mainTlp.RowStyles.Insert(mainTlp.RowCount - 1, new RowStyle(SizeType.AutoSize));
			mainTlp.Controls.Add(control, 0, mainTlp.RowCount - 2);
		}

		private void ClearItems()
		{
			while (mainTlp.RowStyles.Count > 1)
			{
				mainTlp.RowStyles.RemoveAt(0);
			}
		}
	}
}
