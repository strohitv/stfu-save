using STFU.Executable.AutoUploader.WPF.Converters;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class PlannedVideoVM : ViewModelBase, IDataViewModel<IPlannedVideo>
    {
        #region Private Fields

        private BooleanToStringConverter boolConverter;
        private ObservableCollection<FieldNameVM> fieldNames;
        private IPlannedVideo source;

        #endregion Private Fields

        #region Public Constructors

        public PlannedVideoVM()
        {
            boolConverter = new BooleanToStringConverter();
            fieldNames = new ObservableCollection<FieldNameVM>();
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler SourceUpdated;

        #endregion Public Events

        #region Public Properties

        public string AllFieldsSet { get { return boolConverter.Convert(fieldNames.All(v => !string.IsNullOrWhiteSpace(v.Value)), typeof(string), null, CultureInfo.InvariantCulture) as string; } }

        public ObservableCollection<FieldNameVM> FieldNames
        {
            get => fieldNames;
            set { fieldNames = value; OnPropertyChanged(); }
        }

        public bool IsSourceSet => source != null;

        public string Name
        {
            get => source.Name;
            set { source.Name = value; OnPropertyChanged(); }
        }

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

        #endregion Public Properties

        #region Public Methods

        public void Refresh()
        {
            FieldNames.Clear();
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

        #endregion Public Methods

        #region Private Methods

        private void FieldName_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var fieldName = sender as FieldNameVM;
            if (e.PropertyName == nameof(fieldName.Value))
            {
                source.Fields[fieldName.Key] = fieldName.Value;
            }
        }

        private void OnSourceUpdated()
        {
            OnPropertyChanged(nameof(IsSourceSet));
            SourceUpdated?.Invoke(this, new EventArgs());
        }

        #endregion Private Methods
    }
}