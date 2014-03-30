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

        public void BeginCatchElements()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                while (_cancellationTokenSource != null)
                    Thread.Sleep(10);
            }

            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            Task.Factory.StartNew(() => CatchElements(cancellationToken), cancellationToken);
        }

        private readonly int _currentProcessId;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Dispatcher _dispatcher;

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
            Notify(new AutomationElementInfo(element));
        }

        private void Notify(AutomationElementInfo element)
        {
            _cancellationTokenSource = null;
            _dispatcher.Invoke(new Action(() => OnCatched(element)));
        }

        public event EventHandler<CatchedElementsEventArgs> Catched;

        private void OnCatched(AutomationElementInfo element)
        {
            var handler = Catched;
            if (handler != null)
                handler(this, new CatchedElementsEventArgs(element));
        }
    }
}