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
using System.IO;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;

namespace DW.CodedUI
{
    /// <summary>
    /// Holds global settings to be used at runtime of the DW.CodedUI.
    /// </summary>
    public static class CodedUIEnvironment
    {
        static CodedUIEnvironment()
        {
            SleepSettings = new SleepSettingsHolder();
            DefaultSettings = new DefaultSettingsHolder();
            ListenerSettings = new ListenerSettingsHolder();
            LoggerSettings = new LoggerSettingsHolder();
        }

        /// <summary>
        /// Holds global settings to be used at runtime in the <see cref="DW.CodedUI.Utilities.DynamicSleep" />.
        /// </summary>
        public static SleepSettingsHolder SleepSettings { get; private set; }

        /// <summary>
        /// Holds the global default settings to be used at runtime in the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" />.
        /// </summary>
        public static DefaultSettingsHolder DefaultSettings { get; private set; }

        /// <summary>
        /// Holds the global settings to be used in the <see cref="DW.CodedUI.Utilities.ElementListener" /> and <see cref="DW.CodedUI.Utilities.WindowListener" />.
        /// </summary>
        public static ListenerSettingsHolder ListenerSettings { get; private set; }

        /// <summary>
        /// Holds the settings of the activity logs. See <see cref="DW.CodedUI.Utilities.LogWriter" />.
        /// </summary>
        public static LoggerSettingsHolder LoggerSettings { get; set; }

        /// <summary>
        /// Contains global time settings to be used at runtime in the <see cref="DW.CodedUI.Utilities.DynamicSleep" />.
        /// </summary>
        public class SleepSettingsHolder
        {
            internal SleepSettingsHolder()
            {
                VeryShort = 500;
                Short = 1000;
                Medium = 1500;
                Long = 2000;
                VeryLong = 2500;

                Default = Time.Medium;
            }

            /// <summary>
            /// Gets or sets the  default time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait()" />. The default value is <see cref="DW.CodedUI.Utilities.Time.Medium" />.
            /// </summary>
            public Time Default { get; set; }

            /// <summary>
            /// Gets or sets the very short time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />. The default value is 500 milliseconds.
            /// </summary>
            public int VeryShort { get; set; }

            /// <summary>
            /// Gets or sets the short time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />. The default value is 1000 milliseconds.
            /// </summary>
            public int Short { get; set; }

            /// <summary>
            /// Gets or sets the medium time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />. The default value is 1500 milliseconds.
            /// </summary>
            public int Medium { get; set; }

            /// <summary>
            /// Gets or sets the long time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />. The default value is 2000 milliseconds.
            /// </summary>
            public int Long { get; set; }

            /// <summary>
            /// Gets or sets the very long time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />. The default value is 2500 milliseconds.
            /// </summary>
            public int VeryLong { get; set; }
        }

        /// <summary>
        /// Contains global default settings to be used at runtime in the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" />.
        /// </summary>
        public class DefaultSettingsHolder
        {
            internal DefaultSettingsHolder()
            {
                TimeoutTime = 10000;
                IntervalTime = 200;
                Timeout = InExclude.With;
                Assert = InExclude.With;
                Interval = InExclude.Without;
            }

            /// <summary>
            /// Gets or sets a value that indicates the timeout in milliseconds to be used in the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> if Timeout is set to InExclude.With. The default is 10000 milliseconds.
            /// </summary>
            public uint TimeoutTime { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates the interval in milliseconds to be used in the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> if Interval is set to InExclude.With. The default is 200 milliseconds.
            /// </summary>
            public uint IntervalTime { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates if the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> has a Timeout on default or not. The default is <see cref="DW.CodedUI.Utilities.InExclude.With" />.
            /// </summary>
            public InExclude Timeout { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates if the default settings of the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> will assert the search result or not. The default is <see cref="DW.CodedUI.Utilities.InExclude.With" />.
            /// </summary>
            public InExclude Assert { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates if if the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> has a Intervall on default or not. The default is <see cref="DW.CodedUI.Utilities.InExclude.Without" />.
            /// </summary>
            public InExclude Interval { get; set; }
        }

        /// <summary>
        /// Contains global settings to be used in the <see cref="DW.CodedUI.Utilities.ElementListener" /> and <see cref="DW.CodedUI.Utilities.WindowListener" />.
        /// </summary>
        public class ListenerSettingsHolder
        {
            internal ListenerSettingsHolder()
            {
                CheckInverval = TimeSpan.FromSeconds(1);
                AsyncEventInvoke = false;
            }

            /// <summary>
            /// Gets or sets a value that indicates in which intervall the object states will be checked. The default is one second.
            /// </summary>
            public TimeSpan CheckInverval { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates of the events in the listeners should be invoked asynchronously or not.
            /// </summary>
            public bool AsyncEventInvoke { get; set; }
        }

        /// <summary>
        /// Contains the settings used for the activity logs. See <see cref="DW.CodedUI.Utilities.LogWriter" />.
        /// </summary>
        public class LoggerSettingsHolder
        {
            private string _logFilesDirectory;

            internal LoggerSettingsHolder()
            {
                IsEnabled = false;
                LogFilesDirectory = Path.Combine(Path.GetTempPath(), "DWCodedUI", Guid.NewGuid().ToString());
                LogPassedTestsToo = false;
                AddTestResultToFileName = false;
            }

            /// <summary>
            /// Gets or sets a value that indicates if the activity logging is enabled or not. The default is false.
            /// </summary>
            public bool IsEnabled { get; set; }

            /// <summary>
            /// Gets or sets the directory where the log files got created. If not changed %temp%\DWCodedUI\[Guid]\ will be used.
            /// </summary>
            /// <remarks>When the directoy will be set the IsEnabled will be set to true automatically. Call IsEnabled = False afterwards to deactivate the logging.</remarks>
            public string LogFilesDirectory
            {
                get { return _logFilesDirectory; }
                set
                {
                    _logFilesDirectory = value;
                    IsEnabled = true;
                }
            }

            /// <summary>
            /// Gets or sets a value that indicates if tests should be loggen also when they passed. The default is false.
            /// </summary>
            public bool LogPassedTestsToo { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates if the result file name should start with the result of the test. The default is false.
            /// </summary>
            public bool AddTestResultToFileName { get; set; }
        }

        internal static BasicWindow LastWindow { get; set; }
    }
}
