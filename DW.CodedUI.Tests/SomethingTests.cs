using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class SomethingTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            CodedUIEnvironment.LoggerSettings.LogFilesDirectory = @"D:\Logs";
            CodedUIEnvironment.LoggerSettings.LogPassedTestsToo = true;
            CodedUIEnvironment.LoggerSettings.AddTestResultToFileName = true;

            CodedUIEnvironment.LoggerSettings.DateTimeFormat = "HH:mm:ss.ffff";
            CodedUIEnvironment.LoggerSettings.ShortLogging = true;
            CodedUIEnvironment.LoggerSettings.LogLineFormat = ":: %DateTime% >> %Message%";

            CodedUIEnvironment.LoggerSettings.PrepareInstantWrite(TestContext);
        }

        [TestCleanup]
        public void Cleanup()
        {
            LogWriter.Write(TestContext);
        }

        [TestMethod]
        public void Notepad_AddAndRemoveLineBreakAndClose()
        {
            Do.Launch(@"C:\Windows\System32\notepad.exe").And.Wait(1000);
            var window = WindowFinder.Search(Use.Process("notepad"));

            var viewMenuItem = UI.GetChild(By.Name("Ansicht"), From.Element(window));
            MouseEx.Click(viewMenuItem);
            DynamicSleep.Wait(1000);

            var subMenuItem = UI.GetChild(By.AutomationId("27"), From.Element(window));
            MouseEx.Click(subMenuItem);
            DynamicSleep.Wait(1000);

            MouseEx.Click(viewMenuItem);
            DynamicSleep.Wait(1000);

            subMenuItem = UI.GetChild(By.Name("Statusleiste"), From.Element(window));
            MouseEx.Click(subMenuItem);
            DynamicSleep.Wait(1000);

            MouseEx.Click(window.CloseButton);
        }

        [TestMethod]
        public void Notepad_AddSomeTextAndCloseWithoutSave()
        {
            Do.Launch(@"C:\Windows\System32\notepad.exe").And.Wait(1000);
            var window = WindowFinder.Search(Use.Process("notepad"));

            KeyboardEx.SendKeys(window, "das ist ein Text");
            DynamicSleep.Wait(1000);

            MouseEx.Click(window.CloseButton);
            DynamicSleep.Wait(1000);

            var messageBox = WindowFinder.Search<BasicMessageBox>(Use.Title("Editor"));
            var dontSaveButton = UI.GetChild(By.AutomationId("CommandButton_7"), From.Element(messageBox));
            MouseEx.Click(dontSaveButton);
            DynamicSleep.Wait(1000);
        }

        [TestMethod]
        public void FindWindowByAutomationId()
        {
            Do.Launch(@"D:\Sources\Playground\WpfApplication13\WpfApplication13\bin\Debug\WpfApplication13.exe").And.Wait(2000);

            var window = WindowFinder.Search<BasicWindow>(Use.AutomationId("KrasseSache"));

            MouseEx.Click(window.CloseButton);
        }
    }
}
