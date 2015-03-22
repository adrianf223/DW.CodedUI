using System;
using System.Collections.Generic;
using System.Linq;

namespace DW.CodedUI.Internal
{
    internal static class LogPool
    {
        private static readonly object _listLocker = new object();
        private static List<string> _logLines = new List<string>();

        internal static DateTime StartDateTime { get; private set; }

        internal static void Append(string message, params object[] args)
        {
            if (!CodedUIEnvironment.LoggerSettings.IsEnabled)
                return;

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
            lock (_listLocker)
            {
                if (!_logLines.Any())
                    StartDateTime = DateTime.Now;
                _logLines.Add(message);
            }
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
