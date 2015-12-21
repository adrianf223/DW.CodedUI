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
using DW.CodedUI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Tests
{
    [TestClass]
    public class SomethingTests
    {
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

            KeyboardEx.TypeText(window, "das ist ein Text");
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
