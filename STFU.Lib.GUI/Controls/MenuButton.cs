using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace STFU.Lib.GUI.Controls
{
	public class MenuButton : Button
	{
		[DefaultValue(null)]
		public ContextMenuStrip Menu { get; set; }

		[DefaultValue(false)]
		public bool ShowMenuUnderCursor { get; set; }

		private int BorderX => ClientRectangle.Width - 18;

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			if (mevent.X >= BorderX && Menu != null && mevent.Button == MouseButtons.Left)
			{
				Point menuLocation;

				if (ShowMenuUnderCursor)
				{
					menuLocation = mevent.Location;
				}
				else
				{
					menuLocation = new Point(0, Height);
				}

				if (Menu.Visible)
				{
					Menu.Hide();
				}
				else
				{
					Menu.Show(this, menuLocation);
				}
			}
			else
			{
				base.OnMouseDown(mevent);
			}
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);

			if (Menu != null)
			{
				int arrowX = ClientRectangle.Width - 14;
				int arrowY = ClientRectangle.Height / 2 - 1;

				Brush brush = Enabled ? SystemBrushes.ControlText : SystemBrushes.ControlDark;
				Point[] arrows = new Point[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
				pevent.Graphics.FillPolygon(brush, arrows);
				
				int offsetY = 6;
				pevent.Graphics.DrawLine(new Pen(SystemColors.ControlDark, 1), new Point(BorderX, offsetY), new Point(BorderX, ClientRectangle.Height - offsetY));
			}
		}
	}
}
