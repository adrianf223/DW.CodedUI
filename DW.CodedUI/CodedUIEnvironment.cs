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
        }

        /// <summary>
        /// Holds global settings to be used at runtime in the <see cref="DW.CodedUI.Utilities.DynamicSleep" />.
        /// </summary>
        public static SleepSettingsHolder SleepSettings { get; private set; }

        /// <summary>
        /// Contains global settings to be used at runtime in the <see cref="DW.CodedUI.Utilities.DynamicSleep" />.
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
            /// The default time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait()" />.
            /// </summary>
            public Time Default { get; set; }

            /// <summary>
            /// The very short time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int VeryShort { get; set; }

            /// <summary>
            /// The short time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int Short { get; set; }

            /// <summary>
            /// The medium time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int Medium { get; set; }

            /// <summary>
            /// The long time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int Long { get; set; }

            /// <summary>
            /// The very long time to be used in the <see cref="DW.CodedUI.Utilities.DynamicSleep.Wait(Time)" />.
            /// </summary>
            public int VeryLong { get; set; }
        }

        internal static BasicWindow LastWindow { get; set; }
    }
}
