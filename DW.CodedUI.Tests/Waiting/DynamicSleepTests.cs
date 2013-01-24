using System;
using System.Diagnostics;
using DW.CodedUI.Waiting;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Waiting
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    [ExecutionSpeed(2000)]
    public class DynamicSleepTests
    {
        [TestMethod]
        [ExecutionSpeed(Speed.Fast)]
        public void Wait_FastIsSetLocal_WaitsOneSecond()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            DynamicSleep.Wait();

            stopWatch.Stop();

            Assert.IsTrue(stopWatch.Elapsed.TotalMilliseconds > 950 && stopWatch.Elapsed.TotalMilliseconds < 1050);
        }

        [TestMethod]
        public void Wait_2000IsSetGlobal_WaitsTwoSeconds()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            DynamicSleep.Wait();

            stopWatch.Stop();

            Assert.IsTrue(stopWatch.Elapsed.TotalMilliseconds > 1950 && stopWatch.Elapsed.TotalMilliseconds < 2050);
        }
    }

    [CodedUITest]
    public class DynamicSleepTests2
    {
        [TestMethod]
        public void Wait_NoSpeedIsSet_DoesNotWait()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            DynamicSleep.Wait();

            stopWatch.Stop();

            Assert.IsTrue(stopWatch.Elapsed.TotalMilliseconds < 50);
        }
    }

    // ReSharper restore InconsistentNaming
}
