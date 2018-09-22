using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface IProcessContainer
	{
		event EventHandler AllProcessesCompleted;

		IReadOnlyCollection<Process> ProcessesToWatch { get; }
		bool Running { get; }
		bool ShouldEnd { get; }

		void AddProcess(Process proc);
		void AddProcesses(IEnumerable<Process> proc);
		void RemoveAllProcesses();
		void RemoveProcess(Process proc);
		void RemoveProcessAt(int index);

		void Start();
		void Stop();
	}
}
