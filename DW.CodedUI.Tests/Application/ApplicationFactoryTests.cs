using System;
using System.ComponentModel;
using System.Threading;
using DW.CodedUI.Application;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Application
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class ApplicationFactoryTests
    {
        [TestMethod]
        public void Launch_WithExistingExecutable_LaunchesTheApplication()
        {
            var toTestApplication = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            Assert.AreNotEqual(IntPtr.Zero, toTestApplication.WindowHandle);

            toTestApplication.Shutdown();
        }

        [TestMethod, ExpectedException(typeof(Win32Exception))]
        public void Launch_WithInvalidExecutablePath_ThrowsException()
        {
            ApplicationFactory.Launch(ApplicationInfo.Title, @"DoesNotExist.exe");
        }

        [TestMethod]
        public void Launch_TwiceWithDifferentInstancesAndFirstWillBeClosed_SecondStaysOpen()
        {
            var toTestApplication1 = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments, 1);
            Thread.Sleep(1000);
            var toTestApplication2 = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments, 2);
            Thread.Sleep(1000);

            Assert.AreNotEqual(IntPtr.Zero, toTestApplication1.WindowHandle);
            Assert.AreNotEqual(IntPtr.Zero, toTestApplication2.WindowHandle);

            toTestApplication1.Shutdown();
            Thread.Sleep(1000);

            Assert.IsTrue(toTestApplication1.HasExited);
            Assert.IsFalse(toTestApplication2.HasExited);

            toTestApplication2.Shutdown();
        }
    }

    // ReSharper restore InconsistentNaming
}
