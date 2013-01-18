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
    public class BasicButtonTests
    {
        private Window _wpfWindow;
        private Button _wpfButton;
        private TestableWindow _testableWindow;
        private BasicButton _button;

        [TestInitialize]
        public void Setup()
        {
            _wpfWindow = new Window();
            _wpfWindow.Height = 300;
            _wpfWindow.Width = 300;
            _wpfWindow.Title = "BasicButtonTests";

            _wpfButton = new Button();
            _wpfButton.Content = "Button Text";
            AutomationProperties.SetAutomationId(_wpfButton, "ButtonId");
            _wpfWindow.Content = _wpfButton;

            _wpfWindow.Show();
            _testableWindow = new TestableWindow("BasicButtonTests");
            _button = BasicElementFinder.FindChildByAutomationId<BasicButton>(_testableWindow, "ButtonId");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _wpfWindow.Close();
        }

        [TestMethod]
        public void UnsafeClick_Called_ClicksTheButton()
        {
            var triggered = false;
            var eventHandler = new RoutedEventHandler((s, e) => triggered = true);
            _wpfButton.Click += eventHandler;

            DispatcherUtility.DoEvents();
            _button.Unsafe.Click();
            
            DispatcherUtility.DoEvents();
            Assert.IsTrue(triggered);

            _wpfButton.Click -= eventHandler;
        }

        [TestMethod]
        public void Text_Getted_ReturnsContentText()
        {
            Assert.AreEqual("Button Text", _button.Text);
        }
    }

    // ReSharper restore InconsistentNaming
}
