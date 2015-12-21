namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors which appeared when clicking.
    /// </summary>
    public class MouseClickException : LoggedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.MouseClickException" /> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public MouseClickException(string message)
            : base(message)
        {
        }
    }
}