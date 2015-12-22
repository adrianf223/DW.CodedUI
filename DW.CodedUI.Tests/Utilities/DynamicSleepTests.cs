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
using System.Diagnostics;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    [TestClass]
    public class DynamicSleepTests
    {
        [TestInitialize]
        public void Setup()
        {
            CodedUIEnvironment.SleepSettings.Short = 10;
            CodedUIEnvironment.SleepSettings.Medium = 100;
            CodedUIEnvironment.SleepSettings.Long = 1000;
            CodedUIEnvironment.SleepSettings.Default = Time.Long;
        }

        [TestMethod]
        public void Wait_WithoutParameter_UsesTheDefaultWaitTime()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            DynamicSleep.Wait();

            stopwatch.Stop();
            Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromMilliseconds(1020) && stopwatch.Elapsed > TimeSpan.FromMilliseconds(800), stopwatch.Elapsed.ToString());
        }

        [TestMethod]
        public void Wait_WithAMediumParameter_Waits100Milliseconds()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            DynamicSleep.Wait(Time.Medium);

            stopwatch.Stop();
            Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromMilliseconds(120) && stopwatch.Elapsed > TimeSpan.FromMilliseconds(80), stopwatch.Elapsed.ToString());
        }

        [TestMethod]
        public void Wait_WithMilliseconds_WaitsTheGivenTime()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            DynamicSleep.Wait(1200);

            stopwatch.Stop();
            Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromMilliseconds(1220) && stopwatch.Elapsed > TimeSpan.FromMilliseconds(1180), stopwatch.Elapsed.ToString());
        }
    }
}
