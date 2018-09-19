using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface ILanguageCategoryLoader
	{
		IReadOnlyList<ICategory> Categories { get; }

		IReadOnlyList<ILanguage> Languages { get; }
	}
}
