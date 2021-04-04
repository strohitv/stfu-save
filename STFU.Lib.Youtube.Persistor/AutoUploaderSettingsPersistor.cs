using System;
using System.IO;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Persistor.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class AutoUploaderSettingsPersistor
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(AutoUploaderSettingsPersistor));

		public string Path { get; private set; } = null;
		public AutoUploaderSettings Settings { get; private set; } = null;
		public AutoUploaderSettings Saved { get; private set; } = null;

		public AutoUploaderSettingsPersistor(AutoUploaderSettings settings, string path)
		{
			LOGGER.Debug($"Creating autouploader settings persistor for path '{path}'");

			Path = path;
			Settings = settings;
		}

		public bool Load()
		{
			LOGGER.Info($"Loading autouploader settings from path '{Path}'");
			Settings.Reset();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();
						LOGGER.Debug($"Json from loaded path: '{json}'");

						var settings = JsonConvert.DeserializeObject<AutoUploaderSettings>(json);
						Settings.ShowReleaseNotes = settings.ShowReleaseNotes;

						LOGGER.Info($"Loaded autouploader settings");
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
				LOGGER.Error($"Could not load autouploader settings, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			LOGGER.Info($"Saving autouploader settings to file '{Path}'");
			var json = JsonConvert.SerializeObject(Settings);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}
				LOGGER.Info($"Autouploader settings saved");

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
				LOGGER.Error($"Could not save autouploader settings, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			LOGGER.Debug($"Recreating cache of saved autouploader settings");
			Saved = new AutoUploaderSettings();
			Saved.ShowReleaseNotes = Settings.ShowReleaseNotes;
		}
	}
}
