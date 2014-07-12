using System.Threading;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Holds methods for a dynamic sleep.
    /// </summary>
    public static class DynamicSleep
    {
        /// <summary>
        /// Suspends the current thread for a specified time in milliseconds. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.Default.
        /// </summary>
        public static void Wait()
        {
            Wait(CodedUIEnvironment.SleepSettings.Default);
        }

        /// <summary>
        /// Suspends the current thread for a specified time in milliseconds. The time can be adjusted in the <see cref="DW.CodedUI.CodedUIEnvironment.SleepSettings" />.
        /// </summary>
        /// <param name="time">The length of time to suspend.</param>
        public static void Wait(Time time)
        {
            var milliseconds = 0;
            switch (time)
            {
                case Time.VeryShort: milliseconds = CodedUIEnvironment.SleepSettings.VeryShort; break;
                case Time.Short: milliseconds = CodedUIEnvironment.SleepSettings.Short; break;
                case Time.Medium: milliseconds = CodedUIEnvironment.SleepSettings.Medium; break;
                case Time.Long: milliseconds = CodedUIEnvironment.SleepSettings.Long; break;
                case Time.VeryLong: milliseconds = CodedUIEnvironment.SleepSettings.VeryLong; break;
            }
            Wait(milliseconds);
        }

        /// <summary>
        /// Suspends the current thread for a specified time in milliseconds.
        /// </summary>
        /// <param name="milliseconds">The time to suspend in milliseconds.</param>
        public static void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
