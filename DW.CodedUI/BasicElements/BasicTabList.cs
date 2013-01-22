using System;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    // TODO: Obsolete
    [Obsolete("The BasicTabList is nut supported anyore. Use the BasicTabControl instead")]
    public class BasicTabList : BasicTabControl
    {
        public BasicTabList(AutomationElement automationElement)
            : base(automationElement)
        {
        }
    }
}