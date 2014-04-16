using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents the OpenFileDialog.
    /// </summary>
    public class BasicOpenFileDialog : BasicDialog
    {
#if TRIAL
        static BasicOpenFileDialog()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicOpenFileDialog" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicOpenFileDialog(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the ComboBox to write the file name(s) in.
        /// </summary>
        public BasicComboBox InputComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1148").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Edit)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the upper BreadCrumbBar.
        /// </summary>
        public BasicElement BreadCrumbBar
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("41477").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Pane)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box in the upper BreadCrumbBar to write a location in.
        /// </summary>
        public BasicElement BreadCrumbTextBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1001").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ToolBar)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Filters ComboBox.
        /// </summary>
        public BasicComboBox FilterComboBox
        {
            get { return UI.GetChild<BasicComboBox>(By.AutomationId("1136").And.Condition(e => Equals(e.Properties.ControlType, ControlType.ComboBox)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public BasicButton CancelButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("2").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the Open button.
        /// </summary>
        public BasicButton OpenButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("1").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Button)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the list with the files in the current folder.
        /// </summary>
        public BasicList FilesList
        {
            get { return UI.GetChild<BasicList>(By.Condition(e => Equals(e.Properties.ControlType, ControlType.List)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the text box for searching.
        /// </summary>
        public BasicEdit SearchTextBox
        {
            get { return UI.GetChild<BasicEdit>(By.AutomationId("SearchEditBox"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to start or cancel search.
        /// </summary>
        public BasicButton SearchButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("SearchBoxSearchButton"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the tree with the available folders.
        /// </summary>
        public BasicTreeView FolderTree
        {
            get { return UI.GetChild<BasicTreeView>(By.AutomationId("100").And.Condition(e => Equals(e.Properties.ControlType, ControlType.Tree)), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the ToolBar.
        /// </summary>
        public BasicElement ToolBar
        {
            get { return UI.GetChild<BasicElement>(By.AutomationId("FolderBandModuleInner"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to change the current view style.
        /// </summary>
        public BasicButton ChangeViewButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("ViewControl"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button to show or hide the current preview pane.
        /// </summary>
        public BasicButton ShowPreviewButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("PreviewButton"), From.Element(this), With.NoTimeout()); }
        }

        /// <summary>
        /// Gets the button for show the help.
        /// </summary>
        public BasicButton HelpButton
        {
            get { return UI.GetChild<BasicButton>(By.AutomationId("HelpButton"), From.Element(this), With.NoTimeout()); }
        }
    }
}
