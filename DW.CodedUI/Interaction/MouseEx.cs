using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting;
using Point = System.Drawing.Point;

namespace DW.CodedUI.Interaction
{
    public static class MouseEx
    {
        public static void Click(BasicElement element)
        {
            Click(element, MouseButtons.Left, ModifierKeys.None, null);
        }

        public static void Click(BasicElement element, At relativePosition)
        {
            Click(element, MouseButtons.Left, ModifierKeys.None, relativePosition);
        }

        public static void Click(BasicElement element, ModifierKeys modifierKeys)
        {
            Click(element, MouseButtons.Left, modifierKeys, null);
        }

        public static void Click(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            Click(element, MouseButtons.Left, modifierKeys, relativePosition);
        }

        public static void Click(BasicElement element, MouseButtons button)
        {
            Click(element, button, ModifierKeys.None, null);
        }

        public static void Click(BasicElement element, MouseButtons button, At relativePosition)
        {
            Click(element, button, ModifierKeys.None, relativePosition);
        }

        public static void Click(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            Click(element, button, modifierKeys, null);
        }

        public static void Click(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            var rect = element.Properties.BoundingRectangle;

            if (rect == Rect.Empty)
                throw new InvalidOperationException("The control cannot be clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            if (relativePosition == null)
                ClickCentered(element, button, modifierKeys, rect);
            else
                ClickRelative(element, button, modifierKeys, relativePosition);
        }

        public static void DoubleClick(BasicElement element)
        {
            DoubleClick(element, MouseButtons.Left, ModifierKeys.None, null);
        }

        public static void DoubleClick(BasicElement element, At relativePosition)
        {
            DoubleClick(element, MouseButtons.Left, ModifierKeys.None, relativePosition);
        }

        public static void DoubleClick(BasicElement element, ModifierKeys modifierKeys)
        {
            DoubleClick(element, MouseButtons.Left, modifierKeys, null);
        }

        public static void DoubleClick(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            DoubleClick(element, MouseButtons.Left, modifierKeys, relativePosition);
        }

        public static void DoubleClick(BasicElement element, MouseButtons button)
        {
            DoubleClick(element, button, ModifierKeys.None, null);
        }

        public static void DoubleClick(BasicElement element, MouseButtons button, At relativePosition)
        {
            DoubleClick(element, button, ModifierKeys.None, relativePosition);
        }

        public static void DoubleClick(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            DoubleClick(element, button, modifierKeys, null);
        }

        public static void DoubleClick(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            var rect = element.Properties.BoundingRectangle;

            if (rect == Rect.Empty)
                throw new InvalidOperationException("The control cannot be double clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            if (relativePosition == null)
                DoubleClickCentered(element, button, modifierKeys, rect);
            else
                DoubleClickRelative(element, button, modifierKeys, relativePosition);
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
