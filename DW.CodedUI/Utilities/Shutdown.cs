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
using DW.CodedUI.BasicElements;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.Utilities
{
    // ReSharper disable UnusedMember.Global
    // ReSharper disable LoopCanBeConvertedToQuery
    // ReSharper disable MemberCanBePrivate.Global

    /// <summary>
    /// Brings possibility to shut down an application
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestCleanup]
    /// [ExecutionSpeed(Speed.Fast)]
    /// public void TearDown()
    /// {
    ///     var shutdownConfiguration = new ShutdownConfiguration();
    ///     shutdownConfiguration.SetSetMessageBoxInfo(new MessageBoxInfo("Really Close?", MessageBoxResult.OK),
    ///                                                new MessageBoxInfo("Save changes?", MessageBoxResult.Cancel));
    ///     var shutdown = new Shutdown(shutdownConfiguration);
    /// 
    ///     shutdown.CloseApplication(_target); // May raise messageboxes up
    ///     DynamicSleep.Wait();
    ///     shutdown.CleanMessageBoxes(); // Close the possible messageboxes
    ///     DynamicSleep.Wait();
    ///     shutdown.CloseApplication(_target); // Just to be sure the application has been closed
    /// }]]>
    /// </code>
    /// </example>
    public class Shutdown
    {
        private readonly ShutdownConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the Shutdown class
        /// </summary>
        public Shutdown(ShutdownConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Wait for messageboxes and closes them by the ShutdownConfiguration
        /// </summary>
        /// <returns>Amount of closed MessageBoxes</returns>
        /// <remarks>If a MessageBox is not defined in the ShutdownConfiguration it will not closed</remarks>
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

        private BasicMessageBox FindMessageBox()
        {
            foreach (var messageBoxInfo in _configuration.MessageBoxInfo)
            {
                var messageBox = MessageBoxFinder.FindFirstAvailableByTitle(messageBoxInfo.Title);
                if (messageBox != null)
                    return messageBox;
            }
            return null;
        }

        /// <summary>
        /// Closed the application
        /// </summary>
        /// <param name="window">The main window of the application</param>
        public void CloseApplication(WpfWindow window)
        {
            var process = Process.GetProcesses().FirstOrDefault(p => p.MainWindowHandle == window.WindowHandle);
            if (process == null)
                return;
            if (process.CloseMainWindow())
                return;
            process.Kill();
        }

        /// <summary>
        /// Closed the application
        /// </summary>
        /// <param name="window">The main window of the application</param>
        public void CloseApplication(TestableApplication window)
        {
            if (!window.Shutdown())
                CloseApplication((WpfWindow)window);
        }

        private MessageBoxResult GetBoxResult(string title)
        {
            var result = _configuration.MessageBoxInfo.FirstOrDefault(m => m.Title == title);
            if (result != null)
                return result.MessageBoxResult;
            return MessageBoxResult.None;
        }
    }

    // ReSharper restore UnusedMember.Global
    // ReSharper restore LoopCanBeConvertedToQuery
    // ReSharper restore MemberCanBePrivate.Global
}
