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
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class DoTests
    {
        [TestMethod]
        public void Action_ThreeTimes_AllGotCalledOnce()
        {
            var firstExecutionCount = 0;
            var secondExecutionCount = 0;
            var thirdExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; });

            Assert.AreEqual(1, firstExecutionCount);
            Assert.AreEqual(1, secondExecutionCount);
            Assert.AreEqual(1, thirdExecutionCount);
        }

        [TestMethod]
        public void Action_ThreeTimesAndOneRepeat_AllGotCalledTwice()
        {
            var firstExecutionCount = 0;
            var secondExecutionCount = 0;
            var thirdExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; })
              .Repeat(1);

            Assert.AreEqual(2, firstExecutionCount);
            Assert.AreEqual(2, secondExecutionCount);
            Assert.AreEqual(2, thirdExecutionCount);
        }

        [TestMethod]
        public void Action_ThreeTimesAndTwoRepeat_AllGotCalledThreeTimes()
        {
            var firstExecutionCount = 0;
            var secondExecutionCount = 0;
            var thirdExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; })
              .Repeat(2);

            Assert.AreEqual(3, firstExecutionCount);
            Assert.AreEqual(3, secondExecutionCount);
            Assert.AreEqual(3, thirdExecutionCount);
        }

        [TestMethod]
        public void Action_ThreeTimesWithTwoRepeatAndTwoWithFourRepeats_CallsActionsAccordingly()
        {
            var firstExecutionCount = 0;
            var secondExecutionCount = 0;
            var thirdExecutionCount = 0;
            var fourthExecutionCount = 0;
            var fifthExecutionCount = 0;

            Do.Action(() => { ++firstExecutionCount; })
              .And.Action(() => { ++secondExecutionCount; })
              .And.Action(() => { ++thirdExecutionCount; })
              .Repeat(2)
              .And.Action(() => { ++fourthExecutionCount; })
              .And.Action(() => { ++fifthExecutionCount; })
              .Repeat(4);

            Assert.AreEqual(3, firstExecutionCount);
            Assert.AreEqual(3, secondExecutionCount);
            Assert.AreEqual(3, thirdExecutionCount);
            Assert.AreEqual(5, fourthExecutionCount);
            Assert.AreEqual(5, fifthExecutionCount);
        }

        [TestMethod]
        public void Wait_WithMilliseconds_WaitsTheGivenTime()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Do.Wait(1200);

            stopwatch.Stop();
            Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromMilliseconds(1220) && stopwatch.Elapsed > TimeSpan.FromMilliseconds(1180), stopwatch.Elapsed.ToString());
        }

        [TestMethod]
        public void Launch_CalledWith100and100_PositionatesTheWuindow()
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            var mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));
            mainWindow.CloseButton.Unsafe.Click();
        }
    }
}
