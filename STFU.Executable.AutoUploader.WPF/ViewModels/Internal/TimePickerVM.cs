using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace STFU.Executable.AutoUploader.WPF.ViewModels.Internal
{
    public class TimePickerVM : ViewModelBase
    {
        public TimePickerVM()
        {
            Up = new ButtonCommand(UpAction);
            Down = new ButtonCommand(DownAction);
        }

        private void DownAction()
        {
            switch (selected)
            {
                case Selected.None:
                case Selected.Hours:
                    Hours--;
                    selected = Selected.Hours;
                    OnPropertyChanged(nameof(IsHoursSelected));
                    break;
                case Selected.Minutes:
                    Minutes--;
                    OnPropertyChanged(nameof(IsMinutesSelected));
                    break;
            }
        }

        private void UpAction()
        {
            switch (selected)
            {
                case Selected.None:
                case Selected.Hours:
                    Hours++;
                    selected = Selected.Hours;
                    OnPropertyChanged(nameof(IsHoursSelected));
                    break;
                case Selected.Minutes:
                    Minutes++;
                    OnPropertyChanged(nameof(IsMinutesSelected));
                    break;
            }
        }

        private int minutes;

        public int Minutes
        {
            get => minutes;
            set
            {
                var dt = DateTime.MinValue.AddDays(1).AddHours(hours).AddMinutes(value);
                Hours = dt.Hour;
                minutes = dt.Minute;
                OnPropertyChanged();
            }
        }

        internal void FocusLost(object sender, RoutedEventArgs e)
        {
            if (selected == Selected.None)
                return;

            if (sender is TextBlock textBlock)
            {
                if (textBlock.Tag is string s && s.Length > 0)
                    switch (s[0])
                    {
                        case 'h':
                            if (selected == Selected.Hours)
                                selected = Selected.None;
                            break;
                        case 'm':
                            if (selected == Selected.Minutes)
                                selected = Selected.None;
                            break;
                    }
                OnPropertyChanged(nameof(IsMinutesSelected));
                OnPropertyChanged(nameof(IsHoursSelected));
            }
        }

        private int hours;
        private Selected selected;

        public bool IsMinutesSelected { get { return selected == Selected.Minutes; } }

        public bool IsHoursSelected { get { return selected == Selected.Hours; } }

        public int Hours
        {
            get => hours;
            set
            {
                hours = value;
                while (hours < 0)
                    hours += 24;
                hours %= 24;
                OnPropertyChanged();
            }
        }

        public DateTime Time
        {
            get { return new DateTime(0, 0, 0, hours, minutes, 0); }
            set
            {
                Minutes = value.Minute;
                Hours = value.Hour;
                OnPropertyChanged();
            }
        }

        internal void ItemSelected(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock textBlock)
            {
                if (textBlock.Tag is string s && s.Length > 0)
                    switch (s[0])
                    {
                        case 'h':
                            selected = Selected.Hours;
                            break;
                        case 'm':
                            selected = Selected.Minutes;
                            break;
                    }
            }
            OnPropertyChanged(nameof(IsMinutesSelected));
            OnPropertyChanged(nameof(IsHoursSelected));
        }

        public ButtonCommand Up { get; set; }
        public ButtonCommand Down { get; set; }

        enum Selected
        {
            None,
            Hours,
            Minutes
        }
    }
}