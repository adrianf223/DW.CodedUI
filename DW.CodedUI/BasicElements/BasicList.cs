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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using DW.CodedUI.BasicElements.Data;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a ListBox or ListView.
    /// </summary>
    public class BasicList : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicList" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicList(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly.
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Scrolls inside the visible range; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="horizontalAmount">The amount of characters to scroll.</param>
            /// <param name="verticalAmount">The amount of lines to scroll.</param>
            public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.Scroll(horizontalAmount, verticalAmount);
            }

            /// <summary>
            /// Scrolls inside the visible range horizontal; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="amount">The amount of characters to scroll.</param>
            public void ScrollHorizontal(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollHorizontal(amount);
            }

            /// <summary>
            /// Scrolls inside the visible range vertical; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="amount">The amount of lines to scroll.</param>
            public void ScrollVertical(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollVertical(amount);
            }

            /// <summary>
            /// Sets the horizontal and vertical scroll position in percent.
            /// </summary>
            /// <param name="horizontalPercent">The horizontal percentual value to set.</param>
            /// <param name="verticalPercent">The vertical percentual value to set.</param>
            public void SetScrollPercent(double horizontalPercent, double verticalPercent)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.SetScrollPercent(horizontalPercent, verticalPercent);
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets a value that indicates if the ListBox/ListView allows multi selection or not.
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
        /// Gets the selected ListViewItems\ListBoxItems.
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
        /// Gets all available ListViewItems\ListBoxItems. In WPF by default list items gets created first as soon they became visible.
        /// </summary>
        public IEnumerable<BasicListItem> Items
        {
            get
            {
                return UI.GetChildren<BasicListItem>(By.ClassName("ListBoxItem").Or.ClassName("ListViewItem"), From.Element(this));
            }
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll.
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
        /// Gets the current horizontal view size in percent.
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
        /// Gets a valuie that indicates if the ListBox/ListView can scroll horizontally.
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
        /// Gets the current vertical scroll position; -1 if nothing has to scroll.
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
        /// Gets the current vertical view size in percent.
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
        /// Gets a value that indicates if the ListBox\ListView can scroll vertically.
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
        /// Gets the amount of columns.
        /// </summary>
        /// <remarks>Not supported for a ListBox.</remarks>
        /// <exception cref="System.NotSupportedException">The element does not support ColumnCount.</exception>
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
        /// Gets the amount of rows.
        /// </summary>
        /// <remarks>Not supported for a ListBox.</remarks>
        /// <exception cref="System.NotSupportedException">The element does not support RowCount.</exception>
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
        /// Returns the BasicElement from the cell.
        /// </summary>
        /// <param name="row">The item row.</param>
        /// <param name="column">The item column.</param>
        /// <returns>The BasicElement.</returns>
        /// <remarks>Not supported for a ListBox.</remarks>
        /// <exception cref="System.NotSupportedException">The element does not support GetItem.</exception>
        public BasicElement GetItem(int row, int column)
        {
            object pattern;
            if (AutomationElement.TryGetCurrentPattern(GridPattern.Pattern, out pattern))
                return new BasicElement(((GridPattern)pattern).GetItem(row, column));
            throw new NotSupportedException(string.Format("The '{0}' does not support GetItem.", AutomationElement.Current.ClassName));
        }

        /// <summary>
        /// Returns the column headers of the ListView.
        /// </summary>
        /// <returns>The column headers.</returns>
        /// <remarks>Not supported for a ListBox.</remarks>
        /// <exception cref="System.NotSupportedException">The element does not support GetColumnHeaders.</exception>
        public IEnumerable<BasicElement> GetColumnHeaders()
        {
            object pattern;
            if (AutomationElement.TryGetCurrentPattern(TablePattern.Pattern, out pattern))
                return ((TablePattern) pattern).Current.GetColumnHeaders().Select(i => new BasicElement(i));
            throw new NotSupportedException(string.Format("The '{0}' does not support GetColumnHeaders.", AutomationElement.Current.ClassName));
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicListData GetDataCopy()
        {
            var data = new BasicListData();
            FillData(data);
            data.CanMultiSelect = GetSafeData(() => CanMultiSelect);

            var selectedItems = new List<BasicListItemData>();
            data.SelectedItems = selectedItems;
            try
            {
                foreach (var item in Items)
                {
                    if (item != null)
                        selectedItems.Add(item.GetDataCopy());
                }
            }
            catch { }

            var items = new List<BasicListItemData>();
            data.Items = items;
            try
            {
                foreach (var item in Items)
                {
                    if (item != null)
                        items.Add(item.GetDataCopy());
                }
            }
            catch { }

            data.ColumnCount = GetSafeData(() => ColumnCount);
            data.RowCount = GetSafeData(() => RowCount);
            return data;
        }
    }
}