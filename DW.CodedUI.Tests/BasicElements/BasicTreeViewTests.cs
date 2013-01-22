using System.Linq;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.BasicElements
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class BasicTreeViewTests
    {
        private TestableApplication _application;
        private BasicTreeView _treeView;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _treeView = BasicElementFinder.FindChildByAutomationId<BasicTreeView>(_application, "TreeViewId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void Items_Called_ReturnsAllItems()
        {
            Assert.IsTrue(_treeView.Items.Any());
        }

        [TestMethod]
        public void HorizontalScrollPercent_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.AreEqual(0, _treeView.HorizontalScrollPercent);

            _treeView.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);

            Assert.AreNotEqual(0, _treeView.HorizontalScrollPercent);
        }

        [TestMethod]
        public void HorizontalViewSize_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.IsTrue(_treeView.HorizontalViewSize > 0 && _treeView.HorizontalViewSize < 100);
        }

        [TestMethod]
        public void HorizontallyScrollable_Getted_ReturnsScrollPossibility()
        {
            Assert.IsTrue(_treeView.HorizontallyScrollable);
        }

        [TestMethod]
        public void VerticalScrollPercent_Getted_ReturnsVerticalScrollPostion()
        {
            Assert.AreEqual(0, _treeView.VerticalScrollPercent);

            _treeView.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);

            Assert.AreNotEqual(0, _treeView.VerticalScrollPercent);
        }

        [TestMethod]
        public void VerticalViewSize_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.IsTrue(_treeView.VerticalViewSize > 0 && _treeView.VerticalViewSize < 100);
        }

        [TestMethod]
        public void VerticallyScrollable_Getted_ReturnsScrollPossibility()
        {
            Assert.IsTrue(_treeView.VerticallyScrollable);
        }

        [TestMethod]
        public void UnsafeScroll_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _treeView.HorizontalScrollPercent;
            var oldVerticalPercent = _treeView.VerticalScrollPercent;
            
            _treeView.Unsafe.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
            
            var newHorizontalPercent = _treeView.HorizontalScrollPercent;
            var newVerticalPercent = _treeView.VerticalScrollPercent;
            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }

        [TestMethod]
        public void UnsafeScrollHorizontal_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _treeView.HorizontalScrollPercent;
            
            _treeView.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);
            
            var newHorizontalPercent = _treeView.HorizontalScrollPercent;
            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
        }

        [TestMethod]
        public void UnsafeScrollVertical_Called_ScrollsInTheVisibleRange()
        {
            var oldVerticalPercent = _treeView.VerticalScrollPercent;
            
            _treeView.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            
            var newVerticalPercent = _treeView.VerticalScrollPercent;
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }

        [TestMethod]
        public void UnsafeSetScrollPercent_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _treeView.HorizontalScrollPercent;
            var oldVerticalPercent = _treeView.VerticalScrollPercent;
            
            _treeView.Unsafe.SetScrollPercent(50, 50);
            
            var newHorizontalPercent = _treeView.HorizontalScrollPercent;
            var newVerticalPercent = _treeView.VerticalScrollPercent;
            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }
    }

    // ReSharper restore InconsistentNaming
}
