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
    public class BasicComboBoxTests
    {
        private TestableApplication _application;

        private BasicComboBox _editableComboBoxWithSelection;
        private BasicComboBox _editableComboBoxWithText;
        private BasicComboBox _readonlyComboBoxWithSelection;
        private BasicComboBox _comboBoxWithManyChildren;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _editableComboBoxWithSelection = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_application, "ComboBoxEditableWithSelectionId");
            _editableComboBoxWithText = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_application, "ComboBoxEditableWithTextId");
            _readonlyComboBoxWithSelection = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_application, "ComboBoxReadonlyWithSelectionId");
            _comboBoxWithManyChildren = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_application, "ComboBoxReadonlyWithManyChildrenId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void SelectedItem_Getter_ReturnsSelectedComboBoxItem()
        {
            var selectedItem1 = _editableComboBoxWithSelection.SelectedItem;
            var selectedItem2 = _editableComboBoxWithText.SelectedItem;
            var selectedItem3 = _readonlyComboBoxWithSelection.SelectedItem;

            Assert.IsNotNull(selectedItem1);
            Assert.IsNull(selectedItem2);
            Assert.IsNotNull(selectedItem3);
        }

        [TestMethod]
        public void Items_Getter_ReturnsTwoItems()
        {
            var items = _editableComboBoxWithSelection.Items;
            Assert.AreEqual(2, items.Count());
            Assert.AreEqual("SelectedChild", items.First().Text);
            Assert.AreEqual("UnselectedChild", items.Last().Text);

            items = _editableComboBoxWithText.Items;
            Assert.AreEqual(2, items.Count());
            Assert.AreEqual("SelectedChild", items.First().Text);
            Assert.AreEqual("UnselectedChild", items.Last().Text);

            items = _readonlyComboBoxWithSelection.Items;
            Assert.AreEqual(2, items.Count());
            Assert.AreEqual("SelectedChild", items.First().Text);
            Assert.AreEqual("UnselectedChild", items.Last().Text);
        }

        [TestMethod]
        public void Text_Getter_ReturnsWrittenAndSelectedItemText()
        {
            Assert.AreEqual("SelectedChild", _editableComboBoxWithSelection.Text);
            Assert.AreEqual("ComboBoxText", _editableComboBoxWithText.Text);
            Assert.AreEqual("SelectedChild", _readonlyComboBoxWithSelection.Text);
        }

        [TestMethod]
        public void IsReadOnly_Getter_ReturnsEditableState()
        {
            Assert.IsFalse(_editableComboBoxWithSelection.IsReadOnly);
            Assert.IsFalse(_editableComboBoxWithText.IsReadOnly);
            Assert.IsTrue(_readonlyComboBoxWithSelection.IsReadOnly);
        }

        [TestMethod]
        public void IsExpanded_Getter_ReturnsExpandState()
        {
            Assert.IsFalse(_editableComboBoxWithSelection.IsExpanded);
            Assert.IsFalse(_editableComboBoxWithText.IsExpanded);
            Assert.IsFalse(_readonlyComboBoxWithSelection.IsExpanded);

            _readonlyComboBoxWithSelection.Unsafe.Expand();

            Assert.IsTrue(_readonlyComboBoxWithSelection.IsExpanded);
        }

        [TestMethod]
        public void VerticalScrollPercent_Getted_ReturnsVerticalPosition()
        {
            _editableComboBoxWithSelection.Unsafe.Expand();
            _comboBoxWithManyChildren.Unsafe.Expand();

            Assert.AreEqual(-1, _editableComboBoxWithSelection.VerticalScrollPercent);
            Assert.AreEqual(0, _comboBoxWithManyChildren.VerticalScrollPercent);
        }

        [TestMethod]
        public void VerticalViewSize_Getted_ReturnsVerticalViewSize()
        {
            _editableComboBoxWithSelection.Unsafe.Expand();
            _comboBoxWithManyChildren.Unsafe.Expand();

            Assert.AreEqual(100, _editableComboBoxWithSelection.VerticalViewSize);
            Assert.AreEqual(5, _comboBoxWithManyChildren.VerticalViewSize);
        }

        [TestMethod]
        public void VerticallyScrollable_Getted_ReturnsScrollability()
        {
            _editableComboBoxWithSelection.Unsafe.Expand();
            _comboBoxWithManyChildren.Unsafe.Expand();

            Assert.IsFalse(_editableComboBoxWithSelection.VerticallyScrollable);
            Assert.IsTrue(_comboBoxWithManyChildren.VerticallyScrollable);
        }

        [TestMethod]
        public void FindChildByCondition_ComboBoxHasToScroll_ScrollsToTheItemAndReturnsIt()
        {
            var item = _comboBoxWithManyChildren.FindChildByCondition(c => c.Text == "3Nineth");

            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void UnsafeExpand_Called_ExpandsTheDropDown()
        {
            Assert.IsFalse(_editableComboBoxWithSelection.IsExpanded);

            _editableComboBoxWithSelection.Unsafe.Expand();

            Assert.IsTrue(_editableComboBoxWithSelection.IsExpanded);
        }

        [TestMethod]
        public void UnsafeCollapse_Called_CollapsesTheDropDown()
        {
            Assert.IsFalse(_editableComboBoxWithSelection.IsExpanded);
            _editableComboBoxWithSelection.Unsafe.Expand();
            Assert.IsTrue(_editableComboBoxWithSelection.IsExpanded);

            _editableComboBoxWithSelection.Unsafe.Collapse();

            Assert.IsFalse(_editableComboBoxWithSelection.IsExpanded);
        }

        [TestMethod]
        public void UnsafeSetValue_Called_SetsValueToEditableComboBox()
        {
            Assert.AreEqual("ComboBoxText", _editableComboBoxWithText.Text);

            _editableComboBoxWithText.Unsafe.SetValue("Joachim");

            Assert.AreEqual("Joachim", _editableComboBoxWithText.Text);
        }

        [TestMethod]
        public void UnsafeSetScrollPercent_Called_SetsScrollPosition()
        {
            _comboBoxWithManyChildren.Unsafe.Expand();

            _comboBoxWithManyChildren.Unsafe.SetScrollPercent(75);

            Assert.AreEqual(75, _comboBoxWithManyChildren.VerticalScrollPercent);
        }

        [TestMethod]
        public void UnsafeScrollVertical_Called_ScrollsDown()
        {
            _comboBoxWithManyChildren.Unsafe.Expand();
            var oldPosition = _comboBoxWithManyChildren.VerticalScrollPercent;

            _comboBoxWithManyChildren.Unsafe.ScrollVertical(ScrollAmount.SmallIncrement);

            var newPosition = _comboBoxWithManyChildren.VerticalScrollPercent;

            Assert.AreNotEqual(oldPosition, newPosition);
        }
    }

    // ReSharper restore InconsistentNaming
}
