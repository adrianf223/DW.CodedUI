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
    public class BasicExpanderTests
    {
        private BasicWindow _application;
        private BasicExpander _collapsedExpander;
        private BasicExpander _expandedExpander;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _collapsedExpander = BasicElementFinder.FindChildByAutomationId<BasicExpander>(_application, "CollapsedExpanderId");
            _expandedExpander = BasicElementFinder.FindChildByAutomationId<BasicExpander>(_application, "ExpandedExpanderId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void IsExpanded_Getted_ReturnsExpandState()
        {
            Assert.IsFalse(_collapsedExpander.IsExpanded);
            Assert.IsTrue(_expandedExpander.IsExpanded);
        }

        [TestMethod]
        public void UnsafeExpand_Called_ExpandsTheExpander()
        {
            Assert.IsFalse(_collapsedExpander.IsExpanded);

            _collapsedExpander.Unsafe.Expand();

            Assert.IsTrue(_collapsedExpander.IsExpanded);
        }

        [TestMethod]
        public void CollapseExpand_Called_CollapsesTheExpander()
        {
            Assert.IsTrue(_expandedExpander.IsExpanded);

            _expandedExpander.Unsafe.Collapse();

            Assert.IsFalse(_expandedExpander.IsExpanded);
        }
    }

    // ReSharper restore InconsistentNaming
}
