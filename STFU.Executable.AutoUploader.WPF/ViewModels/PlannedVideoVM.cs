using System;
using System.Collections.ObjectModel;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class PlannedVideoVM : ViewModelBase, IDataViewModel<IPlannedVideo>
    {
        private IPlannedVideo source;

        public IPlannedVideo Source
        {
            get => source; set
            {
                source = value;
                OnPropertyChanged();
                Refresh();
                OnSourceUpdated();
            }
        }

        private void OnSourceUpdated()
        {
            OnPropertyChanged(nameof(IsSourceSet));
            SourceUpdated?.Invoke(this, new EventArgs());
        }

        public event EventHandler SourceUpdated;

        public void Refresh()
        {
            FieldNames = new ObservableCollection<FieldNameVM>();
            foreach (var field in source.Fields)
            {
                var fieldName = new FieldNameVM()
                {
                    Key = field.Key,
                    Value = field.Value
                };
                fieldName.PropertyChanged += FieldName_PropertyChanged;
                FieldNames.Add(fieldName);
            }
            OnPropertyChanged(nameof(Name));
        }

        private void FieldName_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var fieldName = sender as FieldNameVM;
            if(e.PropertyName == nameof(fieldName.Value))
            {
                source.Fields[fieldName.Key] = fieldName.Value;
            }
        }

        public string Name
        {
            get => source.Name;
            set { source.Name = value; OnPropertyChanged(); }
        }

        private ObservableCollection<FieldNameVM> fieldNames;

        public ObservableCollection<FieldNameVM> FieldNames
        {
            get => fieldNames;
            set { fieldNames = value; OnPropertyChanged(); }
        }

        public bool IsSourceSet => source != null;
    }
}