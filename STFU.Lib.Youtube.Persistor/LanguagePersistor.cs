using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class LanguagePersistor
	{
		public string Path { get; private set; } = null;
		public IYoutubeLanguageContainer Container { get; private set; } = null;
		public IYoutubeLanguageContainer Saved { get; private set; } = null;

		public LanguagePersistor(IYoutubeLanguageContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			Container.UnregisterAllLanguages();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var languages = JsonConvert.DeserializeObject<YoutubeLanguage[]>(json);

						foreach (var loaded in languages)
						{
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
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			ILanguage[] languages = Container.RegisteredLanguages.ToArray();

			var json = JsonConvert.SerializeObject(languages);

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
			Saved = new YoutubeLanguageContainer();
			foreach (var language in Container.RegisteredLanguages)
			{
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
