using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents a window.
    /// </summary>
    public class BasicWindow : BasicWindowBase
    {
#if TRIAL
        static BasicWindow()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicWindow" /> class
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        public BasicWindow(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);

            if (automationElement != null)
                ElementsContainer.LastWindow = this;
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

            return windows;
        }
    }
}
