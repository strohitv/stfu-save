namespace STFU.Lib.Youtube.Internal.Upload
{
	internal enum FailureReason
	{
		None,
		Unknown,
		FileTooBig,
		FileDoesNotExist,
		ReadError,
		SendError
	}
}
