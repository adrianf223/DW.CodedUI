using System.Threading;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.UITree
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class MessageBoxFinderTests
    {
        private BasicWindow _application;
        private BasicButton _button;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_application, "ButtonId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void FindFirstAvailable_MessageBoxIsOpen_ReturnsMessageBox()
        {
            _button.Unsafe.Click();
            Thread.Sleep(500);

            var messageBox = MessageBoxFinder.FindFirstAvailable();

            Assert.IsNotNull(messageBox);
            MessageBoxHandler.Close(messageBox);
        }

        [TestMethod]
        public void FindFirstAvailableByTitle_CalledWithUnknownTitle_ReturnsNull()
        {
            var messageBox = MessageBoxFinder.FindFirstAvailableByTitle("Fritz");

            Assert.IsNull(messageBox);
        }

        [TestMethod]
        public void FindFirstAvailableByTitle_MessageBoxIsOpen_ReturnsMessageBox()
        {
            _button.Unsafe.Click();
            Thread.Sleep(500);

            var messageBox = MessageBoxFinder.FindFirstAvailableByTitle("Button Clicked");

            Assert.IsNotNull(messageBox);
            MessageBoxHandler.Close(messageBox);
        }
    }

    // ReSharper restore InconsistentNaming
}
