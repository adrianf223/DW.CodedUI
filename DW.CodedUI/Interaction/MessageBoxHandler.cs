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
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace DW.CodedUI.Interaction
{
    /// <summary>
    /// Provides possibilities to close MessageBoxes
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Method_TestCondition_ExpectedResult()
    /// {
    ///     var messageBox = MessageBoxFinder.FindFirstAvailable();
    /// 
    ///     if (messageBox != null)
    ///         MessageBoxHandler.CloseWithCancel(messageBox);
    /// }]]>
    /// </code>
    /// </example>
    public static class MessageBoxHandler
    {
        private const string AutomationId_OK = "1";
        private const string AutomationId_Cancel = "2";
        private const string AutomationId_Yes = "6";
        private const string AutomationId_No = "7";
        private const string AutomationId_Text = "65535";

        private const int ID_Close = 0x10;

        /// <summary>
        /// Sends just "Close" to the MessageBox
        /// </summary>
        /// <param name="messageBox">The recipient MessageBox</param>
        public static void Close(BasicMessageBox messageBox)
        {
            SendMessage(new HandleRef(null, new IntPtr(messageBox.Properties.NativeWindowHandle)), ID_Close, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Tries to find the OK Button on the MessageBox and presses it.
        /// </summary>
        /// <param name="messageBox">The recipient MessageBox</param>
        /// <remarks>If the OK is not found it tries to close the MessageBox jst with "Close"</remarks>
        public static void CloseWithOK(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_OK))
                Close(messageBox);
        }

        /// <summary>
        /// Tries to find the Cancel Button on the MessageBox and presses it.
        /// </summary>
        /// <param name="messageBox">The recipient MessageBox</param>
        /// <remarks>If the Cancel is not found it tries to close the MessageBox jst with "Close"</remarks>
        public static void CloseWithCancel(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_Cancel))
                Close(messageBox);
        }

        /// <summary>
        /// Tries to find the Yes Button on the MessageBox and presses it.
        /// </summary>
        /// <param name="messageBox">The recipient MessageBox</param>
        /// <remarks>If the Yes is not found it tries to close the MessageBox jst with "Close"</remarks>
        public static void CloseWithYes(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_Yes))
                Close(messageBox);
        }

        /// <summary>
        /// Tries to find the No Button on the MessageBox and presses it.
        /// </summary>
        /// <param name="messageBox">The recipient MessageBox</param>
        /// <remarks>If the No is not found it tries to close the MessageBox jst with "Close"</remarks>
        public static void CloseWithNo(BasicMessageBox messageBox)
        {
            if (!FindAndClick(messageBox, AutomationId_No))
                Close(messageBox);
        }

        /// <summary>
        /// Tries to close the MessageBox with the given retult
        /// </summary>
        /// <param name="messageBox">The recipient MessageBox</param>
        /// <param name="messageBoxResult">The result the MessageBox should have</param>
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

        /// <summary>
        /// Returns the displayed text in the MessageBox
        /// </summary>
        /// <param name="messageBox">The recipient MessageBox</param>
        /// <returns>The text written in the MessageBox</returns>
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

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        private static IEnumerable<IntPtr> GetChildWindows(IntPtr parent)
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