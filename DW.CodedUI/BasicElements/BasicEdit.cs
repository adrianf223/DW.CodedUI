using System;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicEdit : BasicElement
    {
        public BasicEdit(AutomationElement automationElement)
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

            public void SetValue(string value)
            {
                object pattern;
                if (_automationElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
                    ((ValuePattern)pattern).SetValue(value);
                else
                    throw new NotSupportedException(string.Format("The '{0}' does not support to set the value with the unsafe method.", _automationElement.Current.ClassName));
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

        public string Text
        {
            get
            {
                var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
                return pattern.DocumentRange.GetText(-1);
            }
        }

        public bool IsReadOnly
        {
            get
            {
                object pattern;
                if (AutomationElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
                    return ((ValuePattern)pattern).Current.IsReadOnly;
                throw new NotSupportedException(string.Format("The '{0}' does not support to set the value with the unsafe method.", AutomationElement.Current.ClassName));
            }
        }

        // TODO: Put into BasicTextPatternRange
        //public TextPatternRange[] GetSelection
        //{
        //    get
        //    {
        //        var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
        //        return pattern.GetSelection();
        //    }
        //}

        // TODO: Put into BasicTextPatternRange
        //public TextPatternRange[] GetVisibleRanges
        //{
        //    get
        //    {
        //        var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
        //        return pattern.GetVisibleRanges();
        //    }
        //}

        // TODO: Put into BasicTextPatternRange and pass BasicElement
        //public TextPatternRange RangeFromChild(AutomationElement automationElemen)
        //{
        //    var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
        //    return pattern.RangeFromChild(automationElement);
        //}

        // TODO: Put into BasicTextPatternRange
        //public TextPatternRange RangeFromPoint(Point screenLocation)
        //{
        //    var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
        //    return pattern.RangeFromPoint(screenLocation);
        //}

        public SupportedTextSelection SupportedTextSelection
        {
            get
            {
                var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
                return pattern.SupportedTextSelection;
            }
        }

        // TODO: Put into BasicTextPatternRange
        //public TextPatternRange DocumentRange
        //{
        //    get
        //    {
        //        var pattern = (TextPattern)AutomationElement.GetCurrentPattern(TextPattern.Pattern);
        //        return pattern.DocumentRange;
        //    }
        //}

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
    }
}