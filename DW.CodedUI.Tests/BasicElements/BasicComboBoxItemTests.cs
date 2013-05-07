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
    public class BasicComboBoxItemTests
    {
        private BasicWindow _application;
        private BasicComboBox _comboBox;
        private BasicComboBox _comboBoxWithManyChildren;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _comboBox = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_application, "ComboBoxEditableWithSelectionId");
            _comboBoxWithManyChildren = BasicElementFinder.FindChildByAutomationId<BasicComboBox>(_application, "ComboBoxReadonlyWithManyChildrenId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Unsafe.Close();
        }

        [TestMethod]
        public void IsSelected_Getted_ReturnsSelectionState()
        {
            Assert.IsTrue(_comboBox.Items.First().IsSelected);
            Assert.IsFalse(_comboBox.Items.Last().IsSelected);
        }

        [TestMethod]
        public void Text_Getted_ReturnsContentText()
        {
            var item = _comboBox.Items.First();
            var pattern = item.SupportedPatterns;

            Assert.AreEqual("SelectedChild", _comboBox.Items.First().Text);
            Assert.AreEqual("UnselectedChild", _comboBox.Items.Last().Text);
        }

        [TestMethod]
        public void UnsafeDeselect_Called_DeselectsTheItem()
        {
            var item = _comboBox.Items.First();
            Assert.IsNotNull(_comboBox.SelectedItem);
            Assert.IsTrue(item.IsSelected);

            item.Unsafe.Deselect();

            Assert.IsNull(_comboBox.SelectedItem);
            Assert.IsFalse(item.IsSelected);
        }

        [TestMethod]
        public void UnsafeSelect_Called_SelectsTheItem()
        {
            var item = _comboBox.Items.First();
            item.Unsafe.Deselect();
            Assert.IsNull(_comboBox.SelectedItem);
            Assert.IsFalse(item.IsSelected);

            item.Unsafe.Select();

            Assert.IsNotNull(_comboBox.SelectedItem);
            Assert.IsTrue(item.IsSelected);
        }

        [TestMethod]
        public void UnsafeScrollIntoView_Called_ScrollsToTheItem()
        {
            _comboBoxWithManyChildren.Unsafe.Expand();
            _comboBoxWithManyChildren.Items.First().Unsafe.Select();
            _comboBoxWithManyChildren.FindChildByCondition(x => x.Text == "2Seventh");
            var oldPosition = _comboBoxWithManyChildren.VerticalScrollPercent;
            Assert.IsTrue(oldPosition > 0);

            _comboBoxWithManyChildren.Unsafe.Expand();
            _comboBoxWithManyChildren.SelectedItem.Unsafe.ScrollIntoView();

            var newPosition = _comboBoxWithManyChildren.VerticalScrollPercent;
            Assert.AreEqual(0, newPosition);
        }
    }

    // ReSharper restore InconsistentNaming
}
