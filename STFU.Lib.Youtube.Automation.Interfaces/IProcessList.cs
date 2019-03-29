using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface IProcessList : IList<Process>
	{
		/// <summary>
		/// Is being fired when all Processes are completed
		/// </summary>
		event EventHandler ProcessesCompleted;

		/// <summary>
		/// determines if all Processes in the list are completed
		/// </summary>
		bool AllProcessesCompleted { get; }


	}
}
