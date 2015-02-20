#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2015 David Wendland

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
using System.Diagnostics;
using System.Text;
using System.Windows.Automation;
using DW.CodedUI.Internal;

namespace DW.CodedUI.BasicElements
{
    /// <summary>
    /// Represents the base for the <see cref="DW.CodedUI.BasicElements.BasicWindow" /> and <see cref="DW.CodedUI.BasicElements.BasicMessageBox" />.
    /// </summary>
    public abstract class BasicWindowBase : BasicElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.BasicElements.BasicWindow" /> class.
        /// </summary>
        /// <param name="automationElement">The automation control.</param>
        protected BasicWindowBase(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the close button in the title bar of the normalized window.
        /// </summary>
        /// <remarks>Currently the button can be found only on English or German systems and if the <see cref="DW.CodedUI.BasicElements.BasicWindow.WindowState" /> is <see cref="DW.CodedUI.WindowState.Normal" />. If the system is another language consider using the <see cref="DW.CodedUI.UI" /> object with searching with <see cref="DW.CodedUI.By.Name(string)" />.</remarks>
        public BasicButton CloseButton
        {
            get
            {
                var closeButtonName = SystemStrings.GetString(SystemStrings.CloseButton);
                return UI.GetChild<BasicButton>(By.Name(closeButtonName), From.Element(this), With.NoTimeout());
            }
        }

        /// <summary>
        /// Gets the title bar of the window.
        /// </summary>
        public BasicElement TitleBar
        {
            get
            {
                return UI.GetChild(By.Condition(e => e.Properties.ControlType.Equals(ControlType.TitleBar)), From.Element(this), With.NoTimeout());
            }
        }

        /// <summary>
        /// Gets the title of the window.
        /// </summary>
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

        /// <summary>
        /// Gets the process the current window belongs to.
        /// </summary>
        public Process OwningProcess
        {
            get
            {
                uint processId = 0;
                WinApi.GetWindowThreadProcessId((IntPtr)AutomationElement.Current.NativeWindowHandle, out processId);
                return Process.GetProcessById((int)processId);
            }
        }

        /// <summary>
        /// Gets a value that indicates if the window can be clicked or not. This is false if the window is disabled e.g. if a modal window is opened.
        /// </summary>
        public bool CanClicked
        {
            get
            {
                var result = (int)WinApi.GetWindowLongPtr((IntPtr)AutomationElement.Current.NativeWindowHandle, (int)WinApi.WindowLongFlags.GWL_STYLE);
                var isDisabled = (result & WinApi.WS_DISABLED) == WinApi.WS_DISABLED;
                return !isDisabled;
            }
        }

        /// <summary>
        /// Gets the parent (owner) window if any.
        /// </summary>
        /// <param name="assert">Indicates if an exception has to be thrown if the window has no parent (owner).</param>
        /// <returns>The parent (owner) window if any; otherwise null.</returns>
        public BasicWindow GetParentWindow(bool assert = true)
        {
            var thisHandle = (IntPtr)Properties.NativeWindowHandle;
            var ownerHandle = WinApi.GetWindow(thisHandle, WinApi.GetWindowFlags.GW_OWNER);

            if (ownerHandle != IntPtr.Zero)
                return new BasicWindow(AutomationElement.FromHandle(ownerHandle));

            if (assert)
                throw new LoggedException(string.Format("The current window '{0}' has no parent window.", Title));
            return null;
        }

        /// <summary>
        /// Checks if the given object is the same window by comparing the window handle.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the given object is a BasicWindowBase with the same NativeWindowHandle; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            var otherWindow = obj as BasicWindowBase;
            if (otherWindow == null)
                return false;

            return Properties.NativeWindowHandle == otherWindow.Properties.NativeWindowHandle;
        }

        /// <summary>
        /// Returns a hashcode which represents this window object. The NativeWindowHandle will be used.
        /// </summary>
        /// <returns>The hashcode which represents this window.</returns>
        public override int GetHashCode()
        {
            return Properties.NativeWindowHandle.GetHashCode();
        }
    }
}
