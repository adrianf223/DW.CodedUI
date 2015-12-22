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
    public class KeyboardExTests
    {
        // TODO: Replace notepad by a better testable application

        [TestMethod]
        public void PressKey_TypeText_TypeLowerTextWithShiftHoldDown_TheTextAppearsInupperCase()
        {
            Do.Launch(@"C:\Windows\System32\notepad.exe").And.Wait(1000);
            var window = WindowFinder.Search(Use.Process("notepad"));

            KeyboardEx.PressKey(window, ModifierKeys.Shift);
            KeyboardEx.TypeText("demo", 50);
            KeyboardEx.ReleaseKey(ModifierKeys.Shift).And.Wait(2000);

            MouseEx.Click(window.CloseButton).And.Wait(1000);
            var messageBox = WindowFinder.Search<BasicMessageBox>(Use.Title("Editor"));
            var dontSaveButton = UI.GetChild(By.AutomationId("CommandButton_7"), From.Element(messageBox));
            MouseEx.Click(dontSaveButton);
        }

        [TestMethod]
        public void TypeText_SomeTextTypedIntoNotepad_WindowWantsToSaveOnClose()
        {
            Do.Launch(@"C:\Windows\System32\notepad.exe").And.Wait(1000);
            var window = WindowFinder.Search(Use.Process("notepad"));

            KeyboardEx.TypeText(window, "das ist ein Text").And.Wait(1000);

            MouseEx.Click(window.CloseButton).And.Wait(1000);
            var messageBox = WindowFinder.Search<BasicMessageBox>(Use.Title("Editor"));
            var dontSaveButton = UI.GetChild(By.AutomationId("CommandButton_7"), From.Element(messageBox));
            MouseEx.Click(dontSaveButton);
        }

        // TODO: Test just more to be sure everything works
    }
}
