using System;

namespace STFU.UploadLib.Automation
{
	public class AutomationEventArgs : EventArgs
	{
		public string FileName { get; set; }

		public double Progress { get; set; }
	}
}
