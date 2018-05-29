using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using STFU.Lib.Youtube.Automation.Interfaces;

namespace STFU.Lib.Youtube.Automation
{
	public class ProcessContainer : IProcessContainer
	{
		private IList<Process> processes = new List<Process>();

		private IList<Process> Processes => processes;

		public IReadOnlyCollection<Process> ProcessesToWatch => new ReadOnlyCollection<Process>(processes);

		public void AddProcess(Process proc)
		{
			if (!ProcessesToWatch.Any(p => p.Id == proc.Id))
			{
				Processes.Add(proc);
			}
		}

		public void RemoveAllProcesses()
		{
			processes = new List<Process>();
		}

		public void RemoveProcess(Process proc)
		{
			if (ProcessesToWatch.Contains(proc))
			{
				Processes.Remove(proc);
			}
		}

		public void RemoveProcessAt(int index)
		{
			if (ProcessesToWatch.Count > index)
			{
				Processes.RemoveAt(index);
			}
		}
	}
}
