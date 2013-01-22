using System;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    // TODO: Obsolete
    [Obsolete("The BasicTabPage is nut supported anyore. Use the BasicTabItem instead")]
    public class BasicTabPage : BasicTabItem
    {
        public BasicTabPage(AutomationElement automationElement)
            : base(automationElement)
        {
        }
    }
}