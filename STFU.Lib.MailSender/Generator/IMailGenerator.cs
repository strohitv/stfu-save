using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.MailSender.Generator
{
	public interface IMailGenerator
	{
		string Generate(IYoutubeJob job);
	}
}
