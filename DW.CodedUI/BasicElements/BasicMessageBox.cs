using System.Windows.Automation;
using DW.CodedUI.UITree;

namespace DW.CodedUI.BasicElements
{
    public class BasicMessageBox : BasicElement
    {
        public BasicMessageBox(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public string Title
        {
            get { return Name; }
        }

        public BasicElement Icon
        {
            get { return BasicElementFinder.FindChildByAutomationId(this, "20"); }
        }

        public string Text
        {
            get
            {
                var textElement = BasicElementFinder.FindChildByAutomationId<BasicText>(this, "65535");
                if (textElement == null)
                    return string.Empty;
                return textElement.Text;
            }
        }

        public BasicButton OKButton
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "1"); }
        }

        public BasicButton CancelButton
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "2"); }
        }

        public BasicButton YesButton
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "6"); }
        }

        public BasicButton NoButton
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "7"); }
        }
    }
}