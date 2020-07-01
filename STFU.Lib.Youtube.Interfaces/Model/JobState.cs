namespace STFU.Lib.Youtube.Interfaces.Model
{
	public enum JobState
	{
		NotStarted,
		Initializing,
		Running,
		Successful,
		Error,
		Canceled,
		Paused,
		Broke,
		QuotaReached
	}
}
