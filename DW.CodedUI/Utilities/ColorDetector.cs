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
            var positionX = (int)element.AutomationElement.Current.BoundingRectangle.Left + relativePositionX;
            var positionY = (int)element.AutomationElement.Current.BoundingRectangle.Top + relativePositionY;

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
