using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using DW.CodedUI.BasicElements;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;

namespace DW.CodedUI
{
    public static class MouseEx
    {
        public static CombinableDo Click()
        {
            Mouse.Click();
            return new CombinableDo();
        }

        public static CombinableDo Click(ModifierKeys modifierKeys)
        {
            Mouse.Click(modifierKeys);
            return new CombinableDo();
        }

        public static CombinableDo Click(MouseButtons button)
        {
            Mouse.Click(button);
            return new CombinableDo();
        }

        public static CombinableDo Click(Point screenCoordinate)
        {
            Mouse.Click(screenCoordinate);
            return new CombinableDo();
        }

        public static CombinableDo Click(MouseButtons button, ModifierKeys modifierKeys, Point screenCoordinate)
        {
            Mouse.Click(button, modifierKeys, screenCoordinate);
            return new CombinableDo();
        }

        public static CombinableDo Click(BasicElement element)
        {
            return Click(element, MouseButtons.Left, ModifierKeys.None, null);
        }

        public static CombinableDo Click(BasicElement element, At relativePosition)
        {
            return Click(element, MouseButtons.Left, ModifierKeys.None, relativePosition);
        }

        public static CombinableDo Click(BasicElement element, ModifierKeys modifierKeys)
        {
            return Click(element, MouseButtons.Left, modifierKeys, null);
        }

        public static CombinableDo Click(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            return Click(element, MouseButtons.Left, modifierKeys, relativePosition);
        }

        public static CombinableDo Click(BasicElement element, MouseButtons button)
        {
            return Click(element, button, ModifierKeys.None, null);
        }

        public static CombinableDo Click(BasicElement element, MouseButtons button, At relativePosition)
        {
            return Click(element, button, ModifierKeys.None, relativePosition);
        }

        public static CombinableDo Click(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            return Click(element, button, modifierKeys, null);
        }

        public static CombinableDo Click(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            var rect = element.Properties.BoundingRectangle;

            if (rect == Rectangle.Empty)
                throw new InvalidOperationException("The control cannot be clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            if (relativePosition == null)
                ClickCentered(element, button, modifierKeys, rect);
            else
                ClickRelative(element, button, modifierKeys, relativePosition);
            return new CombinableDo();
        }

        public static CombinableDo DoubleClick()
        {
            Mouse.DoubleClick();
            return new CombinableDo();
        }

        public static CombinableDo DoubleClick(ModifierKeys modifierKeys)
        {
            Mouse.DoubleClick(modifierKeys);
            return new CombinableDo();
        }

        public static CombinableDo DoubleClick(MouseButtons button)
        {
            Mouse.DoubleClick(button);
            return new CombinableDo();
        }

        public static CombinableDo DoubleClick(Point screenCoordinate)
        {
            Mouse.DoubleClick(screenCoordinate);
            return new CombinableDo();
        }

        public static CombinableDo DoubleClick(MouseButtons button, ModifierKeys modifierKeys, Point screenCoordinates)
        {
            Mouse.DoubleClick(button, modifierKeys, screenCoordinates);
            return new CombinableDo();
        }

        public static CombinableDo DoubleClick(BasicElement element)
        {
            return DoubleClick(element, MouseButtons.Left, ModifierKeys.None, null);
        }

        public static CombinableDo DoubleClick(BasicElement element, At relativePosition)
        {
            return DoubleClick(element, MouseButtons.Left, ModifierKeys.None, relativePosition);
        }

        public static CombinableDo DoubleClick(BasicElement element, ModifierKeys modifierKeys)
        {
            return DoubleClick(element, MouseButtons.Left, modifierKeys, null);
        }

        public static CombinableDo DoubleClick(BasicElement element, ModifierKeys modifierKeys, At relativePosition)
        {
            return DoubleClick(element, MouseButtons.Left, modifierKeys, relativePosition);
        }

        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button)
        {
            return DoubleClick(element, button, ModifierKeys.None, null);
        }

        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button, At relativePosition)
        {
            return DoubleClick(element, button, ModifierKeys.None, relativePosition);
        }

        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button, ModifierKeys modifierKeys)
        {
            return DoubleClick(element, button, modifierKeys, null);
        }

        public static CombinableDo DoubleClick(BasicElement element, MouseButtons button, ModifierKeys modifierKeys, At relativePosition)
        {
            var rect = element.Properties.BoundingRectangle;

            if (rect == Rectangle.Empty)
                throw new InvalidOperationException("The control cannot be double clicked. It might be invisible or out of the screen. Please check the 'IsVisible' property first.");

            if (relativePosition == null)
                DoubleClickCentered(element, button, modifierKeys, rect);
            else
                DoubleClickRelative(element, button, modifierKeys, relativePosition);
            return new CombinableDo();
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
