namespace DW.CodedUI.Application
{
    /// <summary>
    /// Defines how a window title should be compared
    /// </summary>
    public enum TitleSearchCondition
    {
        /// <summary>
        /// The given title matches exactly
        /// </summary>
        IsEqual,

        /// <summary>
        /// The window contains the given title
        /// </summary>
        Contains
    }
}