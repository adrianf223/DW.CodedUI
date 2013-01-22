using System.Linq;
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
    public class BasicMenuItemTests
    {
        private TestableApplication _application;
        private BasicMenuItem _menuItem;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _menuItem = BasicElementFinder.FindChildByAutomationId<BasicMenuItem>(_application, "MenuItemId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void Text_Getted_ReturnsWrittenText()
        {
            Assert.AreEqual("First", _menuItem.Text);
        }

        [TestMethod]
        public void IsExpanded_Getted_ReturnsExpandState()
        {
            Assert.IsFalse(_menuItem.IsExpanded);

            _menuItem.Unsafe.Expand();

            Assert.IsTrue(_menuItem.IsExpanded);
        }

        [TestMethod]
        public void Items_Getted_ReturnsAvailableItems()
        {
            Assert.AreEqual(1, _menuItem.Items.Count());
        }

        [TestMethod]
        public void UnsafeExpand_Called_ExpandsTheItem()
        {
            Assert.IsFalse(_menuItem.IsExpanded);

            _menuItem.Unsafe.Expand();

            Assert.IsTrue(_menuItem.IsExpanded);
        }

        [TestMethod]
        public void Collapse_Called_CollapsesTheItem()
        {
            Assert.IsFalse(_menuItem.IsExpanded);
            _menuItem.Unsafe.Expand();
            Assert.IsTrue(_menuItem.IsExpanded);

            _menuItem.Unsafe.Collapse();

            Assert.IsFalse(_menuItem.IsExpanded);
        }
    }

    // ReSharper restore InconsistentNaming
}
