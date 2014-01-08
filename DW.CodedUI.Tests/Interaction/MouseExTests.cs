using System.Linq;
using System.Threading;
using System.Windows.Input;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Interaction
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class MouseExTests
    {
        private BasicWindow _window;

        [TestInitialize]
        public void Setup()
        {
            _window = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);

            // TODO: How to test?
            //MouseEx.Click(); MouseButtton
            //MouseEx.Click(); MouseButtton At
            //MouseEx.Click(); MouseButtton ModifierKeys
            //MouseEx.Click(); MouseButtton ModifierKeys At

            //MouseEx.DoubleClick(); At
            //MouseEx.DoubleClick(); ModifierKeys
            //MouseEx.DoubleClick(); ModifierKeys At
            //MouseEx.DoubleClick(); MouseButtton
            //MouseEx.DoubleClick(); MouseButtton At
            //MouseEx.DoubleClick(); MouseButtton ModifierKeys
            //MouseEx.DoubleClick(); MouseButtton ModifierKeys At
        }

        [TestMethod]
        public void Click_OnButton_ClicksTheButton()
        {
            var button = BasicElementFinder.FindChildByAutomationId(_window, "ButtonId");

            MouseEx.Click(button);

            AssertButtonClicked();
        }

        [TestMethod]
        public void Click_WithShiftOnTwoListItems_BothItemsGetsSelected()
        {
            var listView = BasicElementFinder.FindChildByAutomationId<BasicList>(_window, "ListViewId");
            Assert.IsFalse(listView.SelectedItems.Any());

            MouseEx.Click(listView.Items.ElementAt(0));
            MouseEx.Click(listView.Items.ElementAt(1), ModifierKeys.Shift);

            Assert.AreEqual(2, listView.SelectedItems.Count());
        }

        [TestMethod]
        public void Click_WithControlOnAListItemTwice_ItemGetsSelectedAndDeselected()
        {
            var listView = BasicElementFinder.FindChildByAutomationId<BasicList>(_window, "ListViewId");
            Assert.IsFalse(listView.SelectedItems.Any());

            MouseEx.Click(listView.Items.ElementAt(0));
            Assert.AreEqual(1, listView.SelectedItems.Count());

            MouseEx.Click(listView.Items.ElementAt(0), ModifierKeys.Control);
            Assert.IsFalse(listView.SelectedItems.Any());
        }

        [TestMethod]
        public void Click_AtSpecificPosition_ClicksAtTheRightPosition()
        {
            var button = BasicElementFinder.FindChildByAutomationId(_window, "ButtonId");
            var expectedX = button.Properties.BoundingRectangle.Left + 10;
            var expectedY = button.Properties.BoundingRectangle.Top + 10;

            MouseEx.Click(button, At.TopLeft(10, 10));

            AssertButtonClicked();
            AssertMousePosition(expectedX, expectedY);
        }

        [TestMethod]
        public void Click_WithShiftOnTwoListItemsAtSpecificPosition_BothItemsGetsSelectedWithTheRightPosition()
        {
            var listView = BasicElementFinder.FindChildByAutomationId<BasicList>(_window, "ListViewId");
            Assert.IsFalse(listView.SelectedItems.Any());
            var expectedX = listView.Items.ElementAt(1).Properties.BoundingRectangle.Left + 10;
            var expectedY = listView.Items.ElementAt(1).Properties.BoundingRectangle.Top + 2;

            MouseEx.Click(listView.Items.ElementAt(0));
            MouseEx.Click(listView.Items.ElementAt(1), ModifierKeys.Shift, At.TopLeft(10, 2));

            Assert.AreEqual(2, listView.SelectedItems.Count());
            AssertMousePosition(expectedX, expectedY);
        }

        [TestMethod]
        public void Click_WithControlOnAListItemTwiceAtSpecificPosition_ItemGetsSelectedAndDeselectedWithTheRightPosition()
        {
            var listView = BasicElementFinder.FindChildByAutomationId<BasicList>(_window, "ListViewId");
            Assert.IsFalse(listView.SelectedItems.Any());
            var expectedX = listView.Items.ElementAt(1).Properties.BoundingRectangle.Left + 10;
            var expectedY = listView.Items.ElementAt(1).Properties.BoundingRectangle.Top + 2;

            MouseEx.Click(listView.Items.ElementAt(0));
            Assert.AreEqual(1, listView.SelectedItems.Count());

            MouseEx.Click(listView.Items.ElementAt(0), ModifierKeys.Control, At.TopLeft(10, 2));
            Assert.IsFalse(listView.SelectedItems.Any());
            AssertMousePosition(expectedX, expectedY);
        }

        [TestMethod]
        public void DoubleClick_OnTreeItem_ExpandsTheItem()
        {
            var treeViewItem = BasicElementFinder.FindChildByAutomationId<BasicTreeViewItem>(_window, "SelectedTreeViewItemId");

            MouseEx.DoubleClick(treeViewItem);

            Thread.Sleep(500);

            Assert.IsTrue(treeViewItem.IsExpanded);
        }

        private static void AssertButtonClicked()
        {
            Thread.Sleep(500);
            var messageBox = MessageBoxFinder.FindFirstAvailableByTitle("Button Clicked");

            Assert.IsNotNull(messageBox);
            MessageBoxHandler.Close(messageBox);
        }

        private static void AssertMousePosition(double expectedX, double expectedY)
        {
            var mousePosition = System.Windows.Forms.Control.MousePosition;
            Assert.AreEqual(expectedX, mousePosition.X);
            Assert.AreEqual(expectedY, mousePosition.Y);
        }
    }

    // ReSharper restore InconsistentNaming
}
