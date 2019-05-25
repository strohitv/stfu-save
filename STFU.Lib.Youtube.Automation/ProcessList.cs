using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using STFU.Lib.Youtube.Automation.Interfaces;

namespace STFU.Lib.Youtube.Automation
{
	public class ProcessList : List<Process>, IProcessList
	{
		public ProcessList() : base() { }

		public bool AllProcessesCompleted => Count == 0 || this.All(p => p.HasExited);

		public event EventHandler ProcessesCompleted;

		private void ProcessExited(object sender, EventArgs e)
		{
			if (AllProcessesCompleted)
			{
				ProcessesCompleted?.Invoke(this, new EventArgs());
			}

			((Process)sender).Exited -= ProcessExited;
		}

		public new void Add(Process item)
		{
			item.Exited += ProcessExited;

			base.Add(item);
		}

		public new void AddRange(IEnumerable<Process> items)
		{
			foreach (var item in items)
			{
				item.EnableRaisingEvents = true;
				item.Exited += ProcessExited;
			}

			base.AddRange(items);
		}

		public new void Clear()
		{
			foreach (var item in this)
			{
				item.Exited -= ProcessExited;
			}

			base.Clear();
		}

		public new void Insert(int index, Process item)
		{
			item.Exited += ProcessExited;

			base.Insert(index, item);
		}

		public new void InsertRange(int index, IEnumerable<Process> items)
		{
			foreach (var item in items)
			{
				item.Exited += ProcessExited;
			}

			base.InsertRange(index, items);
		}

		public new void Remove(Process item)
		{
			item.Exited -= ProcessExited;
			base.Remove(item);
		}

		public new void RemoveAll(Predicate<Process> match)
		{
			foreach (var item in this.FindAll(match))
			{
				item.Exited -= ProcessExited;
			}

			base.RemoveAll(match);
		}

		public new void RemoveAt(int index)
		{
			this[index].Exited -= ProcessExited;
			base.RemoveAt(index);
		}

		public new void RemoveRange(int index, int count)
		{
			for (int i = index; i < index + count; i++)
			{
				this[index].Exited -= ProcessExited;
			}

			base.RemoveRange(index, count);
		}
	}
}
