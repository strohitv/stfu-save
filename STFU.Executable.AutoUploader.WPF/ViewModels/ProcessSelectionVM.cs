using System.Diagnostics;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    [DebuggerDisplay("{Name}")]
    public class ProcessSelectionVM : ViewModelBase
    {
        private bool isChecked;

        public bool Checked
        {
            get { return isChecked; }
            set { isChecked = value; OnPropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        public Process Process { get; set; }
    }
}