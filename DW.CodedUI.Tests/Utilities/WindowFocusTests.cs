#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    [TestClass]
    public class WindowFocusTests
    {
        private static BasicWindow _mainWindow;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            _mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));
            var currentButton = UI.GetChild<BasicButton>(By.AutomationId("CUI_WindowFocusTests_Button"), From.Element(_mainWindow));
            currentButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            var basicWindow = WindowFinder.Search(Use.AutomationId("CUI_WindowFocusTestsWindow", CompareKind.StartsWith), And.NoAssert().And.Timeout(100));
            if (basicWindow != null)
            {
                basicWindow.CloseButton.Unsafe.Click();
                DynamicSleep.Wait(1000);
            }
            basicWindow = WindowFinder.Search(Use.AutomationId("CUI_WindowFocusTestsWindow", CompareKind.StartsWith), And.NoAssert().And.Timeout(100));
            if (basicWindow != null)
            {
                basicWindow.CloseButton.Unsafe.Click();
                DynamicSleep.Wait(1000);
            }

            _mainWindow.CloseButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
        }

        [TestMethod]
        public void BringOnTop_TypesTextToDifferentWindows_TheWindowsGetsTheTextAccordingly()
        {
            var window1 = WindowFinder.Search(Use.AutomationId("CUI_WindowFocusTestsWindow_1"));
            var window2 = WindowFinder.Search(Use.AutomationId("CUI_WindowFocusTestsWindow_2"));
            var textBox1 = UI.GetChild<BasicEdit>(By.AutomationId("CUI_InputTextBox"), From.Element(window1));
            var textBox2 = UI.GetChild<BasicEdit>(By.AutomationId("CUI_InputTextBox"), From.Element(window2));

            WindowFocus.BringOnTop(window1);
            MouseEx.Click(window1);
            KeyboardEx.TypeText("First Window Text").And.Wait(1000);

            WindowFocus.BringOnTop(window2);
            MouseEx.Click(window2);
            KeyboardEx.TypeText("Second Window Text").And.Wait(1000);

            Assert.AreEqual("First Window Text", textBox1.Text);
            Assert.AreEqual("Second Window Text", textBox2.Text);
        }
    }
}
