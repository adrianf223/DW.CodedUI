using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using DW.CodedUI.UITree;

namespace DW.CodedUI.BasicElements
{
    public class BasicTabControl : BasicElement
    {
        public BasicTabControl(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public BasicTabItem SelectedItem
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                var selectedItem = pattern.Current.GetSelection().FirstOrDefault();
                return selectedItem != null ? new BasicTabItem(selectedItem) : null;
            }
        }

        public IEnumerable<BasicTabItem> Items
        {
            get
            {
                
                return BasicElementFinder.FindChildrenByClassName<BasicTabItem>(AutomationElement, "TabItem");
            }
        }
    }
}