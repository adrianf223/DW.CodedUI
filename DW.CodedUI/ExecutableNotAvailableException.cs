using System;
using System.Text;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors that occur during launching an executable.
    /// </summary>
    public class ExecutableNotAvailableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.ExecutableNotAvailableException" /> class.
        /// </summary>
        /// <param name="path">The path of the executable to start.</param>
        public ExecutableNotAvailableException(string path)
            : base(BuildMessage(path))
        {
        }

        private static string BuildMessage(string path)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Cannot start the process because the file is not there.");
            builder.AppendLine("Assembly:");
            builder.AppendLine(path);
            builder.AppendLine();
            return builder.ToString();
        }
    }
}