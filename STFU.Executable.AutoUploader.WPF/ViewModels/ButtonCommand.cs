using System;
using System.Windows.Input;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class ButtonCommand : ICommand
    {
        #region Protected Fields

        protected readonly Action action;
        protected readonly Predicate<object> predicate;

        #endregion Protected Fields

        #region Public Constructors

        public ButtonCommand(Action action, Predicate<object> predicate = null)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.predicate = predicate;
        }

        #endregion Public Constructors

        #region Protected Constructors

        protected ButtonCommand(Predicate<object> predicate = null)
        {
            this.predicate = predicate;
        }

        #endregion Protected Constructors

        #region Public Events

        public event EventHandler CanExecuteChanged;

        #endregion Public Events

        #region Public Methods

        public bool CanExecute(object parameter)
        {
            return predicate == null || predicate(parameter);
        }

        public virtual void Execute(object parameter)
        {
            action();
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        #endregion Protected Methods
    }

    public class ButtonCommand<T> : ButtonCommand
    {
        #region Protected Fields

        protected readonly new Action<T> action;

        #endregion Protected Fields

        #region Public Constructors

        public ButtonCommand(Action<T> action, Predicate<object> predicate = null)
            : base(predicate)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(object parameter)
        {
            if (parameter is T)
                action((T)parameter);
            else
                action(default(T));
        }

        #endregion Public Methods
    }
}