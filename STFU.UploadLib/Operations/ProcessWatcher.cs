using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace STFU.UploadLib.Operations
{
	class ProcessWatcher
	{
		List<Process> procs = new List<Process>();

		public void Add(Process proc)
		{
			Procs.Add(proc);
		}

		public void Remove(Process proc)
		{
			Procs.Remove(proc);
		}

		public void Clear()
		{
			Procs.Clear();
		}

		public bool Contains(Process proc)
		{
			return Procs.Contains(proc);
		}

		public int Count { get { return Procs.Count; } }

		internal List<Process> Procs
		{
			get
			{
				return procs;
			}

			private set
			{
				procs = value;
			}
		}

		public bool AnyIsRunning()
		{
			if (Count == 0)
			{
				// Keine Prozesse überwacht, also läuft auch keiner.
				return false;
			}

			return Procs.Any(proc => !proc.HasExited);
		}
	}
}
