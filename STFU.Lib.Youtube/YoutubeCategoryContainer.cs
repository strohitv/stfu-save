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

		public void RegisterCategory(ICategory client)
		{
			if (!RegisteredCategories.Any(c => c.Id == client.Id))
			{
				Categories.Add(client);
			}
		}

		public void UnregisterAllCategories()
		{
			Categories.Clear();
		}

		public void UnregisterCategory(ICategory client)
		{
			if (Categories.Contains(client))
			{
				Categories.Remove(client);
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
