﻿#region License
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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Brings you possibility to get the color of from specific position
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Click_OnButton_ChangesButtonColor()
    /// {
    ///     var control = WpfElementFinder.FindChildByAutomationId(_target, "Example");
    ///     var oldColor = ColorDetector.GetColor(control);
    /// 
    ///     Mouse.Click(control)
    /// 
    ///     var newColor = ColorDetector.GetColor(control);
    /// 
    ///     Assert.AreNotEqual(oldColor, newColor);
    /// }]]>
    /// </code>
    /// </example>
    public static class ColorDetector
    {
        // TODO: Obsolete

        /// <summary>
        /// Gets the color of a WPF control on a specific relative position
        /// </summary>
        /// <param name="control">The control to get the color from</param>
        /// <param name="relativePositionX">Relative X position inside the control</param>
        /// <param name="relativePositionY">Relative Y position inside the control</param>
        /// <returns></returns>
        [Obsolete("The DW.CodedUI is focus on the BasicElement. Use the other overload instead.")]
        public static Color GetColor(WpfControl control, int relativePositionX = 1, int relativePositionY = 1)
        {
            var automationElement = AutomationElement.FromHandle(control.WindowHandle);
            return GetColor(new BasicElement(automationElement), relativePositionX, relativePositionY);
        }

        /// <summary>
        /// Gets the color of a BasicElement on a specific relative position
        /// </summary>
        /// <param name="element">The element to get the color from</param>
        /// <param name="relativePositionX">Relative position from the left side of the control</param>
        /// <param name="relativePositionY">Relative position from the top of the control</param>
        /// <returns></returns>
        public static Color GetColor(BasicElement element, int relativePositionX = 1, int relativePositionY = 1)
        {
            var positionX = (int)element.AutomationElement.Current.BoundingRectangle.Left + relativePositionX;
            var positionY = (int)element.AutomationElement.Current.BoundingRectangle.Top + relativePositionY;

            var originalMouseSpeed = Mouse.MouseMoveSpeed;
            Mouse.MouseMoveSpeed = 10000;
            Mouse.Move(new Point(positionX, positionY));
            Mouse.MouseMoveSpeed = originalMouseSpeed;

            var hdcScreen = CreateDC("Display", null, null, IntPtr.Zero);
            var cr = GetPixel(hdcScreen, positionX, positionY);
            DeleteDC(hdcScreen);

            var clr = Color.FromArgb((cr & 0x000000FF),
                                     (cr & 0x0000FF00) >> 8,
                                     (cr & 0x00FF0000) >> 16);
            return clr;
        
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(string strDriver, string strDevice, string strOutput, IntPtr pData);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern int GetPixel(IntPtr hdc, int x, int y);
    }
}
