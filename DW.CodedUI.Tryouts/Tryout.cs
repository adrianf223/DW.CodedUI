using System.Diagnostics;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tryouts
{
    [CodedUITest]
    public class Tryout
    {
        [TestMethod]
        public void Method_TestCondition_ExpectedResult1()
        {
            Process.Start(@"D:\Sources\Playground\WpfApplication31\WpfApplication31\bin\Debug\WpfApplication31.exe");
            var window = WindowFinder.Search(Using.Title("MainWindow"));

            var button = UI.GetChild(By.AutomationId("1001"), From.Element(window));
            MouseEx.Click(button);
            var messageBox = WindowFinder.Search<BasicMessageBox>(Using.Title("title"));
            MouseEx.Click(messageBox.OKButton);

            button = UI.GetChild(By.AutomationId("1002"), From.Element(window));
            MouseEx.Click(button);
            var openfileDialog = WindowFinder.Search<BasicOpenFileDialog>(Using.Title("Öffnen"));
            MouseEx.Click(openfileDialog.CancelButton);

            button = UI.GetChild(By.AutomationId("1003"), From.Element(window));
            MouseEx.Click(button);
            var saveFileDialog = WindowFinder.Search<BasicSaveFileDialog>(Using.Title("Speichern"));
            MouseEx.Click(saveFileDialog.CancelButton);

            button = UI.GetChild(By.AutomationId("1004"), From.Element(window));
            MouseEx.Click(button);
            var fontPickerDialog = WindowFinder.Search<BasicFontPickerDialog>(Using.Title("Schriftart"));
            MouseEx.Click(fontPickerDialog.CancelButton);

            button = UI.GetChild(By.AutomationId("1005"), From.Element(window));
            MouseEx.Click(button);
            var colorPickerDialog = WindowFinder.Search<BasicColorPickerDialog>(Using.Title("Farbe"));
            MouseEx.Click(colorPickerDialog.CancelButton);

            MouseEx.Click(window.CloseButton);
        }

        [TestMethod]
        public void Method_TestCondition_ExpectedResult2()
        {
            Do.Launch(@"D:\Sources\Playground\WpfApplication31\WpfApplication31\bin\Debug\WpfApplication31.exe").And.WaitCPUIdle(5);
        }
    }
}
