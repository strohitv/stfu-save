using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace STFU.UploadLib.Operations
{
	internal class ProcessWatcher
	{
		internal event EventHandler AllProcessesCompleted;

		private List<Process> procs = new List<Process>();
		private bool pause = false;
		private bool hasFired = false;

		public bool ShouldWaitForProcs { get; set; }

		internal bool Pause { get { return pause; }
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

			if (!Pause && procs.Count == 0)
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

		private List<Process> Procs
		{
			get
			{
				return procs;
			}

			set
			{
				procs = value;
			}
		}

		internal ReadOnlyCollection<Process> Processes
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
