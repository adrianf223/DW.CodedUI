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

namespace DW.CodedUI.BasicElements.Data
{
    /// <summary>
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicFontPickerDialog" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicFontPickerDialog.GetDataCopy()" />.
    /// </summary>
    public class BasicFontPickerDialogData : BasicElementData
    {
        internal BasicFontPickerDialogData()
        {
        }

        /// <summary>
        /// Gets the section for selecting the font name.
        /// </summary>
        /// <remarks>This is an different displayed ComboBox.</remarks>
        public BasicComboBoxData FontNameSection { get; internal set; }

        /// <summary>
        /// Gets the text box where the font name is written in.
        /// </summary>
        /// <remarks>This is the text box of a writable ComboBox.</remarks>
        public BasicEditData FontNameTextBox { get; internal set; }

        /// <summary>
        /// Gets the list of available font names.
        /// </summary>
        /// <remarks>This is the open drop down of a ComboBox.</remarks>
        public BasicListData FontNameList { get; internal set; }

        /// <summary>
        /// Gets the section for selecting the font style.
        /// </summary>
        /// <remarks>This is an different displayed ComboBox.</remarks>
        public BasicComboBoxData FontStyleSection { get; internal set; }

        /// <summary>
        /// Gets the text box where the font style is written in.
        /// </summary>
        /// <remarks>This is the text box of a writable ComboBox.</remarks>
        public BasicEditData FontStyleTextBox { get; internal set; }

        /// <summary>
        /// Gets the list of available font styles.
        /// </summary>
        /// <remarks>This is the open drop down of a ComboBox.</remarks>
        public BasicListData FontStyleList { get; internal set; }

        /// <summary>
        /// Gets the section for selecting the font size.
        /// </summary>
        /// <remarks>This is an different displayed ComboBox.</remarks>
        public BasicComboBoxData FontSizeSection { get; internal set; }

        /// <summary>
        /// Gets the text box where the font size is written in.
        /// </summary>
        /// <remarks>This is the text box of a writable ComboBox.</remarks>
        public BasicEditData FontSizeTextBox { get; internal set; }

        /// <summary>
        /// Gets the list of available font sizes.
        /// </summary>
        /// <remarks>This is the open drop down of a ComboBox.</remarks>
        public BasicListData FontSizeList { get; internal set; }

        /// <summary>
        /// Gets the CheckBox which defines if the font has to be line through.
        /// </summary>
        public BasicCheckBoxData LineThroughCheckBox { get; internal set; }

        /// <summary>
        /// Gets the CheckBox which defines if the font has to be underlined.
        /// </summary>
        public BasicCheckBoxData UnderlineCheckBox { get; internal set; }

        /// <summary>
        /// Gets the ComboBox to select the font color.
        /// </summary>
        public BasicComboBoxData FontColorComboBox { get; internal set; }

        /// <summary>
        /// Gets the ComboBox to select the font script value.
        /// </summary>
        public BasicComboBoxData ScriptComboBox { get; internal set; }

        /// <summary>
        /// Gets the OK button.
        /// </summary>
        public BasicButtonData OKButton { get; internal set; }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButtonData CancelButton { get; internal set; }

        /// <summary>
        /// Gets the Apply button.
        /// </summary>
        public BasicButtonData ApplyButton { get; internal set; }

        /// <summary>
        /// Gets the Help button.
        /// </summary>
        public BasicButtonData HelpButton { get; internal set; }
    }
}