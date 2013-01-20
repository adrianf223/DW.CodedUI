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
    public class BasicCheckBoxTests
    {
        private TestableApplication _application;
        private BasicCheckBox _checkBoxChecked;
        private BasicCheckBox _checkBoxUnchecked;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _checkBoxChecked = BasicElementFinder.FindChildByAutomationId<BasicCheckBox>(_application, ApplicationInfo.CheckBoxCheckedAutomationId);
            _checkBoxUnchecked = BasicElementFinder.FindChildByAutomationId<BasicCheckBox>(_application, ApplicationInfo.CheckBoxUncheckedAutomationId);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void IsChecked_Getted_ReturnsCheckState()
        {
            Assert.IsFalse(_checkBoxUnchecked.IsChecked);
            Assert.IsTrue(_checkBoxChecked.IsChecked);
        }

        [TestMethod]
        public void UnsafeToggle_Called_ChangesToggleState()
        {
            _checkBoxChecked.Unsafe.Toggle();
            _checkBoxUnchecked.Unsafe.Toggle();

            Assert.IsTrue(_checkBoxUnchecked.IsChecked);
            Assert.IsFalse(_checkBoxChecked.IsChecked);
        }

        [TestMethod]
        public void Text_Getted_ReturnsContentText()
        {
            Assert.AreEqual(ApplicationInfo.CheckBoxText, _checkBoxChecked.Text);
        }
    }

    // ReSharper restore InconsistentNaming
}
