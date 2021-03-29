using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using log4net;
using STFU.Lib.Youtube.Automation.Interfaces;

namespace STFU.Lib.Youtube.Automation
{
	public class ProcessList : List<Process>, IProcessList
	{
		private static ILog LOGGER { get; set; } = LogManager.GetLogger(nameof(ProcessList));

		public ProcessList() : base() { }

		public bool AllProcessesCompleted => Count == 0 || this.All(p => p.HasExited);

		public event EventHandler ProcessesCompleted;

		private void ProcessExited(object sender, EventArgs e)
		{
			if (AllProcessesCompleted)
			{
				ProcessesCompleted?.Invoke(this, new EventArgs());
			}

			try
			{
				var proc = (Process)sender;
				LOGGER.Info($"Process with id: {proc.Id} and name: '{proc.ProcessName}' exited");
			}
			catch (Exception ex)
			{
				LOGGER.Error($"Could not retrieve process id or name to log its exit!", ex);
			}

			((Process)sender).Exited -= ProcessExited;
		}

		public new void Add(Process item)
		{
			LOGGER.Info($"Process with id: {item.Id} and name: '{item.ProcessName}' added");

			item.Exited += ProcessExited;

			base.Add(item);
		}

		public new void AddRange(IEnumerable<Process> items)
		{
			foreach (var item in items)
			{
				LOGGER.Info($"Process with id: {item.Id} and name: '{item.ProcessName}' added");

				item.EnableRaisingEvents = true;
				item.Exited += ProcessExited;
			}

			base.AddRange(items);
		}

		public new void Clear()
		{
			LOGGER.Info($"Clearling process list");

			foreach (var item in this)
			{
				item.Exited -= ProcessExited;
			}

			base.Clear();
		}

		public new void Insert(int index, Process item)
		{
			LOGGER.Info($"Process with id: {item.Id} and name: '{item.ProcessName}' inserted into position {index}");

			item.Exited += ProcessExited;

			base.Insert(index, item);
		}

		public new void InsertRange(int index, IEnumerable<Process> items)
		{
			LOGGER.Info($"Several processes are being inserted from index {index} onwards");

			foreach (var item in items)
			{
				LOGGER.Info($"Process with id: {item.Id} and name: '{item.ProcessName}' inserted");

				item.Exited += ProcessExited;
			}

			base.InsertRange(index, items);
		}

		public new void Remove(Process item)
		{
			LOGGER.Info($"Process with id: {item.Id} and name: '{item.ProcessName}' removed");

			item.Exited -= ProcessExited;
			base.Remove(item);
		}

		public new void RemoveAll(Predicate<Process> match)
		{
			LOGGER.Info($"Removing processes that match a certain predicate");

			foreach (var item in FindAll(match))
			{
				LOGGER.Info($"Process with id: {item.Id} and name: '{item.ProcessName}' removed");

				item.Exited -= ProcessExited;
			}

			base.RemoveAll(match);
		}

		public new void RemoveAt(int index)
		{
			LOGGER.Info($"Process with id: {this[index].Id} and name: '{this[index].ProcessName}' removed from index {index}");

			this[index].Exited -= ProcessExited;
			base.RemoveAt(index);
		}

		public new void RemoveRange(int index, int count)
		{
			LOGGER.Info($"Removing {count} processes from index {index} onwards");

			for (int i = index; i < index + count; i++)
			{
				LOGGER.Info($"Process with id: {this[i].Id} and name: '{this[i].ProcessName}' removed");

				this[index].Exited -= ProcessExited;
			}

			base.RemoveRange(index, count);
		}
	}
}
