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
    /// Represents a TextBox
    /// </summary>
    public class BasicEdit : BasicElement
    {
        // Patterns:
        // ValuePatternIdentifiers
        // ScrollPatternIdentifiers
        // TextPatternIdentifiers
        // SynchronizedInputPatternIdentifiers

        /// <summary>
        /// Initializes a new instance of the BasicEdit class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicEdit(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the written text
        /// </summary>
        /// <remarks>Not tested yet!</remarks>
        public string Text
        {
            get
            {
                var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
                return pattern.DocumentRange.GetText(-1);
            }
        }
    }

    // ReSharper restore ClassNeverInstantiated.Global
}