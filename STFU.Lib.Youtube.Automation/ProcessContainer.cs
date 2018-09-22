using STFU.Lib.Youtube.Automation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace STFU.Lib.Youtube.Automation
{
	public class ProcessContainer : IProcessContainer
	{
		public event EventHandler AllProcessesCompleted;

		private bool hasFired = false;
		private IList<Process> Processes { get; set; } = new List<Process>();

		public IReadOnlyCollection<Process> ProcessesToWatch => new ReadOnlyCollection<Process>(Processes);

		public bool Running { get; private set; } = false;

		public bool ShouldEnd => Running && Processes.Count == 0;

		public void AddProcess(Process proc)
		{
			try
			{
				if (!Processes.Any(p => p.Id == proc.Id)
					&& !proc.HasExited)
				{
					proc.EnableRaisingEvents = true;
					proc.Exited += OnProcExit;
					Processes.Add(proc);
					hasFired = false;
				}
			}
			catch (Win32Exception)
			{ }
		}

		private void OnProcExit(object sender, EventArgs e)
		{
			var proc = (Process)sender;
			RemoveProcess(proc);
			CheckEventFire();
		}

		private void CheckEventFire()
		{
			if (Running && !hasFired && Processes.Count == 0)
			{
				AllProcessesCompleted?.Invoke(this, new EventArgs());
				hasFired = true;
			}
		}

		public void AddProcesses(IEnumerable<Process> procs)
		{
			foreach (var proc in procs)
			{
				AddProcess(proc);
			}
		}

		public void RemoveAllProcesses()
		{
			foreach (var proc in Processes)
			{
				proc.Exited -= OnProcExit;
			}

			Processes.Clear();
		}

		public void RemoveProcess(Process proc)
		{
			proc.Exited -= OnProcExit;

			if (ProcessesToWatch.Contains(proc))
			{
				Processes.Remove(proc);
			}
		}

		public void RemoveProcessAt(int index)
		{
			if (ProcessesToWatch.Count > index)
			{
				Processes[index].Exited -= OnProcExit;
				Processes.RemoveAt(index);
			}
		}

		public void Start()
		{
			Running = true;
			CheckEventFire();
		}

		public void Stop()
		{
			Running = false;
		}
	}
}
