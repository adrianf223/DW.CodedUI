using System.Diagnostics;
using System.IO;

namespace DW.CodedUI.Application
{
    public static class ApplicationFactory
    {
        public static void Launch(string applicationPath, string arguments = null)
        {
            var processStartInfo = new ProcessStartInfo(applicationPath, arguments);
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(applicationPath);
            var process = Process.Start(processStartInfo);
            process.WaitForInputIdle();
        }
    }
}
