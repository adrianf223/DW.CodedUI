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
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;

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
        /// <summary>
        /// Searches for an open window
        /// </summary>
        /// <param name="pattern">The search pattern</param>
        /// <param name="windowSearchCondition">How to find the window using the pattern</param>
        /// <param name="stringComparison">How to compare the string (used for a Title search only)</param>
        /// <param name="regexOptions">Options for the regex search for the window (used for the Regex conditions only)</param>
        /// <param name="instance">Which instance has to be used</param>
        /// <param name="timeout">Timeout for searching for a window in milliseconds. If not set the default value is 0</param>
        /// <returns>The found window as a BasicWindow; otherwise null</returns>
        public static BasicWindow Search(string pattern,
                                         WindowSearchCondition windowSearchCondition = WindowSearchCondition.TitleContains,
                                         StringComparison stringComparison = StringComparison.Ordinal,
                                         RegexOptions regexOptions = RegexOptions.None,
                                         int instance = 1,
                                         int timeout = 0)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.Elapsed.TotalMilliseconds >= timeout)
                    return null;

                var foundInstance = 0;
                foreach (var child in BasicElementFinder.GetChildren(AutomationElement.RootElement))
                {
                    if (Matches(child, pattern, windowSearchCondition, stringComparison, regexOptions) && ++foundInstance == instance)
                    {
                        return child != null ? new BasicWindow(child) : null;
                    }
                }
                Thread.Sleep(200);
            }
        }

        internal static BasicWindow SearchByProcessId(int processId, int timeout)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.Elapsed.TotalMilliseconds >= timeout)
                    return null;

                foreach (var child in BasicElementFinder.GetChildren(AutomationElement.RootElement))
                {
                    if (child.Current.ProcessId == processId)
                        return new BasicWindow(child);
                }
                Thread.Sleep(200);
            }
            return null;
        }

        private static bool Matches(AutomationElement automationElement,
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
                    return TitleMatches(automationElement, pattern, windowSearchCondition, stringComparison, regexOptions);
                case WindowSearchCondition.ProcessContains:
                case WindowSearchCondition.ProcessEquals:
                case WindowSearchCondition.ProcessRegex:
                    return ProcessMatches(automationElement, pattern, windowSearchCondition, stringComparison, regexOptions);
            }
            return false;
        }

        private static bool TitleMatches(AutomationElement automationElement,
                                         string pattern,
                                         WindowSearchCondition windowSearchCondition,
                                         StringComparison stringComparison,
                                         RegexOptions regexOptions)
        {
            switch (windowSearchCondition)
            {
                case WindowSearchCondition.TitleContains:
                    return automationElement.Current.Name.Contains(pattern);
                case WindowSearchCondition.TitleEquals:
                    return automationElement.Current.Name.Equals(pattern, stringComparison);
                case WindowSearchCondition.TitleRegex:
                    return Regex.IsMatch(automationElement.Current.Name, pattern, regexOptions);
            }
            return false;
        }

        private static bool ProcessMatches(AutomationElement automationElement,
                                           string pattern,
                                           WindowSearchCondition windowSearchCondition,
                                           StringComparison stringComparison,
                                           RegexOptions regexOptions)
        {
            var process = Process.GetProcessById(automationElement.Current.ProcessId);
            switch (windowSearchCondition)
            {
                case WindowSearchCondition.ProcessContains:
                    return process.ProcessName.Contains(pattern);
                case WindowSearchCondition.ProcessEquals:
                    return process.ProcessName.Equals(pattern, stringComparison);
                case WindowSearchCondition.ProcessRegex:
                    return Regex.IsMatch(process.ProcessName, pattern, regexOptions);
            }
            return false;
        }
    }
}
