using System;

namespace STFU.UploadLib.Communication.Youtube
{
	public class ProgressChangedEventArgs : EventArgs
	{
		private string fileName;
		private double progress;

		public string FileName
		{
			get
			{
				return fileName;
			}

			internal set
			{
				fileName = value;
			}
		}

		public double Progress
		{
			get
			{
				return progress;
			}

			internal set
			{
				progress = value;
			}
		}
	}
}
