using System;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class PublishTimeVM : ViewModelBase, IDataViewModel<IPublishTime>, IPublishTime
    {
        private IPublishTime source;

        public IPublishTime Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged();
                Refresh();
                OnSourceUpdated();
            }
        }

        public DayOfWeek DayOfWeek
        {
            get => source.DayOfWeek;
            set { source.DayOfWeek = value; OnPropertyChanged(); }
        }

        public int SkipDays
        {
            get => source.SkipDays;
            set { source.SkipDays = value; OnPropertyChanged(); }
        }

        public TimeSpan Time
        {
            get => source.Time;
            set { source.Time = value; OnPropertyChanged(); }
        }

        public bool IsSourceSet => source != null;

        private void OnSourceUpdated()
        {
            OnPropertyChanged(nameof(IsSourceSet));
            SourceUpdated?.Invoke(this, new EventArgs());
        }

        public event EventHandler SourceUpdated;

        public void Refresh()
        {
            OnPropertyChanged(nameof(DayOfWeek));
            OnPropertyChanged(nameof(SkipDays));
            OnPropertyChanged(nameof(Time));
        }
    }
}