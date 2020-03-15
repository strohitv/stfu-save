using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeCategoryContainer: IYoutubeCategoryContainer
	{
		private IList<ICategory> Categories { get; } = new List<ICategory>();

		public IReadOnlyCollection<ICategory> RegisteredCategories => new ReadOnlyCollection<ICategory>(Categories);

		public void RegisterCategory(ICategory category)
		{
			if (!RegisteredCategories.Any(c => c.Id == category.Id))
			{
				Categories.Add(category);
			}
		}

		public void UnregisterAllCategories()
		{
			Categories.Clear();
		}

		public void UnregisterCategory(ICategory category)
		{
			if (Categories.Contains(category))
			{
				Categories.Remove(category);
			}
		}

		public void UnregisterCategoryAt(int index)
		{
			if (Categories.Count > index)
			{
				Categories.RemoveAt(index);
			}
		}
	}
}
