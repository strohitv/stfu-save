using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Common.Model
{
	public class YoutubeClient : IYoutubeClient
	{
		public string Id { get; }

		public string Secret { get; }

		public string Name { get; }

		public YoutubeClient(string id, string secret, string name)
		{
			Id = id;
			Secret = secret;
			Name = name;
		}
	}
}
