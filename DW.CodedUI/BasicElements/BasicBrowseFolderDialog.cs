#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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
    /// Represents the BrowseFolderDialog.
    /// </summary>
    public class BasicBrowseFolderDialog : BasicDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicBrowseFolderDialog" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicBrowseFolderDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the descripton text.
        /// </summary>
        public BasicText DescriptionText
        {
            get { return UI.GetChild<BasicText>(By.AutomationId("14146").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the new folder button.
        /// </summary>
        public BasicButton NewFolderButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("14150").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the OK button.
        /// </summary>
        public BasicButton OKButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the tree for selecting a folder.
        /// </summary>
        public BasicTreeView FolderTree
        {
            get { return UI.GetChild<BasicTreeView>(By.AutomationId("100").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Tree)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicBrowseFolderDialogData GetDataCopy()
        {
            var data = new BasicBrowseFolderDialogData();
            FillData(data);

            data.DescriptionText = GetSafeData(() =>
            {
                if (DescriptionText == null)
                    return null;
                return DescriptionText.GetDataCopy();
            });

            data.NewFolderButton = GetSafeData(() =>
            {
                if (NewFolderButton == null)
                    return null;
                return NewFolderButton.GetDataCopy();
            });

            data.OKButton = GetSafeData(() =>
            {
                if (OKButton == null)
                    return null;
                return OKButton.GetDataCopy();
            });

            data.CancelButton = GetSafeData(() =>
            {
                if (CancelButton == null)
                    return null;
                return CancelButton.GetDataCopy();
            });

            data.FolderTree = GetSafeData(() =>
            {
                if (FolderTree == null)
                    return null;
                return FolderTree.GetDataCopy();
            });
            
            return data;
        }
    }
}