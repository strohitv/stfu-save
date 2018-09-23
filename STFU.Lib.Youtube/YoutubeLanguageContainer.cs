using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeLanguageContainer : IYoutubeLanguageContainer
	{
		private IList<ILanguage> Languages { get; } = new List<ILanguage>();

		public IReadOnlyCollection<ILanguage> RegisteredLanguages => new ReadOnlyCollection<ILanguage>(Languages);

		public void RegisterLanguage(ILanguage client)
		{
			if (!RegisteredLanguages.Any(c => c.Id == client.Id))
			{
				Languages.Add(client);
			}
		}

		public void UnregisterAllLanguages()
		{
			Languages.Clear();
		}

		public void UnregisterLanguage(ILanguage client)
		{
			if (Languages.Contains(client))
			{
				Languages.Remove(client);
			}
		}

		public void UnregisterLanguageAt(int index)
		{
			if (Languages.Count > index)
			{
				Languages.RemoveAt(index);
			}
		}
	}
}
