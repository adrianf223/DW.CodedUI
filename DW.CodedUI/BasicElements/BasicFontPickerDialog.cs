using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicFontPickerDialog : BasicDialog
    {
        public BasicFontPickerDialog(AutomationElement element)
            : base(element)
        {
        }

        public BasicComboBox FontNameSection
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1136").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        public BasicEdit FontNameTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(FontNameSection)); }
        }

        public BasicList FontNameList
        {
            get { return UI.GetChild<BasicList>(By.AutomationId("1000").And.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(FontNameSection)); }
        }

        public BasicComboBox FontStyleSection
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1137").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        public BasicEdit FontStyleTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(FontStyleSection)); }
        }

        public BasicList FontStyleList
        {
            get { return UI.GetChild<BasicList>(By.AutomationId("1000").And.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(FontStyleSection)); }
        }

        public BasicComboBox FontSizeSection
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1138").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        public BasicEdit FontSizeTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(FontSizeSection)); }
        }

        public BasicList FontSizeList
        {
            get { return UI.GetChild<BasicList>(By.AutomationId("1000").And.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(FontSizeSection)); }
        }

        public BasicCheckBox LineThroughCheckBox
        {
            get { return UI.GetChild<BasicCheckBox>(By.AutomationId("1040").And.Condition(e => Equals(e.Properties.ControlType, ControlType.CheckBox)), From.Element(FontSizeSection)); }
        }

        public BasicCheckBox UnderlineCheckBox
        {
            get { return UI.GetChild<BasicCheckBox>(By.AutomationId("1041").And.Condition(e => Equals(e.Properties.ControlType, ControlType.CheckBox)), From.Element(FontSizeSection)); }
        }

        public BasicComboBox FontColorComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1139").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        public BasicComboBox ScriptComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1140").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this)); }
        }

        public BasicButton OKButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton ApplyButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1026").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton HelpButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1038").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }
    }
}
