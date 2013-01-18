#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

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

namespace DW.CodedUI.BasicElements
{
    // ReSharper disable ClassNeverInstantiated.Global

    /// <summary>
    /// Represents a button
    /// </summary>
    public class BasicButton : BasicElement
    {
        // Patterns:
        // InvokePattern
        // SynchronizedInputPatternIdentifiers

        /// <summary>
        /// Initializes a new instance of the BasicButton class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicButton(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Invokes a click on a button whithout using the mouse
            /// </summary>
            /// <remarks>
            /// It doesn't matter if a modal dialog is open and the button cannot clicked by the user, the button gets invoked
            /// </remarks>
            public void Click()
            {
                var invokePattern = (InvokePattern) _automationElement.GetCurrentPattern(InvokePattern.Pattern);
                invokePattern.Invoke();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets the text written in the button
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }

    // ReSharper restore ClassNeverInstantiated.Global
}