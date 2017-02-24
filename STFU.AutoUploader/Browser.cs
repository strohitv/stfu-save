using System;
using System.Text;
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
			GeckoPreferences.User["browser.xul.error_pages.enabled"] = false;
			GeckoPreferences.User["browser.download.manager.showAlertOnComplete"] = false;
			GeckoPreferences.User["security.warn_viewing_mixed"] = false;
			GeckoPreferences.User["privacy.popups.showBrowserMessage"] = false;

			browserPanel.Visible = false;

			browser = new GeckoWebBrowser() { Dock = DockStyle.Fill };
			browser.NoDefaultContextMenu = true;
			browser.ReadyStateChange += Browser_ReadyStateChange;
			browser.DomSubmit += Browser_DomSubmit;
			browser.DomCompositionStart += Browser_DomCompositionStart;
			browser.DomContentChanged += Browser_DomContentChanged;
			browser.DOMContentLoaded += Browser_DOMContentLoaded;
			browser.Load += Browser_Load;
			browser.RequestProgressChanged += Browser_RequestProgressChanged;
			browser.StatusTextChanged += Browser_StatusTextChanged;
			browser.ConsoleMessage += Browser_ConsoleMessage;

			Controls.Add(browser);

			browser.Navigate(Url);
		}
		StringBuilder builder = new StringBuilder();

		private void Browser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
		{
			var test4 = browser.Document.Head.GetAttributeNode("Location");
			string test = browser.Url.AbsoluteUri;
			string test2 = browser.ReferrerUrl.AbsoluteUri;
			string test3 = browser.Document.Uri;
			builder.Append(e.Message + Environment.NewLine);
		}

		private void Browser_StatusTextChanged(object sender, EventArgs e)
		{
			var test4 = browser.Document.Head.GetAttributeNode("Location");
			string test = browser.Url.AbsoluteUri;
			string test2 = browser.ReferrerUrl.AbsoluteUri;
			string test3 = browser.Document.Uri;
		}

		private void Browser_RequestProgressChanged(object sender, GeckoRequestProgressEventArgs e)
		{
			var test4 = browser.Document.Head.GetAttributeNode("Location");
			string test = browser.Url.AbsoluteUri;
			string test2 = browser.ReferrerUrl.AbsoluteUri;
			string test3 = browser.Document.Uri;
		}

		private void Browser_Load(object sender, DomEventArgs e)
		{
			var test4 = browser.Document.Head.GetAttributeNode("Location");
			string test = browser.Url.AbsoluteUri;
			string test2 = browser.ReferrerUrl.AbsoluteUri;
			string test3 = browser.Document.Uri;
		}

		private void Browser_DOMContentLoaded(object sender, DomEventArgs e)
		{
			string test = browser.Url.AbsoluteUri;
			string test2 = browser.ReferrerUrl.AbsoluteUri;
			string test3 = browser.Document.Uri;
		}

		private void Browser_DomContentChanged(object sender, DomEventArgs e)
		{
			string test = browser.Url.AbsoluteUri;
			string test2 = browser.ReferrerUrl.AbsoluteUri;
			string test3 = browser.Document.Uri;
		}

		private void Browser_DomCompositionStart(object sender, DomEventArgs e)
		{
			string test = browser.Url.AbsoluteUri;
			string test2 = browser.ReferrerUrl.AbsoluteUri;
			string test3 = browser.Document.Uri;
		}

		private void Browser_DomSubmit(object sender, DomEventArgs e)
		{
			Console.WriteLine(e.Type);
		}

		private void Browser_ReadyStateChange(object sender, DomEventArgs e)
		{
			string test = browser.ReferrerUrl.AbsoluteUri;
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
