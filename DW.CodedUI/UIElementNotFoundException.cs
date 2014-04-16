using System;
using System.Text;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors that occur if an element in the UI cannot be found.
    /// </summary>
    public class UIElementNotFoundException : Exception
    {
#if TRIAL
        static UIElementNotFoundException()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.UIElementNotFoundException" /> class.
        /// </summary>
        /// <param name="by">The conditions how the element has been searched.</param>
        /// <param name="useTimeout">A value that indicates if a timeout was used.</param>
        /// <param name="useInterval">A value that indicates if an interval was used.</param>
        /// <param name="intervalTime">The time used in the interval.</param>
        /// <param name="timeout">The elapsed search time.</param>
        /// <param name="multiply">A value that indicates if one or multiple elements has been searched.</param>
        public UIElementNotFoundException(By by, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, bool multiply)
            : base(BuildMessage(by, useTimeout, useInterval, intervalTime, timeout, multiply))
        {
        }

        private static string BuildMessage(By by, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, bool multiply)
        {
            var builder = new StringBuilder();
            builder.AppendLine(multiply ? "No UI element could be found." : "The UI element could not be found.");
            builder.AppendLine();
            builder.AppendLine("Condition(s):");
            builder.AppendLine(by.GetConditionDescription());
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
