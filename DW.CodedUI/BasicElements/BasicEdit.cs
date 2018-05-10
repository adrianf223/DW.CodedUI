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

using System;
using System.Text;
using System.Windows.Automation;
using DW.CodedUI.BasicElements.Data;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a TextBox or RichTextBox.
    /// </summary>
    public class BasicEdit : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicEdit" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicEdit(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly.
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Sets the text into the TextBox.
            /// </summary>
            /// <param name="value">The value to set.</param>
            /// <remarks>Not supported for a RichTextBox.</remarks>
            public void SetValue(string value)
            {
                var pattern = Patterns.GetValuePattern(_automationElement);
                pattern.SetValue(value);
            }

            /// <summary>
            /// Scrolls inside the visible range; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="horizontalAmount">The amount of characters to scroll.</param>
            /// <param name="verticalAmount">The amount of lines to scroll.</param>
            public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.Scroll(horizontalAmount, verticalAmount);
            }

            /// <summary>
            /// Scrolls inside the visible range horizontal; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="amount">The amount of characters to scroll.</param>
            public void ScrollHorizontal(ScrollAmount amount)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.ScrollHorizontal(amount);
            }

            /// <summary>
            /// Scrolls inside the visible range vertical; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="amount">The amount of lines to scroll.</param>
            public void ScrollVertical(ScrollAmount amount)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.ScrollVertical(amount);
            }

            /// <summary>
            /// Sets the horizontal and vertical scroll position.
            /// </summary>
            /// <param name="horizontalPercent">The horizontal percentual value to set.</param>
            /// <param name="verticalPercent">The vertical percentual value to set.</param>
            public void SetScrollPercent(double horizontalPercent, double verticalPercent)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.SetScrollPercent(horizontalPercent, verticalPercent);
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets the written text in the [Rich]TextBox.
        /// </summary>
        public string Text
        {
            get
            {
                var pattern = Patterns.GetTextPattern(AutomationElement);
                return pattern.DocumentRange.GetText(-1);
            }
        }

        /// <summary>
        /// Gets the selected text in the [Rich]TextBox.
        /// </summary>
        public string SelectedText
        {
            get
            {
                var pattern = Patterns.GetTextPattern(AutomationElement);
                var selection = pattern.GetSelection();
                var builder = new StringBuilder();
                foreach (var textPatternRange in selection)
                    builder.Append(textPatternRange.GetText(-1));
                return builder.ToString();
            }
        }

        /// <summary>
        /// Gets a value that indicates if the [Rich]TextBox is read only or not.
        /// </summary>
        /// <remarks>Not supported for a RichTextBox.</remarks>
        public bool IsReadOnly
        {
            get
            {
                var pattern = Patterns.GetValuePattern(AutomationElement);
                return pattern.Current.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets a value that indicates how text can be selected.
        /// </summary>
        public SupportedTextSelection SupportedTextSelection
        {
            get
            {
                var pattern = Patterns.GetTextPattern(AutomationElement);
                return pattern.SupportedTextSelection;
            }
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll.
        /// </summary>
        public double HorizontalScrollPercent
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.HorizontalScrollPercent;
            }
        }

        /// <summary>
        /// Gets the current horizontal view size in percent.
        /// </summary>
        public double HorizontalViewSize
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.HorizontalViewSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the [Rich]TextBox can scroll horizontally.
        /// </summary>
        public bool HorizontallyScrollable
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.HorizontallyScrollable;
            }
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll. 
        /// </summary>
        public double VerticalScrollPercent
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.VerticalScrollPercent;
            }
        }

        /// <summary>
        /// Gets the current vertical view size in percent.
        /// </summary>
        public double VerticalViewSize
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.VerticalViewSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the [Rich]TextBox can scroll vertically.
        /// </summary>
        public bool VerticallyScrollable
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.VerticallyScrollable;
            }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicEditData GetDataCopy()
        {
            var data = new BasicEditData();
            FillData(data);
            data.Text = GetSafeData(() => Text);
            data.IsReadOnly = GetSafeData(() => IsReadOnly);
            return data;
        }
    }
}