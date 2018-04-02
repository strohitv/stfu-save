using System.Threading;

namespace STFU.Lib.Youtube.Common.Internal.Interfaces
{
	internal interface IYoutubeVideoCommunicator
	{
		void Upload(CancellationToken token);
	}
}
