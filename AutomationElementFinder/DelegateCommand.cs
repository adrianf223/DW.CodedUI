#region License

/*--------------------------------------------------------------------------------
    Copyright (c) 2012 David Wendland

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
--------------------------------------------------------------------------------*/

#endregion License

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