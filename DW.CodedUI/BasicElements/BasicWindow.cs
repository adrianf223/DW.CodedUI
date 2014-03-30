using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    public class BasicWindow : BasicWindowBase
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
                    return UI.GetChild<BasicButton>(By.Name("Maximieren"), From.Element(this));
                return UI.GetChild<BasicButton>(By.Name("Maximize"), From.Element(this));
            }
        }

        public BasicButton RestoreButton
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                if (currentCulture.Name == "de-DE")
                    return UI.GetChild<BasicButton>(By.Name("Wiederherstellen"), From.Element(this));
                return UI.GetChild<BasicButton>(By.Name("Restore"), From.Element(this));
            }
        }

        public BasicButton MinimizeButton
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                if (currentCulture.Name == "de-DE")
                    return UI.GetChild<BasicButton>(By.Name("Minimieren"), From.Element(this));
                return UI.GetChild<BasicButton>(By.Name("Minimize"), From.Element(this));
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

        // TODO: Adjust and test
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
