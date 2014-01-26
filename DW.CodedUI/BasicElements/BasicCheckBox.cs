using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicCheckBox : BasicElement
    {
        public BasicCheckBox(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        public UnsafeMethods Unsafe { get; private set; }

        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            public void Toggle()
            {
                var pattern = (TogglePattern)_automationElement.GetCurrentPattern(TogglePattern.Pattern);
                pattern.Toggle();
            }
        }

        public bool IsChecked
        {
            get
            {
                var pattern = (TogglePattern)AutomationElement.GetCurrentPattern(TogglePattern.Pattern);
                return pattern.Current.ToggleState == ToggleState.On;
            }
        }

        public string Text
        {
            get { return Name; }
        }
    }
}