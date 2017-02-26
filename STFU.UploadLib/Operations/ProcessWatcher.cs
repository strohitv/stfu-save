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
			procs.Add(proc);
		}

		public void Remove(Process proc)
		{
			procs.Remove(proc);
		}

		public void Clear()
		{
			procs.Clear();
		}

		public bool Contains(Process proc)
		{
			return procs.Contains(proc);
		}

		public int Count { get { return procs.Count; } }

		public bool AnyIsRunning()
		{
			if (Count == 0)
			{
				// Keine Prozesse überwacht, also läuft auch keiner.
				return false;
			}

			return procs.Any(proc => !proc.HasExited);
		}
	}
}
