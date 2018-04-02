namespace STFU.Lib.Youtube.Common.Internal.Upload
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
