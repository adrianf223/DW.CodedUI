using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

        public BasicButton MaximizeButton
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                if (currentCulture.Name == "de-DE")
                    return BasicElementFinder.FindChildByName<BasicButton>(this, "Maximieren");
                return BasicElementFinder.FindChildByName<BasicButton>(this, "Maximize");
            }
        }

        public BasicButton RestoreButton
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                if (currentCulture.Name == "de-DE")
                    return BasicElementFinder.FindChildByName<BasicButton>(this, "Wiederherstellen");
                return BasicElementFinder.FindChildByName<BasicButton>(this, "Restore");
            }
        }

        public BasicButton MinimizeButton
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                if (currentCulture.Name == "de-DE")
                    return BasicElementFinder.FindChildByName<BasicButton>(this, "Minimieren");
                return BasicElementFinder.FindChildByName<BasicButton>(this, "Minimize");
            }
        }

        public BasicButton CloseButton
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                if (currentCulture.Name == "de-DE")
                    return BasicElementFinder.FindChildByName<BasicButton>(this, "Schließen");
                return BasicElementFinder.FindChildByName<BasicButton>(this, "Close");
            }
        }

        public BasicElement TitleBar
        {
            get
            {
                return BasicElementFinder.FindChildByCondition(this, e => e.Current.ControlType.Equals(ControlType.TitleBar));
            }
        }

        public string Title
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Name))
                    return Name;

                var strbTitle = new StringBuilder(255);
                WinApi.GetWindowText((IntPtr)AutomationElement.Current.NativeWindowHandle, strbTitle, strbTitle.Capacity + 1);
                return strbTitle.ToString();
            }
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
