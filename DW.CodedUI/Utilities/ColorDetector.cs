using System;
using System.Drawing;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace DW.CodedUI.Utilities
{
    public static class ColorDetector
    {
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

            var clr = Color.FromArgb((cr & 0x000000FF),
                                     (cr & 0x0000FF00) >> 8,
                                     (cr & 0x00FF0000) >> 16);
            return clr;
        
        }
    }
}
