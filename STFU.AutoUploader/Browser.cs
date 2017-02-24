using System;
using System.Windows.Forms;
using Gecko;

namespace STFU.AutoUploader
{
	public partial class Browser : Form
	{
		private string Url { get; set; }
		public string AuthToken { get; private set; }

		GeckoWebBrowser browser;
		private delegate void closeDelegate();

		public Browser(string url)
		{
			InitializeComponent();

			Url = url;
		}

		private void BrowserLoad(object sender, EventArgs e)
		{
			Xpcom.Initialize("Firefox");
			//nsICookieManager CookieMan;
			//CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
			//CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
			//CookieMan.RemoveAll();

			browserPanel.Visible = false;

			browser = new GeckoWebBrowser() { Dock = DockStyle.Fill };
			browser.NoDefaultContextMenu = true;
			browser.ReadyStateChange += Browser_ReadyStateChange;
			browser.DomSubmit += Browser_DomSubmit;
			browser.Redirecting += Browser_Redirecting;

			Controls.Add(browser);

			browser.Navigate(Url);
		}

		private void Browser_Redirecting(object sender, GeckoRedirectingEventArgs e)
		{
			Console.WriteLine(e);
		}

		private void Browser_DomSubmit(object sender, DomEventArgs e)
		{
			Console.WriteLine(e.Type);
		}

		private void Browser_ReadyStateChange(object sender, DomEventArgs e)
		{
			if (browser.Url.AbsoluteUri.StartsWith("http://localhost"))
			{
				AuthToken = new Uri(browser.Url.AbsoluteUri).Query.Remove(0, 6);
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
