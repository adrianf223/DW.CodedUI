using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using DW.CodedUI.BasicElements;
using DW.CodedUI.UITree;

namespace DW.CodedUI.Application
{
    public static class ApplicationFactory
    {
        public static BasicWindow Launch(string applicationPath, string arguments = null, int timeout = 10000, WindowState expectedWindowState = WindowState.Normal)
        {
            var processStartInfo = new ProcessStartInfo(applicationPath, arguments);
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(applicationPath);
            var process = Process.Start(processStartInfo);
            process.WaitForInputIdle();

            BasicWindow window = null;
            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.Elapsed.TotalMilliseconds >= timeout)
                    return window;

                window = WindowFinder.Search(process.Id.ToString(CultureInfo.InvariantCulture), WindowSearchCondition.ProcessId, timeout: timeout);
                if (window != null && window.WindowState == expectedWindowState)
                    return window;
                Thread.Sleep(200);
            }
        }
    }
}
