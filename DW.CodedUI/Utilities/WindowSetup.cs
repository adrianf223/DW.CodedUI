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

using System.Drawing;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Brings a quick and easy possibility to 
    /// </summary>
    public class WindowSetup
    {
        private readonly BasicWindow _window;

        private WindowSetup(BasicWindow window)
        {
            _window = window;
        }

        /// <summary>
        /// Takes the window to do the setup on it.
        /// </summary>
        /// <param name="window">The window to be used for setup.</param>
        /// <returns>A WindowSetup to be able to append additional actions.</returns>
        public static WindowSetup Prepare(BasicWindow window)
        {
            return new WindowSetup(window);
        }

        /// <summary>
        /// Sets the new state of the window.
        /// </summary>
        /// <param name="windowState">The new state of the window.</param>
        /// <returns>A WindowSetup to be able to append additional actions.</returns>
        public WindowSetup State(WindowState windowState)
        {
            LogPool.Append("Set window state to '{0}'.", windowState);

            _window.Unsafe.SetState(windowState);
            return this;
        }

        /// <summary>
        /// Sets the new position of the window.
        /// </summary>
        /// <param name="left">The new position from the left.</param>
        /// <param name="top">The new position from the top.</param>
        /// <returns>A WindowSetup to be able to append additional actions.</returns>
        public WindowSetup Position(int left, int top)
        {
            LogPool.Append("Set window position to left {0} and top {1}.", left, top);

            _window.Unsafe.SetPosition(new Point(left, top));
            return this;
        }

        /// <summary>
        /// Sets the new size of the window.
        /// </summary>
        /// <param name="width">The new width of the window.</param>
        /// <param name="height">The new height of the window.</param>
        /// <returns>A WindowSetup to be able to append additional actions.</returns>
        public WindowSetup Size(int width, int height)
        {
            LogPool.Append("Set window size to  width {0} and height {1}.", width, height);

            _window.Unsafe.SetSize(new Size(width, height));
            return this;
        }
    }
}
