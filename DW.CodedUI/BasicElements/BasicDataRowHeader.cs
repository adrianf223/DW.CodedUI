using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents the header in a DataGrid row.
    /// </summary>
    public class BasicDataRowHeader : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicDataRowHeader" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicDataRowHeader(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the top Thumb for resizing.
        /// </summary>
        public BasicElement TopGripper => UI.GetChild(By.AutomationId("PART_TopHeaderGripper"), From.Element(this));

        /// <summary>
        /// Gets the bottom Thumb for resizing.
        /// </summary>
        public BasicElement BottomGripper => UI.GetChild(By.AutomationId("PART_BottomHeaderGripper"), From.Element(this));
    }
}
