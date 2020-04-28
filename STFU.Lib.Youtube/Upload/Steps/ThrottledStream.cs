using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ThrottledStream : Stream
	{
		Stream baseStream = null;
		int throttle = 0;
		Stopwatch watch = Stopwatch.StartNew();
		long totalBytesRead = 0;

		int kbModifier = 1000;

		public ThrottledStream(Stream incommingStream, int throttleKb)
		{
			throttle = (throttleKb / 8) * kbModifier;
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
			var newcount = GetBytesToReturn(count);
			int read = baseStream.Read(buffer, offset, newcount);
			Interlocked.Add(ref totalBytesRead, read);
			return read;
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
			if (throttle <= 0)
			{
				return count;
			}

			long canSend = (long)(watch.ElapsedMilliseconds * (throttle / 1000.0));

			int diff = (int)(canSend - totalBytesRead);

			if (diff <= 0)
			{
				var waitInSec = ((diff * -1.0) / (throttle));

				await Task.Delay((int)(waitInSec * 1000)).ConfigureAwait(false);
			}

			if (diff >= count)
			{
				return count;
			}

			return diff > 0 ? diff : Math.Min(kbModifier * 8, count);
		}
	}
}
