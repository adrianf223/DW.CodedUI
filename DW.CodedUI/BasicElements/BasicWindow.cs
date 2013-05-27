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
                ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, ShowWindowCommands.Maximize);
            }

            /// <summary>
            /// Minimizes the window
            /// </summary>
            public void Minimize()
            {
                ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, ShowWindowCommands.Minimize);
            }

            /// <summary>
            /// Normalizes the window
            /// </summary>
            public void Normalize()
            {
                ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, ShowWindowCommands.Normal);
            }

            /// <summary>
            /// Closes the window
            /// </summary>
            public void Close()
            {
                SendMessage(new HandleRef(null, new IntPtr(_automationElement.Current.NativeWindowHandle)), ID_Close, IntPtr.Zero, IntPtr.Zero);
            }

            [DllImport("user32.dll")]
            private static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

            [DllImport("user32.dll")]
            private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            private const int ID_Close = 0x10;

            private enum ShowWindowCommands
            {
                Hide = 0,
                Normal = 1,
                ShowMinimized = 2,
                Maximize = 3,
                ShowMaximized = 3,
                ShowNoActivate = 4,
                Show = 5,
                Minimize = 6,
                ShowMinNoActive = 7,
                ShowNA = 8,
                Restore = 9,
                ShowDefault = 10,
                ForceMinimize = 11
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
                var placement = new WINDOWPLACEMENT();
                placement.length = Marshal.SizeOf(placement);
                GetWindowPlacement((IntPtr)AutomationElement.Current.NativeWindowHandle, ref placement);
                return placement.showCmd;
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public WindowState showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        /// <summary>
        /// Indicated if the window can be used. Mostly this is an indicator that a modal child window is opened.
        /// </summary>
        /// <returns>True if the window can be used; otherwise false</returns>
        public bool CanClicked    
        {
            get
            {
                var titleBar = BasicElementFinder.FindChildByAutomationId(this, "TitleBar");
                return titleBar.IsEnabled;
            }
        }

        /// <summary>
        /// Returns a collection of open and visible child windows. It returns an empty collection if there aren't any
        /// </summary>
        /// <returns>List of open and visible child BasicWindow objects ready for UI tests</returns>
        public IEnumerable<BasicWindow> GetChildWindows()
        {
            var windows = new List<BasicWindow>();
            EnumThreadDelegate filter = delegate(IntPtr hWnd, IntPtr lParam)
            {
                if (hWnd != (IntPtr)AutomationElement.Current.NativeWindowHandle && IsWindowVisible(hWnd))
                    windows.Add(new BasicWindow(AutomationElement.FromHandle(hWnd)));
                return true;
            };

            var process = Process.GetProcessById(AutomationElement.Current.ProcessId);
            foreach (ProcessThread thread in process.Threads)
                EnumThreadWindows((uint) thread.Id, filter, IntPtr.Zero);

            return windows;
        }

        private delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(uint dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
    }
}
