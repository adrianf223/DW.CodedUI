using System;
using System.Collections.Generic;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    public static class WindowFinder
    {
        //#region Old

        //public static BasicWindow GetForegroundWindow()
        //{
        //    var windowHandle = WinApi.GetForegroundWindow();
        //    if (windowHandle == IntPtr.Zero)
        //        return null;
        //    return new BasicWindow(AutomationElement.FromHandle(windowHandle));
        //}

        //public static BasicWindow Search(string pattern,
        //                                 WindowSearchCondition windowSearchCondition = WindowSearchCondition.TitleContains,
        //                                 StringComparison stringComparison = StringComparison.Ordinal,
        //                                 RegexOptions regexOptions = RegexOptions.None,
        //                                 int instance = 1,
        //                                 int timeout = 10000,
        //                                 bool searchInvisibleWindows = false,
        //                                 bool searchWindowsWithoutTitle = false)
        //{
        //    var watch = new Stopwatch();
        //    watch.Start();
        //    while (true)
        //    {
        //        if (watch.Elapsed.TotalMilliseconds >= timeout)
        //            return null;

        //        var foundInstance = 0;
        //        var windows = GetAllWindows(searchInvisibleWindows, searchWindowsWithoutTitle);
        //        foreach (var window in windows)
        //        {
        //            if (Matches(window, pattern, windowSearchCondition, stringComparison, regexOptions) && ++foundInstance == instance)
        //                return new BasicWindow(AutomationElement.FromHandle(window.Key));
        //        }
        //        Thread.Sleep(200);
        //    }
        //}

        //public static BasicOpenFileDialog SearchOpenFileDialog(string pattern,
        //                                                       WindowSearchCondition windowSearchCondition = WindowSearchCondition.TitleContains,
        //                                                       StringComparison stringComparison = StringComparison.Ordinal,
        //                                                       RegexOptions regexOptions = RegexOptions.None,
        //                                                       int instance = 1,
        //                                                       int timeout = 10000)
        //{
        //    var window = Search(pattern, windowSearchCondition, stringComparison, regexOptions, instance, timeout);
        //    if (window != null)
        //        return new BasicOpenFileDialog(window.AutomationElement);
        //    return null;
        //}

        //#endregion Old

        public static BasicWindow Search(Using use, AndSetting settings)
        {
            return null;
        }

        //private static Dictionary<IntPtr, string> GetAllWindows(bool searchInvisibleWindows, bool searchWindowsWithoutTitle)
        //{
        //    var collection = new Dictionary<IntPtr, string>();
        //    WinApi.EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
        //    {
        //        if (searchInvisibleWindows || WinApi.IsWindowVisible(hWnd))
        //        {
        //            var strbTitle = new StringBuilder(255);
        //            WinApi.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
        //            var strTitle = strbTitle.ToString();
        //            if (searchWindowsWithoutTitle || !string.IsNullOrEmpty(strTitle))
        //                collection[hWnd] = strTitle;
        //        }
        //        return true;
        //    };
        //    WinApi.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero);
        //    return collection;
        //}

        //private static bool Matches(KeyValuePair<IntPtr, string> window,
        //                            string pattern,
        //                            WindowSearchCondition windowSearchCondition,
        //                            StringComparison stringComparison,
        //                            RegexOptions regexOptions)
        //{
        //    switch (windowSearchCondition)
        //    {
        //        case WindowSearchCondition.TitleContains:
        //        case WindowSearchCondition.TitleEquals:
        //        case WindowSearchCondition.TitleRegex:
        //            return TitleMatches(window, pattern, windowSearchCondition, stringComparison, regexOptions);
        //        case WindowSearchCondition.ProcessContains:
        //        case WindowSearchCondition.ProcessEquals:
        //        case WindowSearchCondition.ProcessRegex:
        //        case WindowSearchCondition.ProcessId:
        //            return ProcessMatches(window, pattern, windowSearchCondition, stringComparison, regexOptions);
        //    }
        //    return false;
        //}

        //private static bool TitleMatches(KeyValuePair<IntPtr, string> window,
        //                                 string pattern,
        //                                 WindowSearchCondition windowSearchCondition,
        //                                 StringComparison stringComparison,
        //                                 RegexOptions regexOptions)
        //{
        //    switch (windowSearchCondition)
        //    {
        //        case WindowSearchCondition.TitleContains:
        //            return window.Value.Contains(pattern);
        //        case WindowSearchCondition.TitleEquals:
        //            return window.Value.Equals(pattern, stringComparison);
        //        case WindowSearchCondition.TitleRegex:
        //            return Regex.IsMatch(window.Value, pattern, regexOptions);
        //    }
        //    return false;
        //}

        //private static bool ProcessMatches(KeyValuePair<IntPtr, string> window,
        //                                   string pattern,
        //                                   WindowSearchCondition windowSearchCondition,
        //                                   StringComparison stringComparison,
        //                                   RegexOptions regexOptions)
        //{
        //    var process = GetProcessByWindowHandle(window.Key);
        //    switch (windowSearchCondition)
        //    {
        //        case WindowSearchCondition.ProcessContains:
        //            return process.ProcessName.Contains(pattern);
        //        case WindowSearchCondition.ProcessEquals:
        //            return process.ProcessName.Equals(pattern, stringComparison);
        //        case WindowSearchCondition.ProcessRegex:
        //            return Regex.IsMatch(process.ProcessName, pattern, regexOptions);
        //        case WindowSearchCondition.ProcessId:
        //            return process.Id.ToString(CultureInfo.InvariantCulture).Equals(pattern, stringComparison);
        //    }
        //    return false;
        //}

        //private static Process GetProcessByWindowHandle(IntPtr hWnd)
        //{
        //    uint processId = 0;
        //    WinApi.GetWindowThreadProcessId(hWnd, out processId);
        //    return Process.GetProcessById((int)processId);
        //}
    }

    public class Using
    {
        public static CombinableUsing Title(string title)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Title(title);
        }

        public static CombinableUsing Title(string title, CompareKind comparison)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Title(title, comparison);
        }

        public static CombinableUsing Process(string name)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Process(name);
        }

        public static CombinableUsing Process(string name, CompareKind comparison)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Process(name, comparison);
        }

        public static CombinableUsing Condition(Predicate<BasicWindow> condition)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Condition(condition);
        }
    }

    public class CombinableUsing : Using
    {
        internal CombinableUsing()
        {
            _conditions = new List<Predicate<BasicWindow>>();
            _conditionDescriptions = new List<string>();
        }

        private readonly List<Predicate<BasicWindow>> _conditions;
        private readonly List<string> _conditionDescriptions;
        private bool _isAndCondition;

        public CombinableUsing And
        {
            get
            {
                _isAndCondition = true;
                return this;
            }
        }

        public CombinableUsing Or
        {
            get
            {
                _isAndCondition = false;
                return this;
            }
        }

        public new CombinableUsing Title(string title)
        {
            return Title(title, CompareKind.ContainsIgnoreCase);
        }

        public new CombinableUsing Title(string title, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.Title, title, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.Title, {0}, {1})", title, comparison));

            return this;
        }

        public new CombinableUsing Process(string name)
        {
            return Process(name, CompareKind.ContainsIgnoreCase);
        }

        public new CombinableUsing Process(string name, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.OwningProcess.ProcessName, name, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.OwningProcess.ProcessName, {0}, {1})", name, comparison));
            return this;
        }

        public new CombinableUsing Condition(Predicate<BasicWindow> condition)
        {
            _conditions.Add(condition);
            _conditionDescriptions.Add("condition(element)");
            return this;
        }
    }

    public class AndSetting
    {
        public static CombinableAndSetting Timeout(uint milliseconds)
        {
            var combinableAndSetting = new CombinableAndSetting();
            return combinableAndSetting.Timeout(milliseconds);
        }

        public static CombinableAndSetting NoTimeout()
        {
            var combinableAndSetting = new CombinableAndSetting();
            return combinableAndSetting.NoTimeout();
        }

        public static CombinableAndSetting Assert()
        {
            var combinableAndSetting = new CombinableAndSetting();
            return combinableAndSetting.Assert();
        }

        public static CombinableAndSetting NoAssert()
        {
            var combinableAndSetting = new CombinableAndSetting();
            return combinableAndSetting.NoAssert();
        }

        public static CombinableAndSetting InstanceNumber(uint instanceNumber)
        {
            var combinableAndSetting = new CombinableAndSetting();
            return combinableAndSetting.InstanceNumber(instanceNumber);
        }
    }

    public class CombinableAndSetting : AndSetting
    {
        internal CombinableAndSetting()
        {
            _conditions = new List<AndSettingCondition>();
        }

        private List<AndSettingCondition> _conditions;
        private uint _timeOut;
        private uint _instanceNumber;

        public CombinableAndSetting And
        {
            get { return this; }
        }

        public new CombinableAndSetting Timeout(uint milliseconds)
        {
            _timeOut = milliseconds;
            if (!_conditions.Contains(AndSettingCondition.Timeout))
                _conditions.Add(AndSettingCondition.Timeout);
            return this;
        }

        public new CombinableAndSetting NoTimeout()
        {
            if (!_conditions.Contains(AndSettingCondition.NoTimeout))
                _conditions.Add(AndSettingCondition.NoTimeout);
            return this;
        }

        public new CombinableAndSetting Assert()
        {
            if (!_conditions.Contains(AndSettingCondition.Assert))
                _conditions.Add(AndSettingCondition.Assert);
            return this;
        }

        public new CombinableAndSetting NoAssert()
        {
            if (!_conditions.Contains(AndSettingCondition.NoAssert))
                _conditions.Add(AndSettingCondition.NoAssert);
            return this;
        }

        public new CombinableAndSetting InstanceNumber(uint instanceNumber)
        {
            _instanceNumber = instanceNumber;
            if (!_conditions.Contains(AndSettingCondition.Instance))
                _conditions.Add(AndSettingCondition.Instance);
            return this;
        }
    }

    public enum AndSettingCondition
    {
        Timeout,
        NoTimeout,
        Instance,
        Assert,
        NoAssert
    }

    public enum CompareKind
    {
        Exact,
        Contains,
        StartsWith,
        EndsWith,
        ExactIgnoreCase,
        ContainsIgnoreCase,
        StartsWithIgnoreCase,
        EndsWithIgnoreCase,
    }
}
