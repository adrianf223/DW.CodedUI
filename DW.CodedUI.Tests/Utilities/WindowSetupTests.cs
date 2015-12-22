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

using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests.Utilities
{
    [TestClass]
    public class WindowSetupTests
    {
        [TestMethod]
        public void State_CalledWithMaximized_MaximizesTheWindow()
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            var mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));

            WindowSetup.Prepare(mainWindow).State(WindowState.Maximized);

            Assert.AreEqual(WindowState.Maximized, mainWindow.WindowState);
            mainWindow.CloseButton.Unsafe.Click();
        }

        [TestMethod]
        public void Position_CalledWith100and100_PositionatesTheWuindow()
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            var mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));

            WindowSetup.Prepare(mainWindow).Position(100, 100);

            Assert.AreEqual(100, mainWindow.Properties.BoundingRectangle.Left);
            Assert.AreEqual(100, mainWindow.Properties.BoundingRectangle.Top);
            mainWindow.CloseButton.Unsafe.Click();
        }

        [TestMethod]
        public void Size_CalledWith100and100_PositionatesTheWuindow()
        {
            Do.Launch(TestData.ApplicationPath).And.Wait(1000);
            var mainWindow = WindowFinder.Search(Use.AutomationId(TestData.MainWindowAutomationId));

            WindowSetup.Prepare(mainWindow).Size(500, 400);

            Assert.AreEqual(500, mainWindow.Properties.BoundingRectangle.Width);
            Assert.AreEqual(400, mainWindow.Properties.BoundingRectangle.Height);
            mainWindow.CloseButton.Unsafe.Click();
        }
    }
}
