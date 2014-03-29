using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicList : BasicElement
    {
        public BasicList(AutomationElement automationElement)
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

            public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.Scroll(horizontalAmount, verticalAmount);
            }

            public void ScrollHorizontal(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollHorizontal(amount);
            }

            public void ScrollVertical(ScrollAmount amount)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.ScrollVertical(amount);
            }

            public void SetScrollPercent(double horizontalPercent, double verticalPercent)
            {
                var pattern = (ScrollPattern)_automationElement.GetCurrentPattern(ScrollPattern.Pattern);
                pattern.SetScrollPercent(horizontalPercent, verticalPercent);
            }
        }

        public UnsafeMethods Unsafe { get; private set; }

        public bool CanMultiSelect
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                return pattern.Current.CanSelectMultiple;
            }
        }

        public IEnumerable<BasicListItem> SelectedItems
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                return pattern.Current.GetSelection().Select(element => new BasicListItem(element));
            }
        }

        public IEnumerable<BasicListItem> Items
        {
            get
            {
                return UI.GetChildren<BasicListItem>(By.ClassName("ListBoxItem").Or.ClassName("ListViewItem"), From.Element(this));
            }
        }

        public BasicListItem FindChildByCondition(Predicate<BasicListItem> condition)
        {
            var automationElementCondition = new Predicate<BasicElement>(element => condition.Invoke(new BasicListItem(element.AutomationElement)));
            var item = UI.GetChild<BasicListItem>(By.Condition(automationElementCondition), From.Element(this));
            if (item != null)
                return item;
            if (VerticalScrollPercent == -1)
                return null;
            while (VerticalScrollPercent < 100)
            {
                Unsafe.ScrollVertical(ScrollAmount.LargeIncrement);
                item = UI.GetChild<BasicListItem>(By.Condition(automationElementCondition), From.Element(this));
                if (item != null)
                    return item;
            }

            return null;
        }

        public double HorizontalScrollPercent
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.HorizontalScrollPercent;
            }
        }

        public double HorizontalViewSize
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.HorizontalViewSize;
            }
        }

        public bool HorizontallyScrollable
        {
            get
            {
                var pattern = (ScrollPattern)AutomationElement.GetCurrentPattern(ScrollPattern.Pattern);
                return pattern.Current.HorizontallyScrollable;
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

        public int ColumnCount
        {
            get
            {
                object pattern;
                if (AutomationElement.TryGetCurrentPattern(GridPattern.Pattern, out pattern))
                    return ((GridPattern)pattern).Current.ColumnCount;
                throw new NotSupportedException(string.Format("The '{0}' does not support ColumnCount.", AutomationElement.Current.ClassName));
            }
        }

        public int RowCount
        {
            get
            {
                object pattern;
                if (AutomationElement.TryGetCurrentPattern(GridPattern.Pattern, out pattern))
                    return ((GridPattern)pattern).Current.RowCount;
                throw new NotSupportedException(string.Format("The '{0}' does not support RowCount.", AutomationElement.Current.ClassName));
            }
        }

        public BasicElement GetItem(int row, int column)
        {
            object pattern;
            if (AutomationElement.TryGetCurrentPattern(GridPattern.Pattern, out pattern))
                return new BasicElement(((GridPattern)pattern).GetItem(row, column));
            throw new NotSupportedException(string.Format("The '{0}' does not support GetItem.", AutomationElement.Current.ClassName));
        }

        public IEnumerable<BasicElement> GetColumnHeaders()
        {
            object pattern;
            if (AutomationElement.TryGetCurrentPattern(TablePattern.Pattern, out pattern))
                return ((TablePattern) pattern).Current.GetColumnHeaders().Select(i => new BasicElement(i));
            throw new NotSupportedException(string.Format("The '{0}' does not support GetColumnHeaders.", AutomationElement.Current.ClassName));
        }
    }
}