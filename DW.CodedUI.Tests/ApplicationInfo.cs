using System;
using System.IO;

namespace DW.CodedUI.Tests
{
    internal static class ApplicationInfo
    {
        internal static string ExecutablePath
        {
            get
            {
                var currentDirectory = Environment.CurrentDirectory;
                var path = Path.Combine(currentDirectory, @"..\..\..\DW.CodedUI.Demo\bin\Debug\2012\DW.CodedUI.Demo.exe");
                return path;
            }
        }
        internal const string FastStartArguments = "/FastStart";
        internal const string WindowTitle = "Application Window Title";
        internal const int StartupWaitTime = 3000;
    }
}
