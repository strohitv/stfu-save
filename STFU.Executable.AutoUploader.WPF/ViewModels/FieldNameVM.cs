namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class FieldNameVM : ViewModelBase
    {
        private string key;

        public string Key
        {
            get => key;
            set { key = value; OnPropertyChanged(); }
        }

        private string value;

        public string Value
        {
            get => value;
            set { this.value = value; OnPropertyChanged(); }
        }
    }
}