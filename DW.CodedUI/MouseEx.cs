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
using System.Windows.Forms;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using Point = System.Drawing.Point;

namespace DW.CodedUI
{
    /// <summary>
    /// Provides static methods for performing mouse actions in a user interface.
    /// </summary>
    public static class MouseEx
    {
        /// <summary>
        /// Executes a mouse click.
        /// </summary>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click()
        {
            return Do.Action(Mouse.Click);
        }

        /// <summary>
        /// Executes a mouse click while holding the modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(ModifierKeys modifierKeys)
        {
            return Do.Action(() => Mouse.Click(modifierKeys));
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse button.
        /// </summary>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(MouseButtons button)
        {
            return Do.Action(() => Mouse.Click(button));
        }

        /// <summary>
        /// Executes a mouse click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(Point screenCoordinate)
        {
            return Do.Action(() => Mouse.Click(screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse click at a specific position within the screen by using a specific mouse button and holding a modifier key.
        /// </summary>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <param name="screenCoordinate">The point on the whole screen where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(MouseButtons button, ModifierKeys modifierKeys, Point screenCoordinate)
        {
            return Do.Action(() => Mouse.Click(button, modifierKeys, screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse click in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element)
        {
            return Do.Action(() => Click(element, MouseButtons.Left, ModifierKeys.None, null));
        }

        /// <summary>
        /// Executes a mouse click on a relative position inside the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions</returns>
        public static CombinableDo Click(BasicElement element, At relativePosition)
        {
            return Do.Action(() => Click(element, MouseButtons.Left, ModifierKeys.None, relativePosition));
        }

        /// <summary>
        /// Executes a mouse click in the center of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, ModifierKeys modifierKeys)
        {
            return Do.Action(() => Click(element, MouseButtons.Left, modifierKeys, null));
        }

        /// <summary>
        /// Executes a mouse click at a relative position of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            return Do.Action(() => Click(element, MouseButtons.Left, modifierKeys, relativePosition));
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse buttons in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons button)
        {
            return Do.Action(() => Click(element, button, ModifierKeys.None, null));
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse buttons on a relative position in the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons button, At relativePosition)
        {
            return Do.Action(() => Click(element, button, ModifierKeys.None, relativePosition));
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse buttons and hold modifier keys in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            return Do.Action(() => Click(element, button, modifierKeys, null));
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse button and hold modifier keys in the relative position of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            return Do.Action(() =>
            {
                var rect = element.Properties.BoundingRectangle;

                if (rect == Rectangle.Empty)
                    throw new InvalidOperationException("The control cannot be clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

                if (relativePosition == null)
                    ClickCentered(element, button, modifierKeys, rect);
                else
                    ClickRelative(element, button, modifierKeys, relativePosition);

            });
        }

        /// <summary>
        /// Executes a mouse double click.
        /// </summary>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick()
        {
            return Do.Action(Mouse.DoubleClick);
        }

        /// <summary>
        /// Executes a mouse double click while holding the modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(ModifierKeys modifierKeys)
        {
            return Do.Action(() => Mouse.DoubleClick(modifierKeys));
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse button.
        /// </summary>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(MouseButtons button)
        {
            return Do.Action(() => Mouse.DoubleClick(button));
        }

        /// <summary>
        /// Executes a mouse double click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(Point screenCoordinate)
        {
            return Do.Action(() => Mouse.DoubleClick(screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse double click at a specific position within the screen by using a specific mouse button and holding a modifier key.
        /// </summary>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <param name="screenCoordinate">The point on the whole screen where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(MouseButtons button, ModifierKeys modifierKeys, Point screenCoordinate)
        {
            return Do.Action(() => Mouse.DoubleClick(button, modifierKeys, screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse double click in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element)
        {
            return Do.Action(() => DoubleClick(element, MouseButtons.Left, ModifierKeys.None, null));
        }

        /// <summary>
        /// Executes a mouse double click on a relative position inside the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions</returns>
        public static CombinableDo DoubleClick(BasicElement element, At relativePosition)
        {
            return Do.Action(() => DoubleClick(element, MouseButtons.Left, ModifierKeys.None, relativePosition));
        }

        /// <summary>
        /// Executes a mouse double click in the center of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, ModifierKeys modifierKeys)
        {
            return Do.Action(() => DoubleClick(element, MouseButtons.Left, modifierKeys, null));
        }

        /// <summary>
        /// Executes a mouse double click at a relative position of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            return Do.Action(() => DoubleClick(element, MouseButtons.Left, modifierKeys, relativePosition));
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse buttons in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button)
        {
            return Do.Action(() => DoubleClick(element, button, ModifierKeys.None, null));
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse buttons on a relative position in the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button, At relativePosition)
        {
            return Do.Action(() => DoubleClick(element, button, ModifierKeys.None, relativePosition));
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse buttons and hold modifier keys in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            return Do.Action(() => DoubleClick(element, button, modifierKeys, null));
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse button and hold modifier keys in the relative position of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            return Do.Action(() =>
            {
                var rect = element.Properties.BoundingRectangle;

                if (rect == Rectangle.Empty)
                    throw new InvalidOperationException("The control cannot be double clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

                if (relativePosition == null)
                    DoubleClickCentered(element, button, modifierKeys, rect);
                else
                    DoubleClickRelative(element, button, modifierKeys, relativePosition);
            });
        }

        private static void ClickCentered(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, Rectangle rect)
        {
            Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
                Mouse.Click(button, modifierKeys, point);
            else
            {
                var x = rect.Left + (rect.Width / 2.0);
                var y = rect.Top + (rect.Height / 2.0);
                Mouse.Click(button, modifierKeys, new Point((int)x, (int)y));
            }
        }

        private static void ClickRelative(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            var position = relativePosition.GetPoint(element);
            Mouse.Click(button, modifierKeys, position);
        }

        private static void DoubleClickCentered(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, Rectangle rect)
        {
            Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
                Mouse.DoubleClick(button, modifierKeys, point);
            else
            {
                var x = rect.Left + (rect.Width / 2.0);
                var y = rect.Top + (rect.Height / 2.0);
                Mouse.DoubleClick(button, modifierKeys, new Point((int)x, (int)y));
            }
        }

        private static void DoubleClickRelative(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            var position = relativePosition.GetPoint(element);
            Mouse.DoubleClick(button, modifierKeys, position);
        }
    }
}
