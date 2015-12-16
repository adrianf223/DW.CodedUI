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

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;
using Cursor = System.Windows.Forms.Cursor;
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
            return Do.Action(() =>
            {
                LogPool.Append("Click.");
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
            });
        }

        /// <summary>
        /// Executes a mouse click while holding the modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(ModifierKeys modifierKeys)
        {
            return Do.Action(() =>
            {
                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Click.");
                else
                    LogPool.Append("Click with the modifier keys '{0}'.", modifierKeys);

                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
                // TODO: Release modifierKeys
            });
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse button.
        /// </summary>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(MouseButtons button)
        {
            return Do.Action(() =>
            {
                if (button == MouseButtons.None)
                    LogPool.Append("Click.");
                else
                    LogPool.Append("Click with the buttons '{0}'.", button);

                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
            });
        }

        /// <summary>
        /// Executes a mouse click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(Point screenCoordinate)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Click on the screen coordinate '{0}'.", screenCoordinate);

                Cursor.Position = screenCoordinate;
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
            });
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
            return Do.Action(() =>
            {
                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Click on the screen coordinate '{0}'.", screenCoordinate);
                else
                    LogPool.Append("Click with the modifier keys '{0}' on the screen coordinate '{1}'.", modifierKeys, screenCoordinate);

                Cursor.Position = screenCoordinate;
                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                // TODO: Release modifierKeys
            });
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
                AppendToLogPool("Click", element, button, modifierKeys, relativePosition);

                var rect = element.Properties.BoundingRectangle;

                if (rect == Rectangle.Empty)
                    throw new LoggedException("The control cannot be clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

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
            return Do.Action(() =>
            {
                LogPool.Append("Doubleclick.");

                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
            });
        }

        /// <summary>
        /// Executes a mouse double click while holding the modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(ModifierKeys modifierKeys)
        {
            return Do.Action(() =>
            {
                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Doubleclick.");
                else
                    LogPool.Append("Doubleclick with the modifier keys '{0}'.", modifierKeys);

                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
                // TODO: Release modifierKeys
            });
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse button.
        /// </summary>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(MouseButtons button)
        {
            return Do.Action(() =>
            {
                if (button == MouseButtons.None)
                    LogPool.Append("Doubleclick.");
                else
                    LogPool.Append("Doubleclick with the buttons '{0}'.", button);

                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
            });
        }

        /// <summary>
        /// Executes a mouse double click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(Point screenCoordinate)
        {
            return Do.Action(() =>
            {
                LogPool.Append("Doubleclick on the screen coordinate '{0}'.", screenCoordinate);

                Cursor.Position = screenCoordinate;
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
                WinApi.mouse_event(ToWinApiMouseButtons(MouseButtons.Left), 0, 0, 0, 0);
            });
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
            return Do.Action(() =>
            {
                if (modifierKeys == ModifierKeys.None)
                    LogPool.Append("Doubleclick on the screen coordinate '{0}'.", screenCoordinate);
                else
                    LogPool.Append("Doubleclick with the modifier keys '{0}' on the screen coordinate '{1}'.", modifierKeys, screenCoordinate);

                Cursor.Position = screenCoordinate;
                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                // TODO: Release modifierKeys

            });
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
                AppendToLogPool("DoubleClick", element, button, modifierKeys, relativePosition);

                var rect = element.Properties.BoundingRectangle;

                if (rect == Rectangle.Empty)
                    throw new LoggedException("The control cannot be double clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

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
            {
                Cursor.Position = point;
                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                // TODO: Release modifierKeys
            }
            else
            {
                var x = rect.Left + (rect.Width / 2.0);
                var y = rect.Top + (rect.Height / 2.0);

                Cursor.Position = new Point((int)x, (int)y);
                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                // TODO: Release modifierKeys
            }
        }

        private static void ClickRelative(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            Cursor.Position = relativePosition.GetPoint(element);
            // TODO: Press modifierKeys
            WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
            // TODO: Release modifierKeys
        }

        private static void DoubleClickCentered(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, Rectangle rect)
        {
            Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
            {
                Cursor.Position = point;
                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                // TODO: Release modifierKeys
            }
            else
            {
                var x = rect.Left + (rect.Width / 2.0);
                var y = rect.Top + (rect.Height / 2.0);

                Cursor.Position = new Point((int)x, (int)y);
                // TODO: Press modifierKeys
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
                // TODO: Release modifierKeys
            }
        }

        private static void DoubleClickRelative(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            Cursor.Position = relativePosition.GetPoint(element);
            // TODO: Press modifierKeys
            WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
            WinApi.mouse_event(ToWinApiMouseButtons(button), 0, 0, 0, 0);
            // TODO: Release modifierKeys
        }

        private static long ToWinApiMouseButtons(MouseButtons mouseButtons)
        {
            // TODO: Support XButton1 and XButton2, see WinApi.MouseEventDataXButtons
            if (mouseButtons.HasFlag(MouseButtons.Middle))
                return (long)(WinApi.MouseEventFlags.MIDDLEDOWN | WinApi.MouseEventFlags.MIDDLEUP);
            if (mouseButtons.HasFlag(MouseButtons.Right))
                return (long)(WinApi.MouseEventFlags.RIGHTDOWN | WinApi.MouseEventFlags.RIGHTUP);
            return (long)(WinApi.MouseEventFlags.LEFTDOWN | WinApi.MouseEventFlags.LEFTUP);
        }

        private static void AppendToLogPool(string clickKind, BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            var builder = new StringBuilder(clickKind);
            builder.Append(string.Format(" on element '{0}'", element));
            var useAnd = false;
            if (button != MouseButtons.None)
            {
                useAnd = true;
                builder.Append(string.Format(" with the buttons '{0}'", button));
            }
            if (modifierKeys != ModifierKeys.None)
            {
                if (useAnd)
                    builder.Append(string.Format(" and the modifier keys '{0}'", modifierKeys));
                else
                    builder.Append(string.Format(" with modifier keys '{0}'", modifierKeys));
            }
            if (relativePosition != null)
                builder.Append(string.Format(" at the relative position '{0}'", relativePosition));

            builder.Append(".");

            LogPool.Append(builder.ToString());
        }
    }
}
