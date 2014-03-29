using System;
using System.Text;

namespace DW.CodedUI
{
    public class UIElementNotFoundException : Exception
    {
        public UIElementNotFoundException(By @by, bool useTimeout, TimeSpan timeout, bool multiply)
            : base(BuildMessage(by, useTimeout, timeout, multiply))
        {
        }

        private static string BuildMessage(By by, bool useTimeout, TimeSpan timeout, bool multiply)
        {
            var builder = new StringBuilder();
            if (multiply)
                builder.AppendLine("No UI element could be found.");
            else
                builder.AppendLine("The UI element could not be found.");
            builder.AppendLine();
            builder.AppendLine(by.GetConditionDescription());
            builder.AppendLine();
            if (useTimeout)
            {
                builder.Append("With timeout: ");
                builder.Append(timeout);
            }
            else
                builder.Append("Without timeout");

            return builder.ToString();
        }
    }
}
