using System;
using System.Text;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors that occur if an window, dialog or messagebox cannot be found.
    /// </summary>
    public class WindowNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.WindowNotFoundException" /> class.
        /// </summary>
        /// <param name="use">The conditions how the window has been searched.</param>
        /// <param name="useTimeout">A value that indicates if a timeout was used.</param>
        /// <param name="useInterval">A value that indicates if an interval was used.</param>
        /// <param name="intervalTime">The time used in the interval.</param>
        /// <param name="timeout">The elapsed search time.</param>
        public WindowNotFoundException(Using use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout)
            : base(BuildMessage(use, useTimeout, useInterval, intervalTime, timeout))
        {
        }

        private static string BuildMessage(Using use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout)
        {
            var builder = new StringBuilder();
            builder.AppendLine("The window could not be found.");
            builder.AppendLine();
            builder.AppendLine("Condition(s):");
            builder.AppendLine(use.GetConditionDescription());
            builder.AppendLine();
            builder.AppendLine("Settings:");
            if (useTimeout)
                builder.AppendLine("* With timeout: " + timeout);
            else
                builder.AppendLine("* Without timeout");
            if (useInterval)
                builder.AppendLine("* With interval: " + intervalTime);
            else
                builder.AppendLine("* Without interval");
            builder.AppendLine();
            return builder.ToString();
        }
    }
}