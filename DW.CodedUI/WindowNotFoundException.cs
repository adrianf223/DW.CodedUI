using System;
using System.Text;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors that occur if an window, dialog or messagebox cannot be found.
    /// </summary>
    public class WindowNotFoundException : Exception
    {
#if TRIAL
        static WindowNotFoundException()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.WindowNotFoundException" /> class.
        /// </summary>
        /// <param name="use">The conditions how the window has been searched.</param>
        /// <param name="useTimeout">A value that indicates if a timeout was used.</param>
        /// <param name="useInterval">A value that indicates if an interval was used.</param>
        /// <param name="intervalTime">The time used in the interval.</param>
        /// <param name="timeout">The elapsed search time.</param>
        /// <param name="is">The relationship to another object.</param>
        public WindowNotFoundException(Use use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, Is @is)
            : base(BuildMessage(use, useTimeout, useInterval, intervalTime, timeout, @is))
        {
        }

        private static string BuildMessage(Use use, bool useTimeout, bool useInterval, uint intervalTime, TimeSpan timeout, Is @is)
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
    }
}