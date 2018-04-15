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

namespace DW.CodedUI.BasicElements.Data
{
    /// <summary>
    /// Represents the data of a <see cref="DW.CodedUI.BasicElements.BasicMessageBox" /> at the time of the call <see cref="DW.CodedUI.BasicElements.BasicMessageBox.GetDataCopy()" />.
    /// </summary>
    public class BasicMessageBoxData : BasicElementData
    {
        internal BasicMessageBoxData()
        {
        }

        /// <summary>
        /// The icon shown in the MessageBox if any; otherwise an exception is thrown.
        /// </summary>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The MessageBox does not contain an icon.</exception>
        public BasicElementData Icon { get; internal set; }

        /// <summary>
        /// Gets the text shown in the MessageBox if any; otherwise an empty string.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets the OK Button.
        /// </summary>
        public BasicButtonData OKButton { get; internal set; }

        /// <summary>
        /// Gets the Cancel Button.
        /// </summary>
        public BasicButtonData CancelButton { get; internal set; }

        /// <summary>
        /// Gets the Abort Button.
        /// </summary>
        public BasicButtonData AbortButton { get; internal set; }

        /// <summary>
        /// Gets the Retry Button.
        /// </summary>
        public BasicButtonData RetryButton { get; internal set; }

        /// <summary>
        /// Gets the Ignore Button.
        /// </summary>
        public BasicButtonData IgnoreButton { get; internal set; }

        /// <summary>
        /// Gets the Yes Button.
        /// </summary>
        public BasicButtonData YesButton { get; internal set; }

        /// <summary>
        /// Gets the No Button.
        /// </summary>
        public BasicButtonData NoButton { get; internal set; }
    }
}
