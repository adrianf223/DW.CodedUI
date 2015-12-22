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

using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class WindowFinderTests
    {
        // TODO: Replace application under test
        [TestMethod]
        public void Search_ByTitle_ReturnsTheWindow()
        {
            Do.Launch(@"D:\Sources\Playground\WpfApplication13\WpfApplication13\bin\Debug\WpfApplication13.exe").And.Wait(2000);

            var window = WindowFinder.Search<BasicWindow>(Use.Title("mainwindow"));

            MouseEx.Click(window.CloseButton);
        }

        [TestMethod]
        public void Search_ByAutomationId_ReturnsTheWindow()
        {
            Do.Launch(@"D:\Sources\Playground\WpfApplication13\WpfApplication13\bin\Debug\WpfApplication13.exe").And.Wait(2000);

            var window = WindowFinder.Search<BasicWindow>(Use.AutomationId("KrasseSache"));

            MouseEx.Click(window.CloseButton);
        }

        // TODO: Add some more tests to be sure it always works well
    }
}
