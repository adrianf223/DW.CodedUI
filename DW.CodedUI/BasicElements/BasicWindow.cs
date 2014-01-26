using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using DW.CodedUI.Interaction;
using DW.CodedUI.Internal;
using DW.CodedUI.UITree;
using DW.CodedUI.Utilities;
using WindowState = DW.CodedUI.Application.WindowState;

namespace DW.CodedUI.BasicElements
{
    public class BasicWindow : BasicElement
    {
        public BasicWindow(AutomationElement automationElement)
            : base(automationElement)
        {
            Unsafe = new UnsafeMethods(automationElement);
        }

        public UnsafeMethods Unsafe { get; private set; }

        public class UnsafeMethods
        {
            private readonly AutomationElement _automationElement;

            internal UnsafeMethods(AutomationElement automationElement)
            {
                _automationElement = automationElement;
            }

            public void Maximize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Maximize);
            }

            public void Minimize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Minimize);
            }

            public void Normalize()
            {
                WinApi.ShowWindow((IntPtr)_automationElement.Current.NativeWindowHandle, WinApi.ShowWindowCommands.Normal);
            }

            public void Close()
            {
                WinApi.SendMessage(new HandleRef(null, new IntPtr(_automationElement.Current.NativeWindowHandle)), WinApi.ID_Close, IntPtr.Zero, IntPtr.Zero);
            }
        }

        public void Maximize()
        {
            var maximizeButton = BasicElementFinder.FindChildByAutomationId<BasicButton>(this, "Maximize");
            if (maximizeButton != null && maximizeButton.IsVisible && maximizeButton.IsEnabled)
                MouseEx.Click(maximizeButton);
        }

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

        public string Title
        {
            get { return Name; }
        }

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

        public bool CanClicked
        {
            get
            {
                int result = (int)WinApi.GetWindowLongPtr((IntPtr)AutomationElement.Current.NativeWindowHandle, (int)WinApi.WindowLongFlags.GWL_STYLE);
                var isDisabled = (result & WinApi.WS_DISABLED) == WinApi.WS_DISABLED;
                return !isDisabled;
            }
        }

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
