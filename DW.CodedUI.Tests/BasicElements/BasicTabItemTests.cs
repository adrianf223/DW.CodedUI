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
    public class BasicTabItemTests
    {
        private TestableApplication _application;
        private BasicTabItem _selectedTabItem;
        private BasicTabItem _deSelectedTabItem;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _selectedTabItem = BasicElementFinder.FindChildByAutomationId<BasicTabItem>(_application, "SelectedTabItemId");
            _deSelectedTabItem = BasicElementFinder.FindChildByAutomationId<BasicTabItem>(_application, "DeselectedTabItemId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void Text_Getted_ReturnsWrittenText()
        {
            Assert.AreEqual("SelectedTabItemText", _selectedTabItem.Text);
            Assert.AreEqual("DeselectedTabItemText", _deSelectedTabItem.Text);
        }

        [TestMethod]
        public void IsSelected_Getted_ReturnsSelectionState()
        {
            Assert.IsTrue(_selectedTabItem.IsSelected);
            Assert.IsFalse(_deSelectedTabItem.IsSelected);
        }

        [TestMethod]
        public void UnsafeSelect_Called_SelectsTheItem()
        {
            Assert.IsTrue(_selectedTabItem.IsSelected);
            Assert.IsFalse(_deSelectedTabItem.IsSelected);

            _deSelectedTabItem.Unsafe.Select();

            Assert.IsFalse(_selectedTabItem.IsSelected);
            Assert.IsTrue(_deSelectedTabItem.IsSelected);
        }
    }

    // ReSharper restore InconsistentNaming
}
