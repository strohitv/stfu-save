using System.Collections.Generic;
using System.Diagnostics;

namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface IProcessContainer
	{
		IReadOnlyCollection<Process> ProcessesToWatch { get; }

		void AddProcess(Process proc);
		void RemoveAllProcesses();
		void RemoveProcess(Process proc);
		void RemoveProcessAt(int index);
	}
}
