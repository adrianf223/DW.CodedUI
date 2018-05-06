using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    [TestClass]
    public class PatternsTests
    {
        private static BasicWindow _mainWindow;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            _mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _mainWindow.CloseButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
        }

        [TestMethod]
        public void InvokePattern_ReadFromButton_CanInvoked()
        {
            var button = UI.GetChild(By.AutomationId("CUI_ShowMessageBox_Button"), From.Element(_mainWindow));

            var pattern = Patterns.GetInvokePattern(button.AutomationElement);
            pattern.Invoke();

            DynamicSleep.Wait(1000);
            var messageBox = WindowFinder.Search<BasicMessageBox>(Use.Title("MessageBoxTitle"));
            messageBox.OKButton.Unsafe.Click();
        }
    }
}
