using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Automation.Interfaces;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class ProcessViewModel : ViewModelBase
    {
        private bool reactToCheckedEvents;

        private IProcessContainer processContainer;
        private List<Process> selectedProcesses = new List<Process>();

        public IReadOnlyCollection<Process> Selected { get { return selectedProcesses; } }

        internal void RefreshSelectedProcesses()
        {
            selectedProcesses.Clear();
            selectedProcesses.AddRange(Processes.Where(i => i.Checked).Select(i => i.Process));
        }

        public ObservableCollection<ProcessSelectionVM> Processes { get; set; } = new ObservableCollection<ProcessSelectionVM>();

        public void ApplyProcessSelection()
        {
            RefreshSelectedProcesses();
            ProcessContainer.RemoveAllProcesses();
            ProcessContainer.AddProcesses(Selected);
        }

        public IProcessContainer ProcessContainer
        {
            get => processContainer;
            internal set
            {
                processContainer = value;
                selectedProcesses.Clear();
                selectedProcesses.AddRange(ProcessContainer.ProcessesToWatch);
            }
        }

        public bool ReactToCheckedEvents { get => reactToCheckedEvents; set { reactToCheckedEvents = value; OnPropertyChanged(); } }

        public async void RefreshAllProcessesAsync()
        {
            ReactToCheckedEvents = false;
            Processes.Clear();

            List<ProcessSelectionVM> items = new List<ProcessSelectionVM>();
            await Task.Run(() =>
            {
                var currentSessionID = Process.GetCurrentProcess().SessionId;

                Process[] currentProcesses = Process.GetProcesses()
                    .OrderBy(item => item.ProcessName)
                    .Where(p => HasAccess(p) && p.SessionId == currentSessionID && p.Id != Process.GetCurrentProcess().Id)
                    .ToArray();

                foreach (var process in currentProcesses)
                {
                    var item = new ProcessSelectionVM()
                    {
                        Process = process,
                        Name = process.ProcessName,
                        Checked = selectedProcesses.Any(p => process.Id == p.Id)
                    };

                    try
                    {
                        item.Description = process.MainModule.FileVersionInfo.FileDescription;
                    }
                    catch (Exception)
                    { }

                    items.Add(item);
                }
            });

            items.ForEach((e) => { Processes.Add(e); });
            RefreshSelectedProcesses();

            ReactToCheckedEvents = true;
        }

        private bool HasAccess(Process p)
        {
            bool result = false;

            try
            {
                result = p.HasExited || true;
            }
            catch (Exception)
            { }

            return result;
        }
    }
}
