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

        public static BasicMessageBox SearchMessageBox(Using use)
        {
            return SearchMessageBox(use, new CombinableAnd());
        }

        public static BasicMessageBox SearchMessageBox(Using use, And settings)
        {
            var window = Search(use, settings);
            if (window != null)
                return new BasicMessageBox(window.AutomationElement);
            return null;
        }

        public static BasicOpenFileDialog SearchOpenFileDialog(Using use)
        {
            return SearchOpenFileDialog(use, new CombinableAnd());
        }

        public static BasicOpenFileDialog SearchOpenFileDialog(Using use, And settings)
        {
            var window = Search(use, settings);
            if (window != null)
                return new BasicOpenFileDialog(window.AutomationElement);
            return null;
        }

        public static BasicSaveFileDialog SearchSaveFileDialog(Using use)
        {
            return SearchSaveFileDialog(use, new CombinableAnd());
        }

        public static BasicSaveFileDialog SearchSaveFileDialog(Using use, And settings)
        {
            var window = Search(use, settings);
            if (window != null)
                return new BasicSaveFileDialog(window.AutomationElement);
            return null;
        }

        public static BasicBrowseFolderDialog SearchBrowseFolderDialog(Using use)
        {
            return SearchBrowseFolderDialog(use, new CombinableAnd());
        }

        public static BasicBrowseFolderDialog SearchBrowseFolderDialog(Using use, And settings)
        {
            var window = Search(use, settings);
            if (window != null)
                return new BasicBrowseFolderDialog(window.AutomationElement);
            return null;
        }

        public static BasicFontPickerDialog SearchFontPickerDialog(Using use)
        {
            return SearchFontPickerDialog(use, new CombinableAnd());
        }

        public static BasicFontPickerDialog SearchFontPickerDialog(Using use, And settings)
        {
            var window = Search(use, settings);
            if (window != null)
                return new BasicFontPickerDialog(window.AutomationElement);
            return null;
        }

        public static BasicColorPickerDialog SearchColorPickerDialog(Using use)
        {
            return SearchColorPickerDialog(use, new CombinableAnd());
        }

        public static BasicColorPickerDialog SearchColorPickerDialog(Using use, And settings)
        {
            var window = Search(use, settings);
            if (window != null)
                return new BasicColorPickerDialog(window.AutomationElement);
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
