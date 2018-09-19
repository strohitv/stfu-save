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
		private string path = null;
		public string Path { get => path; private set => path = value; }

		IYoutubeLanguageContainer container = null;
		public IYoutubeLanguageContainer Container { get => container; private set => container = value; }

		IYoutubeLanguageContainer saved = null;
		public IYoutubeLanguageContainer Saved { get => saved; private set => saved = value; }

		public LanguagePersistor(IYoutubeLanguageContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			container.UnregisterAllLanguages();

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
							container.RegisterLanguage(loaded);
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
			ILanguage[] languages = container.RegisteredLanguages.ToArray();

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
