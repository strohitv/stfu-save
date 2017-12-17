using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STFU.UploadLib.Automation;
using STFU.UploadLib.Templates;

namespace STFU.AutoUploader
{
	public partial class TemplateForm : Form
	{
		private AutomationUploader uploader;
		private Template current;

		public TemplateForm(AutomationUploader upl)
		{
			InitializeComponent();

			uploader = upl;
		}

		private void addPathButtonClick(object sender, EventArgs e)
		{
			Template templ = new Template();
			uploader.Templates.Add(templ);

			RefillListView();
		}

		private void RefillListView()
		{
			templateListView.Items.Clear();

			foreach (var template in uploader.Templates)
			{
				templateListView.Items.Add(template.Name);
			}
		}

		private void templateListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			editTableLayoutPanel.Enabled = templateListView.SelectedItems.Count > 0;
		}

		private void splitContainerPaint(object sender, PaintEventArgs e)
		{
			var control = sender as SplitContainer;
			//paint the three dots'
			Point[] points = new Point[3];
			var w = control.Width;
			var h = control.Height;
			var d = control.SplitterDistance;
			var sW = control.SplitterWidth;

			//calculate the position of the points'
			if (control.Orientation == Orientation.Horizontal)
			{
				points[0] = new Point((w / 2), d + (sW / 2));
				points[1] = new Point(points[0].X - 10, points[0].Y);
				points[2] = new Point(points[0].X + 10, points[0].Y);
			}
			else
			{
				points[0] = new Point(d + (sW / 2), (h / 2));
				points[1] = new Point(points[0].X, points[0].Y - 10);
				points[2] = new Point(points[0].X, points[0].Y + 10);
			}

			foreach (Point p in points)
			{
				p.Offset(-2, -2);
				e.Graphics.FillEllipse(SystemBrushes.ControlDark,
					new Rectangle(p, new Size(7, 7)));

				p.Offset(1, 1);
				e.Graphics.FillEllipse(SystemBrushes.ControlLight,
					new Rectangle(p, new Size(7, 7)));
			}
		}

		private void TemplateFormLoad(object sender, EventArgs e)
		{
			privacyCombobox.SelectedIndex = 2;
		}

		private void shouldPublishAtCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			publishAtGroupBox.Enabled = shouldPublishAtCheckBox.Checked;
		}

		private void publishingTimesListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			saveTimeButton.Enabled = newTimePicker.Enabled = publishingTimesListView.SelectedItems.Count == 0;
		}

		private void addTimeButtonClick(object sender, EventArgs e)
		{

		}
	}
}
