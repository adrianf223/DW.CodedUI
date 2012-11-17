#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.Utilities
{
    public class TextBlockReader
    {
        public static string GetAutomationId(WpfControl container)
        {
            string id, text;
            GetTextBlockInfo(container, out id, out text);
            return id;
        }

        public static string GetText(WpfControl container)
        {
            string id, text;
            GetTextBlockInfo(container, out id, out text);
            return text;
        }

        private static void GetTextBlockInfo(WpfControl container, out string id, out string text)
        {
            var cellElement = (UITechnologyElement)container.GetProperty(UITestControl.PropertyNames.UITechnologyElement);
            var ae = (AutomationElement)cellElement.NativeElement;
            var child = TreeWalker.RawViewWalker.GetFirstChild(ae);
            id = child.Current.AutomationId;
            text = child.Current.Name;
        }
    }
}
