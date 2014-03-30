using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicColorPickerDialog : BasicWindow
    {
        public BasicColorPickerDialog(AutomationElement element)
            : base(element)
        {
        }

        public BasicElement ColorsSection
        {
            get { return UI.GetChild(By.AutomationId("720").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this)); }
        }

        public BasicButton DefineColorsButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("719").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicElement ColorPickSection
        {
            get { return UI.GetChild(By.AutomationId("710").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this)); }
        }

        public BasicElement ColorGradientSection
        {
            get { return UI.GetChild(By.AutomationId("702").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this)); }
        }

        public BasicElement ColorDisplaySection
        {
            get { return UI.GetChild(By.AutomationId("709").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this)); }
        }

        public BasicEdit ColorShadeTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("703").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this)); }
        }

        public BasicEdit ColorChromaTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("704").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this)); }
        }

        public BasicEdit ColorBrightnessTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("705").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this)); }
        }

        public BasicEdit RedTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("706").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this)); }
        }

        public BasicEdit GreenTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("707").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this)); }
        }

        public BasicEdit BlueTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("708").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this)); }
        }

        public BasicButton ApplyColorButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("712").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton OKButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton HelpButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1038").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }
    }
}