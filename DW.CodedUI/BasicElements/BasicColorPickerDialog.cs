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
    /// Represents a ColorPickerDialog.
    /// </summary>
    public class BasicColorPickerDialog : BasicWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicColorPickerDialog" /> class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicColorPickerDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the section where all square colors are selectable.
        /// </summary>
        public BasicElement ColorsSection
        {
            get { return UI.GetChild(By.AutomationId("720").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to expand the section where custom colors can be defined.
        /// </summary>
        public BasicButton DefineColorsButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("719").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the section where the user can pick the color out of gradients.
        /// </summary>
        public BasicElement ColorPickSection
        {
            get { return UI.GetChild(By.AutomationId("710").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the section where the user can chose the color brightness with s kind of slider.
        /// </summary>
        public BasicElement ColorGradientSection
        {
            get { return UI.GetChild(By.AutomationId("702").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the secion where the current user color is shown.
        /// </summary>
        public BasicElement ColorDisplaySection
        {
            get { return UI.GetChild(By.AutomationId("709").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box where the color shade value is written in.
        /// </summary>
        public BasicEdit ColorShadeTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("703").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box where the color chroma value is written in.
        /// </summary>
        public BasicEdit ColorChromaTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("704").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box where the color brightness value is written in.
        /// </summary>
        public BasicEdit ColorBrightnessTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("705").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box where the red color value is written in.
        /// </summary>
        public BasicEdit RedTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("706").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box where the green color value is written in.
        /// </summary>
        public BasicEdit GreenTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("707").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box where the blue color value is written in.
        /// </summary>
        public BasicEdit BlueTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("708").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to apply custom colors.
        /// </summary>
        public BasicButton ApplyColorButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("712").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
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
        /// Gets the help button.
        /// </summary>
        public BasicButton HelpButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1038").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicColorPickerDialogData GetDataCopy()
        {
            var data = new BasicColorPickerDialogData();
            FillData(data);

            data.ColorsSection = GetSafeData(() =>
            {
                if (ColorsSection == null)
                    return null;
                return ColorsSection.GetDataCopy();
            });

            data.DefineColorsButton = GetSafeData(() =>
            {
                if (DefineColorsButton == null)
                    return null;
                return DefineColorsButton.GetDataCopy();
            });

            data.ColorPickSection = GetSafeData(() =>
            {
                if (ColorPickSection == null)
                    return null;
                return ColorPickSection.GetDataCopy();
            });

            data.ColorGradientSection = GetSafeData(() =>
            {
                if (ColorGradientSection == null)
                    return null;
                return ColorGradientSection.GetDataCopy();
            });

            data.ColorDisplaySection = GetSafeData(() =>
            {
                if (ColorDisplaySection == null)
                    return null;
                return ColorDisplaySection.GetDataCopy();
            });

            data.ColorShadeTextBox = GetSafeData(() =>
            {
                if (ColorShadeTextBox == null)
                    return null;
                return ColorShadeTextBox.GetDataCopy();
            });

            data.ColorChromaTextBox = GetSafeData(() =>
            {
                if (ColorChromaTextBox == null)
                    return null;
                return ColorChromaTextBox.GetDataCopy();
            });

            data.ColorBrightnessTextBox = GetSafeData(() =>
            {
                if (ColorBrightnessTextBox == null)
                    return null;
                return ColorBrightnessTextBox.GetDataCopy();
            });

            data.RedTextBox = GetSafeData(() =>
            {
                if (RedTextBox == null)
                    return null;
                return RedTextBox.GetDataCopy();
            });

            data.GreenTextBox = GetSafeData(() =>
            {
                if (GreenTextBox == null)
                    return null;
                return GreenTextBox.GetDataCopy();
            });

            data.BlueTextBox = GetSafeData(() =>
            {
                if (BlueTextBox == null)
                    return null;
                return BlueTextBox.GetDataCopy();
            });

            data.ApplyColorButton = GetSafeData(() =>
            {
                if (ApplyColorButton == null)
                    return null;
                return ApplyColorButton.GetDataCopy();
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