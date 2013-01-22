using System;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    // TODO: Obsolete
    [Obsolete("The BasicTreeItem is nut supported anyore. Use the BasicTreeViewItem instead")]
    public class BasicTreeItem : BasicTreeViewItem
    {
        public BasicTreeItem(AutomationElement automationElement)
            : base(automationElement)
        {
        }
    }
}