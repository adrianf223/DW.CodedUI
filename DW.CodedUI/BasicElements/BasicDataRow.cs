using System.Collections.Generic;
using System.Windows.Automation;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a row inside a DataGrid.
    /// </summary>
    public class BasicDataRow : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicDataRow" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicDataRow(AutomationElement automationElement)
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
            /// Adds the data row to the list of selected data rows.
            /// </summary>
            public void AddToSelection()
            {
                var pattern = Patterns.GetSelectionItemPattern(_automationElement);
                pattern.AddToSelection();
            }

            /// <summary>
            /// Removes the data row from the list of the selected data rows.
            /// </summary>
            public void RemoveFromSelection()
            {
                var pattern = Patterns.GetSelectionItemPattern(_automationElement);
                pattern.RemoveFromSelection();
            }
            
            /// <summary>
            /// Deselects all other data rows if any and selects the current data row.
            /// </summary>
            public void Select()
            {
                var pattern = Patterns.GetSelectionItemPattern(_automationElement);
                pattern.Select();
            }
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; }

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
        /// Gets a list of selected data cells.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BasicDataCell> GetSelection()
        {
            var selectionPattern = Patterns.GetSelectionPattern(AutomationElement);
            foreach (var selectedElement in selectionPattern.Current.GetSelection())
                yield return new BasicDataCell(selectedElement);
        }

        /// <summary>
        /// Gets a value that indicates if the DataRow is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                var selectionItemPattern = Patterns.GetSelectionItemPattern(AutomationElement);
                return selectionItemPattern.Current.IsSelected;
            }
        }

        /// <summary>
        /// Gets the header.
        /// </summary>
        public BasicDataRowHeader Header => UI.GetChild<BasicDataRowHeader>(By.ClassName("DataGridRowHeader"), From.Element(this));

        /// <summary>
        /// Gets the details presenter.
        /// </summary>
        public BasicElement DetailsPresenter => UI.GetChild(By.ClassName("DataGridDetailsPresenter"), From.Element(this));

        /// <summary>
        /// Gets the data cells.
        /// </summary>
        public IEnumerable<BasicDataCell> Cells => UI.GetChildren<BasicDataCell>(By.ClassName("DataGridCell"), From.Element(this));
    }
}
