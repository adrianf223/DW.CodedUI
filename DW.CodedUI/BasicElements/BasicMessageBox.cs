using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicMessageBox : BasicElement
    {
        public BasicMessageBox(AutomationElement automationElement)
            : base(automationElement)
        {
            Title = Name;
        }

        public string Title { get; private set; }
    }
}