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
using System.Drawing;
using System.Windows.Forms;
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
        /// Gets the color at the center of the BasicElement.
        /// </summary>
        /// <param name="element">The BasicElement which color should be read.</param>
        /// <returns>The System.Drawing.Color at the center of the BasicElement.</returns>
        public static Color GetColor(BasicElement element)
        {
            var boundingRectangle = element.Properties.BoundingRectangle;
            return GetColor(new Point(boundingRectangle.X + boundingRectangle.Width / 2, boundingRectangle.Y + boundingRectangle.Height / 2));
        }

        /// <summary>
        /// Gets the color at the relative position inside a BasicElement.
        /// </summary>
        /// <param name="element">The BasicElement which color should be read.</param>
        /// <param name="relativePosition">The relative position inside the BasicElement.</param>
        /// <returns>The System.Drawing.Color at the relative position inside the BasicElement.</returns>
        public static Color GetColor(BasicElement element, At relativePosition)
        {
            return GetColor(relativePosition.GetPoint(element));
        }

        /// <summary>
        /// Gets the color at a specific position.
        /// </summary>
        /// <param name="point">The position where from the color should be read.</param>
        /// <returns>The System.Drawing.Color at a specific position.</returns>
        public static Color GetColor(Point point)
        {
            LogPool.Append("Check for the color at the position x={0} y={1}.", point.X, point.Y);

            var hdcScreen = WinApi.CreateDC("Display", null, null, IntPtr.Zero);
            var cr = WinApi.GetPixel(hdcScreen, point.X, point.Y);
            WinApi.DeleteDC(hdcScreen);

            return Color.FromArgb((cr & 0x000000FF),
                                  (cr & 0x0000FF00) >> 8,
                                  (cr & 0x00FF0000) >> 16);
        }

        /// <summary>
        /// Gets the color of a BasicElement on a specific relative position
        /// </summary>
        /// <param name="element">The element to get the color from</param>
        /// <param name="relativePositionX">Relative position from the left side of the control</param>
        /// <param name="relativePositionY">Relative position from the top of the control</param>
        /// <returns>The System.Drawing.Color at the specific position.</returns>
        [Obsolete("Its replaced by overloads. It forwards the call to GetColor(BasicElement, At)")]
        public static Color GetColor(BasicElement element, int relativePositionX = 1, int relativePositionY = 1)
        {
            return GetColor(element, At.TopLeft(relativePositionX, relativePositionY));
        }
    }
}
