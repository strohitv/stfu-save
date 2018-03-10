using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Common.InternalInterfaces
{
	internal interface IYoutubeJobUploader
	{
		IYoutubeJob Job { get; }

		Task UploadAsync(CancellationToken token);
	}
}
