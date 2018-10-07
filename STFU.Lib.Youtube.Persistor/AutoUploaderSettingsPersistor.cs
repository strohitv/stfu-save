using System;
using System.IO;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Persistor.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class AutoUploaderSettingsPersistor
	{
		public string Path { get; private set; } = null;
		public AutoUploaderSettings Settings { get; private set; } = null;
		public AutoUploaderSettings Saved { get; private set; } = null;

		public AutoUploaderSettingsPersistor(AutoUploaderSettings settings, string path)
		{
			Path = path;
			Settings = settings;
		}

		public bool Load()
		{
			Settings.Reset();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var settings = JsonConvert.DeserializeObject<AutoUploaderSettings>(json);
						Settings.ShowReleaseNotes = settings.ShowReleaseNotes;
					}
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			var json = JsonConvert.SerializeObject(Settings);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			Saved = new AutoUploaderSettings();
			Saved.ShowReleaseNotes = Settings.ShowReleaseNotes;
		}
	}
}
