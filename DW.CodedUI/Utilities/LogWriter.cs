using System;
using System.IO;
using System.Text;
using DW.CodedUI.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Write the log file(s) with the entries created during execute tests.
    /// </summary>
    public static class LogWriter
    {
        /// <summary>
        /// Writes the log file(s). Its intended to be used on the text cleanup.
        /// </summary>
        /// <param name="textContext">The TextContext of the class.</param>
        /// <remarks>You get the test context created by adding a public property into the class with the cleanup. 
        /// For configuring see <see cref="DW.CodedUI.CodedUIEnvironment.LoggerSettings" />.</remarks>
        /// <example>
        /// <code lang="csharp">
        /// <![CDATA[
        /// [CodedUITest]
        /// public class SomethingTests
        /// {
        ///     public TestContext TestContext { get; set; }
        /// 
        ///     [TestInitialize]
        ///     public void Setup()
        ///     {
        ///         CodedUIEnvironment.LoggerSettings.LogFilesDirectory = @"D:\CodedUI_Logs";
        ///     }
        /// 
        ///     [TestCleanup]
        ///     public void Cleanup()
        ///     {
        ///         LogWriter.Write(TestContext);
        ///     }
        /// 
        ///     [TestMethod]
        ///     public void Any_Test_Using_The_DW_CodedUI()
        ///     {
        ///         // Something
        ///     }
        /// }]]>
        /// </code>
        /// </example>
        public static void Write(TestContext textContext)
        {
            if (!CodedUIEnvironment.LoggerSettings.IsEnabled)
                return;

            var logDirectory = CreateLogDirectory();
            if (string.IsNullOrWhiteSpace(logDirectory))
                return;

            if (textContext.CurrentTestOutcome != UnitTestOutcome.Passed || CodedUIEnvironment.LoggerSettings.LogPassedTestsToo)
            {
                var methodName = textContext.TestName;
                var filePath = logDirectory;
                if (CodedUIEnvironment.LoggerSettings.AddTestResultToFileName)
                    filePath = Path.Combine(logDirectory, textContext.CurrentTestOutcome + " - " + methodName + ".txt");
                else
                    filePath = Path.Combine(logDirectory, methodName + ".txt");

                var logs = new StringBuilder();
                var startTime = LogPool.StartDateTime;
                var endTime = DateTime.Now;

                logs.AppendLine(string.Format("Executed test: {0}.{1}()", textContext.FullyQualifiedTestClassName, textContext.TestName));
                logs.AppendLine(string.Format("Result: {0}", textContext.CurrentTestOutcome));
                logs.AppendLine(string.Format("Start time: {0}", startTime.ToString("dd/MM/yyyy HH:mm:ss.fff")));
                logs.AppendLine(string.Format("Testrun finished at: {0}", endTime.ToString("dd/MM/yyyy HH:mm:ss.fff")));
                logs.AppendLine(string.Format("Execution time: {0}", (endTime - startTime).ToString("hh\\:mm\\:ss\\.fff")));
                logs.AppendLine();
                logs.AppendLine("### Begin ###");

                var logLines = LogPool.PopList();
                foreach (var line in logLines)
                    logs.AppendLine(line);

                logs.AppendLine("### End ###");

                File.AppendAllText(filePath, logs.ToString());
            }
        }

        private static string CreateLogDirectory()
        {
            try
            {
                var logDirectory = CodedUIEnvironment.LoggerSettings.LogFilesDirectory;
                if (string.IsNullOrWhiteSpace(logDirectory))
                    return string.Empty;

                if (!Directory.Exists(logDirectory))
                    Directory.CreateDirectory(logDirectory);

                return logDirectory;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
