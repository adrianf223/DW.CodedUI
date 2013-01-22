using System;
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
    public class BasicListTests
    {
        private TestableApplication _application;
        private BasicList _listBox;
        private BasicList _listView;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _listBox = BasicElementFinder.FindChildByAutomationId<BasicList>(_application, "ListBoxId");
            _listView = BasicElementFinder.FindChildByAutomationId<BasicList>(_application, "ListViewId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void CanMultiSelect_Getted_ReturnsMultiSelectPossibilities()
        {
            Assert.IsFalse(_listBox.CanMultiSelect);
            Assert.IsTrue(_listView.CanMultiSelect);
        }

        [TestMethod]
        public void SelectedItems_Getted_ReturnsTheSelectedItems()
        {
            Assert.IsFalse(_listBox.SelectedItems.Any());
            Assert.IsFalse(_listView.SelectedItems.Any());

            var listBoxItem = _listBox.Items.First();
            var listViewItems = _listView.Items.ToList();
            listBoxItem.Unsafe.AddToSelection();
            for (var i = 0; i < 5; ++i)
                listViewItems[i].Unsafe.AddToSelection();

            Assert.AreEqual(1, _listBox.SelectedItems.Count());
            Assert.AreEqual(5, _listView.SelectedItems.Count());
        }

        [TestMethod]
        public void Items_Getted_ReturnsCreatedItems()
        {
            Assert.IsTrue(_listBox.Items.Any());
            Assert.IsTrue(_listView.Items.Any());
        }

        [TestMethod]
        public void HorizontalScrollPercent_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.AreEqual(0, _listBox.HorizontalScrollPercent);
            Assert.AreEqual(0, _listView.HorizontalScrollPercent);

            _listBox.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);
            _listView.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);

            Assert.AreNotEqual(0, _listBox.HorizontalScrollPercent);
            Assert.AreNotEqual(0, _listView.HorizontalScrollPercent);
        }

        [TestMethod]
        public void HorizontalViewSize_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.IsTrue(_listBox.HorizontalViewSize > 0 && _listBox.HorizontalViewSize < 100);
            Assert.IsTrue(_listView.HorizontalViewSize > 0 && _listView.HorizontalViewSize < 100);
        }

        [TestMethod]
        public void HorizontallyScrollable_Getted_ReturnsScrollPossibility()
        {
            Assert.IsTrue(_listBox.HorizontallyScrollable);
            Assert.IsTrue(_listView.HorizontallyScrollable);
        }

        [TestMethod]
        public void VerticalScrollPercent_Getted_ReturnsVerticalScrollPostion()
        {
            Assert.AreEqual(0, _listBox.VerticalScrollPercent);
            Assert.AreEqual(0, _listView.VerticalScrollPercent);

            _listBox.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            _listView.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);

            Assert.AreNotEqual(0, _listBox.VerticalScrollPercent);
            Assert.AreNotEqual(0, _listView.VerticalScrollPercent);
        }

        [TestMethod]
        public void VerticalViewSize_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.IsTrue(_listBox.VerticalViewSize > 0 && _listBox.VerticalViewSize < 100);
            Assert.IsTrue(_listView.VerticalViewSize > 0 && _listView.VerticalViewSize < 100);
        }

        [TestMethod]
        public void VerticallyScrollable_Getted_ReturnsScrollPossibility()
        {
            Assert.IsTrue(_listBox.VerticallyScrollable);
            Assert.IsTrue(_listView.VerticallyScrollable);
        }

        [TestMethod]
        public void UnsafeScroll_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _listBox.HorizontalScrollPercent;
            var oldVerticalPercent = _listBox.VerticalScrollPercent;
            _listBox.Unsafe.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
            var newHorizontalPercent = _listBox.HorizontalScrollPercent;
            var newVerticalPercent = _listBox.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);

            oldHorizontalPercent = _listView.HorizontalScrollPercent;
            oldVerticalPercent = _listView.VerticalScrollPercent;
            _listView.Unsafe.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
            newHorizontalPercent = _listView.HorizontalScrollPercent;
            newVerticalPercent = _listView.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }

        [TestMethod]
        public void UnsafeScrollHorizontal_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _listBox.HorizontalScrollPercent;
            _listBox.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);
            var newHorizontalPercent = _listBox.HorizontalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);

            oldHorizontalPercent = _listView.HorizontalScrollPercent;
            _listView.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);
            newHorizontalPercent = _listView.HorizontalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
        }

        [TestMethod]
        public void UnsafeScrollVertical_Called_ScrollsInTheVisibleRange()
        {
            var oldVerticalPercent = _listBox.VerticalScrollPercent;
            _listBox.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            var newVerticalPercent = _listBox.VerticalScrollPercent;

            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);

            oldVerticalPercent = _listView.VerticalScrollPercent;
            _listView.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            newVerticalPercent = _listView.VerticalScrollPercent;

            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }

        [TestMethod]
        public void UnsafeSetScrollPercent_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _listBox.HorizontalScrollPercent;
            var oldVerticalPercent = _listBox.VerticalScrollPercent;
            _listBox.Unsafe.SetScrollPercent(50, 50);
            var newHorizontalPercent = _listBox.HorizontalScrollPercent;
            var newVerticalPercent = _listBox.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);

            oldHorizontalPercent = _listView.HorizontalScrollPercent;
            oldVerticalPercent = _listView.VerticalScrollPercent;
            _listView.Unsafe.SetScrollPercent(50, 50);
            newHorizontalPercent = _listView.HorizontalScrollPercent;
            newVerticalPercent = _listView.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }

        [TestMethod]
        public void FindChildByCondition_Called_ScrollsToTheItemAndReturnsIt()
        {
            var item = _listBox.FindChildByCondition(c => c.Text == "3Nineth");
            Assert.IsNotNull(item);

            item = _listView.FindChildByCondition(c => c.Text == "3Nineth");
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void ColumnCount_Getted_ReturnsThree()
        {
            Assert.AreEqual(3, _listView.ColumnCount);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void ColumnCount_GettedFromListBox_ThrowsException()
        {
            var columnCount = _listBox.ColumnCount;
        }

        [TestMethod]
        public void RowCount_Getted_ReturnsThree()
        {
            Assert.AreEqual(40, _listView.RowCount);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void RowCount_GettedFromListBox_ThrowsException()
        {
            var columnCount = _listBox.RowCount;
        }

        [TestMethod]
        public void GetItem_Called_ReturnsTheItem()
        {
            var item = _listView.GetItem(1, 1);

            Assert.IsNotNull(item);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void GetItem_CalledForListBox_ThrowsException()
        {
            var item = _listBox.GetItem(1, 1);
        }

        [TestMethod]
        public void GetColumnHeaders_Called_ReturnsAllThreeHeaders()
        {
            var headers = _listView.GetColumnHeaders();

            Assert.AreEqual(3, headers.Count());
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void GetColumnHeaders_CalledForListBox_ReturnsAllThreeHeaders()
        {
            var headers = _listBox.GetColumnHeaders();
        }
    }

    // ReSharper restore InconsistentNaming
}
