using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using log4net;
using STFU.Executable.AutoUploader.Forms;

namespace STFU.Executable.AutoUploader
{
	public static class Program
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(Program));

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			LOGGER.Info("Application was started");
			AppDomain.CurrentDomain.FirstChanceException += LogException;

			ClearOldExceptionFiles();

			ServicePointManager.DefaultConnectionLimit = int.MaxValue;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(args.Any(arg => arg.ToLower() == "showreleasenotes")));
		}

		private static void ClearOldExceptionFiles()
		{
			if (Directory.Exists("errors"))
			{
				LOGGER.Info($"Clearing old exception logs");
				var subdirectories = Directory.EnumerateDirectories("errors");
				foreach (var subdir in subdirectories)
				{
					LOGGER.Debug($"Clearing old exception logs in folder '{subdir}'");
					var maxTime = new TimeSpan(14, 0, 0, 0);
					foreach (var file in Directory.EnumerateFiles(subdir))
					{
						if (DateTime.Now - new FileInfo(file).CreationTime > maxTime)
						{
							LOGGER.Debug($"Deleting file '{file}'");
							File.Delete(file);
						}
					}
				}

				if (new DirectoryInfo("errors").EnumerateFiles("*", SearchOption.AllDirectories).ToArray().Length == 0)
				{
					LOGGER.Info($"Deleting old errors folder once and for all");

					try
					{
						Directory.Delete("errors", true);
					}
					catch (Exception ex)
					{
						LOGGER.Error($"Errors folder could not be deleted because of an exception occured", ex);
					}
				}
			}
		}

		private static void LogException(object sender, FirstChanceExceptionEventArgs e)
		{
			if (!IsIncompleteResume(e)
				&& !IsCoreLibException(e)
				&& !IsCancelException(e))
			{
				LOGGER.Error("An unexpected Exception occured.", e.Exception);
			}
		}

		private static bool IsCancelException(FirstChanceExceptionEventArgs e)
		{
			return (e.Exception is IOException && ((IOException)e.Exception).HResult == -2146232800)
				|| (e.Exception is WebException && ((WebException)e.Exception).Status == WebExceptionStatus.RequestCanceled);
		}

		private static bool IsCoreLibException(FirstChanceExceptionEventArgs e)
		{
			return e.Exception.Source == "mscorlib";
		}

		private static bool IsIncompleteResume(FirstChanceExceptionEventArgs e)
		{
			return e.Exception is WebException
					&& ((WebException)e.Exception).Status == WebExceptionStatus.ProtocolError
					&& (int)(((WebException)e.Exception).Response as HttpWebResponse).StatusCode == 308;
		}
	}
}
