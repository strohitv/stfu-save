using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using STFU.Executable.AutoUploader.Forms;

namespace STFU.Executable.AutoUploader
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			ServicePointManager.DefaultConnectionLimit = int.MaxValue;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(args.Any(arg => arg.ToLower() == "showreleasenotes")));
		}
	}
}
