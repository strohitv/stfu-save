using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace STFU.AutoUploader
{
	public partial class Browser : Form
	{
		private string Url { get; set; }
		public string AuthToken { get; private set; }

		public Browser(string url)
		{
			InitializeComponent();

			Url = url;
		}

		private void BrowserLoad(object sender, EventArgs e)
		{
			var browser = new ChromiumWebBrowser(Url)
			{
				Dock = DockStyle.Fill
			};

			browserPanel.Controls.Add(browser);

			browser.AddressChanged += BrowserAddressChanged;
		}

		private delegate void closeDelegate();
		private void BrowserAddressChanged(object sender, AddressChangedEventArgs e)
		{
			if (e.Address.StartsWith("http://localhost"))
			{
				AuthToken = new Uri(e.Address).Query.Remove(0, 6);
				closeDelegate del = Close;
				Invoke(del);
				return;
			}
		}

		private void BrowserFormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult = DialogResult.Abort;

			if (!string.IsNullOrWhiteSpace(AuthToken))
			{
				DialogResult = DialogResult.OK;
			}
		}
	}
}
