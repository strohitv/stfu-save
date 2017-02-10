using StrohisUploadLib.Queue;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrohisUploadLib.Communication.Youtube
{
	internal class UploadCommunication
	{
		internal static bool Upload(ref Job video)
		{
			string url = WebService.InitializeUpload(ref video);

			Uri testUrl = null;
			if (!Uri.TryCreate(url, UriKind.Absolute, out testUrl))
			{
				return false;
			}

			Trace.WriteLine(testUrl.AbsoluteUri);

			while (Uri.TryCreate(WebService.UploadFile(ref video, url), UriKind.Absolute, out testUrl))
			{
				Trace.WriteLine("Upload wurde unerwartet abgebrochen. Warte 1 Minuten vor Neuversuch...");
				Thread.Sleep(new TimeSpan(0, 1, 0));
			}
			return true;
		}
	}
}
