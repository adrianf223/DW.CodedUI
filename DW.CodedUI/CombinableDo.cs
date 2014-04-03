using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DW.CodedUI
{
    public class CombinableDo
    {
        internal CombinableDo()
        {
        }

        public CombinableDo And
        {
            get { return this; }
        }

        public CombinableDo Wait(uint milliseconds)
        {
            Thread.Sleep((int)milliseconds);
            return this;
        }

        public CombinableDo Launch(string path, string arguments = null)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                throw new ExecutableNotAvailableException(path);

            try
            {
                var processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = path;
                if (arguments != null) 
                    processStartInfo.Arguments = arguments;
                processStartInfo.WorkingDirectory = Path.GetDirectoryName(path);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot launch the application. See inner exception.", ex);
            }

            return this;
        }

        public CombinableDo WaitCPUIdle(uint mimimumPercent, uint maximumWaitTime = 60000)
        {
            if (maximumWaitTime == 0)
                throw new ArgumentOutOfRangeException("The maximumWaitTime (in milliseconds) cannot be 0");

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
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot meassure the current CPU load. See inner exception.", ex);
            }
        }

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