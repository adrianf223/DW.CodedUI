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

using System.Collections.Generic;

namespace DW.CodedUI.BasicElements.Data
{
    /// <summary>
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicList" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicList.GetDataCopy()" />.
    /// </summary>
    public class BasicListData : BasicElementData
    {
        internal BasicListData()
        {
        }

        /// <summary>
        /// Gets a value that indicates if the ListBox/ListView allows multi selection or not.
        /// </summary>
        public bool CanMultiSelect { get; internal set; }

        /// <summary>
        /// Gets the selected ListViewItems\ListBoxItems.
        /// </summary>
        public IEnumerable<BasicListItemData> SelectedItems { get; internal set; }

        /// <summary>
        /// Gets all available ListViewItems\ListBoxItems. In WPF by default list items gets created first as soon they became visible.
        /// </summary>
        public IEnumerable<BasicListItemData> Items { get; internal set; }

        /// <summary>
        /// Gets the amount of columns.
        /// </summary>
        /// <remarks>Not supported for a ListBox.</remarks>
        /// <exception cref="System.NotSupportedException">The element does not support ColumnCount.</exception>
        public int ColumnCount { get; internal set; }

        /// <summary>
        /// Gets the amount of rows.
        /// </summary>
        /// <remarks>Not supported for a ListBox.</remarks>
        /// <exception cref="System.NotSupportedException">The element does not support RowCount.</exception>
        public int RowCount { get; internal set; }
    }
}