using System;
using System.IO;

namespace STFU.Lib.Common
{
	public static class ErrorLogger
	{
		public static void LogError(string folder, string text)
		{
			EnsureDirectoriesExist(folder);

			using (StreamWriter writer = new StreamWriter($@"errors\{folder}\{ DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
			{
				writer.WriteLine($"Fehler aufgetreten. Zeitpunkt: {DateTime.Now.ToString()}");
				writer.WriteLine(text);
				writer.WriteLine();
				writer.WriteLine("=======================");
				writer.WriteLine();
				writer.WriteLine();
			}
		}

		public static void LogException(Exception ex, string folder, string additionalText)
		{
			EnsureDirectoriesExist(folder);

			using (StreamWriter writer = new StreamWriter($@"errors\{folder}\{ DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
			{
				writer.WriteLine($"Exception aufgetreten. Zeitpunkt: {DateTime.Now.ToString()}");
				writer.WriteLine();
				WriteException(ex, writer, additionalText);

				writer.WriteLine();
				writer.WriteLine("=======================");
				writer.WriteLine();
				writer.WriteLine();
			}
		}

		private static void EnsureDirectoriesExist(string folder)
		{
			if (!Directory.Exists("errors"))
			{
				Directory.CreateDirectory("errors");
			}

			if (!Directory.Exists($@"errors\{folder}"))
			{
				Directory.CreateDirectory($@"errors\{folder}");
			}
		}

		// Programming
		public static void LogException(Exception ex, string additionalText)
		{
			if (!Directory.Exists("errors"))
			{
				Directory.CreateDirectory("errors");
			}

			if (!Directory.Exists(@"errors\csharp"))
			{
				Directory.CreateDirectory(@"errors\csharp");
			}

			using (StreamWriter writer = new StreamWriter($@"errors\csharp\{DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
			{
				writer.WriteLine($"Exception aufgetreten. Zeitpunkt: {DateTime.Now.ToString()}");
				writer.WriteLine();
				WriteException(ex, writer, additionalText);

				writer.WriteLine();
				writer.WriteLine("=======================");
				writer.WriteLine();
				writer.WriteLine();
			}
		}

		private static void WriteException(Exception ex, StreamWriter writer, string additionalText)
		{
			WriteException(ex, writer, additionalText, "");
		}

		private static void WriteException(Exception ex, StreamWriter writer, string additionalText, string prefix)
		{
			writer.WriteLine($"{prefix}Fehlermeldung: {ex.Message}");
			writer.WriteLine($"{prefix}Source: {ex.Source}");
			writer.WriteLine($"{prefix}Stacktrace: {ex.StackTrace}");
			writer.WriteLine($"{prefix}TargetSite: {ex.TargetSite}");
			writer.WriteLine($"{prefix}Hilfelink: {ex.HelpLink}");

			if (additionalText != null)
			{
				writer.WriteLine($"{prefix}Auszuführendes Script: {additionalText}");
			}

			if (ex.InnerException != null)
			{
				WriteException(ex.InnerException, writer, null, "        ");
			}
		}
	}
}
