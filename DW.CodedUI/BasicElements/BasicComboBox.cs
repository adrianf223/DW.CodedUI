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

using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using DW.CodedUI.UITree;

namespace DW.CodedUI.BasicElements
{
    // ReSharper disable UnusedMember.Global

    /// <summary>
    /// Represents a ComboBox
    /// </summary>
    public class BasicComboBox : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the BasicComboBox class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicComboBox(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the selected item
        /// </summary>
        /// <remarks>Not tested yet!</remarks>
        public BasicComboBoxItem SelectedItem // TODO: Test
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                return new BasicComboBoxItem(pattern.Current.GetSelection().FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets all created items
        /// </summary>
        /// <remarks>Not tested yet!</remarks>
        public IEnumerable<BasicComboBoxItem> Items // TODO: Test
        {
            get
            {
                var expandCollapsePattern = (ExpandCollapsePattern)AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                expandCollapsePattern.Expand();
                expandCollapsePattern.Collapse();

                return BasicElementFinder.FindChildrenByClassName<BasicComboBoxItem>(AutomationElement, "ListBoxItem");
            }
        }
    }

    // ReSharper restore UnusedMember.Global
}