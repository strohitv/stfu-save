namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public interface IAddPlannedVideoViewModel
    {
        ButtonCommand OkCommand { get; set; }
        bool? Result { get; }
    }
}