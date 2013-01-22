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

using System;
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
            /// Scrolls inside the visible range; Small is just like arrow up/down; Large is like page up/down
            /// </summary>
            /// <param name="horizontalAmount">The amount of characters to scroll</param>
            /// <param name="verticalAmount">The amount of lines to scroll</param>
            public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.Scroll(horizontalAmount, verticalAmount);
            }

            /// <summary>
            /// Scrolls inside the visible range horizontal; Small is just like arrow up/down; Large is like page up/down
            /// </summary>
            /// <param name="amount">The amount of characters to scroll</param>
            public void ScrollHorizontal(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollHorizontal(amount);
            }

            /// <summary>
            /// Scrolls inside the visible range vertical; Small is just like arrow up/down; Large is like page up/down
            /// </summary>
            /// <param name="amount">The amount of lines to scroll</param>
            public void ScrollVertical(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollVertical(amount);
            }

            /// <summary>
            /// Sets the horizontal and vertical scroll position
            /// </summary>
            /// <param name="horizontalPercent">The horizontal percentual value to set</param>
            /// <param name="verticalPercent">The vertical percentual value to set</param>
            public void SetScrollPercent(double horizontalPercent, double verticalPercent)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.SetScrollPercent(horizontalPercent, verticalPercent);
            }
        }

        /// <summary>
        /// Gets access to unsafe methods
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets if the ListBox\ListView allows multi selection or not
        /// </summary>
        public bool CanMultiSelect
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                return pattern.Current.CanSelectMultiple;
            }
        }

        /// <summary>
        /// Gets the selected ListViewItems\ListBoxItems
        /// </summary>
        public IEnumerable<BasicListItem> SelectedItems
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                return pattern.Current.GetSelection().Select(element => new BasicListItem(element));
            }
        }

        /// <summary>
        /// Gets all available ListViewItems\ListBoxItems
        /// </summary>
        public IEnumerable<BasicListItem> Items
        {
            get
            {
                if (AutomationElement.Current.ClassName == "ListBox")
                    return BasicElementFinder.FindChildrenByClassName<BasicListItem>(AutomationElement, "ListBoxItem");
                return BasicElementFinder.FindChildrenByClassName<BasicListItem>(AutomationElement, "ListViewItem");
            }
        }

        /// <summary>
        /// Tries to find a ListBoxItem\ListViewItem by the given condition. It scrolls down automatically if needed.
        /// </summary>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public BasicListItem FindChildByCondition(Func<BasicListItem, bool> condition)
        {
            var automationElementCondition = new Func<AutomationElement, bool>(element => condition.Invoke(new BasicListItem(element)));
            var item = BasicElementFinder.FindChildByCondition<BasicListItem>(AutomationElement, automationElementCondition);
            if (item != null)
                return item;
            if (VerticalScrollPercent == -1)
                return null;
            while (VerticalScrollPercent < 100)
            {
                Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
                item = BasicElementFinder.FindChildByCondition<BasicListItem>(AutomationElement, automationElementCondition);
                if (item != null)
                    return item;
            }

            return null;
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll; 
        /// </summary>
        public double HorizontalScrollPercent
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.HorizontalScrollPercent;
            }
        }

        /// <summary>
        /// Gets the current horizontal view size. 100 means 100%
        /// </summary>
        public double HorizontalViewSize
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.HorizontalViewSize;
            }
        }

        /// <summary>
        /// Gets if the ListBox\ListView can scroll horizontally
        /// </summary>
        public bool HorizontallyScrollable
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.HorizontallyScrollable;
            }
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll; 
        /// </summary>
        public double VerticalScrollPercent
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.VerticalScrollPercent;
            }
        }

        /// <summary>
        /// Gets the current vertical view size. 100 means 100%
        /// </summary>
        public double VerticalViewSize
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.VerticalViewSize;
            }
        }

        /// <summary>
        /// Gets if the ListBox\ListView can scroll vertically
        /// </summary>
        public bool VerticallyScrollable
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.VerticallyScrollable;
            }
        }

        /// <summary>
        /// Gets the amount of columns
        /// </summary>
        /// <remarks>Not supported for a ListBox</remarks>
        public int ColumnCount
        {
            get
            {
                object pattern;
                if (AutomationElement.TryGetCurrentPattern(GridPattern.Pattern, out pattern))
                    return ((GridPattern)pattern).Current.ColumnCount;
                throw new NotSupportedException(string.Format("The '{0}' does not support ColumnCount.", AutomationElement.Current.ClassName));
            }
        }

        /// <summary>
        /// Gets the amount of rows
        /// </summary>
        /// <remarks>Not supported for a ListBox</remarks>
        public int RowCount
        {
            get
            {
                object pattern;
                if (AutomationElement.TryGetCurrentPattern(GridPattern.Pattern, out pattern))
                    return ((GridPattern)pattern).Current.RowCount;
                throw new NotSupportedException(string.Format("The '{0}' does not support RowCount.", AutomationElement.Current.ClassName));
            }
        }

        /// <summary>
        /// Returns the BasicElement from the cell
        /// </summary>
        /// <param name="row">The item row</param>
        /// <param name="column">The item column</param>
        /// <returns>The BasicElement</returns>
        /// <remarks>Not supported for a ListBox</remarks>
        public BasicElement GetItem(int row, int column) // TODO: Try to put into specific BasicElement
        {
            object pattern;
            if (AutomationElement.TryGetCurrentPattern(GridPattern.Pattern, out pattern))
                return new BasicElement(((GridPattern)pattern).GetItem(row, column));
            throw new NotSupportedException(string.Format("The '{0}' does not support GetItem.", AutomationElement.Current.ClassName));
        }


        /// <summary>
        /// Returns the column headers of the ListView
        /// </summary>
        /// <returns>The column headers</returns>
        /// <remarks>Not supported for a ListBox</remarks>
        public IEnumerable<BasicElement> GetColumnHeaders() // TODO: Put to BasicGridViewColumnHeader[]
        {
            object pattern;
            if (AutomationElement.TryGetCurrentPattern(TablePattern.Pattern, out pattern))
                return ((TablePattern) pattern).Current.GetColumnHeaders().Select(i => new BasicElement(i));
            throw new NotSupportedException(string.Format("The '{0}' does not support GetColumnHeaders.", AutomationElement.Current.ClassName));
        }
    }
}