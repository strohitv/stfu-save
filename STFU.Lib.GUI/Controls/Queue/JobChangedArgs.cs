using System;
using log4net;

namespace STFU.Lib.GUI.Controls.Queue
{
	public class JobChangedArgs
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(JobChangedArgs));

		public JobChangedType Type { get; private set; }

		public EventArgs Args { get; private set; }

		public JobChangedArgs(JobChangedType type, EventArgs args)
		{
			LOGGER.Debug($"Creating new instance of JobChangedArgs. Type: '{type}'");

			Type = type;
			Args = args;
		}
	}
}
