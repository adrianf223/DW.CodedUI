#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012 David Wendland

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
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using DW.CodedUI.Application;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace DW.CodedUI.Interaction
{
    public static class MessageBoxHandler
    {
        private const string AutomationId_OK = "1";
        private const string AutomationId_Cancel = "2";
        private const string AutomationId_Yes = "6";
        private const string AutomationId_No = "7";
        private const string AutomationId_Text = "65535";

        private const int ID_Close = 0x10;

        public static void Close(OpenWindow messageBox)
        {
            SendMessage(new HandleRef(null, new IntPtr(messageBox.NativeWindowHandle)), ID_Close, IntPtr.Zero, IntPtr.Zero);
        }

        public static void CloseWithOK(OpenWindow messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_OK))
                Close(messageBox);
        }

        public static void CloseWithCancel(OpenWindow messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_Cancel))
                Close(messageBox);
        }

        public static void CloseWithYes(OpenWindow messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_Yes))
                Close(messageBox);
        }

        public static void CloseWithNo(OpenWindow messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_No))
                Close(messageBox);
        }

        public static void Close(OpenWindow messageBox, MessageBoxResult messageBoxResult)
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

        public static string GetText(OpenWindow messageBox)
        {
            var element = FindMessageBoxElement(messageBox, AutomationId_Text);
            if (element == null)
                return "";
            return element.Current.Name;
        }

        private static bool FindAndClick(OpenWindow messageBox, string automationId)
        {
            var element = FindMessageBoxElement(messageBox, automationId);
            if (element == null)
                return false;
            System.Windows.Point point = element.GetClickablePoint();
            var originalMouseSpeed = Mouse.MouseMoveSpeed;
            Mouse.MouseMoveSpeed = 10000;
            Mouse.Move(new System.Drawing.Point((int) point.X, (int) point.Y));
            Mouse.MouseMoveSpeed = originalMouseSpeed;
            Mouse.Click(MouseButtons.Left);
            return true;
        }

        private static AutomationElement FindMessageBoxElement(OpenWindow messageBox, string automationId)
        {
            var childs = GetChildWindows(new IntPtr(messageBox.NativeWindowHandle));
            foreach (var child in childs)
            {
                var element = AutomationElement.FromHandle(child);
                if (element.Current.AutomationId == automationId)
                    return element;
            }
            return null;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        private static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            var result = new List<IntPtr>();
            var listHandle = GCHandle.Alloc(result);
            try
            {
                var childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
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

        private delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    }
}