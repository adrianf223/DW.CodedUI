using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicMessageBox : BasicWindowBase
    {
        public BasicMessageBox(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        private const string OKButtonId = "1"; // If its the only button it got the automation ID 2
        private const string CancelButtonId = "2";
        private const string AbortButtonId = "3";
        private const string RetryButtonId = "4";
        private const string IgnoreButtonId = "5";
        private const string YesButtonId = "6";
        private const string NoButtonId = "7";
        private const string IconId = "20";
        private const string TextId = "65535";

        public BasicElement Icon
        {
            get { return UI.GetChild(By.AutomationId(IconId), From.Element(this)); }
        }

        public string Text
        {
            get
            {
                var textElement = UI.GetChild<BasicText>(By.AutomationId(TextId), From.Element(this));
                if (textElement == null)
                    return string.Empty;
                return textElement.Text;
            }
        }

        public BasicButton OKButton
        {
            get
            {
                var okButton = UI.GetChild<BasicButton>(By.AutomationId(OKButtonId), From.Element(this), With.NoAssert().NoTimeout());
                return okButton ?? CancelButton;
            }
        }

        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(CancelButtonId), From.Element(this)); }
        }

        public BasicButton AbortButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(AbortButtonId), From.Element(this)); }
        }

        public BasicButton RetryButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(RetryButtonId), From.Element(this)); }
        }

        public BasicButton IgnoreButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(IgnoreButtonId), From.Element(this)); }
        }

        public BasicButton YesButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(YesButtonId), From.Element(this)); }
        }

        public BasicButton NoButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(NoButtonId), From.Element(this)); }
        }
    }
}