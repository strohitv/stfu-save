using System;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Interfaces.Model.Args
{
	public class UploadStepStateChangedEventArgs : EventArgs
	{
		public UploadStepState OldState { get; }
		public UploadStepState NewState { get; }

		public UploadStepStateChangedEventArgs(UploadStepState oldState, UploadStepState newState)
		{
			OldState = oldState;
			NewState = newState;
		}
	}
}
