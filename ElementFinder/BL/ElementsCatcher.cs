#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2014 David Wendland

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
THE SOFTWARE
*/
#endregion License

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