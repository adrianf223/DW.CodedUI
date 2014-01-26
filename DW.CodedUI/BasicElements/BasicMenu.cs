using System.Collections.Generic;
using System.Windows.Automation;
using DW.CodedUI.UITree;

namespace DW.CodedUI.BasicElements
{
    public class BasicMenu : BasicElement
    {
        public BasicMenu(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public IEnumerable<BasicMenuItem> Items
        {
            get
            {
                return BasicElementFinder.FindChildrenByClassName<BasicMenuItem>(AutomationElement, "MenuItem");
            }
        }
    }
}