using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public class ThrottledStream : Stream
{
	private const long Infinite = 0;
	private const int historyInTicks = 30000 * 10000;
	private Stream baseStream;
	private long maximumBytesPerSecondRead;
	private Dictionary<long, int> bytesPerTick = new Dictionary<long, int>();

	private long currentTicks
	{
		get
		{
			return DateTime.Now.Ticks;
		}
	}

	public long MaximumBytesPerSecond
	{
		get
		{
			return maximumBytesPerSecondRead;
		}
		set
		{
			if (MaximumBytesPerSecond != value)
			{
				maximumBytesPerSecondRead = value;
			}
		}
	}

	public override bool CanRead
	{
		get
		{
			return baseStream.CanRead;
		}
	}

	public override bool CanSeek
	{
		get
		{
			return baseStream.CanSeek;
		}
	}

	public override bool CanWrite
	{
		get
		{
			return baseStream.CanWrite;
		}
	}

	public override long Length
	{
		get
		{
			return baseStream.Length;
		}
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

	public ThrottledStream(Stream baseStream)
	: this(baseStream, Infinite)
	{
		// Nothing todo.
	}

	public ThrottledStream(Stream baseStream, long maximumBytesPerSecond)
	{
		if (maximumBytesPerSecond < 0)
		{
			throw new ArgumentOutOfRangeException("maximumBytesPerSecond",
			maximumBytesPerSecond, "The maximum number of bytes per second can't be negatie.");
		}

		this.baseStream = baseStream ?? throw new ArgumentNullException("baseStream");
		maximumBytesPerSecondRead = maximumBytesPerSecond;
	}

	public override void Flush()
	{
		baseStream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throttle();

		long currentTicks = this.currentTicks;
		if (bytesPerTick.ContainsKey(currentTicks))
		{
			bytesPerTick[currentTicks] += count;
		}
		else
		{
			bytesPerTick.Add(this.currentTicks, count);
		}

		return baseStream.Read(buffer, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return baseStream.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		baseStream.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		baseStream.Write(buffer, offset, count);
	}

	public override string ToString()
	{
		return baseStream.ToString();
	}

	private void throttle()
	{
		// Make sure the buffer isn't empty.
		if (maximumBytesPerSecondRead <= 0)
		{
			return;
		}

		long historyTicks = currentTicks - historyInTicks;

		var historyBytes = bytesPerTick.Where(kvp => kvp.Key > historyTicks);

		foreach (var outdatedEntry in bytesPerTick.Where(kvp => kvp.Key < historyTicks))
		{
			bytesPerTick.Remove(outdatedEntry.Key);
		}

		if (historyBytes.Count() > 1)
		{
			long byteCountRead = historyBytes.Sum(kvp => kvp.Value);

			long elapsedTicks = historyBytes.Max(kvp => kvp.Key) - historyBytes.Min(kvp => kvp.Key);
			// Calculate the current bps.
			if ((elapsedTicks / 10000) > 0)
			{
				long bps = byteCountRead * 1000L / (elapsedTicks / 10000);
				// If the bps are more then the maximum bps, try to throttle.
				if (bps > maximumBytesPerSecondRead)
				{
					// Calculate the time to sleep.
					long wakeElapsed = byteCountRead * 1000L / maximumBytesPerSecondRead;
					int toSleep = (int)(wakeElapsed - (elapsedTicks / 10000));
					if (toSleep > 1)
					{
						Thread.Sleep(toSleep);
					}
				}
			}
		}
	}
}