using System.Windows.Automation;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a ComboBoxItem.
    /// </summary>
    public class BasicComboBoxItem : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicComboBoxItem" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicComboBoxItem(AutomationElement automationElement)
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
            /// Selects the ComboBoxItem.
            /// </summary>
            public void Select()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.Select();
            }

            /// <summary>
            /// Deselect the ComboBoxItem.
            /// </summary>
            public void Deselect()
            {
                var pattern = (SelectionItemPattern)_automationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                pattern.RemoveFromSelection();
            }

            /// <summary>
            /// Scrolls to the ComboBoxItem.
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
        /// Gets a value that indicates if the ComboBoxItem is selected or not.
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
        /// Gets the text written in the ComboBoxItem.
        /// </summary>
        public string Text
        {
            get { return Name; }
        }
    }
}