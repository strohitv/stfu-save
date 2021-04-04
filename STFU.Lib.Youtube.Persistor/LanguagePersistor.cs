using System;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class LanguagePersistor
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(LanguagePersistor));

		public string Path { get; private set; } = null;
		public IYoutubeLanguageContainer Container { get; private set; } = null;
		public IYoutubeLanguageContainer Saved { get; private set; } = null;

		public LanguagePersistor(IYoutubeLanguageContainer container, string path)
		{
			LOGGER.Debug($"Creating language persistor for path '{path}'");

			Path = path;
			Container = container;
		}

		public bool Load()
		{
			LOGGER.Info($"Loading languages from path '{Path}'");
			Container.UnregisterAllLanguages();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();
						LOGGER.Debug($"Json from loaded path: '{json}'");

						var languages = JsonConvert.DeserializeObject<YoutubeLanguage[]>(json);
						LOGGER.Info($"Loaded {languages.Length} languages");

						foreach (var loaded in languages)
						{
							LOGGER.Info($"Adding language '{loaded.Name}'");
							Container.RegisterLanguage(loaded);
						}
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
				LOGGER.Error($"Could not load languages, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			ILanguage[] languages = Container.RegisteredLanguages.ToArray();
			LOGGER.Info($"Saving {languages.Length} languages to file '{Path}'");

			var json = JsonConvert.SerializeObject(languages);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}
				LOGGER.Info($"Languages saved");

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
				LOGGER.Error($"Could not save languages, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			LOGGER.Debug($"Recreating cache of saved languages");
			Saved = new YoutubeLanguageContainer();
			foreach (var language in Container.RegisteredLanguages)
			{
				LOGGER.Debug($"Recreating cache for language '{language.Name}'");
				var newLanguage = new YoutubeLanguage()
				{
					Hl = language.Hl,
					Id = language.Id,
					Name = language.Name
				};

				Saved.RegisterLanguage(newLanguage);
			}
		}
	}
}
