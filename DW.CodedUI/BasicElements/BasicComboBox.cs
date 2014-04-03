using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

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
        /// Tries to find a ComboBoxItem by the given condition. It scrolls down automatically if needed.
        /// </summary>
        /// <param name="condition">The condition to check on every child control.</param>
        /// <returns>The first found child element if any; otherwise null.</returns>
        public BasicComboBoxItem FindChildByCondition(Predicate<BasicComboBoxItem> condition)
        {
            Unsafe.Expand();

            var automationElementCondition = new Predicate<BasicElement>(element => condition.Invoke(new BasicComboBoxItem(element.AutomationElement)));
            var item = UI.GetChild<BasicComboBoxItem>(By.Condition(automationElementCondition), From.Element(this));
            if (item != null)
                return item;

            var scrollPattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
            if (scrollPattern.Current.VerticalScrollPercent == -1)
                return null;
            while (scrollPattern.Current.VerticalScrollPercent < 100)
            {
                scrollPattern.ScrollVertical(ScrollAmount.LargeIncrement);
                item = UI.GetChild<BasicComboBoxItem>(By.Condition(automationElementCondition), From.Element(this));
                if (item != null)
                    return item;
            }

            return null;
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
    }
}