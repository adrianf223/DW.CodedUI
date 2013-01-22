using System.Threading;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.BasicElements
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class BasicToggleButtonTests
    {
        private TestableApplication _application;
        private BasicToggleButton _checkedToggleButton;
        private BasicToggleButton _uncheckedToggleButton;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _checkedToggleButton = BasicElementFinder.FindChildByAutomationId<BasicToggleButton>(_application, "CheckedToggleButtonId");
            _uncheckedToggleButton = BasicElementFinder.FindChildByAutomationId<BasicToggleButton>(_application, "UncheckedToggleButtonId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void Text_Getted_ReturnsWrittenText()
        {
            Assert.AreEqual("CheckedToggleButtonText", _checkedToggleButton.Text);
            Assert.AreEqual("UncheckedToggleButtonText", _uncheckedToggleButton.Text);
        }

        [TestMethod]
        public void IsChecked_Getted_ReturnsCheckState()
        {
            Assert.IsTrue(_checkedToggleButton.IsChecked);
            Assert.IsFalse(_uncheckedToggleButton.IsChecked);
        }

        [TestMethod]
        public void UnsafeToggle_Called_ChangesToggleState()
        {
            Assert.IsTrue(_checkedToggleButton.IsChecked);
            Assert.IsFalse(_uncheckedToggleButton.IsChecked);

            _checkedToggleButton.Unsafe.Toggle();
            _uncheckedToggleButton.Unsafe.Toggle();

            Assert.IsFalse(_checkedToggleButton.IsChecked);
            Assert.IsTrue(_uncheckedToggleButton.IsChecked);
        }
    }

    // ReSharper restore InconsistentNaming
}
