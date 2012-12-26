using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    public class BasicComboBoxItem : BasicElement
    {
        public BasicComboBoxItem(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public bool IsSelected // TODO: Test
        {
            get
            {
                var pattern = (SelectionItemPattern)AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                return pattern.Current.IsSelected;
            }
        }
    }
}