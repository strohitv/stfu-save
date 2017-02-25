using System;
using System.Windows.Forms;

namespace STFU.AutoUploader
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				////For Windows 7 and above, best to include relevant app.manifest entries as well
				//Cef.EnableHighDPISupport();

				////We're going to manually call Cef.Shutdown below, this maybe required in some complex scenarious
				//CefSharpSettings.ShutdownOnExit = false;

				//var settings = new CefSettings();
				//settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";

				////Perform dependency check to make sure all relevant resources are in our output directory.
				//Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());

			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				////Shutdown before your application exists or it will hang.
				//Cef.Shutdown();
			}
		}
	}
}
