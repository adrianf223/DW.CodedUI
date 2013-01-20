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

using System;
using System.Runtime.InteropServices;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Provides possibilities to bring any kind of a window on top
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Method_TestCondition_ExpectedResult()
    /// {
    ///     var myMessageBox = MessageBoxFinder.FindFirstAvailable();
    /// 
    ///     WindowFocux.BringOnTop(myMessageBox);
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public static class WindowFocus
    {
        /// <summary>
        /// Brings a MessageBox on top
        /// </summary>
        /// <param name="messageBox">The MessageBox to bring on top</param>
        public static void BringOnTop(BasicMessageBox messageBox)
        {
            SetForegroundWindow(new IntPtr(messageBox.Properties.NativeWindowHandle));
        }

        /// <summary>
        /// Brings a WPF Window on top
        /// </summary>
        /// <param name="window">The window to bring on top</param>
        /// <remarks>TestableApplication and TestableWindow can be passed as well</remarks>
        public static void BringOnTop(WpfWindow window)
        {
            SetForegroundWindow(window.WindowHandle);
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}