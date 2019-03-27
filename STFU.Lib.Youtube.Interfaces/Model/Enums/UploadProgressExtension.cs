namespace STFU.Lib.Youtube.Interfaces.Model.Enums
{
	public static class UploadStateExtension
	{
		public static bool IsStarted(this UploadProgress state)
		{
			return state == UploadProgress.Running || state == UploadProgress.PausePending
				 || state == UploadProgress.Paused || state == UploadProgress.CancelPending;
		}

		public static bool IsCanceled(this UploadProgress state)
		{
			return state == UploadProgress.Canceled;
		}

		public static bool IsFailed(this UploadProgress state)
		{
			return state == UploadProgress.Failed;
		}

		public static bool IsPausingOrPaused(this UploadProgress state)
		{
			return state == UploadProgress.PausePending || state == UploadProgress.Paused;
		}
	}
}