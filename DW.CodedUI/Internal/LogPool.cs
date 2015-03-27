using System;
using System.Collections.Generic;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.Internal
{
    internal static class LogPool
    {
        private static readonly object _listLocker = new object();
        private static List<string> _logLines = new List<string>();

        internal static DateTime StartDateTime { get; private set; }
        internal static bool StartDateTimeWritten { get; set; }

        internal static void Append(string message, params object[] args)
        {
            if (!CodedUIEnvironment.LoggerSettings.IsEnabled)
                return;

            if (!StartDateTimeWritten)
            {
                StartDateTime = DateTime.Now;
                StartDateTimeWritten = true;
            }

            try
            {
                var logLineFormat = AdjustLogLineFormat(CodedUIEnvironment.LoggerSettings.LogLineFormat);
                var dateTime = DateTime.Now.ToString(CodedUIEnvironment.LoggerSettings.DateTimeFormat);

                message =  string.Format(logLineFormat, dateTime, string.Format(message, args));
            }
            catch (Exception ex)
            {
                message = string.Format("Cannot format the log message properly '{0}' because '{1}'", message, ex.Message);
            }

            if (CodedUIEnvironment.LoggerSettings.InstantLoggingContext != null)
            {
                LogWriter.WriteInstant(message);
                return;
            }

            lock (_listLocker)
                _logLines.Add(message);
        }

        private static string AdjustLogLineFormat(string logLineFormat)
        {
            var line = logLineFormat.ToLower().Replace("%datetime%", "{0}");
            return line.Replace("%message%", "{1}");
        }

        internal static IEnumerable<string> PopList()
        {
            lock (_listLocker)
            {
                var lines = _logLines;
                _logLines = new List<string>();
                return lines;
            }
        }
    }
}
