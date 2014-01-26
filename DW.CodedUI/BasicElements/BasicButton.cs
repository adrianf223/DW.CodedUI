using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicButton : BasicElement
    {
        public BasicButton(AutomationElement automationElement)
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

            public void Click()
            {
                var invokePattern = (InvokePattern) _automationElement.GetCurrentPattern(InvokePattern.Pattern);
                invokePattern.Invoke();
            }
        }

        public UnsafeMethods Unsafe { get; private set; }

        public string Text
        {
            get { return Name; }
        }
    }
}