using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents an Expander.
    /// </summary>
    public class BasicExpander : BasicElement
    {
#if TRIAL
        static BasicExpander()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicExpander" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicExpander(AutomationElement automationElement)
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
            /// Expands the Expander.
            /// </summary>
            public void Expand()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Expand();
            }

            /// <summary>
            /// Collapses the Expander.
            /// </summary>
            public void Collapse()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Collapse();
            }
        }

        /// <summary>
        /// Gets a value that indicates if the Expander it is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                var pattern = (ExpandCollapsePattern)AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                return pattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded;
            }
        }
    }
}