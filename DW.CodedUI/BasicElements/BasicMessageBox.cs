using System.Windows.Automation;

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
            get { return UI.GetChild(By.AutomationId("20"), From.Element(this)); }
        }

        public string Text
        {
            get
            {
                var textElement = UI.GetChild<BasicText>(By.AutomationId("65535"), From.Element(this));
                if (textElement == null)
                    return string.Empty;
                return textElement.Text;
            }
        }

        public BasicButton OKButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1"), From.Element(this)); }
        }

        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2"), From.Element(this)); }
        }

        public BasicButton YesButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("6"), From.Element(this)); }
        }

        public BasicButton NoButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("7"), From.Element(this)); }
        }
    }
}