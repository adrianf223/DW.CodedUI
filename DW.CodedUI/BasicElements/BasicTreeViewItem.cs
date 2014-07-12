using System.Collections.Generic;
using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a TreeViewItem.
    /// </summary>
    public class BasicTreeViewItem : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicTreeViewItem" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicTreeViewItem(AutomationElement automationElement)
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
            /// Expands the item.
            /// </summary>
            public void Expand()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Expand();
            }

            /// <summary>
            /// Collapses the item.
            /// </summary>
            public void Collapse()
            {
                var pattern = (ExpandCollapsePattern)_automationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                pattern.Collapse();
            }

            /// <summary>
            /// Selects the item.
            /// </summary>
            public void Select()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.Select();
            }

            /// <summary>
            /// Deselects the item.
            /// </summary>
            public void Deselect()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.RemoveFromSelection();
            }

            /// <summary>
            /// Scrolls the parent TreeView to the item.
            /// </summary>
            public void ScrollIntoView()
            {
                var pattern = (ScrollItemPattern)_automationElement.GetCurrentPattern(ScrollItemPattern.Pattern);
                pattern.ScrollIntoView();   
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Gets a value that indicates if it is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                var pattern = (SelectionItemPattern)AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                return pattern.Current.IsSelected;
            }
        }

        /// <summary>
        /// Gets a value that indicates if it is expanded or not.
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
        /// Gets all available child tree items. In WPF normally all child items get created first as soon they became visible.
        /// </summary>
        public IEnumerable<BasicTreeViewItem> Items
        {
            get
            {
                Unsafe.Expand();
                Unsafe.Collapse();
                return UI.GetChildren<BasicTreeViewItem>(By.ClassName("TreeViewItem"), From.Element(this));
            }
        }

        /// <summary>
        /// Gets the text written in the TreeViewItem.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}