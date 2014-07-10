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
        }

        /// <summary>
        /// Holds global settings to be used at runtime in the <see cref="DW.CodedUI.Utilities.DynamicSleep" />.
        /// </summary>
        public static SleepSettingsHolder SleepSettings { get; private set; }
        public static DefaultSettingsHolder DefaultSettings { get; private set; }

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
            /// Gets or sets the  default time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait()" />.
            /// </summary>
            public Time Default { get; set; }

            /// <summary>
            /// Gets or sets the very short time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int VeryShort { get; set; }

            /// <summary>
            /// Gets or sets the short time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int Short { get; set; }

            /// <summary>
            /// Gets or sets the medium time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int Medium { get; set; }

            /// <summary>
            /// Gets or sets the long time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int Long { get; set; }

            /// <summary>
            /// Gets or sets the very long time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
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
                Assert = InExclude.Without;
                Interval = InExclude.Without;
            }

            /// <summary>
            /// Gets or sets a value that indicates the timeout in milliseconds to be used in the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> if Timeout is set to InExclude.With.
            /// </summary>
            public uint TimeoutTime { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates the interval in milliseconds to be used in the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> if Interval is set to InExclude.With.
            /// </summary>
            public uint IntervalTime { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates if the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> has a Timeout on default or not.
            /// </summary>
            public InExclude Timeout { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates if the default settings of the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> will assert the search result or not.
            /// </summary>
            public InExclude Assert { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates if if the <see cref="DW.CodedUI.UI" /> or <see cref="DW.CodedUI.WindowFinder" /> has a Intervall on default or not.
            /// </summary>
            public InExclude Interval { get; set; }
        }

        internal static BasicWindow LastWindow { get; set; }
    }
}
