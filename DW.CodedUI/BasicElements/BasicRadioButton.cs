using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a RadioButton.
    /// </summary>
    public class BasicRadioButton : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicRadioButton" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicRadioButton(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly.
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Checks the RadioButton. All other items in the group became unchecked automatically.
            /// </summary>
            public void Check()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.Select();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets a value that indicates if the RadioButton is checked or not.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                var pattern = (SelectionItemPattern)AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                return pattern.Current.IsSelected;
            }
        }

        /// <summary>
        /// Gets the text written in the RadioButton.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}