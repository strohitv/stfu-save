using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IYoutubeLanguageContainer
	{
		IReadOnlyCollection<ILanguage> RegisteredLanguages { get; }

		void RegisterLanguage(ILanguage language);
		void UnregisterAllLanguages();
		void UnregisterLanguage(ILanguage language);
		void UnregisterLanguageAt(int index);
	}
}
