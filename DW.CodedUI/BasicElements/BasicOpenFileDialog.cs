using System.Windows.Automation;
using DW.CodedUI.UITree;

namespace DW.CodedUI.BasicElements
{
    public class BasicOpenFileDialog : BasicWindow
    {
        public BasicOpenFileDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public BasicComboBox InputComboBox
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicComboBox>(this, "1148"); }
        }

        public BasicElement BreadCrumbBar
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicComboBox>(this, "41477"); }
        }

        public BasicElement BreadCrumbTextBox
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicComboBox>(this, "1001"); }
        }

        public BasicComboBox FilterComboBox
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicComboBox>(this, "1136"); }
        }

        public BasicButton CancelButton
        {
            get { return BasicElementFinder.FindChildByCondition<BasicButton>(this, element => element.Current.AutomationId == "2" && Equals(element.Current.ControlType, ControlType.Button)); }
        }

        public BasicButton OpenButton
        {
            get { return BasicElementFinder.FindChildByCondition<BasicButton>(this, element => element.Current.AutomationId == "1" && Equals(element.Current.ControlType, ControlType.Button)); }
        }

        public BasicList FilesList
        {
            get { return BasicElementFinder.FindChildByCondition<BasicList>(this, element => Equals(element.Current.ControlType, ControlType.List)); }
        }

        public BasicEdit SearchTextBox
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicEdit>(this, "SearchEditBox"); }
        }

        public BasicButton SearchButton
        {
            get { return BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "SearchBoxSearchButton"); }
        }

        public BasicTreeView FolderTree
        {
            get { return BasicElementFinder.FindChildByCondition<BasicTreeView>(this, element => element.Current.AutomationId == "100" && Equals(element.Current.ControlType, ControlType.Tree)); }
        }
    }
}