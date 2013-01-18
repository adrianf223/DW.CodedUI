using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using DW.CodedUI.Application;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.BasicElements
{
    // ReSharper disable InconsistentNaming

    [CodedUITest]
    public class BasicTextTests
    {
        private Window _wpfWindow;
        private TestableWindow _testableWindow;
        private BasicText _textBlock;
        private BasicText _label;

        [TestInitialize]
        public void Setup()
        {
            _wpfWindow = new Window();
            _wpfWindow.Height = 300;
            _wpfWindow.Width = 300;
            _wpfWindow.Title = "BasicTextTests";

            var stackPanel = new StackPanel();
            var wpfLabel = new Label();
            wpfLabel.Content = "Label Text";
            AutomationProperties.SetAutomationId(wpfLabel, "LabelId");
            stackPanel.Children.Add(wpfLabel);

            var wpfTextBlock = new TextBlock();
            wpfTextBlock.Text = "TextBlock Text";
            AutomationProperties.SetAutomationId(wpfTextBlock, "TextBlockId");
            stackPanel.Children.Add(wpfTextBlock);

            _wpfWindow.Content = stackPanel;

            _wpfWindow.Show();
            _testableWindow = new TestableWindow("BasicTextTests");
            _textBlock = BasicElementFinder.FindChildByAutomationId<BasicText>(_testableWindow, "TextBlockId");
            _label = BasicElementFinder.FindChildByAutomationId<BasicText>(_testableWindow, "LabelId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _wpfWindow.Close();
        }

        [TestMethod]
        public void Text_ReadFromTextBlock_ReturnsText()
        {
            var text = _textBlock.Text;

            Assert.AreEqual("TextBlock Text", text);
        }

        [TestMethod]
        public void Text_ReadFromLabel_ReturnsText()
        {
            var text = _label.Text;

            Assert.AreEqual("Label Text", text);
        }
    }

    // ReSharper restore InconsistentNaming
}
