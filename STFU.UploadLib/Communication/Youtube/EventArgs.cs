using System;

namespace STFU.UploadLib.Communication.Youtube
{
	public class ProgressChangedEventArgs : EventArgs
	{
		public string FileName { get; internal set; }

		public double Progress { get; internal set; }
	}
}
