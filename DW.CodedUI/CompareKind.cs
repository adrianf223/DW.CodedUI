namespace DW.CodedUI
{
    /// <summary>
    /// Defines how to compare texts.
    /// </summary>
    public enum CompareKind
    {
        /// <summary>
        /// Compares the string to see if the first is the same like the second.
        /// </summary>
        Exact,

        /// <summary>
        /// Compares the string to see if the first contains the second.
        /// </summary>
        Contains,

        /// <summary>
        /// Compares the string to see if the first starts with the second.
        /// </summary>
        StartsWith,

        /// <summary>
        /// Compares the string to see if the first ends with the second.
        /// </summary>
        EndsWith,

        /// <summary>
        /// Compares the string to match exact with ignoring the casing.
        /// </summary>
        ExactIgnoreCase,

        /// <summary>
        /// Compares the string to see if the first contains the second with ignoring the casing.
        /// </summary>
        ContainsIgnoreCase,

        /// <summary>
        /// Compares the string to see if the first starts with the second with ignoring the casing.
        /// </summary>
        StartsWithIgnoreCase,

        /// <summary>
        /// Compares the string to see if the first ends with the second with ignoring the casing.
        /// </summary>
        EndsWithIgnoreCase
    }
}