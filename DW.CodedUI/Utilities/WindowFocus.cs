using System;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI.Utilities
{
    public static class WindowFocus
    {
        public static void BringOnTop(BasicMessageBox messageBox)
        {
            WinApi.SetForegroundWindow(new IntPtr(messageBox.Properties.NativeWindowHandle));
        }

        public static void BringOnTop(BasicWindow window)
        {
            WinApi.SetForegroundWindow((IntPtr)window.AutomationElement.Current.NativeWindowHandle);
        }
    }
}