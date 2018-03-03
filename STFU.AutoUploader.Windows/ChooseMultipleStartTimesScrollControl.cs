using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using STFU.UploadLib.Templates;

namespace STFU.AutoUploader
{
	public partial class ChooseMultipleStartTimesScrollControl : UserControl
	{
		private IList<PublishInformation> information = new List<PublishInformation>();

		public ChooseMultipleStartTimesScrollControl()
		{
			InitializeComponent();
		}

		public void AddRange(IEnumerable<PublishInformation> info)
		{
			foreach (var item in info)
			{
				information.Add(item);
			}
		}

		internal IList<PublishInformation> GetPublishInformation()
		{
			foreach (ChooseSingleStartTimeControl control in mainTlp.Controls)
			{
				control.GetPublishInformation();
			}

			return information.ToList();
		}

		private void ChooseMultipleStartTimesScrollControlLoad(object sender, EventArgs e)
		{
			for (int i = 0; i < information.Count; i++)
			{
				var control = new ChooseSingleStartTimeControl(information[i]);
				control.Margin = new Padding(0, 0, 0, 10);
				control.Anchor = AnchorStyles.Left | AnchorStyles.Right;

				mainTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
				mainTlp.RowCount++;
				mainTlp.RowStyles[mainTlp.RowCount - 2].SizeType = SizeType.AutoSize;
				mainTlp.RowStyles[mainTlp.RowCount - 2].Height = 0;
				mainTlp.Controls.Add(control, 0, mainTlp.RowCount - 2);
			}
		}
	}
}
