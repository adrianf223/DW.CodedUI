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
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicTreeViewItem" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicTreeViewItem.GetDataCopy()" />.
    /// </summary>
    public class BasicTreeViewItemData : BasicElementData
    {
        internal BasicTreeViewItemData()
        {
        }

        /// <summary>
        /// Gets a value that indicates if it is selected or not.
        /// </summary>
        public bool IsSelected { get; internal set; }

        /// <summary>
        /// Gets a value that indicates if it is expanded or not.
        /// </summary>
        public bool IsExpanded { get; internal set; }

        /// <summary>
        /// Gets all available child tree items. In WPF normally all child items get created first as soon they became visible.
        /// </summary>
        public IEnumerable<BasicTreeViewItemData> Items { get; internal set; }

        /// <summary>
        /// Gets the text written in the TreeViewItem.
        /// </summary>
        public string Text { get; internal set; }
    }
}