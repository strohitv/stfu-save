using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Common.Internal.Interfaces
{
	internal interface IYoutubeJobUploader
	{
		IYoutubeJob Job { get; }

		Task UploadAsync(CancellationToken token);
	}
}
