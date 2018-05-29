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

				if (!pause && !hasFired && Procs.Count == 0)
				{
					AllProcessesCompleted?.Invoke(this, new EventArgs());
					hasFired = true;
				}
			}
		}

		public void Add(Process proc)
		{
			try
			{
				if (!proc.HasExited)
				{
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

			if (!Pause && Procs.Count == 0)
			{
				AllProcessesCompleted?.Invoke(this, new EventArgs());
				hasFired = true;
			}
		}

		public void Remove(Process proc)
		{
			Procs.Remove(proc);
		}

		public void Clear()
		{
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
				return !Pause && ShouldWaitForProcs && Procs.Count == 0;
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
