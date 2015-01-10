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

using System.Windows.Automation;
using DW.CodedUI.BasicElements.Data;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents the OpenFileDialog.
    /// </summary>
    public class BasicOpenFileDialog : BasicDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicOpenFileDialog" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicOpenFileDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the ComboBox to write the file name(s) in.
        /// </summary>
        public BasicComboBox InputComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1148").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the upper BreadCrumbBar.
        /// </summary>
        public BasicElement BreadCrumbBar
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("41477").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Pane)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box in the upper BreadCrumbBar to write a location in.
        /// </summary>
        public BasicElement BreadCrumbTextBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ToolBar)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Filters ComboBox.
        /// </summary>
        public BasicComboBox FilterComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1136").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Open button.
        /// </summary>
        public BasicButton OpenButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the list with the files in the current folder.
        /// </summary>
        public BasicList FilesList
        {
            get { return UI.GetChild<BasicList>(By.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box for searching.
        /// </summary>
        public BasicEdit SearchTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("SearchEditBox"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to start or cancel search.
        /// </summary>
        public BasicButton SearchButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("SearchBoxSearchButton"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the tree with the available folders.
        /// </summary>
        public BasicTreeView FolderTree
        {
            get { return UI.GetChild<BasicTreeView>(By.AutomationId("100").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Tree)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the ToolBar.
        /// </summary>
        public BasicElement ToolBar
        {
            get { return UI.GetChild<BasicElement>(By.AutomationId("FolderBandModuleInner"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to change the current view style.
        /// </summary>
        public BasicButton ChangeViewButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("ViewControl"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to show or hide the current preview pane.
        /// </summary>
        public BasicButton ShowPreviewButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("PreviewButton"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button for show the help.
        /// </summary>
        public BasicButton HelpButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("HelpButton"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicOpenFileDialogData GetDataCopy()
        {
            var data = new BasicOpenFileDialogData();
            FillData(data);

            data.InputComboBox = GetSafeData(() =>
            {
                if (InputComboBox == null)
                    return null;
                return InputComboBox.GetDataCopy();
            });

            data.BreadCrumbBar = GetSafeData(() =>
            {
                if (BreadCrumbBar == null)
                    return null;
                return BreadCrumbBar.GetDataCopy();
            });

            data.BreadCrumbTextBox = GetSafeData(() =>
            {
                if (BreadCrumbTextBox == null)
                    return null;
                return BreadCrumbTextBox.GetDataCopy();
            });

            data.FilterComboBox = GetSafeData(() =>
            {
                if (FilterComboBox == null)
                    return null;
                return FilterComboBox.GetDataCopy();
            });

            data.CancelButton = GetSafeData(() =>
            {
                if (CancelButton == null)
                    return null;
                return CancelButton.GetDataCopy();
            });

            data.OpenButton = GetSafeData(() =>
            {
                if (OpenButton == null)
                    return null;
                return OpenButton.GetDataCopy();
            });

            data.FilesList = GetSafeData(() =>
            {
                if (FilesList == null)
                    return null;
                return FilesList.GetDataCopy();
            });

            data.SearchTextBox = GetSafeData(() =>
            {
                if (SearchTextBox == null)
                    return null;
                return SearchTextBox.GetDataCopy();
            });

            data.SearchButton = GetSafeData(() =>
            {
                if (SearchButton == null)
                    return null;
                return SearchButton.GetDataCopy();
            });

            data.FolderTree = GetSafeData(() =>
            {
                if (FolderTree == null)
                    return null;
                return FolderTree.GetDataCopy();
            });

            data.ToolBar = GetSafeData(() =>
            {
                if (ToolBar == null)
                    return null;
                return ToolBar.GetDataCopy();
            });

            data.ChangeViewButton = GetSafeData(() =>
            {
                if (ChangeViewButton == null)
                    return null;
                return ChangeViewButton.GetDataCopy();
            });

            data.ShowPreviewButton = GetSafeData(() =>
            {
                if (ShowPreviewButton == null)
                    return null;
                return ShowPreviewButton.GetDataCopy();
            });

            data.HelpButton = GetSafeData(() =>
            {
                if (HelpButton == null)
                    return null;
                return HelpButton.GetDataCopy();
            });

            return data;
        }
    }
}
