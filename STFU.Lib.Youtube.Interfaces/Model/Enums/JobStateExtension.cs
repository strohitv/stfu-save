namespace STFU.Lib.Youtube.Interfaces.Model.Enums
{
	public static class JobStateExtension
	{
		public static bool IsStarted(this JobState state)
		{
			return state == JobState.Running
				 || state == JobState.Paused
				 || state == JobState.Broke;
		}

		public static bool IsCanceled(this JobState state)
		{
			return state == JobState.Canceled;
		}

		public static bool IsFailed(this JobState state)
		{
			return state == JobState.Error;
		}

		public static bool IsPausingOrPaused(this JobState state)
		{
			return state == JobState.Paused;
		}
	}
}