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
    public class BasicListItemTests
    {
        private BasicWindow _application;
        private BasicList _listBox;
        private BasicList _listView;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _listBox = BasicElementFinder.FindChildByAutomationId<BasicList>(_application, "ListBoxId");
            _listView = BasicElementFinder.FindChildByAutomationId<BasicList>(_application, "ListViewId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void IsSelected_Gettes_ReturnsTheSelectionState()
        {
            Assert.IsFalse(_listBox.Items.First().IsSelected);
            Assert.IsFalse(_listView.Items.First().IsSelected);

            _listBox.Items.First().Unsafe.AddToSelection();
            _listView.Items.First().Unsafe.AddToSelection();

            Assert.IsTrue(_listBox.Items.First().IsSelected);
            Assert.IsTrue(_listView.Items.First().IsSelected);
        }

        [TestMethod]
        public void Text_Getted_ReturnsContentTextOfTheItem()
        {
            Assert.AreEqual("First", _listBox.Items.First().Text);
            Assert.AreEqual("First", _listView.Items.First().Text);
        }

        [TestMethod]
        public void UnsafeAddToSelection_Called_AddsTheItemToTheListOfSelectedItems()
        {
            var listViewItems = _listView.Items.ToList();
            for (var i = 0; i < 2; ++i)
                listViewItems[i].Unsafe.AddToSelection();
            Assert.AreEqual(2, _listView.SelectedItems.Count());
        }

        [TestMethod]
        public void UnsafeRemoveFromSelection_Called_RemovesTheItemToTheListOfSelectedItems()
        {
            var listViewItems = _listView.Items.ToList();
            for (var i = 0; i < 2; ++i)
                listViewItems[i].Unsafe.AddToSelection();
            Assert.AreEqual(2, _listView.SelectedItems.Count());

            for (var i = 0; i < 2; ++i)
                listViewItems[i].Unsafe.RemoveFromSelection();
            Assert.IsFalse(_listView.SelectedItems.Any());
        }

        [TestMethod]
        public void UnsafeSelect_Called_ChangesSelection()
        {
            var listViewItems = _listView.Items.ToList();
            listViewItems[0].Unsafe.Select();
            Assert.IsTrue(listViewItems[0].IsSelected);

            listViewItems[1].Unsafe.Select();
            Assert.IsFalse(listViewItems[0].IsSelected);
            Assert.IsTrue(listViewItems[1].IsSelected);
        }

        [TestMethod]
        public void UnsafeScrollIntoView_Called_ScrollsToTheItem()
        {
            _listBox.Items.First().Unsafe.Select();
            _listBox.FindChildByCondition(x => x.Text == "2Seventh");
            var oldPosition = _listBox.VerticalScrollPercent;
            Assert.IsTrue(oldPosition > 0);

            _listBox.SelectedItems.First().Unsafe.ScrollIntoView();

            var newPosition = _listBox.VerticalScrollPercent;
            Assert.AreEqual(0, newPosition);

            _listView.Items.First().Unsafe.Select();
            _listView.FindChildByCondition(x => x.Text == "2Seventh");
            oldPosition = _listView.VerticalScrollPercent;
            Assert.IsTrue(oldPosition > 0);

            _listView.SelectedItems.First().Unsafe.ScrollIntoView();

            newPosition = _listView.VerticalScrollPercent;
            Assert.AreEqual(0, newPosition);
        }
    }

    // ReSharper restore InconsistentNaming
}
