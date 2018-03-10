namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeClient
	{
		string Id { get; }
		
		string Secret { get; }

		string Name { get; }
	}
}
