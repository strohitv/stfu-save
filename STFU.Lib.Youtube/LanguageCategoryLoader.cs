using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube
{
	public class LanguageCategoryLoader : ILanguageCategoryLoader
	{
		private IYoutubeAccountContainer Container { get; }

		public LanguageCategoryLoader(IYoutubeAccountContainer container)
		{
			Container = container;
		}

		private IReadOnlyList<ICategory> categories = new List<ICategory>().AsReadOnly();

		public IReadOnlyList<ICategory> Categories
		{
			get
			{
				if (categories.Count == 0)
				{
					categories = YoutubeCategoryService.LoadCategories(Container);
				}

				return categories;
			}
		}

		private IReadOnlyList<ILanguage> languages = new List<ILanguage>().AsReadOnly();

		public IReadOnlyList<ILanguage> Languages
		{
			get
			{
				if (languages.Count == 0)
				{
					// TODO: Auf Festplatte speichern und auch schon vorher laden als beim Template öffnen.
					languages = YoutubeLanguageService.LoadLanguages(Container);
				}

				return languages;
			}
		}
	}
}
