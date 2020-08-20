using STFU.Lib.Twitter.Model;

namespace STFU.Lib.Twitter
{
	public class TwitterAccountContainer : ITwitterAccountContainer
	{
		public ITwitterAccount Account { get; set; }
	}
}
