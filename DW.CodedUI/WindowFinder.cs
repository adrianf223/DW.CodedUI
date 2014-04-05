using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Searches for Windows, Dialogs or MessageBoxes.
    /// </summary>
    public static class WindowFinder
    {
        /// <summary>
        /// Searches for a window by the given conditions. Default settings are And.Assert().And.Timeout(10000).
        /// </summary>
        /// <param name="use">Defines the conditions to be used for searching for a window.</param>
        /// <returns>The found window if any; otherwise an exception is shown.</returns>
        /// <exception cref="DW.CodedUI.WindowNotFoundException">The window could not be found.</exception>
        public static BasicWindow Search(Using use)
        {
            return Search(use, new CombinableAnd());
        }

        /// <summary>
        /// Searches for a window by the given conditions and settings. If not disabled And.Assert().And.Timeout(10000) gets appended.
        /// </summary>
        /// <param name="use">Defines the conditions to be used for searching for a window.</param>
        /// <param name="settings">Defines the settings to be used while searching.</param>
        /// <returns>The found window if any; otherwise an exception as long its not disabled by And.NoAssert(). If its disabled the return is null.</returns>
        /// <exception cref="DW.CodedUI.WindowNotFoundException">The window could not be found. (If not disabled.)</exception>
        public static BasicWindow Search(Using use, And settings)
        {
            var condition = use.GetCondition();
            var settingsConditions = settings.GetConditions();
            var instanceNumber = settings.GetInstanceNumber();
            var timeout = settings.GetTimeout();
            var useTimeout = settingsConditions.Contains(AndCondition.Timeout);
            var assertResult = settingsConditions.Contains(AndCondition.Assert);
            var checkInstance = settingsConditions.Contains(AndCondition.Instance);
            var useInterval = settingsConditions.Contains(AndCondition.Interval);
            var interval = settings.GetInterval();

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                var foundInstance = 0;
                var windows = GetAllWindows();
                foreach (var window in windows)
                {
                    var matchingWindow = Matches(window, condition);
                    if (matchingWindow == null)
                        continue;

                    if (!checkInstance || ++foundInstance == instanceNumber)
                        return matchingWindow;
                }

                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new WindowNotFoundException(use, useTimeout, useInterval, interval, watch.Elapsed);
                    return null;
                }

                if (useInterval)
                    Thread.Sleep((int)interval);
            }
        }

        /// <summary>
        /// Searches for window kinds like Window, MessageBox or system dialogs. Default settings are And.Assert().And.Timeout(10000).
        /// </summary>
        /// <typeparam name="TWindow">The type of window to be created.</typeparam>
        /// <param name="use">Defines the conditions to be used for searching for a window.</param>
        /// <returns>The found window if any; otherwise an exception is shown.</returns>
        /// <exception cref="DW.CodedUI.WindowNotFoundException">The window could not be found.</exception>
        public static TWindow Search<TWindow>(Using use) where TWindow : BasicWindowBase
        {
            return Search<TWindow>(use, new CombinableAnd());
        }

        /// <summary>
        /// Searches for window kinds like Window, MessageBox or system dialogs. If not disabled And.Assert().And.Timeout(10000) gets appended.
        /// </summary>
        /// <typeparam name="TWindow">The type of window to be created.</typeparam>
        /// <param name="use">Defines the conditions to be used for searching for a window.</param>
        /// <param name="settings">Defines the settings to be used while searching.</param>
        /// <returns>The found window if any; otherwise an exception as long its not disabled by And.NoAssert(). If its disabled the return is null.</returns>
        /// <exception cref="DW.CodedUI.WindowNotFoundException">The window could not be found. (If not disabled.)</exception>
        public static TWindow Search<TWindow>(Using use, And settings) where TWindow : BasicWindowBase
        {
            var window = Search(use, settings);
            if (window != null)
                return (TWindow)Activator.CreateInstance(typeof(TWindow), window.AutomationElement);
            return null;
        }

        /// <summary>
        /// Gets the window which is actually in the foreground.
        /// </summary>
        /// <returns>The found window if any; otherwise null.</returns>
        public static BasicWindow GetForegroundWindow()
        {
            var windowHandle = WinApi.GetForegroundWindow();
            if (windowHandle == IntPtr.Zero)
                return null;
            return new BasicWindow(AutomationElement.FromHandle(windowHandle));
        }

        private static BasicWindow Matches(KeyValuePair<IntPtr, string> window, Predicate<BasicWindow> condition)
        {
            try
            {
                var automationElement = AutomationElement.FromHandle(window.Key);
                var basicWindow = new BasicWindow(automationElement);
                if (basicWindow.IsAvailable && condition(basicWindow))
                    return basicWindow;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        private static Dictionary<IntPtr, string> GetAllWindows()
        {
            var collection = new Dictionary<IntPtr, string>();
            WinApi.EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
            {
                if (WinApi.IsWindowVisible(hWnd))
                {
                    var strbTitle = new StringBuilder(255);
                    WinApi.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
                    var strTitle = strbTitle.ToString();
                    if (!string.IsNullOrEmpty(strTitle))
                        collection[hWnd] = strTitle;
                }
                return true;
            };
            WinApi.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero);
            return collection;
        }
    }
}
