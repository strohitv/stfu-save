namespace STFU.Lib.Youtube.Internal.Upload.Model
{
	internal enum UploadStepState
	{
		NotRunning,
		Initializing,
		Running,
		Successful,
		Error,
		CancelPending,
		Canceled,
		PausePending,
		Paused
	}
}
