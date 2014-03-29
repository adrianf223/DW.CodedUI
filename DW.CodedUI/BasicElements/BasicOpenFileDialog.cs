using System.Windows.Automation;
using DW.CodedUI.UITree;

namespace DW.CodedUI.BasicElements
{
    // TODO: Check that no automation gets duplicated (BasicComboBox)
    public class BasicOpenFileDialog : BasicWindow
    {
        public BasicOpenFileDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public BasicComboBox InputComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1148"), From.Element(this)); }
        }

        public BasicElement BreadCrumbBar
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("41477"), From.Element(this)); }
        }

        public BasicElement BreadCrumbTextBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1001"), From.Element(this)); }
        }

        public BasicComboBox FilterComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1136"), From.Element(this)); }
        }

        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton OpenButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicList FilesList
        {
            get { return UI.GetChild<BasicList>(By.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(this)); }
        }

        public BasicEdit SearchTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("SearchEditBox"), From.Element(this)); }
        }

        public BasicButton SearchButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("SearchBoxSearchButton"), From.Element(this)); }
        }

        public BasicTreeView FolderTree
        {
            get { return UI.GetChild<BasicTreeView>(By.AutomationId("100").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Tree)), From.Element(this)); }
        }
    }
}
