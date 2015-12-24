#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using DW.CodedUI.BasicElements.Data;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a window.
    /// </summary>
    public class BasicWindow : BasicWindowBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicWindow" /> class
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicWindow(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);

            if (automationElement != null)
                CodedUIEnvironment.LastWindow = this;
        }

        /// <summary>
        /// Gets access to unsafe methods.
        /// </summary>
        public UnsafeMethods Unsafe { get; private set; }

        /// <summary>
        /// Contains unsafe methods for interact with the control directly.
        /// </summary>
        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            /// <summary>
            /// Maximizes the window.
            /// </summary>
            public void Maximize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Maximize);
            }

            /// <summary>
            /// Minimizes the window.
            /// </summary>
            public void Minimize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Minimize);
            }

            /// <summary>
            /// Normalizes the window.
            /// </summary>
            public void Normalize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Normal);
            }

            /// <summary>
            /// Closes the window.
            /// </summary>
            public void Close()
            {
                WinApi.SendMessage(new HandleRef(null, new IntPtr(_automationElement.Current.NativeWindowHandle)), WinApi.ID_Close, IntPtr.Zero, IntPtr.Zero);
            }

            /// <summary>
            /// Sets the new state of the window.
            /// </summary>
            /// <param name="windowState">The new state of the window.</param>
            public void SetState(WindowState windowState)
            {
                switch (windowState)
                {
                    case WindowState.Maximized:
                        Maximize();
                        break;
                    case WindowState.Minimized:
                        Minimize();
                        break;
                    case WindowState.Normal:
                        Normalize();
                        break;
                    case WindowState.Hidden:
                        WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Hide);
                        break;
                }
            }

            /// <summary>
            /// Sets the new size of the window.
            /// </summary>
            /// <param name="size">The new site of the window.</param>
            public void SetSize(Size size)
            {
                var rect = _automationElement.Current.BoundingRectangle;
                SetRect(new Rectangle(rect.Location, size));
            }

            /// <summary>
            /// Sets the new position of the window.
            /// </summary>
            /// <param name="position">The new position of the window.</param>
            public void SetPosition(Point position)
            {
                var rect = _automationElement.Current.BoundingRectangle;
                SetRect(new Rectangle(position, rect.Size));
            }

            /// <summary>
            /// Sets the new size and position of a window.
            /// </summary>
            /// <param name="rect">The new position and size of the window.</param>
            public void SetRect(Rectangle rect)
            {
                WinApi.SetWindowPos((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.HwndInsertAfter.HWND_TOP, (int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, WinApi.SetWindowPositionFlags.SWP_NOZORDER);
            }
        }

        /// <summary>
        /// Gets the maximize button in the title bar of the normalized window.
        /// </summary>
        /// <remarks>Currently the button can be found only on English or German systems and if the <see cref="DW.CodedUI.BasicElements.BasicWindow.WindowState" /> is <see cref="DW.CodedUI.WindowState.Normal" />. If the system is another language consider using the <see cref="DW.CodedUI.UI" /> object with searching with <see cref="DW.CodedUI.By.Name(string)" />.</remarks>
        public BasicButton MaximizeButton
        {
            get
            {
                var maximizeButtonName1 = SystemStrings.GetString(SystemStrings.MaximizeButton);
                var maximizeButtonName2 = SystemStrings.GetString(SystemStrings.IncreaseButton);
                return UI.GetChild<BasicButton>(By.Name(maximizeButtonName1).Or.Name(maximizeButtonName2), From.Element(this), With.NoTimeout().NoAssert());
            }
        }

        /// <summary>
        /// Gets the restore button in the title bar of the maximized window.
        /// </summary>
        /// <remarks>Currently the button can be found only on English or German systems and if the <see cref="DW.CodedUI.BasicElements.BasicWindow.WindowState" /> is <see cref="DW.CodedUI.WindowState.Maximized" />. If the system is another language consider using the <see cref="DW.CodedUI.UI" /> object with searching with <see cref="DW.CodedUI.By.Name(string)" />.</remarks>
        public BasicButton RestoreButton
        {
            get
            {
                var normalizeButtonName = SystemStrings.GetString(SystemStrings.DecreaseButton);
                return UI.GetChild<BasicButton>(By.Name(normalizeButtonName), From.Element(this), With.NoTimeout().NoAssert());
            }
        }

        /// <summary>
        /// Gets the minimize button in the title bar.
        /// </summary>
        /// <remarks>Currently the button can be found only on English or German systems. If the system is another language consider using the <see cref="DW.CodedUI.UI" /> object with searching with <see cref="DW.CodedUI.By.Name(string)" />.</remarks>
        public BasicButton MinimizeButton
        {
            get
            {
                var minimizeButtonName = SystemStrings.GetString(SystemStrings.MinimizeButton);
                return UI.GetChild<BasicButton>(By.Name(minimizeButtonName), From.Element(this), With.NoTimeout().NoAssert());
            }
        }

        /// <summary>
        /// Gets the the actual window state.
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
        /// Returns a collection of open and visible child windows if any; otherwise an empty list.
        /// </summary>
        /// <returns>List of open and visible child BasicWindow objects ready for UI tests.</returns>
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

            for (var i = 0; i < windows.Count; ++i)
            {
                var window = windows[i];
                var parentWindow = window.GetParentWindow(false);
                
                if (parentWindow == null || !Equals(parentWindow))
                {
                    windows.Remove(window);
                    --i;
                }
            }

            return windows;
        }

        /// <summary>
        /// Make a shadow copy of the element at the current state which stays available even the element is gone.
        /// </summary>
        /// <returns>A shadow copy of the current element.</returns>
        public new BasicWindowData GetDataCopy()
        {
            var data = new BasicWindowData();
            FillData(data);
            data.Title = GetSafeData(() => Title);
            return data;
        }
    }
}
