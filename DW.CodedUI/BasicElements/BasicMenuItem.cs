using System.Collections.Generic;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a MenuItem.
    /// </summary>
    public class BasicMenuItem : BasicElement
    {
#if TRIAL
        static BasicMenuItem()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicMenuItem" /> class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicMenuItem(AutomationElement automationElement)
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
            /// Expands the MenuItem.
            /// </summary>
            public void Expand()
            {
                var expandCollapsePattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                expandCollapsePattern.Expand();
            }

            /// <summary>
            /// Collapses the MenuItem.
            /// </summary>
            public void Collapse()
            {
                var expandCollapsePattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                expandCollapsePattern.Collapse();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets a value that indicates if the MenuItem is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                var pattern = (ExpandCollapsePattern)AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                return pattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded;
            }
        }

        /// <summary>
        /// Gets all available MenuItems. In WPF normally the child items gets created first when they became visible.
        /// </summary>
        public IEnumerable<BasicMenuItem> Items
        {
            get
            {
                Unsafe.Expand();
                return UI.GetChildren<BasicMenuItem>(By.ClassName("MenuItem"), From.Element(this));
            }
        }

        /// <summary>
        /// Gets the text written in the MenuItem.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}