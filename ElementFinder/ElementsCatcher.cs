using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Threading;
using DW.CodedUI.BasicElements;

namespace ElementFinder
{
    public class ElementsCatcher
    {
        public ElementsCatcher()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            _currentProcessId = Process.GetCurrentProcess().Id;
        }

        private readonly int _currentProcessId;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Dispatcher _dispatcher;
        private bool _quickSearch;

        public event EventHandler<CatchedElementsEventArgs> Catched;

        public bool QuickSearch
        {
            get { return _quickSearch; }
            set
            {
                WaitForTask();
                _quickSearch = value;
            }
        }

        public void BeginCatchElements()
        {
            CancelCurrentTask();

            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            Task.Factory.StartNew(() => CatchElements(cancellationToken), cancellationToken);
        }

        private void CancelCurrentTask()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                WaitForTask();
            }
        }

        private void WaitForTask()
        {
            while (_cancellationTokenSource != null)
                Thread.Sleep(10);
        }

        private void CatchElements(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Notify(null);
                return;
            }

            var position = System.Windows.Forms.Cursor.Position;
            var element = AutomationElement.FromPoint(position);
            if (element.Current.ProcessId == _currentProcessId)
            {
                Notify(null);
                return;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                Notify(null);
                return;
            }

            if (_quickSearch)
            {
                Notify(new AutomationElementInfo(element));
                return;
            }
            // Search childs
            // Search siblings?
        }

        private void Notify(AutomationElementInfo element)
        {
            _cancellationTokenSource = null;
            _dispatcher.Invoke(new Action(() => OnCatched(element)));
        }

        private void OnCatched(AutomationElementInfo element)
        {
            var handler = Catched;
            if (handler != null)
                handler(this, new CatchedElementsEventArgs(element));
        }
    }
}