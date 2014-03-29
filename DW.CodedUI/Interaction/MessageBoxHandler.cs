using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace DW.CodedUI.Interaction
{
    [Obsolete("Methods in this object are not supported anymore. Use the buttons in the 'BasicMessageBox' instead.")]
    public static class MessageBoxHandler
    {
        private const string AutomationId_OK = "1";
        private const string AutomationId_Cancel = "2";
        private const string AutomationId_Yes = "6";
        private const string AutomationId_No = "7";
        private const string AutomationId_Text = "65535";

        private const int ID_Close = 0x10;
        
        [Obsolete]
        public static void Close(BasicMessageBox messageBox)
        {
            WinApi.SendMessage(new HandleRef(null, new IntPtr(messageBox.Properties.NativeWindowHandle)), ID_Close, IntPtr.Zero, IntPtr.Zero);
        }

        [Obsolete]
        public static void CloseWithOK(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_OK))
                Close(messageBox);
        }

        [Obsolete]
        public static void CloseWithCancel(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_Cancel))
                Close(messageBox);
        }

        [Obsolete]
        public static void CloseWithYes(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_Yes))
                Close(messageBox);
        }

        [Obsolete]
        public static void CloseWithNo(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_No))
                Close(messageBox);
        }

        [Obsolete]
        public static void Close(BasicMessageBox messageBox, MessageBoxResult messageBoxResult)
        {
            switch (messageBoxResult)
            {
                case MessageBoxResult.Yes:
                    CloseWithYes(messageBox);
                    break;
                case MessageBoxResult.No:
                    CloseWithNo(messageBox);
                    break;
                case MessageBoxResult.OK:
                    CloseWithOK(messageBox);
                    break;
                case MessageBoxResult.Cancel:
                    CloseWithCancel(messageBox);
                    break;
                default:
                    Close(messageBox);
                    break;
            }
        }

        [Obsolete]
        public static string GetText(BasicMessageBox messageBox)
        {
            var element = FindMessageBoxElement(messageBox, AutomationId_Text);
            if (element == null)
                return "";
            return element.Current.Name;
        }

        private static bool FindAndClick(BasicMessageBox messageBox, string automationId)
        {
            var element = FindMessageBoxElement(messageBox, automationId);
            if (element == null)
                return false;
            var point = element.GetClickablePoint();
            var originalMouseSpeed = Mouse.MouseMoveSpeed;
            Mouse.MouseMoveSpeed = 10000;
            Mouse.Move(new System.Drawing.Point((int) point.X, (int) point.Y));
            Mouse.MouseMoveSpeed = originalMouseSpeed;
            Mouse.Click(MouseButtons.Left);
            return true;
        }

        private static AutomationElement FindMessageBoxElement(BasicMessageBox messageBox, string automationId)
        {
            var childs = GetChildWindows(new IntPtr(messageBox.Properties.NativeWindowHandle));
            foreach (var child in childs)
            {
                var element = AutomationElement.FromHandle(child);
                if (element.Current.AutomationId == automationId)
                    return element;
            }
            return null;
        }

        private static IEnumerable<IntPtr> GetChildWindows(IntPtr parent)
        {
            var result = new List<IntPtr>();
            var listHandle = GCHandle.Alloc(result);
            try
            {
                var childProc = new WinApi.EnumWindowProc(EnumWindow);
                WinApi.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            var gch = GCHandle.FromIntPtr(pointer);
            var list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            list.Add(handle);
            return true;
        }
    }
}