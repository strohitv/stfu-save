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
				LOGGER.Info($"Uploading video '{path}' to '{request.Method} {request.RequestUri}'");

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
					catch (AggregateException ex)
					{
						// Upload wurde abgebrochen
						LOGGER.Debug("Upload has been canceled", ex);
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
				LOGGER.Error("An exception occured. This was expected in case of the user canceling the request.", ex);
				// im Falle eines Abbruchs fliegt da noch ne Webexception, da der RequestStream abgebrochen wurde.
			}
		}

		private DateTime lastSpeedLog = DateTime.Now;
		private int nextProgressLog = 10;

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
				
				Status.UploadedDuration += span;

				var uploadedTime = speeds.Select(s => s.Item1).Sum(s => s.TotalSeconds);
				var uploadedBytes = speeds.Select(s => s.Item2).Sum();

				var uploadSpeedPerSecond = (long)(uploadedBytes / uploadedTime);

				if (uploadSpeedPerSecond == 0)
				{
					uploadSpeedPerSecond = 1;
				}

				var remainingTime = new TimeSpan((length - currentPosition) * 10_000_000 / uploadSpeedPerSecond);

				Status.RemainingDuration = remainingTime;
				Status.CurrentSpeed = uploadSpeedPerSecond;
				Status.Progress = Progress;

				if (lastSpeedLog < DateTime.Now - new TimeSpan(0,0,15))
				{
					LOGGER.Info($"Status of upload '{fileStream.Name}': progress = {Status.Progress}, speed = {Status.CurrentSpeed}, filestream position: {fileStream.Position} / total: {fileStream.Length}");
					lastSpeedLog = DateTime.Now;
				}
				else if (nextProgressLog < Status.Progress)
				{
					LOGGER.Info($"Status of upload '{fileStream.Name}' reached {nextProgressLog}%: progress = {Status.Progress}, speed = {Status.CurrentSpeed}, filestream position: {fileStream.Position} / total: {fileStream.Length}");
					nextProgressLog += 10;
				}
				else
				{
					LOGGER.Debug($"Status of upload '{fileStream.Name}': progress = {Status.Progress}, speed = {Status.CurrentSpeed}, filestream position: {fileStream.Position} / total: {fileStream.Length}");
				}
			}
		}
	}
}
