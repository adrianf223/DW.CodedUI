#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

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
    /// Represents the FontPickerDialog.
    /// </summary>
    public class BasicFontPickerDialog : BasicDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicFontPickerDialog" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicFontPickerDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the section for selecting the font name.
        /// </summary>
        /// <remarks>This is an different displayed ComboBox.</remarks>
        public BasicComboBox FontNameSection
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1136").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the text box where the font name is written in.
        /// </summary>
        /// <remarks>This is the text box of a writable ComboBox.</remarks>
        public BasicEdit FontNameTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(FontNameSection)); }
        }

        /// <summary>
        /// Gets the list of available font names.
        /// </summary>
        /// <remarks>This is the open drop down of a ComboBox.</remarks>
        public BasicList FontNameList
        {
            get { return UI.GetChild<BasicList>(By.AutomationId("1000").And.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(FontNameSection)); }
        }

        /// <summary>
        /// Gets the section for selecting the font style.
        /// </summary>
        /// <remarks>This is an different displayed ComboBox.</remarks>
        public BasicComboBox FontStyleSection
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1137").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the text box where the font style is written in.
        /// </summary>
        /// <remarks>This is the text box of a writable ComboBox.</remarks>
        public BasicEdit FontStyleTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(FontStyleSection)); }
        }

        /// <summary>
        /// Gets the list of available font styles.
        /// </summary>
        /// <remarks>This is the open drop down of a ComboBox.</remarks>
        public BasicList FontStyleList
        {
            get { return UI.GetChild<BasicList>(By.AutomationId("1000").And.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(FontStyleSection)); }
        }

        /// <summary>
        /// Gets the section for selecting the font size.
        /// </summary>
        /// <remarks>This is an different displayed ComboBox.</remarks>
        public BasicComboBox FontSizeSection
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1138").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the text box where the font size is written in.
        /// </summary>
        /// <remarks>This is the text box of a writable ComboBox.</remarks>
        public BasicEdit FontSizeTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(FontSizeSection)); }
        }

        /// <summary>
        /// Gets the list of available font sizes.
        /// </summary>
        /// <remarks>This is the open drop down of a ComboBox.</remarks>
        public BasicList FontSizeList
        {
            get { return UI.GetChild<BasicList>(By.AutomationId("1000").And.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(FontSizeSection)); }
        }

        /// <summary>
        /// Gets the CheckBox which defines if the font has to be line through.
        /// </summary>
        public BasicCheckBox LineThroughCheckBox
        {
            get { return UI.GetChild<BasicCheckBox>(By.AutomationId("1040").And.Condition(e => Equals(e.Properties.ControlType, ControlType.CheckBox)), From.Element(FontSizeSection)); }
        }

        /// <summary>
        /// Gets the CheckBox which defines if the font has to be underlined.
        /// </summary>
        public BasicCheckBox UnderlineCheckBox
        {
            get { return UI.GetChild<BasicCheckBox>(By.AutomationId("1041").And.Condition(e => Equals(e.Properties.ControlType, ControlType.CheckBox)), From.Element(FontSizeSection)); }
        }

        /// <summary>
        /// Gets the ComboBox to select the font color.
        /// </summary>
        public BasicComboBox FontColorComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1139").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the ComboBox to select the font script value.
        /// </summary>
        public BasicComboBox ScriptComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1140").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the OK button.
        /// </summary>
        public BasicButton OKButton
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
        /// Gets the Apply button.
        /// </summary>
        public BasicButton ApplyButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1026").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        /// <summary>
        /// Gets the Help button.
        /// </summary>
        public BasicButton HelpButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1038").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicFontPickerDialogData GetDataCopy()
        {
            var data = new BasicFontPickerDialogData();
            FillData(data);

            data.FontNameSection = GetSafeData(() =>
            {
                if (FontNameSection == null)
                    return null;
                return FontNameSection.GetDataCopy();
            });

            data.FontNameTextBox = GetSafeData(() =>
            {
                if (FontNameTextBox == null)
                    return null;
                return FontNameTextBox.GetDataCopy();
            });

            data.FontNameList = GetSafeData(() =>
            {
                if (FontNameList == null)
                    return null;
                return FontNameList.GetDataCopy();
            });

            data.FontStyleSection = GetSafeData(() =>
            {
                if (FontStyleSection == null)
                    return null;
                return FontStyleSection.GetDataCopy();
            });

            data.FontStyleTextBox = GetSafeData(() =>
            {
                if (FontStyleTextBox == null)
                    return null;
                return FontStyleTextBox.GetDataCopy();
            });

            data.FontStyleList = GetSafeData(() =>
            {
                if (FontStyleList == null)
                    return null;
                return FontStyleList.GetDataCopy();
            });

            data.FontSizeSection = GetSafeData(() =>
            {
                if (FontSizeSection == null)
                    return null;
                return FontSizeSection.GetDataCopy();
            });

            data.FontSizeTextBox = GetSafeData(() =>
            {
                if (FontSizeTextBox == null)
                    return null;
                return FontSizeTextBox.GetDataCopy();
            });

            data.FontSizeList = GetSafeData(() =>
            {
                if (FontSizeList == null)
                    return null;
                return FontSizeList.GetDataCopy();
            });

            data.LineThroughCheckBox = GetSafeData(() =>
            {
                if (LineThroughCheckBox == null)
                    return null;
                return LineThroughCheckBox.GetDataCopy();
            });

            data.UnderlineCheckBox = GetSafeData(() =>
            {
                if (UnderlineCheckBox == null)
                    return null;
                return UnderlineCheckBox.GetDataCopy();
            });

            data.FontColorComboBox = GetSafeData(() =>
            {
                if (FontColorComboBox == null)
                    return null;
                return FontColorComboBox.GetDataCopy();
            });

            data.ScriptComboBox = GetSafeData(() =>
            {
                if (ScriptComboBox == null)
                    return null;
                return ScriptComboBox.GetDataCopy();
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

            data.ApplyButton = GetSafeData(() =>
            {
                if (ApplyButton == null)
                    return null;
                return ApplyButton.GetDataCopy();
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
