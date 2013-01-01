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
    /// <summary>
    /// Represents a ListBox or ListView
    /// </summary>
    public class BasicList : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the BasicList class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicList(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets if the list allows multi selection or not
        /// </summary>
        /// <remarks>Not tested yet!</remarks>
        public bool CanMultiSelect // TODO: Test
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                return pattern.Current.CanSelectMultiple;
            }
        }

        /// <summary>
        /// Gets the selected items
        /// </summary>
        /// <remarks>Not tested yet!</remarks>
        public IEnumerable<BasicListItem> SelectedItems // TODO: Test
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                return pattern.Current.GetSelection().Select(element => new BasicListItem(element));
            }
        }

        /// <summary>
        /// Gets all available items
        /// </summary>
        /// <remarks>Not tested yet!</remarks>
        public IEnumerable<BasicListItem> Items // TODO: Test
        {
            get
            {
                var listBoxChilds = BasicElementFinder.FindChildrenByClassName<BasicListItem>(AutomationElement, "ListBoxItem");
                if (listBoxChilds.Any())
                    return listBoxChilds;
                var listViewChilds = BasicElementFinder.FindChildrenByClassName<BasicListItem>(AutomationElement, "ListViewItem");
                return listViewChilds;
            }
        }
    }
}