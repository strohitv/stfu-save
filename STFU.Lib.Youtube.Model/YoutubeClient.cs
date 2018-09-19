using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeClient : IYoutubeClient
	{
		public string Id { get; }

		public string Secret { get; }

		public string Name { get; }

		public bool LimitReached { get; private set; }

		public YoutubeClient(string id, string secret, string name, bool limitReached)
		{
			Id = id;
			Secret = secret;
			Name = name;
			LimitReached = limitReached;
		}

		public void MarkAsReached()
		{
			LimitReached = true;
		}
	}
}
