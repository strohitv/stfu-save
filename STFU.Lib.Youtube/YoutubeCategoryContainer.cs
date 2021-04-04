using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using log4net;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeCategoryContainer: IYoutubeCategoryContainer
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(YoutubeCategoryContainer));

		private IList<ICategory> Categories { get; } = new List<ICategory>();

		public IReadOnlyCollection<ICategory> RegisteredCategories => new ReadOnlyCollection<ICategory>(Categories);

		public void RegisterCategory(ICategory category)
		{
			if (!RegisteredCategories.Any(c => c.Id == category.Id))
			{
				LOGGER.Debug($"Adding a new category, title: '{category.Title}'");
				Categories.Add(category);
			}
		}

		public void UnregisterAllCategories()
		{
			LOGGER.Debug($"Removing all categories");
			Categories.Clear();
		}

		public void UnregisterCategory(ICategory category)
		{
			if (Categories.Contains(category))
			{
				LOGGER.Debug($"Removing category, title: '{category.Title}'");
				Categories.Remove(category);
			}
		}

		public void UnregisterCategoryAt(int index)
		{
			if (Categories.Count > index)
			{
				LOGGER.Debug($"Removing category at index {index}, title: '{Categories[index].Title}'");
				Categories.RemoveAt(index);
			}
		}
	}
}
