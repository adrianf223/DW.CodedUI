#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

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
