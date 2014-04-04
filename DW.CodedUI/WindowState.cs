namespace DW.CodedUI
{
    /// <summary>
    /// Represents the state of a window.
    /// </summary>
    public enum WindowState
    {
        /// <summary>
        /// The window is there but hidden.
        /// </summary>
        Hidden = 0,

        /// <summary>
        /// The window is shown normalized.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// The window is shown minimized.
        /// </summary>
        Minimized = 2,

        /// <summary>
        /// The window is shown maximized.
        /// </summary>
        Maximized = 3,
    }
}