#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2016 David Wendland

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
using System.Windows.Automation;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines where the UI element search has to start from. See <see cref="DW.CodedUI.UI" />.
    /// </summary>
    public class From
    {
        private readonly BasicElement _sourceElement;

        private From(BasicElement sourceElement)
        {
            _sourceElement = sourceElement;
        }

        /// <summary>
        /// The UI element search has to start from a BasicElement.
        /// </summary>
        /// <param name="element">The element to start the UI search from.</param>
        /// <returns>Instance of the From to be used in the <see cref="DW.CodedUI.UI" /> object.</returns>
        /// <exception cref="System.ArgumentNullException">element is null.</exception>
        public static From Element(BasicElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return new From(element);
        }

        /// <summary>
        /// The UI element search has to start from the desktop.
        /// </summary>
        /// <returns>Instance of the From to be used in the <see cref="DW.CodedUI.UI" /> object.</returns>
        public static From Desktop()
        {
            var desktopElement = AutomationElement.RootElement;
            return new From(new BasicElement(desktopElement));
        }

        /// <summary>
        /// The UI element search has to start from the last found window.
        /// </summary>
        /// <returns>Instance of the From to be used in the <see cref="DW.CodedUI.UI" /> object.</returns>
        public static From LastWindow()
        {
            if (CodedUIEnvironment.LastWindow == null)
                throw new MissingWindowException(true);

            return new From(CodedUIEnvironment.LastWindow);
        }

        /// <summary>
        /// The UI element search has to start from the main window of the current application.
        /// </summary>
        /// <returns>Instance of the From to be used in the <see cref="DW.CodedUI.UI" /> object.</returns>
        /// <remarks>The current process is determined by the last found window.</remarks>
        public static From MainWindow()
        {
            if (CodedUIEnvironment.LastWindow == null)
                throw new MissingWindowException(false);

            var mainWindowHandle = CodedUIEnvironment.LastWindow.OwningProcess.MainWindowHandle;
            if (mainWindowHandle == IntPtr.Zero)
                throw new MissingWindowException(false);
            
            return new From(new BasicElement(AutomationElement.FromHandle(mainWindowHandle)));
        }

        internal BasicElement GetSourceElement()
        {
            return _sourceElement;
        }
    }
}