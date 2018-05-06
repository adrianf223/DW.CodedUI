using System;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Adds easy access to the automation patterns provided by the Microsoft AutomationElements.
    /// </summary>
    /// <exception cref="NotSupportedException">When a pattern is ask for a control who does not support it. The NotSupportedException will be thrown.<br />
    /// Consder checking <see cref="BasicElement.SupportedPatterns" /> at runtime if the corresponding pattern is available.</exception>
    /// <code lang="csharp">
    /// <![CDATA[
    /// [TestMethod]
    /// public void MyButton_IsDisabled_GetInvokedAnyway()
    /// {
    ///     var myButton = UI.GetChild<BasicButton>(By.AutomationId("MyButton"), From.LastWindow);
    ///     
    ///     // When properties and methods of the BasicElements are not enough; use the MS AutomationPattern.
    ///     var invokePattern = Patterns.GetInvokePattern(myElement.AutomationElement);
    ///     invokePattern.Invoke();
    /// }]]>
    /// </code>
    public static class Patterns
    {
        /// <summary>
        /// Reads the AnnotationPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the AnnotationPattern.</param>
        /// <returns>The AnnotationPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static AnnotationPattern GetAnnotationPattern(AutomationElement element) => Get<AnnotationPattern>(element, AnnotationPattern.Pattern);

        /// <summary>
        /// Reads the DockPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the DockPattern.</param>
        /// <returns>The DockPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static DockPattern GetDockPattern(AutomationElement element) => Get<DockPattern>(element, DockPattern.Pattern);

        /// <summary>
        /// Reads the DragPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the DragPattern.</param>
        /// <returns>The DragPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static DragPattern GetDragPattern(AutomationElement element) => Get<DragPattern>(element, DragPattern.Pattern);

        /// <summary>
        /// Reads the DropTargetPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the DropTargetPattern.</param>
        /// <returns>The DropTargetPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static DropTargetPattern GetDropTargetPattern(AutomationElement element) => Get<DropTargetPattern>(element, DropTargetPattern.Pattern);

        /// <summary>
        /// Reads the ExpandCollapsePattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the ExpandCollapsePattern.</param>
        /// <returns>The ExpandCollapsePattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static ExpandCollapsePattern GetExpandCollapsePattern(AutomationElement element) => Get<ExpandCollapsePattern>(element, ExpandCollapsePattern.Pattern);

        /// <summary>
        /// Reads the GridItemPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the GridItemPattern.</param>
        /// <returns>The GridItemPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static GridItemPattern GetGridItemPattern(AutomationElement element) => Get<GridItemPattern>(element, GridItemPattern.Pattern);

        /// <summary>
        /// Reads the GridPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the GridPattern.</param>
        /// <returns>The GridPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static GridPattern GetGridPattern(AutomationElement element) => Get<GridPattern>(element, GridPattern.Pattern);

        /// <summary>
        /// Reads the InvokePattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the InvokePattern.</param>
        /// <returns>The InvokePattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static InvokePattern GetInvokePattern(AutomationElement element) => Get<InvokePattern>(element, InvokePattern.Pattern);

        /// <summary>
        /// Reads the ItemContainerPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the ItemContainerPattern.</param>
        /// <returns>The ItemContainerPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static ItemContainerPattern GetItemContainerPattern(AutomationElement element) => Get<ItemContainerPattern>(element, ItemContainerPattern.Pattern);

        /// <summary>
        /// Reads the LegacyIAccessiblePattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the LegacyIAccessiblePattern.</param>
        /// <returns>The LegacyIAccessiblePattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static LegacyIAccessiblePattern GetLegacyIAccessiblePattern(AutomationElement element) => Get<LegacyIAccessiblePattern>(element, LegacyIAccessiblePattern.Pattern);

        /// <summary>
        /// Reads the MultipleViewPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the MultipleViewPattern.</param>
        /// <returns>The MultipleViewPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static MultipleViewPattern GetMultipleViewPattern(AutomationElement element) => Get<MultipleViewPattern>(element, MultipleViewPattern.Pattern);

        /// <summary>
        /// Reads the ObjectModelPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the ObjectModelPattern.</param>
        /// <returns>The ObjectModelPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static ObjectModelPattern GetObjectModelPattern(AutomationElement element) => Get<ObjectModelPattern>(element, ObjectModelPattern.Pattern);

        /// <summary>
        /// Reads the RangeValuePattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the RangeValuePattern.</param>
        /// <returns>The RangeValuePattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static RangeValuePattern GetRangeValuePattern(AutomationElement element) => Get<RangeValuePattern>(element, RangeValuePattern.Pattern);

        /// <summary>
        /// Reads the ScrollItemPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the ScrollItemPattern.</param>
        /// <returns>The ScrollItemPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static ScrollItemPattern GetScrollItemPattern(AutomationElement element) => Get<ScrollItemPattern>(element, ScrollItemPattern.Pattern);

        /// <summary>
        /// Reads the ScrollPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the ScrollPattern.</param>
        /// <returns>The ScrollPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static ScrollPattern GetScrollPattern(AutomationElement element) => Get<ScrollPattern>(element, ScrollPattern.Pattern);

        /// <summary>
        /// Reads the SelectionItemPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the SelectionItemPattern.</param>
        /// <returns>The SelectionItemPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static SelectionItemPattern GetSelectionItemPattern(AutomationElement element) => Get<SelectionItemPattern>(element, SelectionItemPattern.Pattern);

        /// <summary>
        /// Reads the SelectionPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the SelectionPattern.</param>
        /// <returns>The SelectionPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static SelectionPattern GetSelectionPattern(AutomationElement element) => Get<SelectionPattern>(element, SelectionPattern.Pattern);

        /// <summary>
        /// Reads the SpreadsheetItemPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the SpreadsheetItemPattern.</param>
        /// <returns>The SpreadsheetItemPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static SpreadsheetItemPattern GetSpreadsheetItemPattern(AutomationElement element) => Get<SpreadsheetItemPattern>(element, SpreadsheetItemPattern.Pattern);

        /// <summary>
        /// Reads the SpreadsheetPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the SpreadsheetPattern.</param>
        /// <returns>The SpreadsheetPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static SpreadsheetPattern GetSpreadsheetPattern(AutomationElement element) => Get<SpreadsheetPattern>(element, SpreadsheetPattern.Pattern);

        /// <summary>
        /// Reads the StylesPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the StylesPattern.</param>
        /// <returns>The StylesPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static StylesPattern GetStylesPattern(AutomationElement element) => Get<StylesPattern>(element, StylesPattern.Pattern);

        /// <summary>
        /// Reads the TableItemPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TableItemPattern.</param>
        /// <returns>The TableItemPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TableItemPattern GetTableItemPattern(AutomationElement element) => Get<TableItemPattern>(element, TableItemPattern.Pattern);

        /// <summary>
        /// Reads the TablePattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TablePattern.</param>
        /// <returns>The TablePattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TablePattern GetTablePattern(AutomationElement element) => Get<TablePattern>(element, TablePattern.Pattern);

        /// <summary>
        /// Reads the TextChildPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TextChildPattern.</param>
        /// <returns>The TextChildPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TextChildPattern GetTextChildPattern(AutomationElement element) => Get<TextChildPattern>(element, TextChildPattern.Pattern);

        /// <summary>
        /// Reads the TextPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TextPattern.</param>
        /// <returns>The TextPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TextPattern GetTextPattern(AutomationElement element) => Get<TextPattern>(element, TextPattern.Pattern);

        /// <summary>
        /// Reads the TextPattern2 from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TextPattern2.</param>
        /// <returns>The TextPattern2 the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TextPattern2 GetTextPattern2(AutomationElement element) => Get<TextPattern2>(element, TextPattern2.Pattern);

        /// <summary>
        /// Reads the TogglePattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TogglePattern.</param>
        /// <returns>The TogglePattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TogglePattern GetTogglePattern(AutomationElement element) => Get<TogglePattern>(element, TogglePattern.Pattern);

        /// <summary>
        /// Reads the TransformPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TransformPattern.</param>
        /// <returns>The TransformPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TransformPattern GetTransformPattern(AutomationElement element) => Get<TransformPattern>(element, TransformPattern.Pattern);

        /// <summary>
        /// Reads the TransformPattern2 from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the TransformPattern2.</param>
        /// <returns>The TransformPattern2 the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static TransformPattern2 GetTransformPattern2(AutomationElement element) => Get<TransformPattern2>(element, TransformPattern2.Pattern);

        /// <summary>
        /// Reads the ValuePattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the ValuePattern.</param>
        /// <returns>The ValuePattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static ValuePattern GetValuePattern(AutomationElement element) => Get<ValuePattern>(element, ValuePattern.Pattern);

        /// <summary>
        /// Reads the VirtualizedItemPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the VirtualizedItemPattern.</param>
        /// <returns>The VirtualizedItemPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static VirtualizedItemPattern GetVirtualizedItemPattern(AutomationElement element) => Get<VirtualizedItemPattern>(element, VirtualizedItemPattern.Pattern);

        /// <summary>
        /// Reads the WindowPattern from the given AutomationElement.
        /// </summary>
        /// <param name="element">The AutomationElement which supports the WindowPattern.</param>
        /// <returns>The WindowPattern the the given AutomationElement.</returns>
        /// <exception cref="NotSupportedException">Thrown if the given AutomationElement is not supporting it. Check <see cref="BasicElement.SupportedPatterns" /> at runtime if the pattern is available.</exception>
        public static WindowPattern GetWindowPattern(AutomationElement element) => Get<WindowPattern>(element, WindowPattern.Pattern);
        
        private static TPattern Get<TPattern>(AutomationElement element, AutomationPattern pattern) where TPattern : BasePattern
        {
            if (element.TryGetCurrentPattern(pattern, out var readPattern))
                return (TPattern)readPattern;
            throw new NotSupportedException();
        }
    }
}