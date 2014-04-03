using System;
using System.Text;

namespace DW.CodedUI
{
    public class WindowNotFoundException : Exception
    {
        public WindowNotFoundException(Using use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout)
            : base(BuildMessage(use, useTimeout, useInterval, intervalTime, timeout))
        {
        }

        private static string BuildMessage(Using use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout)
        {
            var builder = new StringBuilder();
            builder.AppendLine("The window could not be found.");
            builder.AppendLine();
            builder.AppendLine(use.GetConditionDescription());
            builder.AppendLine();
            if (useTimeout)
            {
                builder.Append("With timeout: ");
                builder.Append(timeout);
            }
            else
                builder.Append("Without timeout");
            if (useInterval)
            {
                builder.Append("With interval: ");
                builder.Append(intervalTime);
            }
            else
                builder.Append("Without interval");

            return builder.ToString();
        }
    }
}