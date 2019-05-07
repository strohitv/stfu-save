namespace STFU.Lib.Youtube.Internal.Upload.Model
{
	internal enum UploadStepState
	{
		NotRunning,
		Initializing,
		Running,
		Successful,
		Broke,
		Error,
		CancelPending,
		Canceled,
		PausePending,
		Paused
	}
}
