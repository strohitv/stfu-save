using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class TemplateVM : ViewModelBase, IDataViewModel<ITemplate>
    {
        #region Private Fields

        private ObservableCollection<PlannedVideoVM> plannedVideos;
        private ObservableCollection<PublishTimeVM> publishTimes;
        private ITemplate source;
        private bool internalEdit;

        #endregion Private Fields

        #region Public Constructors

        public TemplateVM()
        {
            Category = new CategoryVM();
            Category.SourceUpdated += Category_SourceUpdated;
            Language = new LanguageVM();
            Language.SourceUpdated += Language_SourceUpdated;
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler SourceUpdated;

        #endregion Public Events

        #region Public Properties

        public bool AutoLevels
        {
            get => source?.AutoLevels ?? false;
            set { source.AutoLevels = value; OnPropertyChanged(); }
        }

        public CategoryVM Category { get; private set; }

        public string CSharpCleanUpScript
        {
            get => source?.CSharpCleanUpScript ?? string.Empty;
            set { source.CSharpCleanUpScript = value; OnPropertyChanged(); }
        }

        public string CSharpPreparation
        {
            get => source?.CSharpPreparationScript ?? string.Empty;
            set { source.CSharpPreparationScript = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => source?.Description ?? string.Empty;
            set { source.Description = value; OnPropertyChanged(); }
        }
        public int Id { get => source?.Id ?? 0; }
        public bool IsEmbeddable
        {
            get => source?.IsEmbeddable ?? false;
            set
            {
                source.IsEmbeddable = value;
                OnPropertyChanged();
            }
        }
        public LanguageVM Language { get; private set; }

        public License License
        {
            get => source?.License ?? License.Youtube;
            set { source.License = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => source?.Name ?? string.Empty;
            set { source.Name = value; OnPropertyChanged(); }
        }

        public DateTime NextUploadSuggestion
        {
            get => source?.NextUploadSuggestion ?? new DateTime();
            set { source.NextUploadSuggestion = value; OnPropertyChanged(); }
        }

        public bool NotifySubscribers
        {
            get => source?.NotifySubscribers ?? false;
            set { source.NotifySubscribers = value; OnPropertyChanged(); }
        }

        public ObservableCollection<PlannedVideoVM> PlannedVideos
        {
            get => plannedVideos;
            set { plannedVideos = value; OnPropertyChanged(); }
        }

        public PrivacyStatus Privacy
        {
            get => source?.Privacy ?? PrivacyStatus.Public;
            set { source.Privacy = value; OnPropertyChanged(); }
        }

        public bool PublicStatsViewable
        {
            get => source?.PublicStatsViewable ?? false;
            set { source.PublicStatsViewable = value; OnPropertyChanged(); }
        }

        public ObservableCollection<PublishTimeVM> PublishTimes
        {
            get => publishTimes;
            set { publishTimes = value; OnPropertyChanged(); }
        }

        public bool ShouldPublishAt
        {
            get => source?.ShouldPublishAt ?? false;
            set { source.ShouldPublishAt = value; OnPropertyChanged(); }
        }

        public ITemplate Source
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

        public bool Stabilize
        {
            get => source?.Stabilize ?? false;
            set { source.Stabilize = value; OnPropertyChanged(); }
        }

        public string Tags
        {
            get => source?.Tags ?? string.Empty;
            set { source.Tags = value; OnPropertyChanged(); }
        }

        public string ThumbnailPath
        {
            get => source?.ThumbnailPath ?? string.Empty;
            set { source.ThumbnailPath = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get => source?.Title ?? string.Empty;
            set { source.Title = value; OnPropertyChanged(); }
        }

        public bool IsSourceSet => source != null;

        #endregion Public Properties

        #region Public Methods

        public void Refresh()
        {
            internalEdit = true;

            Category.Source = source.Category;
            Language.Source = source.DefaultLanguage;
            OnPropertyChanged(nameof(AutoLevels));
            OnPropertyChanged(nameof(CSharpCleanUpScript));
            OnPropertyChanged(nameof(CSharpPreparation));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(IsEmbeddable));
            OnPropertyChanged(nameof(License));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(NextUploadSuggestion));
            OnPropertyChanged(nameof(NotifySubscribers));
            OnPropertyChanged(nameof(Privacy));
            OnPropertyChanged(nameof(PublicStatsViewable));
            OnPropertyChanged(nameof(ShouldPublishAt));
            OnPropertyChanged(nameof(Stabilize));
            OnPropertyChanged(nameof(Tags));
            OnPropertyChanged(nameof(ThumbnailPath));
            OnPropertyChanged(nameof(Title));

            if (PlannedVideos != null)
                PlannedVideos.CollectionChanged -= PlannedVideos_CollectionChanged;
            PlannedVideos = new ObservableCollection<PlannedVideoVM>();
            PlannedVideos.CollectionChanged += PlannedVideos_CollectionChanged;
            for (int i = 0; i < source.PlannedVideos.Count; i++)
                PlannedVideos.Add(new PlannedVideoVM() { Source = source.PlannedVideos[i] });

            if (PublishTimes != null)
                PublishTimes.CollectionChanged -= PublishTimes_CollectionChanged;
            PublishTimes = new ObservableCollection<PublishTimeVM>();
            PublishTimes.CollectionChanged += PublishTimes_CollectionChanged;
            for (int i = 0; i < source.PublishTimes.Count; i++)
                PublishTimes.Add(new PublishTimeVM() { Source = source.PublishTimes[i] });

            internalEdit = false;
        }

        public override string ToString()
        {
            return source?.ToString() ?? string.Empty;
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnSourceUpdated()
        {
            OnPropertyChanged(nameof(IsSourceSet));
            SourceUpdated?.Invoke(this, new EventArgs());
        }

        #endregion Protected Methods

        #region Private Methods

        private void Category_SourceUpdated(object sender, EventArgs e) => OnPropertyChanged(nameof(Category));

        private void CollectionChanged<T1, T2>(ObservableCollection<T1> collection, IList<T2> sourceList, NotifyCollectionChangedEventArgs e) where T1 : ViewModelBase, IDataViewModel<T2>
        {
            if (internalEdit)
                return;

            T2 newItem = e.NewItems?.Count > 0 ? e.NewItems.Cast<T2>().FirstOrDefault() : default(T2);
            T2 oldItem = e.OldItems?.Count > 0 ? e.OldItems.Cast<T2>().FirstOrDefault() : default(T2);

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex == -1)
                        sourceList.Add(newItem);
                    else
                        sourceList.Insert(e.NewStartingIndex, newItem);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    sourceList.RemoveAt(e.OldStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    sourceList[e.OldStartingIndex] = newItem;
                    break;
                case NotifyCollectionChangedAction.Move:
                    sourceList.RemoveAt(e.OldStartingIndex);
                    sourceList.Insert(e.NewStartingIndex, oldItem);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    sourceList.Clear();
                    break;
            }
        }

        private void Language_SourceUpdated(object sender, EventArgs e) => OnPropertyChanged(nameof(Language));

        private void PlannedVideos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => CollectionChanged(PlannedVideos, source.PlannedVideos, e);

        private void PublishTimes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => CollectionChanged(PublishTimes, source.PublishTimes, e);

        #endregion Private Methods
    }
}