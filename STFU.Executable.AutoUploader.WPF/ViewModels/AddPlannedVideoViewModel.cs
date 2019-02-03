using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class AddPlannedVideoViewModel : ViewModelBase, IAddPlannedVideoViewModel
    {
        private string filename;

        public string Filename
        {
            get => filename;
            set { filename = value; OnPropertyChanged(); }
        }

        public bool? Result { get; private set; }

        public ButtonCommand CancelCommand { get; set; }

        public ButtonCommand OkCommand { get; set; }

        public AddPlannedVideoViewModel()
        {
            CancelCommand = new ButtonCommand(Cancel);
            OkCommand = new ButtonCommand(Apply);
        }

        private void Apply()
        {
            Result = true;
            OnClose();
        }

        private void Cancel()
        {
            Result = false;
            OnClose();
        }
    }
}
