using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a button.
    /// </summary>
    public class BasicButton : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicButton" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicButton(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

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
            /// Invokes a click on the Button.
            /// </summary>
            public void Click()
            {
                var invokePattern = (InvokePattern) _automationElement.GetCurrentPattern(InvokePattern.Pattern);
                invokePattern.Invoke();
            }
        }

        /// <summary>
        /// Gets the text written in the Button.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}