using System;
using System.Threading;
using DW.CodedUI.Application;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Application
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class TestableApplicationTests
    {
        [TestMethod]
        public void Shutdown_Called_EndsTheApplication()
        {
            var target = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            target.Shutdown();
            Thread.Sleep(1000);

            Assert.IsTrue(target.HasExited);
        }

        [TestMethod]
        public void Handle_Getted_HandleIsSet()
        {
            var target = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            Assert.AreNotEqual(IntPtr.Zero, target.Handle);

            target.Shutdown();
        }

        [TestMethod]
        public void MainWindowHandle_Getted_HandleIsSet()
        {
            var target = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            Assert.AreNotEqual(IntPtr.Zero, target.MainWindowHandle);

            target.Shutdown();
        }

        [TestMethod]
        public void HasExited_ApplicationGetsClosed_RetunsTrue()
        {
            var target = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath, ApplicationInfo.FastStartArguments);
            Thread.Sleep(1000);

            Assert.IsFalse(target.HasExited);
            target.Shutdown();

            Thread.Sleep(1000);
            Assert.IsTrue(target.HasExited);
        }
    }

    // ReSharper restore InconsistentNaming
}
