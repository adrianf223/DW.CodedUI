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
using System.Drawing;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace DW.CodedUI.Utilities
{
    /// <summary>
    /// Brings you possibility to get the color of from specific position.
    /// </summary>
    public static class ColorDetector
    {
        /// <summary>
        /// Gets the color of a BasicElement on a specific relative position
        /// </summary>
        /// <param name="element">The element to get the color from</param>
        /// <param name="relativePositionX">Relative position from the left side of the control</param>
        /// <param name="relativePositionY">Relative position from the top of the control</param>
        /// <returns>The System.Drawing.Color at the specific position.</returns>
        public static Color GetColor(BasicElement element, int relativePositionX = 1, int relativePositionY = 1)
        {
            LogPool.Append("Check for the color at the relative position x={0} y={1} at the element '{2}'.", relativePositionX, relativePositionY, element);

            var positionX = element.AutomationElement.Current.BoundingRectangle.Left + relativePositionX;
            var positionY = element.AutomationElement.Current.BoundingRectangle.Top + relativePositionY;

            var originalMouseSpeed = Mouse.MouseMoveSpeed;
            Mouse.MouseMoveSpeed = 10000;
            Mouse.Move(new Point(positionX, positionY));
            Mouse.MouseMoveSpeed = originalMouseSpeed;

            var hdcScreen = WinApi.CreateDC("Display", null, null, IntPtr.Zero);
            var cr = WinApi.GetPixel(hdcScreen, positionX, positionY);
            WinApi.DeleteDC(hdcScreen);

            return Color.FromArgb((cr & 0x000000FF),
                                  (cr & 0x0000FF00) >> 8,
                                  (cr & 0x00FF0000) >> 16);
        }
    }
}
