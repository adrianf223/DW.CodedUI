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
    public class BasicEditTests
    {
        private Window _wpfWindow;
        private TestableWindow _testableWindow;
        private BasicEdit _edit;

        [TestInitialize]
        public void Setup()
        {
            _wpfWindow = new Window();
            _wpfWindow.Height = 300;
            _wpfWindow.Width = 300;
            _wpfWindow.Title = "BasicEditTests";

            var wpfTextBlock = new TextBox();
            wpfTextBlock.Text = "TextBox Text";
            AutomationProperties.SetAutomationId(wpfTextBlock, "TextBoxId");
            
            _wpfWindow.Content = wpfTextBlock;

            _wpfWindow.Show();
            _testableWindow = new TestableWindow("BasicEditTests");
            _edit = BasicElementFinder.FindChildByAutomationId<BasicEdit>(_testableWindow, "TextBoxId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _wpfWindow.Close();
        }

        [TestMethod]
        public void Text_Getted_ReturnsContentText()
        {
            var text = _edit.Text;

            Assert.AreEqual("TextBox Text", text);
        }
    }

    // ReSharper restore InconsistentNaming
}
