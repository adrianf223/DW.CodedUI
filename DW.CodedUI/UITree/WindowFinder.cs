#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.UITree
{
    /// <summary>
    /// Brings a method to find an open window
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Method_TestCondition_ExpectedResult()
    /// {
    ///     var window = WindowFinder.Search<BasicCheckBox>("title", WindowSearchCondition.TitleContains,StringComparison.OrdinalIgnoreCase);
    ///     Assert.IsNotNull(window);
    /// 
    ///     WindowFocus.BringOnTop(window);
    /// 
    ///     // Do any other stuff with the window
    /// 
    ///     window.Unsafe.Close();
    /// }]]>
    /// </code>
    /// </example>
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

        /// <summary>
        /// Gets the foreground window
        /// </summary>
        /// <returns>The foreground window as a BasicWindow; otherwise null</returns>
        public static BasicWindow GetForegroundWindow()
        {
            var windowHandle = WinApi.GetForegroundWindow();
            if (windowHandle == IntPtr.Zero)
                return null;
            return new BasicWindow(AutomationElement.FromHandle(windowHandle));
        }

        /// <summary>
        /// Searches for an open window
        /// </summary>
        /// <param name="pattern">The search pattern</param>
        /// <param name="windowSearchCondition">How to find the window using the pattern</param>
        /// <param name="stringComparison">How to compare the string (used for a Title search only)</param>
        /// <param name="regexOptions">Options for the regex search for the window (used for the Regex conditions only)</param>
        /// <param name="instance">Which instance has to be used</param>
        /// <param name="timeout">Timeout for searching for a window in milliseconds</param>
        /// <param name="searchInvisibleWindows">Defines if invisible windows should be found as well</param>
        /// <param name="searchWindowsWithoutTitle">Defines if the window must have a title</param>
        /// <returns>The found window as a BasicWindow; otherwise null</returns>
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
