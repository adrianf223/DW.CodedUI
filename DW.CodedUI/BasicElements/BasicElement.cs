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

using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    public class BasicElement
    {
        private Highlighter _highlighter;

        public BasicElement(AutomationElement automationElement)
        {
            AutomationElement = automationElement;
        }

        public AutomationElement AutomationElement { get; private set; }

        public AutomationElement.AutomationElementInformation Properties
        {
            get { return AutomationElement.Current; }
        }

        public string Name
        {
            get { return Properties.Name; }
        }

        public bool IsVisible
        {
            get { return !Properties.IsOffscreen; }
        }

        public bool IsEnabled
        {
            get { return Properties.IsEnabled; }
        }

        public void WaitForControlEnabled()
        {
            while (!Properties.IsEnabled)
                Thread.Sleep(100);
        }

        public void WaitForControlVisible()
        {
            while (Properties.IsOffscreen)
                Thread.Sleep(100);
        }
        
        public void BeginHighlight()
        {
            if (_highlighter != null)
                _highlighter.Close();
            _highlighter = new Highlighter();
            _highlighter.Highlight(AutomationElement);
        }

        public void EndHighlight()
        {
            _highlighter.Close();
        }
    }
}
