using System.Collections.Generic;
using System.Windows.Automation;

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
                return UI.GetChildren<BasicMenuItem>(By.ClassName("MenuItem"), From.Element(this));
            }
        }
    }
}