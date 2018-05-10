using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a cell inside a DataGrid.
    /// </summary>
    public class BasicDataCell : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicDataCell" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicDataCell(AutomationElement automationElement)
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
            /// Sets the new value of the data cell.
            /// </summary>
            /// <param name="newValue">The new value to set.</param>
            public void SetValue(string newValue)
            {
                var pattern = Patterns.GetValuePattern(_automationElement);
                pattern.SetValue(newValue);
            }

            /// <summary>
            /// Scrolls the parent DataGrid to the current item.
            /// </summary>
            public void ScrollIntoView()
            {
                var pattern = Patterns.GetScrollItemPattern(_automationElement);
                pattern.ScrollIntoView();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; }

        /// <summary>
        /// Gets a value that indicates if the data cell is read only or not.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                var pattern = Patterns.GetValuePattern(AutomationElement);
                return pattern.Current.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets the value of the data cell.
        /// </summary>
        public string Value
        {
            get
            {
                var pattern = Patterns.GetValuePattern(AutomationElement);
                return pattern.Current.Value;
            }
        }

        /// <summary>
        /// Gets the column index.
        /// </summary>
        public int Column
        {
            get
            {
                var pattern = Patterns.GetTableItemPattern(AutomationElement);
                return pattern.Current.Column;
            }
        }

        /// <summary>
        /// Gets the span of used columns.
        /// </summary>
        public int ColumnSpan
        {
            get
            {
                var pattern = Patterns.GetTableItemPattern(AutomationElement);
                return pattern.Current.ColumnSpan;
            }
        }

        /// <summary>
        /// Gets the row index.
        /// </summary>
        public int Row
        {
            get
            {
                var pattern = Patterns.GetTableItemPattern(AutomationElement);
                return pattern.Current.Row;
            }
        }

        /// <summary>
        /// Gets the span of used rows.
        /// </summary>
        public int RowSpan
        {
            get
            {
                var pattern = Patterns.GetTableItemPattern(AutomationElement);
                return pattern.Current.RowSpan;
            }
        }

        /// <summary>
        /// Gets the DataGrid the item belongs to.
        /// </summary>
        public BasicDataGrid ContainingGrid
        {
            get
            {
                var pattern = Patterns.GetTableItemPattern(AutomationElement);
                return new BasicDataGrid(pattern.Current.ContainingGrid);
            }
        }
    }
}
