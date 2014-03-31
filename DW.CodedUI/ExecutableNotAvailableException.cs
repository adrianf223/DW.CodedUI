using System;
using System.Text;

namespace DW.CodedUI
{
    public class ExecutableNotAvailableException : Exception
    {
        public ExecutableNotAvailableException(string path)
            : base(BuildMessage(path))
        {
            
        }

        private static string BuildMessage(string path)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Cannot start the process because the file is not there.");
            builder.AppendLine();
            builder.AppendLine(path);
            return builder.ToString();
        }
    }
}