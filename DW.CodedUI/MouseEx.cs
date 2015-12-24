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
using System.Threading;
using System.Windows.Forms;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Provides static methods for performing mouse actions in a user interface.
    /// </summary>
    public static class MouseEx
    {
        /// <summary>
        /// Executes a mouse left click.
        /// </summary>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click()
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with left mouse button.");
                WinApi.MouseEvent((long)MouseButtons.Left);
            },
            "Cannot click with the left mouse button.");
        }

        /// <summary>
        /// Executes a mouse left click while holding specific modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the left mouse button and with the modifier keys '{0}' pressed.", modifierKeys);
                KeyboardEx.PressKey(modifierKeys);
                WinApi.MouseEvent((long)MouseButtons.Left);
                KeyboardEx.ReleaseKey(modifierKeys);

            },
            string.Format("Cannot click the left mouse button with the modifier keys '{0}' pressed.", modifierKeys));
        }

        /// <summary>
        /// Executes a mouse click with specific mouse buttons.
        /// </summary>
        /// <param name="buttons">The mouse buttons which will be clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(MouseButtons buttons)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the buttons '{0}'.", buttons);
                WinApi.MouseEvent((long)buttons);
            },
            string.Format("Cannot click the mouse buttons '{0}'", buttons));
        }

        /// <summary>
        /// Executes a mouse left click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(Point screenCoordinate)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the left mouse button on the screen coordinate '{0}'.", screenCoordinate);
                Cursor.Position = screenCoordinate;
                WinApi.MouseEvent((long)MouseButtons.Left);
            },
            string.Format("Click with the left mouse button on the screen coordinate '{0}'.", screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse click at a specific position within the screen by using specific mouse buttons and holding a modifier key.
        /// </summary>
        /// <param name="buttons">The mouse buttons which will be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <param name="screenCoordinate">The point on the whole screen where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(MouseButtons buttons, ModifierKeys modifierKeys, Point screenCoordinate)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the modifier keys '{0}' on the screen coordinate '{1}'.", modifierKeys, screenCoordinate);

                Cursor.Position = screenCoordinate;
                KeyboardEx.PressKey(modifierKeys);
                WinApi.MouseEvent((long)buttons);
                KeyboardEx.ReleaseKey(modifierKeys);
            },
            string.Format("Cannot click with the modifier keys '{0}' on the screen coordinate '{1}'.", modifierKeys, screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse left click in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the left mouse button in the center of the '{0}'.", element);
                ClickCentered(element, MouseButtons.Left);
            },
            string.Format("Cannot click the BasicElement '{0}' centered with the left mouse button.", element));
        }

        /// <summary>
        /// Executes a mouse left click on a relative position inside the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions</returns>
        public static CombinableDo Click(BasicElement element, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the left mouse button at the relative position '{0}' on the element '{1}'", relativePosition, element);
                ClickRelative(element, MouseButtons.Left, relativePosition);
            },
            string.Format("Cannot click with the left mouse button at the relative position '{0}' on the element '{1}'", relativePosition, element));
        }

        /// <summary>
        /// Executes a mouse left click in the center of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the left mouse button in the center of the '{0}' with the modifier keys '{1}' pressed.", element, modifierKeys);
                ClickCentered(element, MouseButtons.Left, modifierKeys);
            },
            string.Format("Cannot click the with left mouse button in the center of the '{0}' with the modifier keys '{1}' pressed.", element, modifierKeys));
        }

        /// <summary>
        /// Executes a mouse left click at a relative position of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the left mouse button at the relative position '{0}' on the element '{1}' with the modifier keys {2} pressed.", relativePosition, element, modifierKeys);
                ClickRelative(element, MouseButtons.Left, modifierKeys, relativePosition);
            },
            string.Format("Cannot click with the left mouse button at the relative position '{0}' on the element '{1}' with the modifier keys {2} pressed.", relativePosition, element, modifierKeys));
        }

        /// <summary>
        /// Executes a mouse click with specific mouse buttons in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="buttons">The mouse buttons which will be clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons buttons)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click the BasicElement '{0}' centered with the mouse buttons '{1}'.", element, buttons);
                ClickCentered(element, buttons);
            },
            string.Format("Cannot click the BasicElement '{0}' centered with the mouse buttons '{1}'.", element, buttons));
        }

        /// <summary>
        /// Executes a mouse click with specific mouse buttons on a relative position in the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="buttons">The mouse buttons which will be clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons buttons, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the mouse buttons '{0}' at the relative position '{1}' on the element '{2}'", buttons, relativePosition, element);
                ClickRelative(element, buttons, relativePosition);
            },
            string.Format("Cannot click with the mouse buttons '{0}' at the relative position '{1}' on the element '{2}'", buttons, relativePosition, element));
        }

        /// <summary>
        /// Executes a mouse click with specific mouse buttons and hold modifier keys in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="buttons">The mouse buttons which will be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons buttons, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the mouse buttons '{0}' in the center of the '{1}' with the modifier keys '{2}' pressed.", buttons, element, modifierKeys);
                ClickCentered(element, buttons, modifierKeys);
            },
            string.Format("Cannot click with the mouse buttons '{0}' in the center of the '{1}' with the modifier keys '{2}' pressed.", buttons, element, modifierKeys));
        }

        /// <summary>
        /// Executes a mouse click with specific mouse buttons and hold modifier keys in the relative position of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="buttons">The mouse buttons which will be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons buttons, ModifierKeys modifierKeys, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the mouse buttons '{0}' in relative position '{1}' of the '{2}' with the modifier keys '{3}' pressed.", buttons, relativePosition, element, modifierKeys);
                ClickRelative(element, buttons, modifierKeys, relativePosition);
            },
            string.Format("Cannot click with the mouse buttons '{0}' in relative position '{1}' of the '{2}' with the modifier keys '{3}' pressed.", buttons, relativePosition, element, modifierKeys));
        }

        private static void ClickCentered(BasicElement element, MouseButtons buttons)
        {
            Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
            {
                Cursor.Position = point;
                WinApi.MouseEvent((long)buttons);
            }
            else
                throw new MouseClickException(string.Format("The given BasicElement '{0}' has no clickable point.", element));
        }

        private static void ClickCentered(BasicElement element, MouseButtons buttons, ModifierKeys modifierKeys)
        {
            Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
            {
                Cursor.Position = point;
                KeyboardEx.PressKey(modifierKeys);
                WinApi.MouseEvent((long)buttons);
                KeyboardEx.ReleaseKey(modifierKeys);
            }
            else
                throw new MouseClickException(string.Format("The given BasicElement '{0}' has no clickable point.", element));
        }

        private static void ClickRelative(BasicElement element, MouseButtons button, At relativePosition)
        {
            Cursor.Position = relativePosition.GetPoint(element);
            WinApi.MouseEvent((long)button);
        }

        private static void ClickRelative(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            Cursor.Position = relativePosition.GetPoint(element);
            KeyboardEx.PressKey(modifierKeys);
            WinApi.MouseEvent((long)button);
            KeyboardEx.ReleaseKey(modifierKeys);
        }

        /// <summary>
        /// Executes a mouse double left click.
        /// </summary>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick()
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the left mouse button.");
                WinApi.MouseEvent((long)MouseButtons.Left);
                WinApi.MouseEvent((long)MouseButtons.Left);
            },
            "Cannot doubleclick with the left mouse button.");
        }

        /// <summary>
        /// Executes a mouse left double click while holding the modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the left mouse button and with the modifier keys '{0}' pressed.", modifierKeys);
                KeyboardEx.PressKey(modifierKeys);
                WinApi.MouseEvent((long)MouseButtons.Left);
                WinApi.MouseEvent((long)MouseButtons.Left);
                KeyboardEx.ReleaseKey(modifierKeys);

            },
            string.Format("Cannot doubleclick the left mouse button with the modifier keys '{0}' pressed.", modifierKeys));
        }

        /// <summary>
        /// Executes a mouse double click with specific mouse buttons.
        /// </summary>
        /// <param name="buttons">The mouse buttons which will be double clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(MouseButtons buttons)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the buttons '{0}'.", buttons);
                WinApi.MouseEvent((long)buttons);
                WinApi.MouseEvent((long)buttons);
            },
            string.Format("Cannot doubleclick the mouse buttons '{0}'", buttons));
        }

        /// <summary>
        /// Executes a mouse left double click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(Point screenCoordinate)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doublclick with the left mouse button on the screen coordinate '{0}'.", screenCoordinate);
                Cursor.Position = screenCoordinate;
                WinApi.MouseEvent((long)MouseButtons.Left);
                WinApi.MouseEvent((long)MouseButtons.Left);
            },
            string.Format("Doublclick with the left mouse button on the screen coordinate '{0}'.", screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse double click at a specific position within the screen by using specific mouse buttons and holding a modifier key.
        /// </summary>
        /// <param name="buttons">The mouse buttons which will be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <param name="screenCoordinate">The point on the whole screen where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(MouseButtons buttons, ModifierKeys modifierKeys, Point screenCoordinate)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the modifier keys '{0}' on the screen coordinate '{1}'.", modifierKeys, screenCoordinate);

                Cursor.Position = screenCoordinate;
                KeyboardEx.PressKey(modifierKeys);
                WinApi.MouseEvent((long)buttons);
                WinApi.MouseEvent((long)buttons);
                KeyboardEx.ReleaseKey(modifierKeys);
            },
            string.Format("Cannot click with the modifier keys '{0}' on the screen coordinate '{1}'.", modifierKeys, screenCoordinate));
        }

        /// <summary>
        /// Executes a mouse left double click in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the left mouse button in the center of the '{0}'.", element);
                DoubleClickCentered(element, MouseButtons.Left);
            },
            string.Format("Cannot doubleclick the BasicElement '{0}' centered with the left mouse button.", element));
        }

        /// <summary>
        /// Executes a mouse left double click on a relative position inside the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions</returns>
        public static CombinableDo DoubleClick(BasicElement element, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the left mouse button at the relative position '{0}' on the element '{1}'", relativePosition, element);
                DoubleClickRelative(element, MouseButtons.Left, relativePosition);
            },
            string.Format("Cannot doubleclick with the left mouse button at the relative position '{0}' on the element '{1}'", relativePosition, element));
        }

        /// <summary>
        /// Executes a mouse left double click in the center of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the left mouse button in the center of the '{0}' with the modifier keys '{1}' pressed.", element, modifierKeys);
                DoubleClickCentered(element, MouseButtons.Left, modifierKeys);
            },
            string.Format("Cannot doubleclick the with left mouse button in the center of the '{0}' with the modifier keys '{1}' pressed.", element, modifierKeys));
        }

        /// <summary>
        /// Executes a mouse left double click at a relative position of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the left mouse button at the relative position '{0}' on the element '{1}' with the modifier keys {2} pressed.", relativePosition, element, modifierKeys);
                DoubleClickRelative(element, MouseButtons.Left, modifierKeys, relativePosition);
            },
            string.Format("Cannot doubleclick with the left mouse button at the relative position '{0}' on the element '{1}' with the modifier keys {2} pressed.", relativePosition, element, modifierKeys));
        }

        /// <summary>
        /// Executes a mouse double click with specific mouse buttons in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="buttons">The mouse buttons which will be double clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons buttons)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick the BasicElement '{0}' centered with the mouse buttons '{1}'.", element, buttons);
                DoubleClickCentered(element, buttons);
            },
            string.Format("Cannot doubleclick the BasicElement '{0}' centered with the mouse buttons '{1}'.", element, buttons));
        }

        /// <summary>
        /// Executes a mouse double click with specific mouse buttons on a relative position in the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="buttons">The mouse buttons which will be double clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons buttons, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the mouse buttons '{0}' at the relative position '{1}' on the element '{2}'", buttons, relativePosition, element);
                DoubleClickRelative(element, buttons, relativePosition);
            },
            string.Format("Cannot doubleclick with the mouse buttons '{0}' at the relative position '{1}' on the element '{2}'", buttons, relativePosition, element));
        }

        /// <summary>
        /// Executes a mouse double click with specific mouse buttons and hold modifier keys in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="buttons">The mouse buttons which will be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons buttons, ModifierKeys modifierKeys)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Click with the mouse buttons '{0}' in the center of the '{1}' with the modifier keys '{2}' pressed.", buttons, element, modifierKeys);
                DoubleClickCentered(element, buttons, modifierKeys);
            },
            string.Format("Cannot click with the mouse buttons '{0}' in the center of the '{1}' with the modifier keys '{2}' pressed.", buttons, element, modifierKeys));
        }

        /// <summary>
        /// Executes a mouse double click with specific mouse buttons and hold modifier keys in the relative position of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="buttons">The mouse buttons which will be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons buttons, ModifierKeys modifierKeys, At relativePosition)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Doubleclick with the mouse buttons '{0}' in relative position '{1}' of the '{2}' with the modifier keys '{3}' pressed.", buttons, relativePosition, element, modifierKeys);
                DoubleClickRelative(element, buttons, modifierKeys, relativePosition);
            },
            string.Format("Cannot doubleclick with the mouse buttons '{0}' in relative position '{1}' of the '{2}' with the modifier keys '{3}' pressed.", buttons, relativePosition, element, modifierKeys));
        }

        private static void DoubleClickCentered(BasicElement element, MouseButtons buttons)
        {
            Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
            {
                Cursor.Position = point;
                WinApi.MouseEvent((long)buttons);
                WinApi.MouseEvent((long)buttons);
            }
            else
                throw new MouseClickException(string.Format("The given BasicElement '{0}' has no clickable point.", element));
        }

        private static void DoubleClickCentered(BasicElement element, MouseButtons buttons, ModifierKeys modifierKeys)
        {
            Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
            {
                Cursor.Position = point;
                KeyboardEx.PressKey(modifierKeys);
                WinApi.MouseEvent((long)buttons);
                WinApi.MouseEvent((long)buttons);
                KeyboardEx.ReleaseKey(modifierKeys);
            }
            else
                throw new MouseClickException(string.Format("The given BasicElement '{0}' has no clickable point.", element));
        }

        private static void DoubleClickRelative(BasicElement element, MouseButtons button, At relativePosition)
        {
            Cursor.Position = relativePosition.GetPoint(element);
            WinApi.MouseEvent((long)button);
            WinApi.MouseEvent((long)button);
        }

        private static void DoubleClickRelative(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            Cursor.Position = relativePosition.GetPoint(element);
            KeyboardEx.PressKey(modifierKeys);
            WinApi.MouseEvent((long)button);
            WinApi.MouseEvent((long)button);
            KeyboardEx.ReleaseKey(modifierKeys);
        }

        /// <summary>
        /// Places the mouse cursor on the specific position.
        /// </summary>
        /// <param name="to">The position where the mouse cursor should be placed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Move(Position to)
        {
            return WrapIt(() =>
            {
                var position = to.GetPosition();
                LogPool.Append("Place the mouse cursor on position '{0}'.", position);
                Cursor.Position = position;
            },
            string.Format("Cannot place the mouse cursor on position '{0}'.", to.GetPosition()));
        }

        /// <summary>
        /// Moves the mouse cursor from a specific position to another one within a defined time.
        /// </summary>
        /// <param name="from">The position from where the mouse curser should start moving.</param>
        /// <param name="to">The position the mouse cursort should move to.</param>
        /// <param name="duration">The time in milliseconds the curser should move.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        /// <remarks>During the nature of timings ther always will be an additional offset to the duration.<br />
        /// E.g. when say it should run for 3 seconds, it will need about 4 seconds.<br />
        /// If you say it shoudl take about 10 seconds, it will need about 12 seconds and so on.<br />
        /// It depends the machine performance and distance so the MouseEx cannot adjust the time internally.</remarks>
        public static CombinableDo Move(Position from, Position to, uint duration)
        {
            return WrapIt(() =>
            {
                var fromPosition = from.GetPosition();
                var toPosition = to.GetPosition();
                LogPool.Append("Move the mouse cursor from position '{0}' to position '{1}' within '{2}' milliseconds.", fromPosition, toPosition, duration);

                var xSteps = GetSteps(fromPosition.X, toPosition.X, duration);
                var ySteps = GetSteps(fromPosition.Y, toPosition.Y, duration);
                for (double currentX = fromPosition.X, currentY = fromPosition.Y;
                     Math.Abs(currentX - toPosition.X) > 0.5 || Math.Abs(currentY - toPosition.Y) > 0.5;
                     currentX += xSteps, currentY += ySteps)
                {
                    Cursor.Position = new Point((int)currentX, (int)currentY);
                    Thread.Sleep(1);
                }
                Cursor.Position = toPosition;
            },
            string.Format("Cannot move the mouse cursor from position '{0}' to position '{1}' within '{2}' milliseconds.", from.GetPosition(), to.GetPosition(), duration));
        }

        private static double GetSteps(int from, int to, uint duration)
        {
            var distance = GetDistance(from, to);
            var steps = distance / duration;
            if (from > to)
                steps *= -1;
            return steps;
        }

        private static double GetDistance(int from, int to)
        {
            if (to > from)
                return to - from;
            return from - to;
        }

        /// <summary>
        /// Presses and holds the given mouse buttons.
        /// </summary>
        /// <param name="buttons">The mouse buttons to press and hold.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo PressButtons(MouseButtons buttons)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Cannot press and hold the mouse buttons '{0}'", buttons);

                switch (buttons)
                {
                    case MouseButtons.Left:
                        WinApi.MouseEvent((long)WinApi.MouseEventFlags.LEFTDOWN);
                        break;
                    case MouseButtons.Middle:
                        WinApi.MouseEvent((long)WinApi.MouseEventFlags.MIDDLEDOWN);
                        break;
                    case MouseButtons.Right:
                        WinApi.MouseEvent((long)WinApi.MouseEventFlags.RIGHTDOWN);
                        break;
                }
            },
            string.Format("Cannot press and hold the mouse buttons '{0}'", buttons));
        }

        /// <summary>
        /// Releases the given mouse buttons.
        /// </summary>
        /// <param name="buttons">The mouse buttons to release.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo ReleaseButtons(MouseButtons buttons)
        {
            return WrapIt(() =>
            {
                LogPool.Append("Cannot press and hold the mouse buttons '{0}'", buttons);

                switch (buttons)
                {
                    case MouseButtons.Left:
                        WinApi.MouseEvent((long)WinApi.MouseEventFlags.LEFTUP);
                        break;
                    case MouseButtons.Middle:
                        WinApi.MouseEvent((long)WinApi.MouseEventFlags.MIDDLEUP);
                        break;
                    case MouseButtons.Right:
                        WinApi.MouseEvent((long)WinApi.MouseEventFlags.RIGHTUP);
                        break;
                }
            },
            string.Format("Cannot press and hold the mouse buttons '{0}'", buttons));
        }

        private static CombinableDo WrapIt(Action action, string errorText)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new LoggedException(string.Format("{0} See inner exception for details.", errorText), ex);
            }

            return new CombinableDo();
        }
    }
}
