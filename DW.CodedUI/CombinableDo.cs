using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DW.CodedUI
{
    /// <summary>
    /// Brings possibilities to do additional actions one by one combinable.
    /// </summary>
    public class CombinableDo
    {
#if TRIAL
        static CombinableDo()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        internal CombinableDo()
        {
        }

        /// <summary>
        /// Gets a combinable Do to be able to append additional actions.
        /// </summary>
        public CombinableDo And
        {
            get { return this; }
        }

        /// <summary>
        /// Waits the given time.
        /// </summary>
        /// <param name="milliseconds">The milliseconds to wait.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public CombinableDo Wait(uint milliseconds)
        {
            Thread.Sleep((int)milliseconds);
            return this;
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
        public CombinableDo WaitCPUIdle(uint mimimumPercent, uint maximumWaitTime = 60000, uint interval = 1000)
        {
            if (maximumWaitTime == 0)
                throw new ArgumentOutOfRangeException("The maximumWaitTime (in milliseconds) cannot be 0.");

            if (mimimumPercent == 0)
                throw new ArgumentOutOfRangeException("A minimum CPU load of 0 percent is unrealistic. A normal CPU idle is about 1-2%. For a normal run its OK to wait for 25% or lower.");

            try
            {
                var cpuload = new PerformanceCounter();
                cpuload.CategoryName = "Processor";
                cpuload.CounterName = "% Processor Time";
                cpuload.InstanceName = "_Total";

                cpuload.NextValue();
                cpuload.NextValue();
                cpuload.NextValue();
                cpuload.NextValue();

                var watch = new Stopwatch();
                watch.Start();
                while (true)
                {
                    if (watch.Elapsed.TotalMilliseconds >= maximumWaitTime)
                        return this;

                    if (cpuload.NextValue() < mimimumPercent)
                        return this;

                    if (interval > 0)
                        Thread.Sleep((int)interval);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot meassure the current CPU load. See inner exception.", ex);
            }
        }

        /// <summary>
        /// Launches an given executable.
        /// </summary>
        /// <param name="path">The Path of the executable. See <see cref="System.Diagnostics.ProcessStartInfo.FileName" />.</param>
        /// <param name="arguments">The arguments passed to the process. See <see cref="System.Diagnostics.ProcessStartInfo.Arguments" />.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <exception cref="DW.CodedUI.ExecutableNotAvailableException">path is a not available executable.</exception>
        /// <exception cref="System.Exception">Cannot launch the application.</exception>
        public CombinableDo Launch(string path, string arguments = null)
        {
            if (!File.Exists(path))
                throw new ExecutableNotAvailableException(path);

            try
            {
                var processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = path;
                if (arguments != null)
                    processStartInfo.Arguments = arguments;
                processStartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot launch the application. See inner exception.", ex);
            }

            return this;
        }

        /// <summary>
        /// Executes the given action.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <exception cref="System.Exception">Cannot invoke the given action.</exception>
        public CombinableDo Action(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot invoke the given action. See inner exception.", ex);
            }
            return this;
        }
    }
}