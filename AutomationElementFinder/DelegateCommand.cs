using System;
using System.Windows.Input;

namespace AutomationElementFinder
{
    public sealed class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action<object> executeCallback)
            : base(o => true, executeCallback)
        {
        }

        public DelegateCommand(Predicate<object> canExecuteCallback, Action<object> executeCallback)
            : base(canExecuteCallback, executeCallback)
        {
        }
    }

    public class DelegateCommand<T> : DelegateCommandBase
    {
        public DelegateCommand(Action<T> executeCallback)
            : this(o => true, executeCallback)
        {
        }

        public DelegateCommand(Predicate<T> canExecuteCallback, Action<T> executeCallback)
        {
            if (canExecuteCallback == null)
                throw new ArgumentNullException("canExecuteCallback");
            if (executeCallback == null)
                throw new ArgumentNullException("executeCallback");

            CanExecuteCallback = o => canExecuteCallback((T) o);
            ExecuteCallback = o => executeCallback((T) o);
        }

        public bool CanExecute(T parameter)
        {
            return base.CanExecute(parameter);
        }

        public void Execute(T parameter)
        {
            base.Execute(parameter);
        }
    }

    public abstract class DelegateCommandBase : ICommand
    {
        public Predicate<object> CanExecuteCallback { get; protected set; }

        public Action<object> ExecuteCallback { get; protected set; }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (!CanExecuteCallback(parameter))
                throw new InvalidOperationException("The command cannot be executed because the CanExecute returns false");

            ExecuteCallback(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteCallback(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}