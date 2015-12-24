#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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

namespace DW.CodedUI
{
    /// <summary>
    /// Brings possibilities to do additional actions one by one combinable.
    /// </summary>
    public static class Do
    {
        /// <summary>
        /// Waits the given time.
        /// </summary>
        /// <param name="milliseconds">The milliseconds to wait.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Wait(uint milliseconds)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.Wait(milliseconds);
        }

        /// <summary>
        /// Waits that the CPU load became lower than the given minimumPercent.
        /// </summary>
        /// <param name="mimimumPercent">The maximum CPU load in percent to be wait for.</param>
        /// <param name="maximumWaitTime">The timeout how long to wait for the CPU idle.</param>
        /// <param name="interval">The interval how long to wait for the next CPU load check.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The maximumWaitTime (in milliseconds) cannot be 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">A minimum CPU load of 0 percent is unrealistic. A normal CPU idle is about 1-2%. For a normal run its OK to wait for 25% or lower.</exception>
        /// <exception cref="System.Exception">Cannot meassure the current CPU load.</exception>
        public static CombinableDo WaitCPUIdle(uint mimimumPercent, uint maximumWaitTime = 60000, uint interval = 1000)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.WaitCPUIdle(mimimumPercent, maximumWaitTime, interval);
        }

        /// <summary>
        /// Launches an given executable.
        /// </summary>
        /// <param name="path">The Path of the executable. See <see cref="System.Diagnostics.ProcessStartInfo.FileName" />.</param>
        /// <param name="arguments">The arguments passed to the process. See <see cref="System.Diagnostics.ProcessStartInfo.Arguments" />.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <exception cref="DW.CodedUI.ExecutableNotAvailableException">path is a not available executable.</exception>
        /// <exception cref="System.Exception">Cannot launch the application.</exception>
        public static CombinableDo Launch(string path, string arguments = null)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.Launch(path, arguments);
        }

        /// <summary>
        /// Executes the given action.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <exception cref="System.Exception">Cannot invoke the given action.</exception>
        public static CombinableDo Action(Action action)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.Action(action);
        }
    }
}
