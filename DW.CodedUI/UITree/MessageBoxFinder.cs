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
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Utilities;

namespace DW.CodedUI.UITree
{
    /// <summary>
    /// Brings you possibilities to find MessageBoxes
    /// </summary>
    public static class MessageBoxFinder
    {
        /// <summary>
        /// Finds the first available MessageBox
        /// </summary>
        /// <returns>Returns the MessageBox if any; otherwise null</returns>
        public static BasicMessageBox FindFirstAvailable()
        {
            var handle = WinApi.FindWindow("#32770", null);
            if (handle == IntPtr.Zero)
                return null;
            return new BasicMessageBox(AutomationElement.FromHandle(handle));
        }

        /// <summary>
        /// Finds the first available MessageBox with the given title
        /// </summary>
        /// <param name="title">The title of the MessageBox to search for</param>
        /// <returns>Returns the MessageBox if any; otherwise null</returns>
        public static BasicMessageBox FindFirstAvailableByTitle(string title)
        {
            var handle = WinApi.FindWindow("#32770", title);
            if (handle == IntPtr.Zero)
                return null;
            return new BasicMessageBox(AutomationElement.FromHandle(handle));
        }
    }
}