using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Common.Internal;
using STFU.Lib.Youtube.Common.Internal.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Common.Upload
{
	internal class YoutubeJobUploader : IYoutubeJobUploader
	{
		private InternalYoutubeJob job = null;

		public IYoutubeJob Job => job;

		internal YoutubeJobUploader(InternalYoutubeJob job)
		{
			this.job = job;
		}

		public async Task UploadAsync(CancellationToken token)
		{
			await Task.Run(() => Upload(token));
		}

		private void Upload(CancellationToken token)
		{
			IYoutubeVideoCommunicator communicator = new YoutubeVideoCommunicator(Job);
			communicator.Upload(token);
		}
	}
}
