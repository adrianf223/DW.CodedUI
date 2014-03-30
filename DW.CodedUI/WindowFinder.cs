using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    public static class WindowFinder
    {
        public static BasicWindow Search(Using use)
        {
            return Search(use, new CombinableAnd());
        }

        public static BasicWindow Search(Using use, And settings)
        {
            var condition = use.GetCondition();
            var settingsConditions = settings.GetConditions();
            var instanceNumber = settings.GetInstanceNumber();
            var timeout = settings.GetTimeout();
            var useTimeout = settingsConditions.Contains(AndCondition.Timeout);
            var assertResult = settingsConditions.Contains(AndCondition.Assert);
            var checkInstance = settingsConditions.Contains(AndCondition.Instance);

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new WindowNotFoundException(use, useTimeout, watch.Elapsed);
                    return null;
                }

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
            }
        }

        public static TWindow Search<TWindow>(Using use) where TWindow : BasicWindowBase
        {
            return Search<TWindow>(use, new CombinableAnd());
        }

        public static TWindow Search<TWindow>(Using use, And settings) where TWindow : BasicWindowBase
        {
            var window = Search(use, settings);
            if (window != null)
                return (TWindow)Activator.CreateInstance(typeof(TWindow), window.AutomationElement);
            return null;
        }

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
