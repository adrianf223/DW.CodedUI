using System;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Appends exception lines to the logging system.
    /// </summary>
    public class LoggedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.LoggedException" /> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public LoggedException(string message)
            : base(message)
        {
            LogPool.Append("Exception: {0}", this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.LoggedException" /> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public LoggedException(string message, Exception innerException)
            : base(message, innerException)
        {
            LogPool.Append("Exception: {0}", this);
        }
    }
}
