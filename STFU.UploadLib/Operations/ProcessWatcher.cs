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

		public bool ShouldEndAutomatically { get; set; }

		public void Add(Process proc)
		{
			try
			{
				if (!proc.HasExited)
				{
					proc.Exited += OnProcExit;
					Procs.Add(proc);
				}
			}
			catch (Win32Exception)
			{ }
		}

		private void OnProcExit(object sender, EventArgs e)
		{
			var proc = (Process)sender;
			Remove(proc);

			if (procs.Count == 0)
			{
				AllProcessesCompleted?.Invoke(this, new EventArgs());
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
				return ShouldEndAutomatically && Procs.Count == 0;
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
