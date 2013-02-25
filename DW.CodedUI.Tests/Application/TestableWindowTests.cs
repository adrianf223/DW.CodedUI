using System;
using System.Diagnostics;
using System.Threading;
using DW.CodedUI.Application;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Application
{
    // ReSharper disable InconsistentNaming
    
    [CodedUITest]
    public class TestableWindowTests
    {
        [TestMethod]
        public void TestableWindow_CreatedWithTitle_ReturnsAccessableWindow()
        {
            var process = Process.Start(ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            var target = new TestableWindow(ApplicationInfo.Title, 1);

            Assert.AreNotSame(IntPtr.Zero, target.WindowHandle);

            process.CloseMainWindow();
        }

        [TestMethod]
        public void TestableWindow_CreatedWithTitleAndDifferentInstances_ReturnsDifferendWindowHandles()
        {
            var process1 = Process.Start(ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            var process2 = Process.Start(ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            var target1 = new TestableWindow(ApplicationInfo.Title, 1);
            var target2 = new TestableWindow(ApplicationInfo.Title, 2);

            Assert.AreNotSame(target1.WindowHandle, target2.WindowHandle);

            process1.CloseMainWindow();
            process2.CloseMainWindow();
        }

        [TestMethod]
        public void TestableWindow_CreatedWithContainsTitleCondition_ReturnsAccessableWindow()
        {
            var process = Process.Start(ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            var target = new TestableWindow("ation Window T", TitleSearchCondition.Contains);

            Assert.AreNotSame(IntPtr.Zero, target.WindowHandle);

            process.CloseMainWindow();
        }
    }

    // ReSharper restore InconsistentNaming
}
