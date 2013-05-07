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
    public class BasicTabControlTests
    {
        private BasicWindow _application;
        private BasicTabControl _tabControl;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _tabControl = BasicElementFinder.FindChildByAutomationId<BasicTabControl>(_application, "TabControlId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void SelectedItem_Getted_ReturnsSelectedItem()
        {
            var item = _tabControl.SelectedItem;

            Assert.IsNotNull(item);
            Assert.IsTrue(item.IsSelected);
        }

        [TestMethod]
        public void Items_Getted_ReturnsTwoItems()
        {
            var items = _tabControl.Items;

            Assert.AreEqual(2, items.Count());
        }
    }

    // ReSharper restore InconsistentNaming
}
