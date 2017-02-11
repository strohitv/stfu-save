using System;
using System.Diagnostics;
using System.IO;
using STFU.UploadLib;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			FileStream ostrm;
			//StreamWriter writer; 
			//TextWriter oldOut = Console.Out;
			try
			{
				ostrm = new FileStream(string.Format(@"C:\Users\marco\Desktop\uploaderlogs\uploader_{0}.txt", DateTime.Now.ToString("yyyy-MM-dd_HH-mm")), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
				//writer = new StreamWriter(ostrm);
				//writer.AutoFlush = true;
				Trace.Listeners.Add(new TextWriterTraceListener(ostrm));
				Trace.Listeners.Add(new ConsoleTraceListener());
			}
			catch (Exception e)
			{
				Trace.WriteLine("Cannot open Redirect.txt for writing");
				Trace.WriteLine(e.Message);
				return;
			}
			//Console.SetOut(writer);


			//Trace.Write(null);

			// ---

			Trace.AutoFlush = true;
			string refreshToken = "";
			//Trace.WriteLine("test");
			//writer.Flush();

			Uploader u = new Uploader();

			// PLAYLIST LESEN
			//u.GetVideoIdsForPlaylist(refreshToken, "PLm5B9FzOsaWfhLuZtcf5ZPGv8PAXwzUwk");

			// VIDEOS HOCHLADEN
			u.Test(refreshToken);

			return;

			Trace.WriteLine("Done");
			//Console.SetOut(oldOut);
			//writer.Close();
			ostrm.Close();
			//Console.Read();

			return;

			Console.TreatControlCAsInput = true;
			Console.CancelKeyPress += ConsoleCancelKeyPress;

			Console.CursorVisible = false;

			string[] lines = 
			{ 
				"{0} Account hinzufügen", 
				"{0} Video auswählen", 
				"{0} Upload starten", 
				"{0} Awesome sein", 
				"{0} Exit" 
			};

			int currentSelection = 0;
			string selectedChar = ">";
			string notSelectedChar = " ";

			bool end = false;

			do
			{
				Console.Clear();

				for (int i = 0; i < lines.Length; i++)
				{
					Trace.WriteLine(lines[i], (i == currentSelection) ? selectedChar : notSelectedChar);
				}

				bool keyAllowed = true;

				do
				{
					keyAllowed = true;
					var key = Console.ReadKey(true);
					switch (key.Key)
					{
						case ConsoleKey.DownArrow:
							currentSelection = (currentSelection + 1) % 5;
							break;
						case ConsoleKey.Enter:
							if (currentSelection == 4)
							{
								end = true;
							}
							break;
						case ConsoleKey.Escape:
							end = true;
							break;
						case ConsoleKey.LeftArrow:
							currentSelection = 0;
							break;
						case ConsoleKey.RightArrow:
							currentSelection = 4;
							break;
						case ConsoleKey.UpArrow:
							currentSelection = (currentSelection - 1 + 5) % 5;
							break;
						default:
							keyAllowed = false;
							break;
					}
				} while (!keyAllowed);
			} while (!end);
		}

		static void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			// ...
			// Beenden
			// ...
		}
	}
}
