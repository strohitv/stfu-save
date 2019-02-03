using STFU.Lib.Youtube.Automation.Interfaces.Model;
using System;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class PublishTimeVM : ViewModelBase, IDataViewModel<IPublishTime>, IPublishTime
    {
        #region Private Fields

        private IPublishTime source;

        #endregion Private Fields

        #region Public Events

        public event EventHandler SourceUpdated;

        #endregion Public Events

        #region Public Properties

        public DayOfWeek DayOfWeek
        {
            get => source.DayOfWeek;
            set { source.DayOfWeek = value; OnPropertyChanged(); }
        }

        public bool IsSourceSet => source != null;

        public int SkipDays
        {
            get => source.SkipDays;
            set { source.SkipDays = value; OnPropertyChanged(); }
        }

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

        public TimeSpan Time
        {
            get => source.Time;
            set { source.Time = value; OnPropertyChanged(); }
        }

        public string[] WeekDayItems { get { return Enum.GetNames(typeof(DayOfWeek)); } }

        #endregion Public Properties

        #region Public Methods

        public void Refresh()
        {
            OnPropertyChanged(nameof(DayOfWeek));
            OnPropertyChanged(nameof(SkipDays));
            OnPropertyChanged(nameof(Time));
        }

        #endregion Public Methods

        #region Private Methods

        private void OnSourceUpdated()
        {
            OnPropertyChanged(nameof(IsSourceSet));
            SourceUpdated?.Invoke(this, new EventArgs());
        }

        #endregion Private Methods
    }
}