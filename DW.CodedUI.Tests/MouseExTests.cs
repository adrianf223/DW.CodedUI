#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

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

using System.Windows;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class MouseExTests
    {
        private static BasicWindow _mainWindow;
        private static BasicWindow _testWindow;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            _mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));
            var currentButton = UI.GetChild<BasicButton>(By.AutomationId("CUI_MouseExTests_Button"), From.Element(_mainWindow));
            currentButton.Unsafe.Click();
            DynamicSleep.Wait(1000);
            _testWindow = WindowFinder.Search(Use.AutomationId("CUI_MouseExTestsWindow"), And.NoAssert());
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
        public void Click_ChangeStatusBarVisibilityTwoTimes_DoesItAccordingly()
        {
            var statusBar = UI.GetChild(By.AutomationId("CUI_StatusBar"), From.Element(_testWindow));
            Assert.IsTrue(statusBar.IsVisible);

            var viewMenuItem = UI.GetChild(By.AutomationId("CUI_ViewMenuItem"), From.Element(_testWindow));
            MouseEx.Click(viewMenuItem).And.Wait(1000);
            var statusleisteMenuItem = UI.GetChild(By.AutomationId("CUI_ToggleStatusbarMenuItem"), From.Element(_testWindow));
            MouseEx.Click(statusleisteMenuItem).And.Wait(1000);
            Assert.IsFalse(statusBar.IsVisible);

            MouseEx.Click(viewMenuItem).And.Wait(1000);
            statusleisteMenuItem = UI.GetChild(By.AutomationId("CUI_ToggleStatusbarMenuItem"), From.Element(_testWindow));
            MouseEx.Click(statusleisteMenuItem).And.Wait(1000);
            Assert.IsTrue(statusBar.IsVisible);
        }

        [TestMethod]
        public void Move_To_PlacesTheMouse()
        {
            var destination = Position.Point(new Point(200, 300));

            MouseEx.Move(destination);
        }

        [TestMethod]
        public void Move_FromPointToPointFor3Seconds_MovesTheMouseAccordingly()
        {
            var source = Position.Point(new Point(100, 100));
            var destination = Position.Point(new Point(300, 400));

            MouseEx.Move(source, destination, 3000);
        }

        [TestMethod]
        public void Move_FromCurrentToPointFor3Seconds_MovesTheMouseAccordingly()
        {
            var source = Position.Current();
            var destination = Position.Point(new Point(300, 400));

            MouseEx.Move(source, destination, 2000);
        }

        [TestMethod]
        public void PressReleaseButtons_WithAnElementOnTheTopRight_DragsTheIconToAnotherPosition()
        {
            // Element on the right monitor on the very top right
            MouseEx.Move(Position.Point(new Point(3770, 45)));
            MouseEx.PressButtons(MouseButtons.Left);
            MouseEx.Move(Position.Point(new Point(3770, 45)), Position.Point(new Point(3770, 200)), 1000);
            MouseEx.ReleaseButtons(MouseButtons.Left);

            // Drag and drop working cannot be asserted, just place an element on the second monitor upper right and watch it
        }

        [TestMethod]
        public void DoubleClick_InsideTheWindow_ExecutesTheDoubleClick()
        {
            var textBox = UI.GetChild<BasicEdit>(By.AutomationId("CUI_InputTextBox"), From.Element(_testWindow));

            MouseEx.DoubleClick(textBox).And.Wait(1000);

            Assert.AreEqual("TextBox got doubleclicked", textBox.Text);
        }

        [TestMethod]
        public void Click_WithControlPressedInList_SelectsItems()
        {
            // Explorer open full screen on the left monitor
            MouseEx.Move(Position.Point(new Point(-1300, 210)));
            MouseEx.Click().And.Wait(500);
            MouseEx.Move(Position.Point(new Point(-1300, 250)));
            MouseEx.Click(ModifierKeys.Control).And.Wait(500);
            MouseEx.Move(Position.Point(new Point(-1300, 290)));
            MouseEx.Click(ModifierKeys.Control).And.Wait(500);
        }

        [TestMethod]
        public void Click_WithControlPressedInListButThenAnymore_SelectsItems()
        {
            // Explorer open full screen on the left monitor
            MouseEx.Move(Position.Point(new Point(-1300, 210)));
            MouseEx.Click().And.Wait(500);
            MouseEx.Move(Position.Point(new Point(-1300, 250)));
            MouseEx.Click(ModifierKeys.Control).And.Wait(500);
            MouseEx.Move(Position.Point(new Point(-1300, 290)));
            MouseEx.Click(ModifierKeys.Control).And.Wait(500);
            MouseEx.Move(Position.Point(new Point(-1300, 310)));
            MouseEx.Click().And.Wait(500);
        }

        [TestMethod]
        public void Click_WithShiftPressedInList_SelectsItems()
        {
            // Explorer open full screen on the left monitor
            MouseEx.Move(Position.Point(new Point(-1300, 210)));
            MouseEx.Click().And.Wait(500);
            MouseEx.Move(Position.Point(new Point(-1300, 310))); 
            MouseEx.Click(ModifierKeys.Shift).And.Wait(500);
        }
    }
}