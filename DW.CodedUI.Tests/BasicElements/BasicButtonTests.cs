using System.Threading;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.BasicElements
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class BasicButtonTests
    {
        private TestableApplication _application;
        private BasicButton _button;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_application, ApplicationInfo.ButtonAutomationId);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void UnsafeClick_Called_ClicksTheButton()
        {
            _button.Unsafe.Click();
            Thread.Sleep(1000);

            var messageBox = MessageBoxFinder.FindFirstAvailableByTitle(ApplicationInfo.ButtonClickedMessageBox);
            Assert.IsNotNull(messageBox);
            MessageBoxHandler.Close(messageBox);
        }

        [TestMethod]
        public void Text_Getted_ReturnsContentText()
        {
            Assert.AreEqual(ApplicationInfo.ButtonText, _button.Text);
        }
    }

    // ReSharper restore InconsistentNaming
}
