using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace STFU.Lib.Youtube.Automation.Internal.Watcher
{
	public class ProcessWatcher
	{
		internal event EventHandler AllProcessesCompleted;

		private bool pause = false;
		private bool hasFired = false;

		public bool ShouldWaitForProcs { get; set; }

		public bool Pause { get { return pause; }
			set
			{
				pause = value;

				CheckEventFire();
			}
		}

		public void Add(Process proc)
		{
			try
			{
				if (!proc.HasExited)
				{
					proc.EnableRaisingEvents = true;
					proc.Exited += OnProcExit;
					Procs.Add(proc);
					hasFired = false;
				}
			}
			catch (Win32Exception)
			{ }
		}

		private void OnProcExit(object sender, EventArgs e)
		{
			var proc = (Process)sender;
			Remove(proc);
			CheckEventFire();
		}

		private void CheckEventFire()
		{
			if (!Pause && ShouldWaitForProcs && !hasFired && Procs.Count == 0)
			{
				AllProcessesCompleted?.Invoke(this, new EventArgs());
				hasFired = true;
			}
		}

		public void Remove(Process proc)
		{
			proc.Exited -= OnProcExit;

			Procs.Remove(proc);
		}

		public void Clear()
		{
			foreach (var proc in Processes)
			{
				proc.Exited -= OnProcExit;
			}

			Procs.Clear();
		}

		private List<Process> Procs { get; set; } = new List<Process>();

		public ReadOnlyCollection<Process> Processes
		{
			get
			{
				return new ReadOnlyCollection<Process>(Procs);
			}
		}

		public bool ShouldEnd
		{
			get
			{
				return !Pause && Procs.Count == 0;
			}
		}

		private bool ProcIsRunning(Process proc)
		{
			bool result = false;

			try
			{
				result = !proc.HasExited;
			}
			catch (Win32Exception)
			{ }

			return result;
		}
	}
}
