#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using DW.CodedUI.Application;
using DW.CodedUI.Interaction;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.Utilities
{
    public class Shutdown
    {
        private readonly ShutdownConfiguration _configuration;
        
        public Shutdown(ShutdownConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CleanMessageBoxes()
        {
            var timer = new Stopwatch();
            timer.Start();
            var closedMessageBoxes = 0;
            while (true)
            {
                Thread.Sleep(_configuration.WaitTimeBetweenMessageBoxes);
                var messageBox = FindMessageBox();
                if (messageBox != null)
                {
                    timer.Stop();
                    var boxResult = GetBoxResult(messageBox.Title);
                    MessageBoxHandler.Close(messageBox, boxResult);
                    ++closedMessageBoxes;
                    timer.Restart();
                }
                else
                {
                    if (timer.Elapsed.TotalMilliseconds >= _configuration.FinishedIfNoMessageBoxApearsAfter)
                        return closedMessageBoxes;
                }
            }
        }

        private OpenWindow FindMessageBox()
        {
            foreach (var messageBoxInfo in _configuration.MessageBoxInfo)
            {
                var messageBox = WindowsMessageBox.FindMessageBox(messageBoxInfo.Title);
                if (messageBox != null)
                    return messageBox;
            }
            return null;
        }

        public void CloseApplication(WpfWindow window)
        {
            var process = Process.GetProcesses().FirstOrDefault(p => p.MainWindowHandle == window.WindowHandle);
            if (process == null)
                return;
            if (process.CloseMainWindow())
                return;
            process.Kill();
        }

        public void CloseApplication(WindowUnderTest window)
        {
            if (!window.Shutdown())
                CloseApplication((WpfWindow) window);
        }

        private MessageBoxResult GetBoxResult(string title)
        {
            var result = _configuration.MessageBoxInfo.FirstOrDefault(m => m.Title == title);
            if (result != null)
                return result.MessageBoxResult;
            return MessageBoxResult.None;
        }
    }
}
