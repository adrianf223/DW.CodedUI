using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a column header inside a <see cref="DW.CodedUI.BasicElements.BasicDataGrid" />.
    /// </summary>
    public class BasicDataColumnHeader : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicDataColumnHeader" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicDataColumnHeader(AutomationElement automationElement)
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
            /// Invokes a click on the header.
            /// </summary>
            public void Click()
            {
                var invokePattern = Patterns.GetInvokePattern(_automationElement);
                invokePattern.Invoke();
            }

            /// <summary>
            /// Scrolls the parent DataGrid to the current item.
            /// </summary>
            public void ScrollIntoView()
            {
                var scrollItemPattern = Patterns.GetScrollItemPattern(_automationElement);
                scrollItemPattern.ScrollIntoView();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; }

        /// <summary>
        /// Gets the left Thumb inside the header for resizing.
        /// </summary>
        public BasicElement LeftGripper => UI.GetChild(By.AutomationId("PART_LeftHeaderGripper"), From.Element(this));

        /// <summary>
        /// Gets the right Thumb inside the header for resizing.
        /// </summary>
        public BasicElement RightGripper => UI.GetChild(By.AutomationId("PART_RightHeaderGripper"), From.Element(this));
    }
}
