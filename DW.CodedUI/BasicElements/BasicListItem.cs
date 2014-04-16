using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a ListBoxItem or ListViewItem.
    /// </summary>
    public class BasicListItem : BasicElement
    {
#if TRIAL
        static BasicListItem()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicListItem" /> class
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicListItem(AutomationElement automationElement)
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
            /// Adds the ListBoxItem/ListViewItem to the list of selected ListBoxItems/ListViewItems.
            /// </summary>
            public void AddToSelection()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.AddToSelection();
            }

            /// <summary>
            /// Removes the ListBoxItem/ListViewItem from the list of the selected ListBoxItems/ListViewItems.
            /// </summary>
            public void RemoveFromSelection()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.RemoveFromSelection();
            }

            /// <summary>
            /// Deselects all other ListBoxItems/ListViewItems if any and selects the current ListBoxItem/ListViewItem.
            /// </summary>
            public void Select()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.Select();
            }

            /// <summary>
            /// Scrolls to the ListBoxItem/ListViewItem.
            /// </summary>
            public void ScrollIntoView()
            {
                var pattern = (ScrollItemPattern)_automationElement.GetCurrentPattern(ScrollItemPattern.Pattern);
                pattern.ScrollIntoView();
            }
        }

        /// <summary>
        /// Gets a value that indicates if the ListBoxItem/ListViewItem is selected or not.
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
        /// Gets the written text in the ListBoxItem/ListViewItem.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}