namespace STFU.Lib.Youtube.Interfaces.Model
{
	public enum FailureReason
	{
		None,
		Unknown,
		FileTooBig,
		FileDoesNotExist,
		ReadError,
		SendError,
		UserUploadLimitExceeded
	}
}
