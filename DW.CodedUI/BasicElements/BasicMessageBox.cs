using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a MessageBox.
    /// </summary>
    public class BasicMessageBox : BasicWindowBase
    {
#if TRIAL
        static BasicMessageBox()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicMessageBox" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
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

        /// <summary>
        /// The icon shown in the MessageBox if any; otherwise an exception is thrown.
        /// </summary>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The MessageBox does not contain an icon.</exception>
        public BasicElement Icon
        {
            get { return UI.GetChild(By.AutomationId(IconId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text shown in the MessageBox if any; otherwise an empty string.
        /// </summary>
        public string Text
        {
            get
            {
                var textElement = UI.GetChild<BasicText>(By.AutomationId(TextId), From.Element(this), With.NoTimeout().NoAssert());
                if (textElement == null)
                    return string.Empty;
                return textElement.Text;
            }
        }

        /// <summary>
        /// Gets the OK Button.
        /// </summary>
        public BasicButton OKButton
        {
            get
            {
                var okButton = UI.GetChild<BasicButton>(By.AutomationId(OKButtonId), From.Element(this), With.NoAssert().NoTimeout());
                return okButton ?? CancelButton;
            }
        }

        /// <summary>
        /// Gets the Cancel Button.
        /// </summary>
        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(CancelButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Abort Button.
        /// </summary>
        public BasicButton AbortButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(AbortButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Retry Button.
        /// </summary>
        public BasicButton RetryButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(RetryButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Ignore Button.
        /// </summary>
        public BasicButton IgnoreButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(IgnoreButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Yes Button.
        /// </summary>
        public BasicButton YesButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(YesButtonId), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the No Button.
        /// </summary>
        public BasicButton NoButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId(NoButtonId), From.Element(this), With.NoTimeout()); }
        }
    }
}