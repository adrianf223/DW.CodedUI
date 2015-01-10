#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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
THE SOFTWARE
*/
#endregion License

using System;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Brings possibilities to bring all windows on top.
    /// </summary>
    public static class WindowFocus
    {
        /// <summary>
        /// Brings the given window on top.
        /// </summary>
        /// <typeparam name="TWindow">The type of the window passed. This can be a window, messagebox or system dialog.</typeparam>
        /// <param name="window">The window to be on top. This can be a window, messagebox or system dialog.</param>
        public static void BringOnTop<TWindow>(TWindow window) where TWindow : BasicWindowBase
        {
            WinApi.SetForegroundWindow((IntPtr)window.Properties.NativeWindowHandle);
        }
    }
}