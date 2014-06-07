using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents a container which stores old found elements.
    /// </summary>
    public static class ElementsContainer
    {
        /// <summary>
        /// Gets the last found window. This will be set by using the WindowFinder.Search or create a BasicWindow with a valid window instance.
        /// </summary>
        public static BasicWindow LastWindow { get; internal set; }
    }
}