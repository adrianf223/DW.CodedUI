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
    public class BasicTreeViewItemTests
    {
        private BasicWindow _application;
        private BasicTreeView _treeView;
        private BasicTreeViewItem _selectedTreeViewItem;
        private BasicTreeViewItem _deselectedTreeViewItem;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _treeView = BasicElementFinder.FindChildByAutomationId<BasicTreeView>(_application, "TreeViewId");
            _selectedTreeViewItem = BasicElementFinder.FindChildByAutomationId<BasicTreeViewItem>(_application, "SelectedTreeViewItemId");
            _deselectedTreeViewItem = BasicElementFinder.FindChildByAutomationId<BasicTreeViewItem>(_application, "DeselectedTreeViewItemId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void Text_Getted_ReturnsTheWrittenText()
        {
            Assert.AreEqual("SelectedTreeViewItemText", _selectedTreeViewItem.Text);
            Assert.AreEqual("DeselectedTreeViewItemText", _deselectedTreeViewItem.Text);
        }

        [TestMethod]
        public void Items_Getted_ReturnsTwoItems()
        {
            _selectedTreeViewItem.Unsafe.Expand();

            var items = _selectedTreeViewItem.Items;

            Assert.AreEqual(2, items.Count());
        }

        [TestMethod]
        public void IsExpanded_Getted_ReturnsExpandState()
        {
            Assert.IsFalse(_selectedTreeViewItem.IsExpanded);
            Assert.IsFalse(_deselectedTreeViewItem.IsExpanded);

            _selectedTreeViewItem.Unsafe.Expand();

            Assert.IsTrue(_selectedTreeViewItem.IsExpanded);
        }

        [TestMethod]
        public void IsSelected_Getted_ReturnsSelectionState()
        {
            Assert.IsTrue(_selectedTreeViewItem.IsSelected);
            Assert.IsFalse(_deselectedTreeViewItem.IsSelected);
        }

        [TestMethod]
        public void UnsafeExpand_Called_ExpandsTheItem()
        {
            Assert.IsFalse(_selectedTreeViewItem.IsExpanded);

            _selectedTreeViewItem.Unsafe.Expand();

            Assert.IsTrue(_selectedTreeViewItem.IsExpanded);
        }

        [TestMethod]
        public void UnsafeCollapse_Called_CollapsessTheItem()
        {
            Assert.IsFalse(_selectedTreeViewItem.IsExpanded);
            _selectedTreeViewItem.Unsafe.Expand();
            Assert.IsTrue(_selectedTreeViewItem.IsExpanded);

            _selectedTreeViewItem.Unsafe.Collapse();

            Assert.IsFalse(_selectedTreeViewItem.IsExpanded);
        }

        [TestMethod]
        public void UnsafeSelect_Called_SelectsTheItem()
        {
            Assert.IsTrue(_selectedTreeViewItem.IsSelected);
            Assert.IsFalse(_deselectedTreeViewItem.IsSelected);

            _deselectedTreeViewItem.Unsafe.Select();

            Assert.IsFalse(_selectedTreeViewItem.IsSelected);
            Assert.IsTrue(_deselectedTreeViewItem.IsSelected);
        }

        [TestMethod]
        public void UnsafeDeselect_Called_DeselectsTheItem()
        {
            Assert.IsTrue(_selectedTreeViewItem.IsSelected);
            Assert.IsFalse(_deselectedTreeViewItem.IsSelected);

            _deselectedTreeViewItem.Unsafe.Deselect();

            Assert.IsFalse(_selectedTreeViewItem.IsSelected);
            Assert.IsFalse(_deselectedTreeViewItem.IsSelected);
        }

        [TestMethod]
        public void UnsafeScrollIntoView_Called_ScrollsToTheItem()
        {
            _treeView.Items.First().Unsafe.Select();
            _treeView.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            _treeView.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            var oldPosition = _treeView.VerticalScrollPercent;
            Assert.IsTrue(oldPosition > 0);

            _selectedTreeViewItem.Unsafe.ScrollIntoView();

            var newPosition = _treeView.VerticalScrollPercent;
            Assert.AreEqual(0, newPosition);
        }
    }

    // ReSharper restore InconsistentNaming
}
