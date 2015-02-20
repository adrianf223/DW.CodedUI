using System;
using System.Text;

namespace DW.CodedUI.Internal
{
    internal static class MessageBuilder
    {
        internal static string BuildErrorMessage(By by, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, bool multiply)
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

        internal static string BuildMessage(By by, bool useTimeout, bool useInterval, uint timeout, uint intervalTime)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Condition(s):");
            builder.AppendLine(by.GetConditionDescription());
            builder.Append("Settings:");
            if (useTimeout)
                builder.Append(string.Format(" With timeout: {0}; ", timeout));
            else
                builder.Append(" Without timeout; ");
            if (useInterval)
                builder.Append(string.Format(" With interval: {0}.", intervalTime));
            else
                builder.Append(" Without interval.");
            return builder.ToString();
        }

        internal static string BuildErrorMessage(bool isEnabled, bool isVisible, By by, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, bool multiply)
        {
            var builder = new StringBuilder();
            builder.AppendLine(multiply ? "At least one element was found but it was not become ready to use." : "The UI element was found but was not become ready to use.");
            builder.AppendLine("Enabled state of the element: " + (isEnabled ? "Enabled" : "Disabled"));
            builder.AppendLine("Visibility state of the element: " + (isVisible ? "Visible" : "Not visible"));
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

        internal static string BuildErrorMessage(Use use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, Is @is)
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
            switch (@is.GetCondition())
            {
                case IsCondition.ChildOf:
                    builder.AppendLine("* Is child of another window");
                    break;
                case IsCondition.MainWindow:
                    builder.AppendLine("* Is main window");
                    break;
                case IsCondition.Nothing:
                    break;
                case IsCondition.OwnerOf:
                    builder.AppendLine("* Is owner of an element");
                    break;
                case IsCondition.ParentOf:
                    builder.AppendLine("* Is parent of another window");
                    break;
            }
            builder.AppendLine();
            return builder.ToString();
        }

        internal static string BuildMessage(Use use, bool useTimeout, bool useInterval, uint intervalTime, uint timeout, Is @is)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Condition(s):");
            builder.AppendLine(use.GetConditionDescription());
            builder.Append("Settings:");
            if (useTimeout)
                builder.Append(string.Format(" With timeout: {0}; ", timeout));
            else
                builder.Append(" Without timeout; ");
            if (useInterval)
                builder.Append(string.Format(" With interval: {0}", intervalTime));
            else
                builder.Append(" Without interval");
            switch (@is.GetCondition())
            {
                case IsCondition.ChildOf:
                    builder.Append("; Is child of another window.");
                    break;
                case IsCondition.MainWindow:
                    builder.Append("; Is main window.");
                    break;
                case IsCondition.Nothing:
                    builder.Append(".");
                    break;
                case IsCondition.OwnerOf:
                    builder.Append("; Is owner of an element.");
                    break;
                case IsCondition.ParentOf:
                    builder.Append("; Is parent of another window.");
                    break;
            }
            return builder.ToString();
        }
    }
}