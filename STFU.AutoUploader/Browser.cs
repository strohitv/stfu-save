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

			nsICookieManager CookieMan;
			CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
			CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
			CookieMan.RemoveAll();

			GeckoPreferences.User["browser.xul.error_pages.enabled"] = false;
			GeckoPreferences.User["browser.download.manager.showAlertOnComplete"] = false;
			GeckoPreferences.User["security.warn_viewing_mixed"] = false;
			GeckoPreferences.User["privacy.popups.showBrowserMessage"] = false;
			GeckoPreferences.User["browser.xul.error_pages.enabled"] = true;

			browserPanel.Visible = false;

			browser = new GeckoWebBrowser() { Dock = DockStyle.Fill };
			browser.NoDefaultContextMenu = true;
			browser.Navigated += BrowserNavigated;

			Controls.Add(browser);

			browser.Navigate(Url);
		}

		private void BrowserNavigated(object sender, GeckoNavigatedEventArgs e)
		{
			if (e.Uri.AbsoluteUri.StartsWith("http://localhost"))
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
