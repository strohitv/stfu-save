using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ThrottledReadStream : Stream
	{
		private static ILog LOGGER { get; set; } = LogManager.GetLogger(nameof(ThrottledReadStream));

		private delegate void ThrottleEnabledChangedEventHandler();
		private delegate void ThrottleChangedEventHandler();

		private static bool shouldThrottle = false;
		public static bool ShouldThrottle
		{
			get
			{
				return shouldThrottle;
			}
			set
			{
				if (shouldThrottle != value)
				{
					LOGGER.Info($"Throttling is now {(value ? "enabled" : "disabled")}");

					shouldThrottle = value;
					ShouldThrottleChanged?.Invoke();
				}
			}
		}

		private static long globalLimit = 1_000_000;
		public static long GlobalLimit
		{
			get
			{
				return globalLimit;
			}
			set
			{
				if (globalLimit != value)
				{
					LOGGER.Info($"Global upload throttle was set to {value}");

					globalLimit = value;
					ThrottleChanged?.Invoke();
				}
			}
		}

		private long DefinedLimit { get; set; } = GlobalLimit;

		private static ThrottleEnabledChangedEventHandler ShouldThrottleChanged;
		private static ThrottleChangedEventHandler ThrottleChanged;

		private static int KByteModifier { get; set; } = 1000;

		Stream baseStream = null;
		Stopwatch watch = Stopwatch.StartNew();
		long totalBytesRead = 0;

		public ThrottledReadStream(Stream incommingStream)
		{
			baseStream = incommingStream;
			ShouldThrottleChanged += ResetThrottle;
			ThrottleChanged += ResetThrottleIfActive;
		}

		~ThrottledReadStream()
		{
			LOGGER.Info($"Throttled read stream gets destructed");

			ShouldThrottleChanged -= ResetThrottle;
			ThrottleChanged -= ResetThrottleIfActive;
		}

		private void ResetThrottle()
		{
			totalBytesRead = 0;
			watch.Restart();
			DefinedLimit = GlobalLimit;
		}

		private void ResetThrottleIfActive()
		{
			if (ShouldThrottle)
			{
				ResetThrottle();
			}
		}

		public override bool CanRead
		{
			get { return baseStream.CanRead; }
		}

		public override bool CanSeek
		{
			get { return baseStream.CanSeek; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override void Flush()
		{
		}

		public override long Length
		{
			get { return baseStream.Length; }
		}

		public override long Position
		{
			get
			{
				return baseStream.Position;
			}
			set
			{
				baseStream.Position = value;
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (ShouldThrottle)
			{
				var newcount = GetBytesToReturn(count);
				int read = baseStream.Read(buffer, offset, newcount);
				Interlocked.Add(ref totalBytesRead, read);
				return read;
			}
			else
			{
				return baseStream.Read(buffer, offset, count);
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return baseStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		int GetBytesToReturn(int count)
		{
			return GetBytesToReturnAsync(count).Result;
		}

		async Task<int> GetBytesToReturnAsync(int count)
		{
			if (DefinedLimit <= 0)
			{
				return count;
			}

			long canSend = (long)(watch.ElapsedMilliseconds * (DefinedLimit / 1000.0));

			int diff = (int)(canSend - totalBytesRead);

			if (diff <= 0)
			{
				var waitInSec = ((diff * -1.0) / (DefinedLimit));

				await Task.Delay((int)(waitInSec * 1000)).ConfigureAwait(false);
			}

			if (diff >= count)
			{
				return count;
			}

			return diff > 0 ? diff : Math.Min(KByteModifier, count);
		}
	}
}
