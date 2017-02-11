using System;

namespace STFU.UploadLib.Automation
{
	public class AutomationEventArgs : EventArgs
	{
		private string message;
		private double progress;

		public string FileName
		{
			get
			{
				return message;
			}

			set
			{
				message = value;
			}
		}

		public double Progress
		{
			get
			{
				return progress;
			}

			set
			{
				progress = value;
			}
		}
	}
}
