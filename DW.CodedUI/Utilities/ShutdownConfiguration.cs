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

using System.Collections.Generic;

namespace DW.CodedUI.Utilities
{
    // ReSharper disable ClassNeverInstantiated.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable UnusedMember.Global

    /// <summary>
    /// Holds some properties how an application should be shut down
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
    public class ShutdownConfiguration
    {
        /// <summary>
        /// Gets the time in milliseconds to wait if a MessageBox has been closed
        /// </summary>
        /// <value>If not set: 200</value>
        public int WaitTimeBetweenMessageBoxes { get; set; }

        /// <summary>
        /// Gets the time in milliseconds to wait for new MessageBoxes at maximum
        /// </summary>
        /// <value>If not set: 5000</value>
        public int FinishedIfNoMessageBoxApearsAfter { get; set; }

        /// <summary>
        /// Gets a list of information how messageboxes should be closed
        /// </summary>
        public List<MessageBoxInfo> MessageBoxInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ShutdownConfiguration class
        /// </summary>
        public ShutdownConfiguration()
        {
            MessageBoxInfo = new List<MessageBoxInfo>();

            WaitTimeBetweenMessageBoxes = 200;
            FinishedIfNoMessageBoxApearsAfter = 5000;
        }

        /// <summary>
        /// Sets the information how messageboxes should be closed
        /// </summary>
        /// <param name="info"></param>
        public void SetSetMessageBoxInfo(params MessageBoxInfo[] info)
        {
            MessageBoxInfo.AddRange(info);
        }
    }

    // ReSharper restore ClassNeverInstantiated.Global
    // ReSharper restore MemberCanBePrivate.Global
    // ReSharper restore UnusedMember.Global
}