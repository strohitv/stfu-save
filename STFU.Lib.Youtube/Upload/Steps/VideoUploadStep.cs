using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class VideoUploadStep : AbstractUploadStep
	{
		public VideoUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
			: base(video, account, status) { }

		internal override void Run()
		{
			// Thread-Struktur überdenken!
			// Stream.CopyToAsync unterstützt das CancellationToken, also ist ein Abbruch evtl. möglich!
			// Siehe hier: https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=netframework-4.8
			throw new NotImplementedException();
		}
	}
}
