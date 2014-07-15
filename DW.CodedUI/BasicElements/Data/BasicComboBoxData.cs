#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2014 David Wendland

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
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicComboBox" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicComboBox.GetDataCopy()" />.
    /// </summary>
    public class BasicComboBoxData : BasicElementData
    {
        internal BasicComboBoxData()
        {
        }

        /// <summary>
        /// Gets the selected item if any; otherwise null.
        /// </summary>
        public BasicComboBoxItemData SelectedItem { get; internal set; }

        /// <summary>
        /// Gets all created items. In WPF child elements gets created first if the ComboBox has been opened once.
        /// </summary>
        public IEnumerable<BasicComboBoxItemData> Items { get; internal set; }

        /// <summary>
        /// Gets the text from the selected child if set; otherwise the written text.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets a value that indicates if the ComboBox is readonly or not.
        /// </summary>
        public bool IsReadOnly { get; internal set; }

        /// <summary>
        /// Gets a value that indicates if the ComboBox is expanded or not.
        /// </summary>
        public bool IsExpanded { get; internal set; }
    }
}