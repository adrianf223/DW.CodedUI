using System.Collections.Generic;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a Menu or ContextMenu
    /// </summary>
    public class BasicMenu : BasicElement
    {
#if TRIAL
        static BasicMenu()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicMenu" /> class
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicMenu(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets all available MenuItems.
        /// </summary>
        public IEnumerable<BasicMenuItem> Items
        {
            get
            {
                return UI.GetChildren<BasicMenuItem>(By.ClassName("MenuItem"), From.Element(this));
            }
        }
    }
}