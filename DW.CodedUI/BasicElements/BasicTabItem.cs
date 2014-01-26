using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicTabItem : BasicElement
    {
        public BasicTabItem(AutomationElement automationElement)
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

            public void Select()
            {
                var invokePattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                invokePattern.Select();
            }
        }

        public UnsafeMethods Unsafe { get; private set; }

        public bool IsSelected
        {
            get
            {
                var pattern = (SelectionItemPattern)AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                return pattern.Current.IsSelected;
            }
        }

        public string Text
        {
            get { return Name; }
        }
    }
}