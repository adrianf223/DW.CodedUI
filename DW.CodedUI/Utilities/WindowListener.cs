#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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
using System.Linq;
using System.Text;
using DW.CodedUI.Internal;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Brings possibilities to observe the system to get events if something with the windows happened.
    /// </summary>
    public class WindowListener : Listener
    {
        private List<WindowInfo> _startWindowStates;
        private WindowFilters _filters; 

        /// <summary>
        /// Occurs when a window is opened.
        /// </summary>
        public event EventHandler<WindowChangedEventArgs> WindowOpened;

        /// <summary>
        /// Occurs when a window is closed.
        /// </summary>
        public event EventHandler<WindowChangedEventArgs> WindowClosed;

        /// <summary>
        /// Occurs when the visibility of a window has been changed.
        /// </summary>
        public event EventHandler<WindowChangedEventArgs> WindowVisibilityChanged;

        /// <summary>
        /// Occurs when the title of a window has been changed.
        /// </summary>
        public event EventHandler<WindowChangedEventArgs> WindowTitleChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.Utilities.WindowListener" /> class.
        /// </summary>
        public WindowListener()
        {
            _startWindowStates = new List<WindowInfo>();
        }
        
        /// <summary>
        /// Gets or sets values which indicates which properties of the <see cref="DW.CodedUI.BasicElements.BasicElement" /> should be observed.
        /// </summary>
        public WindowFilters Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;
                SetChecks();
            }
        }

        /// <summary>
        /// Starts observing of the system windows. To say what exactly see <see cref="DW.CodedUI.Utilities.WindowListener.Filters" />.
        /// </summary>
        public override void Start()
        {
            _startWindowStates = GetOpenWindows();
            
            base.Start();
        }

        /// <summary>
        /// Stopps observing of the system windows.
        /// </summary>
        /// <remarks>The <see cref="DW.CodedUI.Utilities.ElementListener.Filters" /> will not be resetted.</remarks>
        public override void Stop()
        {
            _startWindowStates.Clear();
            
            base.Stop();
        }

        /// <summary>
        /// All checks are done and the current window states can be taken.
        /// </summary>
        protected override void ChecksOver()
        {
            _startWindowStates = GetOpenWindows();
        }

        private void SetChecks()
        {
            _checks.Clear();

            if (Filters.HasFlag(WindowFilters.Opened))
                SetWindowOpenedCheck();
            if (Filters.HasFlag(WindowFilters.Closed))
                SetWindowClosedCheck();
            if (Filters.HasFlag(WindowFilters.VisibilityChanged))
                SetWindowVisibilityChangedCheck();
            if (Filters.HasFlag(WindowFilters.TitleChanged))
                SetWindowTitleChangedCheck();
        }

        private void SetWindowOpenedCheck()
        {
            var condition = new Action(() =>
            {
                var knownOpenWindows = _startWindowStates.ToList();
                var openWindows = GetOpenWindows();

                var openedWindows = openWindows.Except(knownOpenWindows).ToList();
                foreach (var openedWindow in openedWindows)
                    OnWindowOpened(openedWindow);
            });
            _checks.Add(condition);
        }

        private void SetWindowClosedCheck()
        {
            var condition = new Action(() =>
            {
                var knownOpenWindows = _startWindowStates.ToList();
                var openWindows = GetOpenWindows();
                _startWindowStates = openWindows;

                var closedWindows = knownOpenWindows.Except(openWindows).ToList();
                foreach (var closedWindow in closedWindows)
                    OnWindowClosed(closedWindow);
            });
            _checks.Add(condition);
        }

        private void SetWindowVisibilityChangedCheck()
        {
            var condition = new Action(() =>
            {
                var knownOpenWindows = _startWindowStates.ToList();
                var openWindows = GetOpenWindows();

                foreach (var openWindow in openWindows)
                {
                    var knownOpenWindow = knownOpenWindows.FirstOrDefault(w => w.Equals(openWindow));
                    if (knownOpenWindow == null)
                        continue;

                    if (knownOpenWindow.IsVisible != openWindow.IsVisible)
                        OnWindowVisibilityChanged(knownOpenWindow, openWindow);
                }
            });
            _checks.Add(condition);
        }

        private void SetWindowTitleChangedCheck()
        {
            var condition = new Action(() =>
            {
                var knownOpenWindows = _startWindowStates.ToList();
                var openWindows = GetOpenWindows();
                _startWindowStates = openWindows;

                foreach (var openWindow in openWindows)
                {
                    var knownOpenWindow = knownOpenWindows.FirstOrDefault(w => w.Equals(openWindow));
                    if (knownOpenWindow == null)
                        continue;

                    if (knownOpenWindow.Title != openWindow.Title)
                        OnWindowTitleChanged(knownOpenWindow, openWindow);
                }
            });
            _checks.Add(condition);
        }

        private List<WindowInfo> GetOpenWindows()
        {
            var collection = new List<WindowInfo>();
            WinApi.EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
            {
                var strbTitle = new StringBuilder(255);
                WinApi.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);

                var windowInfo = new WindowInfo();
                windowInfo.Handle = hWnd;
                windowInfo.IsVisible = WinApi.IsWindowVisible(hWnd);
                windowInfo.Title = strbTitle.ToString();
                collection.Add(windowInfo);

                return true;
            };
            WinApi.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero);
            return collection;
        }

        private void OnWindowOpened(WindowInfo newWindowInfo)
        {
            var handler = WindowOpened;
            if (handler != null)
                handler(this, new WindowChangedEventArgs(WindowChangeKind.Opened, null, newWindowInfo));
        }

        private void OnWindowClosed(WindowInfo oldWindowInfo)
        {
            var handler = WindowClosed;
            if (handler != null)
                handler(this, new WindowChangedEventArgs(WindowChangeKind.Closed, oldWindowInfo, null));
        }

        private void OnWindowVisibilityChanged(WindowInfo oldWindowInfo, WindowInfo newWindowInfo)
        {
            var handler = WindowVisibilityChanged;
            if (handler != null)
                handler(this, new WindowChangedEventArgs(WindowChangeKind.VisibleStateChanged, oldWindowInfo, newWindowInfo));
        }

        private void OnWindowTitleChanged(WindowInfo oldWindowInfo, WindowInfo newWindowInfo)
        {
            var handler = WindowTitleChanged;
            if (handler != null)
                handler(this, new WindowChangedEventArgs(WindowChangeKind.TitleChanged, oldWindowInfo, newWindowInfo));
        }
    }
}
