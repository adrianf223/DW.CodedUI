using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Documents;
using System.Windows.Threading;
using DW.CodedUI;
using DW.CodedUI.BasicElements;
using ElementFinder.Properties;

namespace ElementFinder.BL
{
    public class ElementsCatcher
    {
        public ElementsCatcher()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            _currentProcessId = Process.GetCurrentProcess().Id;

            UpdateBlacklist();
        }

        private List<string> _blackListesProcesses;
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
                if (element.Current.ProcessId == _currentProcessId ||
                    IsBlackListed(element.Current.ProcessId))
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

        private bool IsBlackListed(int processId)
        {
            var processName = Process.GetProcessById(processId).ProcessName.ToLower();
            return _blackListesProcesses.Any(processName.Contains);
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

        public void UpdateBlacklist()
        {
            _blackListesProcesses = new List<string>(Settings.Default.BlacklistedProcesses.Split(',').Select(i => i.Trim().ToLower()));
        }
    }
}