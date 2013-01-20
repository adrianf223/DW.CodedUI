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
    /// <summary>
    /// Represents a CheckBox
    /// </summary>
    public class BasicCheckBox : BasicElement
    {
        // Patterns:
        // TogglePattern
        // SynchronizedInputPattern

        /// <summary>
        /// Initializes a new instance of the BasicCheckBox class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicCheckBox(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Gets access to unsafe methods
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

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
            /// Changes the IsChecked state whithout using the mouse
            /// </summary>
            public void Toggle()
            {
                var pattern = (TogglePattern)_automationElement.GetCurrentPattern(TogglePattern.Pattern);
                pattern.Toggle();
            }
        }

        /// <summary>
        /// Gets if the box is checked or not
        /// </summary>
        public bool IsChecked
        {
            get
            {
                var pattern = (TogglePattern)AutomationElement.GetCurrentPattern(TogglePattern.Pattern);
                return pattern.Current.ToggleState == ToggleState.On;
            }
        }

        /// <summary>
        /// Gets the text written in the CheckBox
        /// </summary>
        /// <remarks>If AutomationProperties.AutomationName is set this text is replaced by this. To get the text a child TextBlox has to be searched.</remarks>
        public string Text
        {
            get { return Name; }
        }
    }
}