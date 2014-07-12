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

using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents the SaveFileDialog.
    /// </summary>
    public class BasicSaveFileDialog : BasicDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicSaveFileDialog" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicSaveFileDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the text box for searching.
        /// </summary>
        public BasicEdit SearchTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("SearchEditBox"), From.Element(this)); }
        }

        /// <summary>
        /// Gets the button to start or cancel search.
        /// </summary>
        public BasicButton SearchButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("SearchBoxSearchButton"), From.Element(this)); }
        }

        /// <summary>
        /// Gets the upper BreadCrumbBar.
        /// </summary>
        public BasicElement BreadCrumbBar
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("40965").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Pane)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the text box in the upper BreadCrumbBar to write a location in.
        /// </summary>
        public BasicElement BreadCrumbTextBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ToolBar)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the tree with the available folders.
        /// </summary>
        public BasicTreeView FolderTree
        {
            get { return UI.GetChild<BasicTreeView>(By.AutomationId("100").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Tree)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the text box to write the file name(s) in.
        /// </summary>
        public BasicElement InputTextBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the Filters ComboBox.
        /// </summary>
        public BasicComboBox FilterComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("FileTypeControlHost"), From.Element(this)); }
        }

        /// <summary>
        /// Gets the Save button.
        /// </summary>
        public BasicButton SaveButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the list with the files in the current folder.
        /// </summary>
        public BasicList FilesList
        {
            get { return UI.GetChild<BasicList>(By.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the ToolBar.
        /// </summary>
        public BasicElement ToolBar
        {
            get { return UI.GetChild<BasicElement>(By.AutomationId("FolderBandModuleInner"), From.Element(this)); }
        }

        /// <summary>
        /// Gets the button to change the current view style.
        /// </summary>
        public BasicButton ChangeViewButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("ViewControl"), From.Element(this)); }
        }

        /// <summary>
        /// Gets the button for show the help.
        /// </summary>
        public BasicButton HelpButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("HelpButton"), From.Element(this)); }
        }
    }
}
