using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicComboBox : BasicElement
    {
        public BasicComboBox(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            public void Expand()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Expand();
            }

            public void Collapse()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Collapse();
            }

            public void SetValue(string value)
            {
                object valuePattern;
                if (_automationElement.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern))
                    ((ValuePattern)valuePattern).SetValue(value);
            }

            public void SetScrollPercent(double verticalPercent)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.SetScrollPercent(ScrollPattern.NoScroll, verticalPercent);
            }

            public void ScrollVertical(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollVertical(amount);
            }
        }

        public UnsafeMethods Unsafe { get; private set; }

        public BasicComboBoxItem SelectedItem
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                var selectedItem = pattern.Current.GetSelection().FirstOrDefault();
                return selectedItem != null ? new BasicComboBoxItem(selectedItem) : null;
            }
        }

        public IEnumerable<BasicComboBoxItem> Items
        {
            get
            {
                Unsafe.Expand();
                Unsafe.Collapse();
                return UI.GetChildren<BasicComboBoxItem>(By.ClassName("ListBoxItem"), From.Element(this));
            }
        }

        // TODO: Renew?
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

        public bool IsExpanded
        {
            get
            {
                var expandCollapsePattern = (ExpandCollapsePattern)AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                return expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded;
            }
        }

        public double VerticalScrollPercent
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.VerticalScrollPercent;
            }
        }

        public double VerticalViewSize
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.VerticalViewSize;
            }
        }

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