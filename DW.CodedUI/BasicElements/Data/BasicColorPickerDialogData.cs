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
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicColorPickerDialog" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicColorPickerDialog.GetDataCopy()" />.
    /// </summary>
    public class BasicColorPickerDialogData : BasicElementData
    {
        internal BasicColorPickerDialogData()
        {
        }

        /// <summary>
        /// Gets the section where all square colors are selectable.
        /// </summary>
        public BasicElementData ColorsSection { get; internal set; }

        /// <summary>
        /// Gets the button to expand the section where custom colors can be defined.
        /// </summary>
        public BasicButtonData DefineColorsButton { get; internal set; }

        /// <summary>
        /// Gets the section where the user can pick the color out of gradients.
        /// </summary>
        public BasicElementData ColorPickSection { get; internal set; }

        /// <summary>
        /// Gets the section where the user can chose the color brightness with s kind of slider.
        /// </summary>
        public BasicElementData ColorGradientSection { get; internal set; }

        /// <summary>
        /// Gets the secion where the current user color is shown.
        /// </summary>
        public BasicElementData ColorDisplaySection { get; internal set; }

        /// <summary>
        /// Gets the text box where the color shade value is written in.
        /// </summary>
        public BasicEditData ColorShadeTextBox { get; internal set; }

        /// <summary>
        /// Gets the text box where the color chroma value is written in.
        /// </summary>
        public BasicEditData ColorChromaTextBox { get; internal set; }

        /// <summary>
        /// Gets the text box where the color brightness value is written in.
        /// </summary>
        public BasicEditData ColorBrightnessTextBox { get; internal set; }

        /// <summary>
        /// Gets the text box where the red color value is written in.
        /// </summary>
        public BasicEditData RedTextBox { get; internal set; }

        /// <summary>
        /// Gets the text box where the green color value is written in.
        /// </summary>
        public BasicEditData GreenTextBox { get; internal set; }

        /// <summary>
        /// Gets the text box where the blue color value is written in.
        /// </summary>
        public BasicEditData BlueTextBox { get; internal set; }

        /// <summary>
        /// Gets the button to apply custom colors.
        /// </summary>
        public BasicButtonData ApplyColorButton { get; internal set; }

        /// <summary>
        /// Gets the OK button.
        /// </summary>
        public BasicButtonData OKButton { get; internal set; }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButtonData CancelButton { get; internal set; }

        /// <summary>
        /// Gets the help button.
        /// </summary>
        public BasicButtonData HelpButton { get; internal set; }
    }
}