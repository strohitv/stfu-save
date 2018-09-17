using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Internal.Services;

namespace STFU.Lib.Youtube
{
	public class ValidDataLoader : IValidDataLoader
	{
		private IYoutubeAccountContainer Container { get; }

		public ValidDataLoader(IYoutubeAccountContainer container)
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
					languages = YoutubeLanguageService.LoadLanguages(Container);
				}

				return languages;
			}
		}
	}
}
