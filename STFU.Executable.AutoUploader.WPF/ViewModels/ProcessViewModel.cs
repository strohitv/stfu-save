using STFU.Lib.Youtube.Automation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class ProcessViewModel : ViewModelBase
    {
        #region Private Fields

        private IProcessContainer processContainer;
        private bool reactToCheckedEvents;
        private List<Process> selectedProcesses = new List<Process>();

        #endregion Private Fields

        #region Public Constructors

        public ProcessViewModel()
        {
            RefreshCommand = new ButtonCommand(RefreshAllProcessesAsync);
        }

        #endregion Public Constructors

        #region Public Properties

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

        public ObservableCollection<ProcessSelectionVM> Processes { get; set; } = new ObservableCollection<ProcessSelectionVM>();

        public bool ReactToCheckedEvents { get => reactToCheckedEvents; set { reactToCheckedEvents = value; OnPropertyChanged(); } }

        public ButtonCommand RefreshCommand { get; set; }
        public IReadOnlyCollection<Process> Selected { get { return selectedProcesses; } }

        #endregion Public Properties

        #region Public Methods

        public void ApplyProcessSelection()
        {
            RefreshSelectedProcesses();
            ProcessContainer.RemoveAllProcesses();
            ProcessContainer.AddProcesses(Selected);
        }

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

        #endregion Public Methods

        #region Internal Methods

        internal void RefreshSelectedProcesses()
        {
            selectedProcesses.Clear();
            selectedProcesses.AddRange(Processes.Where(i => i.Checked).Select(i => i.Process));
        }

        #endregion Internal Methods

        #region Private Methods

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

        #endregion Private Methods
    }
}