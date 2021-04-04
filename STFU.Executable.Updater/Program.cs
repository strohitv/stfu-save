using System;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using log4net;

namespace STFU.Executable.Updater
{
	static class Program
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(Program));

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			LOGGER.Info("Updater was started");
			AppDomain.CurrentDomain.FirstChanceException += LogException;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UpdateForm(args[0], args[1]));

			LOGGER.Info("Updater stopped");
		}

		private static void LogException(object sender, FirstChanceExceptionEventArgs e)
		{
			LOGGER.Error("An unexpected Exception occured.", e.Exception);
		}
	}
}
