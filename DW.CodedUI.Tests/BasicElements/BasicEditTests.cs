using System;
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
    public class BasicEditTests
    {
        private TestableApplication _application;
        private BasicEdit _multilineTextBox;
        private BasicEdit _normalTextBox;
        private BasicEdit _readonlyTextBox;
        private BasicEdit _richTextBox;
        private BasicEdit _textBoxWithManyText;
        private BasicEdit _richTextBoxWithManyText;

        [TestInitialize]
        public void Setup()
        {
            _application = ApplicationFactory.Launch(ApplicationInfo.Title, ApplicationInfo.ExecutablePath);
            Thread.Sleep(ApplicationInfo.StartupWaitTime);

            _multilineTextBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_application, "MultilineTextBoxId");
            _normalTextBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_application, "NormalTextBoxId");
            _readonlyTextBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_application, "ReadonlyTextBoxId");
            _richTextBox = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_application, "RichTextBoxId");
            _textBoxWithManyText = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_application, "TextBoxWithManyTextId");
            _richTextBoxWithManyText = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_application, "RichTextBoxWithManyTextId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _application.Shutdown();
        }

        [TestMethod]
        public void Text_Getted_ReturnsWrittenText()
        {
            Assert.AreEqual("MultilineTextBoxText", _multilineTextBox.Text);
            Assert.AreEqual("NormalTextBoxText", _normalTextBox.Text);
            Assert.AreEqual("RichTextBoxText", _richTextBox.Text);
        }

        [TestMethod]
        public void IsReadOnly_Getter_ReturnsReadOnlyState()
        {
            Assert.IsFalse(_normalTextBox.IsReadOnly);
            Assert.IsTrue(_readonlyTextBox.IsReadOnly);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void IsReadOnly_GettedForRichTextBox_ThrowsNotSupportedException()
        {
            Assert.IsFalse(_richTextBox.IsReadOnly);
        }

        [TestMethod]
        public void SupportedTextSelection_Getted_ReturnsSelectionPossibilities()
        {
            Assert.AreEqual(SupportedTextSelection.Single, _normalTextBox.SupportedTextSelection);
            Assert.AreEqual(SupportedTextSelection.Single, _richTextBox.SupportedTextSelection);
        }

        [TestMethod]
        public void HorizontalScrollPercent_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.AreEqual(0, _textBoxWithManyText.HorizontalScrollPercent);
            Assert.AreEqual(0, _richTextBoxWithManyText.HorizontalScrollPercent);

            _textBoxWithManyText.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);
            _richTextBoxWithManyText.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);

            Assert.AreNotEqual(0, _textBoxWithManyText.HorizontalScrollPercent);
            Assert.AreNotEqual(0, _richTextBoxWithManyText.HorizontalScrollPercent);
        }

        [TestMethod]
        public void HorizontalViewSize_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.IsTrue(_textBoxWithManyText.HorizontalViewSize > 0 && _textBoxWithManyText.HorizontalViewSize < 100);
            Assert.IsTrue(_richTextBoxWithManyText.HorizontalViewSize > 0 && _richTextBoxWithManyText.HorizontalViewSize < 100);
        }

        [TestMethod]
        public void HorizontallyScrollable_Getted_ReturnsScrollPossibility()
        {
            Assert.IsTrue(_textBoxWithManyText.HorizontallyScrollable);
            Assert.IsTrue(_richTextBoxWithManyText.HorizontallyScrollable);
        }

        [TestMethod]
        public void VerticalScrollPercent_Getted_ReturnsVerticalScrollPostion()
        {
            Assert.AreEqual(0, _textBoxWithManyText.VerticalScrollPercent);
            Assert.AreEqual(0, _richTextBoxWithManyText.VerticalScrollPercent);

            _textBoxWithManyText.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            _richTextBoxWithManyText.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);

            Assert.AreNotEqual(0, _textBoxWithManyText.VerticalScrollPercent);
            Assert.AreNotEqual(0, _richTextBoxWithManyText.VerticalScrollPercent);
        }

        [TestMethod]
        public void VerticalViewSize_Getted_ReturnsHorizontalScrollPostion()
        {
            Assert.IsTrue(_textBoxWithManyText.VerticalViewSize > 0 && _textBoxWithManyText.VerticalViewSize < 100);
            Assert.IsTrue(_richTextBoxWithManyText.VerticalViewSize > 0 && _richTextBoxWithManyText.VerticalViewSize < 100);
        }

        [TestMethod]
        public void VerticallyScrollable_Getted_ReturnsScrollPossibility()
        {
            Assert.IsTrue(_textBoxWithManyText.VerticallyScrollable);
            Assert.IsTrue(_richTextBoxWithManyText.VerticallyScrollable);
        }

        [TestMethod]
        public void UnsafeSetValue_Called_SetsTheText()
        {
            _normalTextBox.Unsafe.SetValue("Karlheinz");

            Assert.AreEqual("Karlheinz", _normalTextBox.Text);
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void UnsafeSetValue_CalledOnRichTextBox_ThrowsException()
        {
            _richTextBox.Unsafe.SetValue("Karlheinz");
        }

        [TestMethod]
        public void UnsafeScroll_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _textBoxWithManyText.HorizontalScrollPercent;
            var oldVerticalPercent = _textBoxWithManyText.VerticalScrollPercent;
            _textBoxWithManyText.Unsafe.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
            var newHorizontalPercent = _textBoxWithManyText.HorizontalScrollPercent;
            var newVerticalPercent = _textBoxWithManyText.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);

            oldHorizontalPercent = _richTextBoxWithManyText.HorizontalScrollPercent;
            oldVerticalPercent = _richTextBoxWithManyText.VerticalScrollPercent;
            _richTextBoxWithManyText.Unsafe.Scroll(ScrollAmount.LargeIncrement, ScrollAmount.LargeIncrement);
            newHorizontalPercent = _richTextBoxWithManyText.HorizontalScrollPercent;
            newVerticalPercent = _richTextBoxWithManyText.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }

        [TestMethod]
        public void UnsafeScrollHorizontal_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _textBoxWithManyText.HorizontalScrollPercent;
            _textBoxWithManyText.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);
            var newHorizontalPercent = _textBoxWithManyText.HorizontalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);

            oldHorizontalPercent = _richTextBoxWithManyText.HorizontalScrollPercent;
            _richTextBoxWithManyText.Unsafe.ScrollHorizontal(ScrollAmount.LargeIncrement);
            newHorizontalPercent = _richTextBoxWithManyText.HorizontalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
        }

        [TestMethod]
        public void UnsafeScrollVertical_Called_ScrollsInTheVisibleRange()
        {
            var oldVerticalPercent = _textBoxWithManyText.VerticalScrollPercent;
            _textBoxWithManyText.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            var newVerticalPercent = _textBoxWithManyText.VerticalScrollPercent;

            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);

            oldVerticalPercent = _richTextBoxWithManyText.VerticalScrollPercent;
            _richTextBoxWithManyText.Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
            newVerticalPercent = _richTextBoxWithManyText.VerticalScrollPercent;

            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }

        [TestMethod]
        public void UnsafeSetScrollPercent_Called_ScrollsInTheVisibleRange()
        {
            var oldHorizontalPercent = _textBoxWithManyText.HorizontalScrollPercent;
            var oldVerticalPercent = _textBoxWithManyText.VerticalScrollPercent;
            _textBoxWithManyText.Unsafe.SetScrollPercent(50, 50);
            var newHorizontalPercent = _textBoxWithManyText.HorizontalScrollPercent;
            var newVerticalPercent = _textBoxWithManyText.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);

            oldHorizontalPercent = _richTextBoxWithManyText.HorizontalScrollPercent;
            oldVerticalPercent = _richTextBoxWithManyText.VerticalScrollPercent;
            _richTextBoxWithManyText.Unsafe.SetScrollPercent(50, 50);
            newHorizontalPercent = _richTextBoxWithManyText.HorizontalScrollPercent;
            newVerticalPercent = _richTextBoxWithManyText.VerticalScrollPercent;

            Assert.AreNotEqual(oldHorizontalPercent, newHorizontalPercent);
            Assert.AreNotEqual(oldVerticalPercent, newVerticalPercent);
        }
    }

    // ReSharper restore InconsistentNaming
}
