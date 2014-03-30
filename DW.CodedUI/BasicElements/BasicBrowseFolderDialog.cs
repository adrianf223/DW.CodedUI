using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicBrowseFolderDialog : BasicDialog
    {
        public BasicBrowseFolderDialog(AutomationElement element)
            : base(element)
        {
        }

        public BasicText DescriptionText
        {
            get { return UI.GetChild<BasicText>(By.AutomationId("14146").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this)); }
        }

        public BasicButton NewFolderButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("14150").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton OKButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this)); }
        }

        public BasicTreeView FolderTree
        {
            get { return UI.GetChild<BasicTreeView>(By.AutomationId("100").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Tree)), From.Element(this)); }
        }
    }
}