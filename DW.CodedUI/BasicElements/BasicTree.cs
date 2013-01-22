using System;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    // TODO: Obsolete
    [Obsolete("The BasicTree is nut supported anyore. Use the BasicTreeView instead")]
    public class BasicTree : BasicTreeView
    {
        public BasicTree(AutomationElement automationElement)
            : base(automationElement)
        {
        }
    }
}