using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a TextBlock or Label.
    /// </summary>
    public class BasicText : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicText" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicText(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the text written in the TextBlock/Label.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}