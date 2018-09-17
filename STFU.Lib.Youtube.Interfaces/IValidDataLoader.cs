using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IValidDataLoader
	{
		IReadOnlyList<ICategory> Categories { get; }

		IReadOnlyList<ILanguage> Languages { get; }
	}
}
