using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class UploaderStateChangedEventArgs : EventArgs
	{
		public JobState NewState { get; set; }

		public UploaderStateChangedEventArgs(JobState state)
		{
			NewState = state;
		}
	}
}
