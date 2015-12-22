#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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

using System.Drawing;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    [TestClass]
    public class ColorDetectorTests
    {
        private static BasicWindow _mainWindow;
        private static BasicWindow _testWindow;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            _mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));
            var currentButton = UI.GetChild<BasicButton>(By.AutomationId("CUI_ColorDetectorTests_Button"), From.Element(_mainWindow));
            currentButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
            _testWindow = WindowFinder.Search(Use.AutomationId("CUI_ColorDetectorTestsWindow"), And.NoAssert());
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _testWindow.CloseButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
            _mainWindow.CloseButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
        }

        [TestMethod]
        public void GetColor_RedTextBox_ReturnsRed()
        {
            var textBox = UI.GetChild(By.AutomationId("CUI_Red_TextBox"), From.Element(_testWindow));

            var color = ColorDetector.GetColor(textBox);

            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), color);
        }

        [TestMethod]
        public void GetColor_BlueTextBox_ReturnsBlue()
        {
            var textBox = UI.GetChild(By.AutomationId("CUI_Blue_TextBox"), From.Element(_testWindow));

            var color = ColorDetector.GetColor(textBox, At.BottomRight(50, 50));

            Assert.AreEqual(Color.FromArgb(255, 0, 0, 255), color);
        }
    }
}
