#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

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

using System.Threading;
using DW.CodedUI.Internal;

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
            LogPool.Append("Wait {0} milliseconds.", milliseconds);

            Thread.Sleep(milliseconds);
        }
    }
}
