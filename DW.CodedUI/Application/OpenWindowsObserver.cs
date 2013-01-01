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
using System.Linq;
using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.Application
{
    public class OpenWindowsObserver
    {
        private AutomationElement _ownerAutomationElement;

        public WpfControl Owner { get; private set; }
        public List<OpenWindow> OpenWindows { get; private set; }

        public event EventHandler<WindowEventArgs> WindowOpened;
        public event EventHandler<WindowEventArgs> WindowClosed;

        public OpenWindowsObserver()
        {
            OpenWindows = new List<OpenWindow>();
        }

        public void Begin(WpfControl control)
        {
            Owner = control;
            _ownerAutomationElement = AutomationElement.FromHandle(control.WindowHandle);
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, _ownerAutomationElement, TreeScope.Descendants, ChildWindowOpened);
        }

        public void End()
        {
            OpenWindows.Clear();
            Owner = null;
            Automation.RemoveAutomationEventHandler(WindowPattern.WindowOpenedEvent, _ownerAutomationElement, ChildWindowOpened);
        }

        public bool IsWindowOpen(string title)
        {
            return OpenWindows.Any(w => w.Title == title);
        }

        public OpenWindow GetWindow(string title)
        {
            return OpenWindows.FirstOrDefault(w => w.Title == title);
        }

        public List<OpenWindow> GetMessageBoxes()
        {
            return OpenWindows.Where(w => w.Kind == WindowKind.WindowsMessageBox).ToList();
        }

        public bool IsAnyWindowOpen()
        {
            return OpenWindows.Any();
        }

        public bool IsMessageBoxOpen()
        {
            return OpenWindows.Any(w => w.Kind == WindowKind.WindowsMessageBox);
        }

        public bool IsWPFWindowOpen()
        {
            return OpenWindows.Any(w => w.Kind == WindowKind.WPFWindow);
        }

        private void ChildWindowOpened(object sender, AutomationEventArgs e)
        {
            var senderAe = sender as AutomationElement;
            if (senderAe == null)
                return;

            if (OpenWindows.Any(w => w.NativeWindowHandle == senderAe.Current.NativeWindowHandle))
                return;

            var openedWindow = new OpenWindow(senderAe.Current);
            Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, senderAe, TreeScope.Element, (a, b) => ChildWindowClosed(openedWindow));
            OnWindowOpened(openedWindow);
            OpenWindows.Add(openedWindow);
        }

        private void ChildWindowClosed(OpenWindow window)
        {
            OnWindowClosed(window);
            OpenWindows.Remove(window);
        }

        private void OnWindowOpened(OpenWindow window)
        {
            var handler = WindowOpened;
            if (handler != null)
                handler(Owner, new WindowEventArgs(window));
        }

        private void OnWindowClosed(OpenWindow window)
        {
            var handler = WindowClosed;
            if (handler != null)
                handler(Owner, new WindowEventArgs(window));
        }
    }
}