using System;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI.UITree
{
    public static class MessageBoxFinder
    {
        public static BasicMessageBox FindFirstAvailable()
        {
            var handle = WinApi.FindWindow("#32770", null);
            if (handle == IntPtr.Zero)
                return null;
            return new BasicMessageBox(AutomationElement.FromHandle(handle));
        }

        public static BasicMessageBox FindFirstAvailableByTitle(string title)
        {
            var handle = WinApi.FindWindow("#32770", title);
            if (handle == IntPtr.Zero)
                return null;
            return new BasicMessageBox(AutomationElement.FromHandle(handle));
        }
    }
}