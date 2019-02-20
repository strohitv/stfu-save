using System;

namespace STFU.Lib.Youtube.Interfaces.Model.Enums
{
	// Bit 1: Initializing
	// Bit 2: Running
	// Bit 3: Successful
	// Bit 4: Cancel
	// Bit 5: Error
	// Bit 6: Video
	// Bit 7: Thumbnail
	// Bit 8: Pause
	[Flags]
	public enum UploadState
	{
		NotStarted = 00000000,
		VideoInitializing = 0b00100001,
		VideoUploading = 0b00100010,
		VideoUploaded = 0b00100100,
		ThumbnailUploading = 0b01000010,
		PausePending = 10000001,
		Paused = 10000010,
		Successful = 01100100,
		VideoError = 00110000,
		ThumbnailError = 01010000,
		CancelPending = 00001001,
		Canceled = 00001100
	}
}
