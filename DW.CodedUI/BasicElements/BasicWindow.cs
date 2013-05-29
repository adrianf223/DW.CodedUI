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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Automation;
using DW.CodedUI.Interaction;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;
using WindowState = DW.CodedUI.Application.WindowState;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a single open WPF window
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Method_TestCondition_ExpectedResult1()
    /// {
    ///     // do anything and a window appears
    /// 
    ///     var window = WindowFinder.Search("The title");
    /// 
    ///     // Assert anything in the window
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class BasicWindow : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the BasicWindow class
        /// </summary>
        /// <param name="automationElement">The automation control</param>
        public BasicWindow(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        /// <summary>
        /// Gets access to unsafe methods
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Maximizes the window
            /// </summary>
            public void Maximize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Maximize);
            }

            /// <summary>
            /// Minimizes the window
            /// </summary>
            public void Minimize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Minimize);
            }

            /// <summary>
            /// Normalizes the window
            /// </summary>
            public void Normalize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Normal);
            }

            /// <summary>
            /// Closes the window
            /// </summary>
            public void Close()
            {
                WinApi.SendMessage(new HandleRef(null, new IntPtr(_automationElement.Current.NativeWindowHandle)), WinApi.ID_Close, IntPtr.Zero, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Maximizes the window
        /// </summary>
        public void Maximize()
        {
            var maximizeButton = BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "Maximize");
            if (maximizeButton != null && maximizeButton.IsVisible && maximizeButton.IsEnabled)
                MouseEx.Click(maximizeButton);
        }

        /// <summary>
        /// Normalizes the window
        /// </summary>
        public void Normalize()
        {
            if (WindowState == WindowState.Minimized)
                Unsafe.Normalize();
            else
            {
                var restoreButton = BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "Restore");
                if (restoreButton != null && restoreButton.IsVisible && restoreButton.IsEnabled)
                    MouseEx.Click(restoreButton);
            }
        }

        /// <summary>
        /// Minimizes the window
        /// </summary>
        public void Minimize()
        {
            var minimizeButton = BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "Minimize");
            if (minimizeButton != null && minimizeButton.IsVisible && minimizeButton.IsEnabled)
                MouseEx.Click(minimizeButton);
        }

        //public void Close()
        //{
        //    var closeButton = BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "Close");
        //    if (closeButton != null && closeButton.IsVisible && closeButton.IsEnabled)
        //        MouseEx.Click(closeButton);
        //}

        /// <summary>
        /// Gets the window title
        /// </summary>
        public string Title
        {
            get { return Name; }
        }

        /// <summary>
        /// Gets the actual window state
        /// </summary>
        public WindowState WindowState
        {
            get
            {
                var placement = new WinApi.WINDOWPLACEMENT();
                placement.length = Marshal.SizeOf(placement);
                WinApi.GetWindowPlacement((IntPtr)AutomationElement.Current.NativeWindowHandle, ref placement);
                return placement.showCmd;
            }
        }

        /// <summary>
        /// Indicated if the window can be used. Mostly this is an indicator that a modal child window is opened.
        /// </summary>
        /// <returns>True if the window can be used; otherwise false</returns>
        public bool CanClicked
        {
            get
            {
                int result = (int)WinApi.GetWindowLongPtr((IntPtr)AutomationElement.Current.NativeWindowHandle, (int)WinApi.WindowLongFlags.GWL_STYLE);
                var isDisabled = (result & WinApi.WS_DISABLED) == WinApi.WS_DISABLED;
                return !isDisabled;
            }
        }

        /// <summary>
        /// Returns a collection of open and visible child windows. It returns an empty collection if there aren't any
        /// </summary>
        /// <returns>List of open and visible child BasicWindow objects ready for UI tests</returns>
        public IEnumerable<BasicWindow> GetChildWindows()
        {
            var windows = new List<BasicWindow>();
            WinApi.EnumThreadDelegate filter = delegate(IntPtr hWnd, IntPtr lParam)
            {
                if (hWnd != (IntPtr)AutomationElement.Current.NativeWindowHandle && WinApi.IsWindowVisible(hWnd))
                    windows.Add(new BasicWindow(AutomationElement.FromHandle(hWnd)));
                return true;
            };

            var process = Process.GetProcessById(AutomationElement.Current.ProcessId);
            foreach (ProcessThread thread in process.Threads)
                WinApi.EnumThreadWindows((uint)thread.Id, filter, IntPtr.Zero);

            return windows;
        }
    }
}
