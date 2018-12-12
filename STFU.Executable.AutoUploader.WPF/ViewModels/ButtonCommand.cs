using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class ButtonCommand : ICommand
    {
        protected readonly Action action;
        protected readonly Predicate<object> predicate;

        protected ButtonCommand(Predicate<object> predicate = null)
        {
            this.predicate = predicate;
        }

        public ButtonCommand(Action action, Predicate<object> predicate = null)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return predicate == null || predicate(parameter);
        }

        public virtual void Execute(object parameter)
        {
            action();
        }

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    public class ButtonCommand<T> : ButtonCommand
    {
        protected readonly new Action<T> action;

        public ButtonCommand(Action<T> action, Predicate<object> predicate = null)
            : base(predicate)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute(object parameter)
        {
            if (parameter is T)
                action((T)parameter);
            else
                action(default(T));
        }
    }
}
