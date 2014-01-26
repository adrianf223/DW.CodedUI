using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicText : BasicElement
    {
        public BasicText(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public string Text
        {
            get { return Name; }
        }
    }
}