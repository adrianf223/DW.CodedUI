using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents the BrowseFolderDialog.
    /// </summary>
    public class BasicBrowseFolderDialog : BasicDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicBrowseFolderDialog" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicBrowseFolderDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the descripton text.
        /// </summary>
        public BasicText DescriptionText
        {
            get { return UI.GetChild<BasicText>(By.AutomationId("14146").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Text)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the new folder button.
        /// </summary>
        public BasicButton NewFolderButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("14150").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the OK button.
        /// </summary>
        public BasicButton OKButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the tree for selecting a folder.
        /// </summary>
        public BasicTreeView FolderTree
        {
            get { return UI.GetChild<BasicTreeView>(By.AutomationId("100").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Tree)), From.Element(this), With.NoTimeout()); }
        }
    }
}