using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a ToggleButton.
    /// </summary>
    public class BasicToggleButton : BasicElement
    {
#if TRIAL
        static BasicToggleButton()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicToggleButton" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicToggleButton(AutomationElement automationElement)
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
            /// Changes the IsChecked state.
            /// </summary>
            public void Toggle()
            {
                var pattern = (TogglePattern)_automationElement.GetCurrentPattern(TogglePattern.Pattern);
                pattern.Toggle();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets a value that indicates if the ToggleButton is checked or not.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                var pattern = (TogglePattern)AutomationElement.GetCurrentPattern(TogglePattern.Pattern);
                return pattern.Current.ToggleState == ToggleState.On;
            }
        }

        /// <summary>
        /// Gets the text written in the ToggleButton.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}