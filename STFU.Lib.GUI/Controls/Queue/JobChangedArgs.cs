using System;

namespace STFU.Lib.GUI.Controls.Queue
{
	public class JobChangedArgs
	{
		public JobChangedType Type { get; private set; }

		public EventArgs Args { get; private set; }

		public JobChangedArgs(JobChangedType type, EventArgs args)
		{
			Type = type;
			Args = args;
		}
	}
}
