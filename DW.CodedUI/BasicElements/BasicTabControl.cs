using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a TabControl.
    /// </summary>
    public class BasicTabControl : BasicElement
    {
#if TRIAL
        static BasicTabControl()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicTabControl" /> class
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicTabControl(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the selected tab item if any; otherwise null.
        /// </summary>
        public BasicTabItem SelectedItem
        {
            get
            {
                var pattern = (SelectionPattern)AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                var selectedItem = pattern.Current.GetSelection().FirstOrDefault();
                return selectedItem != null ? new BasicTabItem(selectedItem) : null;
            }
        }

        /// <summary>
        /// Gets all available tab items.
        /// </summary>
        public IEnumerable<BasicTabItem> Items
        {
            get
            {
                return UI.GetChildren<BasicTabItem>(By.ClassName("TabItem"), From.Element(this));
            }
        }
    }
}