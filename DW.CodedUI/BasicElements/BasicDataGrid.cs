using System;
using System.Collections.Generic;
using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a DataGrid.
    /// </summary>
    public class BasicDataGrid : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicDataGrid" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicDataGrid(AutomationElement automationElement)
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
            /// Scrolls inside the visible range; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="horizontalAmount">The amount of characters to scroll.</param>
            /// <param name="verticalAmount">The amount of lines to scroll.</param>
            public void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.Scroll(horizontalAmount, verticalAmount);
            }

            /// <summary>
            /// Scrolls inside the visible range horizontal; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="amount">The amount of characters to scroll.</param>
            public void ScrollHorizontal(ScrollAmount amount)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.ScrollHorizontal(amount);
            }

            /// <summary>
            /// Scrolls inside the visible range vertical; Small is just like arrow up/down; Large is like page up/down.
            /// </summary>
            /// <param name="amount">The amount of lines to scroll.</param>
            public void ScrollVertical(ScrollAmount amount)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.ScrollVertical(amount);
            }

            /// <summary>
            /// Sets the horizontal and vertical scroll position.
            /// </summary>
            /// <param name="horizontalPercent">The horizontal percentual value to set.</param>
            /// <param name="verticalPercent">The vertical percentual value to set.</param>
            public void SetScrollPercent(double horizontalPercent, double verticalPercent)
            {
                var pattern = Patterns.GetScrollPattern(_automationElement);
                pattern.SetScrollPercent(horizontalPercent, verticalPercent);
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; }

        /// <summary>
        /// Get the amount of columns (without the header row on the left).
        /// </summary>
        public int ColumnCount
        {
            get
            {
                var tablePattern = Patterns.GetTablePattern(AutomationElement);
                return tablePattern.Current.ColumnCount;
            }
        }

        /// <summary>
        /// Get the amount of rows (without the header row).
        /// </summary>
        public int RowCount
        {
            get
            {
                var tablePattern = Patterns.GetTablePattern(AutomationElement);
                return tablePattern.Current.RowCount;
            }
        }

        /// <summary>
        /// Gets a specific data cell from the DataGrid. (Without headers.)
        /// </summary>
        /// <param name="rowIndex">The row index the item belongs to. Starting at 0.</param>
        /// <param name="columnIndex">The column index the item belongs to. Starting at 0.</param>
        /// <returns>The specific data cell item.</returns>
        /// <exception cref="IndexOutOfRangeException">The row and header index needs to be inside the Range of BasicDataGrid.ColumnCount and BasicDataGrid.RowCount.</exception>
        public BasicDataCell GetItem(int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 || rowIndex > RowCount - 1)
                throw new IndexOutOfRangeException("The row index was outside the range of BasicDataGrid.RowCount");
            if (columnIndex < 0 || columnIndex > ColumnCount - 1)
                throw new IndexOutOfRangeException("The row index was outside the range of BasicDataGrid.ColumnCount");
            var gridPattern = Patterns.GetGridPattern(AutomationElement);
            return new BasicDataCell(gridPattern.GetItem((int)rowIndex, (int)columnIndex));
        }

        /// <summary>
        /// Gets all columns. (Without the column header.)
        /// </summary>
        public IEnumerable<BasicDataColumnHeader> ColumnHeaders
        {
            get
            {
                var tablePattern = Patterns.GetTablePattern(AutomationElement);
                foreach (var header in tablePattern.Current.GetColumnHeaders())
                    yield return new BasicDataColumnHeader(header);
            }
        }

        /// <summary>
        /// Gets all row headers. (Without the header of the column headers.)
        /// </summary>
        public IEnumerable<BasicDataRowHeader> RowHeaders
        {
            get
            {
                var tablePattern = Patterns.GetTablePattern(AutomationElement);
                foreach (var header in tablePattern.Current.GetRowHeaders())
                    yield return new BasicDataRowHeader(header);
            }
        }

        /// <summary>
        /// Gets all data rows. (Without header row.)
        /// </summary>
        public IEnumerable<BasicDataRow> Rows => UI.GetChildren<BasicDataRow>(By.ClassName("DataGridRow"), From.Element(this));

        /// <summary>
        /// Gets a value that indicates if the DataRow supports multiple selections or not.
        /// </summary>
        public bool CanSelectMultiple
        {
            get
            {
                var selectionPattern = Patterns.GetSelectionPattern(AutomationElement);
                return selectionPattern.Current.CanSelectMultiple;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the DataRow requires a selection.
        /// </summary>
        public bool IsSelectionRequired
        {
            get
            {
                var selectionPattern = Patterns.GetSelectionPattern(AutomationElement);
                return selectionPattern.Current.IsSelectionRequired;
            }
        }

        /// <summary>
        /// Gets a list of selected data rows.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BasicDataRow> GetSelection()
        {
            var selectionPattern = Patterns.GetSelectionPattern(AutomationElement);
            foreach (var selectedElement in selectionPattern.Current.GetSelection())
                yield return new BasicDataRow(selectedElement);
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll.
        /// </summary>
        public double HorizontalScrollPercent
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.HorizontalScrollPercent;
            }
        }

        /// <summary>
        /// Gets the current horizontal view size in percent.
        /// </summary>
        public double HorizontalViewSize
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.HorizontalViewSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the data grid can scroll horizontally.
        /// </summary>
        public bool HorizontallyScrollable
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.HorizontallyScrollable;
            }
        }

        /// <summary>
        /// Gets the current vertical scroll position; -1 if nothing has to scroll. 
        /// </summary>
        public double VerticalScrollPercent
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.VerticalScrollPercent;
            }
        }

        /// <summary>
        /// Gets the current vertical view size in percent.
        /// </summary>
        public double VerticalViewSize
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.VerticalViewSize;
            }
        }

        /// <summary>
        /// Gets a value that indicates if the data grid can scroll vertically.
        /// </summary>
        public bool VerticallyScrollable
        {
            get
            {
                var pattern = Patterns.GetScrollPattern(AutomationElement);
                return pattern.Current.VerticallyScrollable;
            }
        }
    }
}
