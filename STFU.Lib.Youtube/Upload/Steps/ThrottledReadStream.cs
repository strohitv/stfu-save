using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ThrottledReadStream : Stream
	{
		static bool ShouldThrottle { get; set; }
		static int throttleByteperSeconds = 0;
		static int kByteModifier = 1000;

		Stream baseStream = null;
		Stopwatch watch = Stopwatch.StartNew();
		long totalBytesRead = 0;

		public static void SetLimit(int kByteLimit)
		{
			if (kByteLimit > 0)
			{
				throttleByteperSeconds = kByteLimit * kByteModifier;
			}
		}

		public ThrottledReadStream(Stream incommingStream)
		{
			baseStream = incommingStream;
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
			if (throttleByteperSeconds <= 0)
			{
				return count;
			}

			long canSend = (long)(watch.ElapsedMilliseconds * (throttleByteperSeconds / 1000.0));

			int diff = (int)(canSend - totalBytesRead);

			if (diff <= 0)
			{
				var waitInSec = ((diff * -1.0) / (throttleByteperSeconds));

				await Task.Delay((int)(waitInSec * 1000)).ConfigureAwait(false);
			}

			if (diff >= count)
			{
				return count;
			}

			return diff > 0 ? diff : Math.Min(kByteModifier, count);
		}
	}
}
