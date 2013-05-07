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
    public class BasicMenuTests
    {
        private BasicWindow _application;
        private BasicMenu _menu;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _menu = BasicElementFinder.FindChildByAutomationId<BasicMenu>(_application, "MenuId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void Items_Called_ReturnsTwoItems()
        {
            Assert.AreEqual(2, _menu.Items.Count());
        }
    }

    // ReSharper restore InconsistentNaming
}
