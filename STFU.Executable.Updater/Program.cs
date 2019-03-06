using System;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;

namespace STFU.Executable.Updater
{
	static class Program
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.FirstChanceException += LogException;

			ClearOldExceptionFiles();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UpdateForm(args[0], args[1]));
		}

		private static void ClearOldExceptionFiles()
		{
			if (Directory.Exists(@"errors\updater"))
			{
				var maxTime = new TimeSpan(14, 0, 0, 0);
				foreach (var file in Directory.EnumerateFiles(@"errors\updater"))
				{
					if (DateTime.Now - new FileInfo(file).CreationTime > maxTime)
					{
						File.Delete(file);
					}
				}
			}
		}

		private static void LogException(object sender, FirstChanceExceptionEventArgs e)
		{
			if (!Directory.Exists("errors"))
			{
				Directory.CreateDirectory("errors");
			}

			if (!Directory.Exists(@"errors\updater"))
			{
				Directory.CreateDirectory(@"errors\updater");
			}

			var filename = @"errors\updater\" + Application.ProductVersion + " - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".log";

			using (StreamWriter writer = new StreamWriter(filename, true))
			{
				WriteException(writer, e.Exception, string.Empty);

				writer.WriteLine();
				writer.WriteLine("Ende der Exception.");
				writer.WriteLine();
				writer.WriteLine();
				writer.WriteLine();
			}
		}

		private static void WriteException(StreamWriter writer, Exception ex, string prefix)
		{
			writer.WriteLine(prefix + "Typ der Exception: " + ex.GetType().Name);
			writer.WriteLine(prefix + "Message: " + ex.Message);

			if (ex.Data != null)
			{
				writer.WriteLine(prefix + "Data: " + ex.Data);
			}

			if (ex.Source != null)
			{
				writer.WriteLine(prefix + "Source: " + ex.Source);
			}

			if (ex.TargetSite != null)
			{
				writer.WriteLine(prefix + "TargetSite: " + ex.TargetSite);
			}

			if (ex.StackTrace != null)
			{
				writer.WriteLine(
					prefix + "Stacktrace: " + Environment.NewLine +
					ex.StackTrace
						.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
						.Aggregate((a, b) => $"\t{prefix}{a}{Environment.NewLine}\t{prefix}{b}")
				);
			}

			writer.WriteLine(
				prefix + "Exception als ToString(): " + Environment.NewLine +
				ex.ToString()
					.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
					.Aggregate((a, b) => $"\t{prefix}{a}{Environment.NewLine}\t{prefix}{b}")
			);

			writer.WriteLine();

			if (ex.InnerException != null)
			{
				WriteException(writer, ex.InnerException, "\t" + prefix);
			}
		}
	}
}
