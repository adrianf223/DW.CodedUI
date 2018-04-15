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
    /// Represents a MessageBox.
    /// </summary>
    public class BasicMessageBox : BasicWindowBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicMessageBox" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicMessageBox(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        private const string OKButtonId = "1"; // If its the only button it got the automation ID 2
        private const string CancelButtonId = "2";
        private const string AbortButtonId = "3";
        private const string RetryButtonId = "4";
        private const string IgnoreButtonId = "5";
        private const string YesButtonId = "6";
        private const string NoButtonId = "7";
        private const string IconId = "20";
        private const string TextId = "65535";

        /// <summary>
        /// The icon shown in the MessageBox if any; otherwise an exception is thrown.
        /// </summary>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The MessageBox does not contain an icon.</exception>
        public BasicElement Icon
        {
            get { return UI.GetChild(By.AutomationId(IconId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text shown in the MessageBox if any; otherwise an empty string.
        /// </summary>
        public string Text
        {
            get
            {
                var textElement = UI.GetChild<BasicText>(By.AutomationId(TextId), From.Element(this), With.NoTimeout().NoAssert());
                if (textElement == null)
                    return string.Empty;
                return textElement.Text;
            }
        }

        /// <summary>
        /// Gets the OK Button.
        /// </summary>
        public BasicButton OKButton
        {
            get
            {
                var okButton = UI.GetChild<BasicButton>(By.AutomationId(OKButtonId), From.Element(this), With.NoAssert().NoTimeout());
                return okButton ?? CancelButton;
            }
        }

        /// <summary>
        /// Gets the Cancel Button.
        /// </summary>
        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(CancelButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Abort Button.
        /// </summary>
        public BasicButton AbortButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(AbortButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Retry Button.
        /// </summary>
        public BasicButton RetryButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(RetryButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Ignore Button.
        /// </summary>
        public BasicButton IgnoreButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(IgnoreButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Yes Button.
        /// </summary>
        public BasicButton YesButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(YesButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the No Button.
        /// </summary>
        public BasicButton NoButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(NoButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicMessageBoxData GetDataCopy()
        {
            var data = new BasicMessageBoxData();
            FillData(data);

            data.Icon = GetSafeData(() =>
            {
                if (Icon == null)
                    return null;
                return Icon.GetDataCopy();
            });

            data.Text = GetSafeData(() => Text);

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

            data.AbortButton = GetSafeData(() =>
            {
                if (AbortButton == null)
                    return null;
                return AbortButton.GetDataCopy();
            });

            data.RetryButton = GetSafeData(() =>
            {
                if (RetryButton == null)
                    return null;
                return RetryButton.GetDataCopy();
            });

            data.IgnoreButton = GetSafeData(() =>
            {
                if (IgnoreButton == null)
                    return null;
                return IgnoreButton.GetDataCopy();
            });

            data.YesButton = GetSafeData(() =>
            {
                if (YesButton == null)
                    return null;
                return YesButton.GetDataCopy();
            });

            data.NoButton = GetSafeData(() =>
            {
                if (NoButton == null)
                    return null;
                return NoButton.GetDataCopy();
            });

            return data;
        }
    }
}