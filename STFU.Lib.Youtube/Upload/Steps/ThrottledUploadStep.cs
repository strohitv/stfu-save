using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public abstract class ThrottledUploadStep : AbstractUploadStep
	{
		public ThrottledUploadStep(IYoutubeJob job)
			: base(job) { }

		protected FileStream fileStream = null;
		protected ThrottledReadStream throttledStream = null;
		protected Stream requestStream = null;

		private List<Tuple<TimeSpan, long>> speeds = new List<Tuple<TimeSpan, long>>();
		private DateTime lastRead = default(DateTime);
		private long lastPosition = 0;

		protected void Upload(string path, HttpWebRequest request)
		{
			try
			{
				ServicePointManager.FindServicePoint(request.RequestUri).UseNagleAlgorithm = false;
				request.Proxy = new WebProxy();
				request.AllowWriteStreamBuffering = false;

				using (fileStream = new FileStream(path, FileMode.Open))
				using (throttledStream = new ThrottledReadStream(fileStream))
				using (requestStream = request.GetRequestStream())
				{
					CancellationTokenSource = new CancellationTokenSource();
					fileStream.Position = lastPosition = Status.LastByte + 1;

					try
					{
						lastRead = DateTime.Now;
						lastPosition = fileStream.Position;
						throttledStream.CopyToAsync(requestStream, 81920, CancellationTokenSource.Token).Wait();
						FinishedSuccessful = true;
						Status.Progress = 100;
					}
					catch (AggregateException)
					{
						// Upload wurde abgebrochen
					}
					finally
					{
						fileStream = null;
						throttledStream = null;
						requestStream = null;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				// im Falle eines Abbruchs fliegt da noch ne Webexception, da der RequestStream abgebrochen wurde.
			}
		}

		public override void RefreshDurationAndSpeed()
		{
			if (fileStream != null && lastRead != default(DateTime))
			{
				while (speeds.Count >= 32)
				{
					speeds.RemoveAt(0);
				}

				var now = DateTime.Now;
				var currentPosition = fileStream.Position;
				var length = fileStream.Length;

				TimeSpan span = now.Subtract(lastRead);
				long difference = currentPosition - lastPosition;

				lastRead = now;
				lastPosition = currentPosition;

				speeds.Add(new Tuple<TimeSpan, long>(span, difference));

				var progress = Progress;

				Status.UploadedDuration += span;

				var uploadedTime = speeds.Select(s => s.Item1).Sum(s => s.TotalSeconds);
				var uploadedBytes = speeds.Select(s => s.Item2).Sum();

				var uploadSpeedPerSecond = (long)(uploadedBytes / uploadedTime);
				var remainingTime = new TimeSpan((length - currentPosition) * 10_000_000 / uploadSpeedPerSecond);

				Status.RemainingDuration = remainingTime;
				Status.CurrentSpeed = uploadSpeedPerSecond;
			}
		}
	}
}
