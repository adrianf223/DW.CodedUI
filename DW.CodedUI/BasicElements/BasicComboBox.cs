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

using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using DW.CodedUI.BasicElements.Data;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a ComboBox.
    /// </summary>
    public class BasicComboBox : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicComboBox" /> class
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicComboBox(AutomationElement automationElement)
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
            /// Expands the ComboBox.
            /// </summary>
            public void Expand()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Expand();
            }

            /// <summary>
            /// Collapses the ComboBox.
            /// </summary>
            public void Collapse()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Collapse();
            }

            /// <summary>
            /// Sets the value if the ComboBox is editable.
            /// </summary>
            /// <param name="value">The value to set.</param>
            public void SetValue(string value)
            {
                object valuePattern;
                if (_automationElement.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern))
                    ((ValuePattern)valuePattern).SetValue(value);
            }

            /// <summary>
            /// Sets the vertical scroll position.
            /// </summary>
            /// <param name="verticalPercent">The percentual value to set.</param>
            public void SetScrollPercent(double verticalPercent)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.SetScrollPercent(ScrollPattern.NoScroll, verticalPercent);
            }

            /// <summary>
            /// Scrolls up or down; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="amount">The amount of lines to scroll</param>
            public void ScrollVertical(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollVertical(amount);
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets the selected item if any; otherwise null.
        /// </summary>
        public BasicComboBoxItem SelectedItem
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                var selectedItem = pattern.Current.GetSelection().FirstOrDefault();
                return selectedItem != null ? new BasicComboBoxItem(selectedItem) : null;
            }
        }

        /// <summary>
        /// Gets all created items. In WPF child elements gets created first if the ComboBox has been opened once.
        /// </summary>
        public IEnumerable<BasicComboBoxItem> Items
        {
            get
            {
                Unsafe.Expand();
                Unsafe.Collapse();
                return UI.GetChildren<BasicComboBoxItem>(By.ClassName("ListBoxItem"), From.Element(this));
            }
        }

        /// <summary>
        /// Gets the text from the selected child if set; otherwise the written text.
        /// </summary>
        public string Text
        {
            get
            {
                if (SelectedItem == null)
                {
                    var valuePattern = (ValuePattern)AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                    return valuePattern.Current.Value;
                }
                return SelectedItem.Text;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the ComboBox is readonly or not.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                object valuePattern;
                if (AutomationElement.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern))
                    return ((ValuePattern)valuePattern).Current.IsReadOnly;
                return true;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the ComboBox is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                var expandCollapsePattern = (ExpandCollapsePattern)AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                return expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded;
            }
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll.
        /// </summary>
        public double VerticalScrollPercent
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
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
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.VerticalViewSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the drop down content can scroll vertically.
        /// </summary>
        public bool VerticallyScrollable
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.VerticallyScrollable;
            }
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicComboBoxData GetDataCopy()
        {
            var data = new BasicComboBoxData();
            FillData(data);
            data.SelectedItem = GetSafeData(() =>
            {
                if (SelectedItem == null)
                    return null;
                return SelectedItem.GetDataCopy();
            });
            var items = new List<BasicComboBoxItemData>();
            data.Items = items;
            try
            {
                foreach (var item in Items)
                {
                    if (item != null)
                        items.Add(item.GetDataCopy());
                }
            }
            catch { }
            data.Text = GetSafeData(() => Text);
            data.IsReadOnly = GetSafeData(() => IsReadOnly);
            data.IsExpanded = GetSafeData(() => IsExpanded);
            return data;
        }
    }
}