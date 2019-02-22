namespace STFU.Lib.Youtube.Interfaces.Model.Enums
{
	public static class UploadStateExtension
	{
		public static bool IsStarted(this UploadState state)
		{
			return ((int)state & 0b11111111) > 0;
		}
		public static bool IsRunningOrInitializing(this UploadState state)
		{
			return ((int)state & 0b00000011) > 0;
		}

		public static bool IsCanceled(this UploadState state)
		{
			return state == UploadState.Canceled;
		}

		public static bool IsFailed(this UploadState state)
		{
			return ((int)state & 0b00010000) > 0;
		}

		public static bool IsVideo(this UploadState state)
		{
			return ((int)state & 0b00100000) > 0;
		}

		public static bool IsThumbnail(this UploadState state)
		{
			return ((int)state & 0b01000000) > 0;
		}
		public static bool IsPausingOrPaused(this UploadState state)
		{
			return ((int)state & 0b10000000) > 0;
		}
	}
}
