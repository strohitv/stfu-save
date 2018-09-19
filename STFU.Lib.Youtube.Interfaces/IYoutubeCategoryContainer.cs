using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IYoutubeCategoryContainer
	{
		IReadOnlyCollection<ICategory> RegisteredCategories { get; }

		void RegisterCategory(ICategory category);
		void UnregisterAllCategories();
		void UnregisterCategory(ICategory category);
		void UnregisterCategoryAt(int index);
	}
}
