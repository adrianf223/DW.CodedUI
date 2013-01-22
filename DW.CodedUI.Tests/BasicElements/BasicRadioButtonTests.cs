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
    public class BasicRadioButtonTests
    {
        private TestableApplication _application;
        private BasicRadioButton _checkedRadioButton;
        private BasicRadioButton _unheckedRadioButton;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _checkedRadioButton = BasicElementFinder.FindChildByAutomationId<BasicRadioButton>(_application, "CheckedRadioButtonId");
            _unheckedRadioButton = BasicElementFinder.FindChildByAutomationId<BasicRadioButton>(_application, "UnheckedRadioButtonId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void IsChecked_Getted_ReturnsCheckState()
        {
            Assert.IsTrue(_checkedRadioButton.IsChecked);
            Assert.IsFalse(_unheckedRadioButton.IsChecked);
        }

        [TestMethod]
        public void UnsafeCheck_Called_ChecksTheItem()
        {
            Assert.IsTrue(_checkedRadioButton.IsChecked);
            Assert.IsFalse(_unheckedRadioButton.IsChecked);

            _unheckedRadioButton.Unsafe.Check();

            Assert.IsFalse(_checkedRadioButton.IsChecked);
            Assert.IsTrue(_unheckedRadioButton.IsChecked);
        }
    }

    // ReSharper restore InconsistentNaming
}
