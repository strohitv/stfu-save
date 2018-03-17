using System.Threading;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Common.Internal.Interfaces;
using STFU.Lib.Youtube.Common.Model;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

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
			job.State = UploadState.Running;

			// prepare upload

			// upload

			// prepare thumbnail upload

			// upload thumbnail

			// finish and return
		}
	}
}
