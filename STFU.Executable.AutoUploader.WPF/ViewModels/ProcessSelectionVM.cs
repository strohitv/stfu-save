using System.Diagnostics;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    [DebuggerDisplay("{Name}")]
    public class ProcessSelectionVM : ViewModelBase
    {
        #region Private Fields

        private string description;
        private bool isChecked;

        private string name;

        #endregion Private Fields

        #region Public Properties

        public bool Checked
        {
            get { return isChecked; }
            set { isChecked = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public Process Process { get; set; }

        #endregion Public Properties
    }
}