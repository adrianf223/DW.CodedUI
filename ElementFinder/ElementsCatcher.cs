using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Threading;
using DW.CodedUI;
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
        private readonly Dispatcher _dispatcher;

        public event EventHandler<CatchedElementsEventArgs> Catched;

        public bool QuickSearch { get; set; }

        public void BeginCatchElements()
        {
            Task.Factory.StartNew(CatchElements);
        }

        private void CatchElements()
        {
            try
            {
                var position = System.Windows.Forms.Cursor.Position;
                var element = AutomationElement.FromPoint(position);
                if (element.Current.ProcessId == _currentProcessId)
                {
                    Notify(null);
                    return;
                }

                if (QuickSearch)
                {
                    Notify(new AutomationElementInfo(element));
                    return;
                }

                var tree = UI.GetFullUITree(element);
                Notify(tree);
            }
            catch
            {
                Notify(null);
            }
        }

        private void Notify(AutomationElementInfo element)
        {
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