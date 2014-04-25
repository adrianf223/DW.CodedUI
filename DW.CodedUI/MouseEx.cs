﻿using System;
using System.Drawing;
using System.Windows;
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
#if TRIAL
        static MouseEx()
        {
            License1.License.Display();
        }
#endif

        /// <summary>
        /// Executes a mouse click.
        /// </summary>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click()
        {
            Mouse.Click();
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse click while holding the modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(ModifierKeys modifierKeys)
        {
            Mouse.Click(modifierKeys);
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse button.
        /// </summary>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(MouseButtons button)
        {
            Mouse.Click(button);
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(Point screenCoordinate)
        {
            Mouse.Click(screenCoordinate);
            return new CombinableDo();
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
            Mouse.Click(button, modifierKeys, screenCoordinate);
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse click in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element)
        {
            return Click(element, MouseButtons.Left, ModifierKeys.None, null);
        }

        /// <summary>
        /// Executes a mouse click on a relative position inside the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to click.</param>
        /// <returns>A combinable Do to be able to append additional actions</returns>
        public static CombinableDo Click(BasicElement element, At relativePosition)
        {
            return Click(element, MouseButtons.Left, ModifierKeys.None, relativePosition);
        }

        /// <summary>
        /// Executes a mouse click in the center of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, ModifierKeys modifierKeys)
        {
            return Click(element, MouseButtons.Left, modifierKeys, null);
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
            return Click(element, MouseButtons.Left, modifierKeys, relativePosition);
        }

        /// <summary>
        /// Executes a mouse click with a specific mouse buttons in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be clicked.</param>
        /// <param name="button">The mouse button that will be used for clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo Click(BasicElement element, MouseButtons button)
        {
            return Click(element, button, ModifierKeys.None, null);
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
            return Click(element, button, ModifierKeys.None, relativePosition);
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
            return Click(element, button, modifierKeys, null);
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
            var rect = element.Properties.BoundingRectangle;

            if (rect == Rect.Empty)
                throw new InvalidOperationException("The control cannot be clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            if (relativePosition == null)
                ClickCentered(element, button, modifierKeys, rect);
            else
                ClickRelative(element, button, modifierKeys, relativePosition);
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse double click.
        /// </summary>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick()
        {
            Mouse.DoubleClick();
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse double click while holding the modifier keys.
        /// </summary>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(ModifierKeys modifierKeys)
        {
            Mouse.DoubleClick(modifierKeys);
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse button.
        /// </summary>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(MouseButtons button)
        {
            Mouse.DoubleClick(button);
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse double click at a specific position within the screen.
        /// </summary>
        /// <param name="screenCoordinate">The point on the whole screen where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(Point screenCoordinate)
        {
            Mouse.DoubleClick(screenCoordinate);
            return new CombinableDo();
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
            Mouse.DoubleClick(button, modifierKeys, screenCoordinate);
            return new CombinableDo();
        }

        /// <summary>
        /// Executes a mouse double click in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element)
        {
            return DoubleClick(element, MouseButtons.Left, ModifierKeys.None, null);
        }

        /// <summary>
        /// Executes a mouse double click on a relative position inside the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="relativePosition">The relative position in the control where to double click.</param>
        /// <returns>A combinable Do to be able to append additional actions</returns>
        public static CombinableDo DoubleClick(BasicElement element, At relativePosition)
        {
            return DoubleClick(element, MouseButtons.Left, ModifierKeys.None, relativePosition);
        }

        /// <summary>
        /// Executes a mouse double click in the center of the given basic element with holding modifier keys.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="modifierKeys">The modifier keys to be hold while the double click is executed.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, ModifierKeys modifierKeys)
        {
            return DoubleClick(element, MouseButtons.Left, modifierKeys, null);
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
            return DoubleClick(element, MouseButtons.Left, modifierKeys, relativePosition);
        }

        /// <summary>
        /// Executes a mouse double click with a specific mouse buttons in the center of the given basic element.
        /// </summary>
        /// <param name="element">The basic element to be double clicked.</param>
        /// <param name="button">The mouse button that will be used for double clicking.</param>
        /// <returns>A combinable Do to be able to append additional actions.</returns>
        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button)
        {
            return DoubleClick(element, button, ModifierKeys.None, null);
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
            return DoubleClick(element, button, ModifierKeys.None, relativePosition);
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
            return DoubleClick(element, button, modifierKeys, null);
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
            var rect = element.Properties.BoundingRectangle;

            if (rect == Rect.Empty)
                throw new InvalidOperationException("The control cannot be double clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            if (relativePosition == null)
                DoubleClickCentered(element, button, modifierKeys, rect);
            else
                DoubleClickRelative(element, button, modifierKeys, relativePosition);
            return new CombinableDo();
        }

        private static void ClickCentered(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, Rect rect)
        {
            System.Windows.Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
                Mouse.Click(button, modifierKeys, new Point((int)point.X, (int)point.Y));
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

        private static void DoubleClickCentered(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, Rect rect)
        {
            System.Windows.Point point;
            if (element.AutomationElement.TryGetClickablePoint(out point))
                Mouse.DoubleClick(button, modifierKeys, new Point((int)point.X, (int)point.Y));
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
