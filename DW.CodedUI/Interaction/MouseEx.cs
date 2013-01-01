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
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting;
using Point = System.Drawing.Point;

namespace DW.CodedUI.Interaction
{
    /// <summary>
    /// Enhances the static Mouse class to click basic elements
    /// </summary>
    public static class MouseEx
    {
        /// <summary>
        /// Tries to click the given element
        /// </summary>
        /// <param name="element">The element to click on</param>
        public static void Click(BasicElement element)
        {
            Click(element, MouseButtons.Left, ModifierKeys.None);
        }

        /// <summary>
        /// Tries to click the given element
        /// </summary>
        /// <param name="element">The element to click on</param>
        /// <param name="modifierKeys">The modifier keys pressed until the click</param>
        public static void Click(BasicElement element, ModifierKeys modifierKeys)
        {
            Click(element, MouseButtons.Left, modifierKeys);
        }

        /// <summary>
        /// Tries to click the given element
        /// </summary>
        /// <param name="element">The element to click on</param>
        /// <param name="button">The mouse button which should be clicked</param>
        public static void Click(BasicElement element, MouseButtons button)
        {
            Click(element, button, ModifierKeys.None);
        }

        /// <summary>
        /// Tries to click the given element
        /// </summary>
        /// <param name="element">The element to click on</param>
        /// <param name="button">The mouse button which should be clicked</param>
        /// <param name="modifierKeys">The modifier keys pressed until the click</param>
        public static void Click(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            System.Windows.Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
                Mouse.Click(button, modifierKeys, new Point((int)point.X, (int)point.Y));
            else
                Click(element.Properties.BoundingRectangle, button, modifierKeys);
        }

        private static void Click(System.Windows.Rect rect, MouseButtons button, ModifierKeys modifierKeys)
        {
            if (rect == Rect.Empty)
                throw new InvalidOperationException("The control cannot be clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            var x = rect.Left + (rect.Width / 2.0);
            var y = rect.Top + (rect.Height / 2.0);
            Mouse.Click(button, modifierKeys, new Point((int)x, (int)y));
        }

        /// <summary>
        /// Tries to double click the given element
        /// </summary>
        /// <param name="element">The element to double click on</param>
        public static void DoubleClick(BasicElement element)
        {
            DoubleClick(element, MouseButtons.Left, ModifierKeys.None);
        }

        /// <summary>
        /// Tries to double click the given element
        /// </summary>
        /// <param name="element">The element to double click on</param>
        /// <param name="modifierKeys">The modifier keys pressed until the double click</param>
        public static void DoubleClick(BasicElement element, ModifierKeys modifierKeys)
        {
            DoubleClick(element, MouseButtons.Left, modifierKeys);
        }

        /// <summary>
        /// Tries to double click the given element
        /// </summary>
        /// <param name="element">The element to double click on</param>
        /// <param name="button">The mouse button which should be double clicked</param>
        public static void DoubleClick(BasicElement element, MouseButtons button)
        {
            DoubleClick(element, button, ModifierKeys.None);
        }

        /// <summary>
        /// Tries to double click the given element
        /// </summary>
        /// <param name="element">The element to double click on</param>
        /// <param name="button">The mouse button which should be double clicked</param>
        /// <param name="modifierKeys">The modifier keys pressed until the double click</param>
        public static void DoubleClick(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            System.Windows.Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
                Mouse.DoubleClick(button, modifierKeys, new Point((int)point.X, (int)point.Y));
            else
                DoubleClick(element.Properties.BoundingRectangle, button, modifierKeys);
        }

        private static void DoubleClick(Rect rect, MouseButtons button, ModifierKeys modifierKeys)
        {
            if (rect == Rect.Empty)
                throw new InvalidOperationException("The control cannot be clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            var x = rect.Left + (rect.Width / 2.0);
            var y = rect.Top + (rect.Height / 2.0);
            Mouse.DoubleClick(button, modifierKeys, new Point((int)x, (int)y));
        }
    }
}
