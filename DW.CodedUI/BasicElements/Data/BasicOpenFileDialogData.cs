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

namespace DW.CodedUI.BasicElements.Data
{
    /// <summary>
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicOpenFileDialog" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicOpenFileDialog.GetDataCopy()" />.
    /// </summary>
    public class BasicOpenFileDialogData : BasicElementData
    {
        internal BasicOpenFileDialogData()
        {
        }

        /// <summary>
        /// Gets the ComboBox to write the file name(s) in.
        /// </summary>
        public BasicComboBoxData InputComboBox { get; internal set; }

        /// <summary>
        /// Gets the upper BreadCrumbBar.
        /// </summary>
        public BasicElementData BreadCrumbBar { get; internal set; }

        /// <summary>
        /// Gets the text box in the upper BreadCrumbBar to write a location in.
        /// </summary>
        public BasicElementData BreadCrumbTextBox { get; internal set; }

        /// <summary>
        /// Gets the Filters ComboBox.
        /// </summary>
        public BasicComboBoxData FilterComboBox { get; internal set; }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButtonData CancelButton { get; internal set; }

        /// <summary>
        /// Gets the Open button.
        /// </summary>
        public BasicButtonData OpenButton { get; internal set; }

        /// <summary>
        /// Gets the list with the files in the current folder.
        /// </summary>
        public BasicListData FilesList { get; internal set; }

        /// <summary>
        /// Gets the text box for searching.
        /// </summary>
        public BasicEditData SearchTextBox { get; internal set; }

        /// <summary>
        /// Gets the button to start or cancel search.
        /// </summary>
        public BasicButtonData SearchButton { get; internal set; }

        /// <summary>
        /// Gets the tree with the available folders.
        /// </summary>
        public BasicTreeViewData FolderTree { get; internal set; }

        /// <summary>
        /// Gets the ToolBar.
        /// </summary>
        public BasicElementData ToolBar { get; internal set; }

        /// <summary>
        /// Gets the button to change the current view style.
        /// </summary>
        public BasicButtonData ChangeViewButton { get; internal set; }

        /// <summary>
        /// Gets the button to show or hide the current preview pane.
        /// </summary>
        public BasicButtonData ShowPreviewButton { get; internal set; }

        /// <summary>
        /// Gets the button for show the help.
        /// </summary>
        public BasicButtonData HelpButton { get; internal set; }
    }
}