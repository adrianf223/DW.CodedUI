using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI.UITree
{
    public static class WindowFinder
    {
        private static Dictionary<IntPtr, string> GetAllWindows(bool searchInvisibleWindows, bool searchWindowsWithoutTitle)
        {
            var collection = new Dictionary<IntPtr, string>();
            WinApi.EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
            {
                if (searchInvisibleWindows || WinApi.IsWindowVisible(hWnd))
                {
                    var strbTitle = new StringBuilder(255);
                    WinApi.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
                    var strTitle = strbTitle.ToString();
                    if (searchWindowsWithoutTitle || !string.IsNullOrEmpty(strTitle))
                        collection[hWnd] = strTitle;
                }
                return true;
            };
            WinApi.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero);
            return collection;
        }

        public static BasicWindow GetForegroundWindow()
        {
            var windowHandle = WinApi.GetForegroundWindow();
            if (windowHandle == IntPtr.Zero)
                return null;
            return new BasicWindow(AutomationElement.FromHandle(windowHandle));
        }

        public static BasicWindow Search(string pattern,
                                         WindowSearchCondition windowSearchCondition = WindowSearchCondition.TitleContains,
                                         StringComparison stringComparison = StringComparison.Ordinal,
                                         RegexOptions regexOptions = RegexOptions.None,
                                         int instance = 1,
                                         int timeout = 10000,
                                         bool searchInvisibleWindows = false,
                                         bool searchWindowsWithoutTitle = false)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.Elapsed.TotalMilliseconds >= timeout)
                    return null;

                var foundInstance = 0;
                var windows = GetAllWindows(searchInvisibleWindows, searchWindowsWithoutTitle);
                foreach (var window in windows)
                {
                    if (Matches(window, pattern, windowSearchCondition, stringComparison, regexOptions) && ++foundInstance == instance)
                        return new BasicWindow(AutomationElement.FromHandle(window.Key));
                }
                Thread.Sleep(200);
            }
        }

        public static BasicOpenFileDialog SearchOpenFileDialog(string pattern,
                                                               WindowSearchCondition windowSearchCondition = WindowSearchCondition.TitleContains,
                                                               StringComparison stringComparison = StringComparison.Ordinal,
                                                               RegexOptions regexOptions = RegexOptions.None,
                                                               int instance = 1,
                                                               int timeout = 10000)
        {
            var window = Search(pattern, windowSearchCondition, stringComparison, regexOptions, instance, timeout);
            if (window != null)
                return new BasicOpenFileDialog(window.AutomationElement);
            return null;
        }

        private static bool Matches(KeyValuePair<IntPtr, string> window,
                                    string pattern,
                                    WindowSearchCondition windowSearchCondition,
                                    StringComparison stringComparison,
                                    RegexOptions regexOptions)
        {
            switch (windowSearchCondition)
            {
                case WindowSearchCondition.TitleContains:
                case WindowSearchCondition.TitleEquals:
                case WindowSearchCondition.TitleRegex:
                    return TitleMatches(window, pattern, windowSearchCondition, stringComparison, regexOptions);
                case WindowSearchCondition.ProcessContains:
                case WindowSearchCondition.ProcessEquals:
                case WindowSearchCondition.ProcessRegex:
                case WindowSearchCondition.ProcessId:
                    return ProcessMatches(window, pattern, windowSearchCondition, stringComparison, regexOptions);
            }
            return false;
        }

        private static bool TitleMatches(KeyValuePair<IntPtr, string> window,
                                         string pattern,
                                         WindowSearchCondition windowSearchCondition,
                                         StringComparison stringComparison,
                                         RegexOptions regexOptions)
        {
            switch (windowSearchCondition)
            {
                case WindowSearchCondition.TitleContains:
                    return window.Value.Contains(pattern);
                case WindowSearchCondition.TitleEquals:
                    return window.Value.Equals(pattern, stringComparison);
                case WindowSearchCondition.TitleRegex:
                    return Regex.IsMatch(window.Value, pattern, regexOptions);
            }
            return false;
        }

        private static bool ProcessMatches(KeyValuePair<IntPtr, string> window,
                                           string pattern,
                                           WindowSearchCondition windowSearchCondition,
                                           StringComparison stringComparison,
                                           RegexOptions regexOptions)
        {
            var process = GetProcessByWindowHandle(window.Key);
            switch (windowSearchCondition)
            {
                case WindowSearchCondition.ProcessContains:
                    return process.ProcessName.Contains(pattern);
                case WindowSearchCondition.ProcessEquals:
                    return process.ProcessName.Equals(pattern, stringComparison);
                case WindowSearchCondition.ProcessRegex:
                    return Regex.IsMatch(process.ProcessName, pattern, regexOptions);
                case WindowSearchCondition.ProcessId:
                    return process.Id.ToString(CultureInfo.InvariantCulture).Equals(pattern, stringComparison);
            }
            return false;
        }

        private static Process GetProcessByWindowHandle(IntPtr hWnd)
        {
            uint processId = 0;
            WinApi.GetWindowThreadProcessId(hWnd, out processId);
            return Process.GetProcessById((int)processId);
        }
    }
}
