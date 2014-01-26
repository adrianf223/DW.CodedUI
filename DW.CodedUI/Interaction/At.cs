using System.Windows;
using DW.CodedUI.BasicElements;
using Point = System.Drawing.Point;

namespace DW.CodedUI.Interaction
{
    public class At
    {
        private double? _left;
        private double? _top;
        private double? _right;
        private double? _bottom;

        private At(double? left, double? top, double? right, double? bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }

        public static At Left(double x)
        {
            return new At(x, null, null, null);
        }

        public static At TopLeft(double x, double y)
        {
            return new At(x, y, null, null);
        }

        public static At Top(double y)
        {
            return new At(null, y, null, null);
        }

        public static At TopRight(double x, double y)
        {
            return new At(null, y, x, null);
        }

        public static At Right(double x)
        {
            return new At(null, null, x, null);
        }

        public static At BottomRight(double x, double y)
        {
            return new At(null, null, x, y);
        }

        public static At Bottom(double y)
        {
            return new At(null, null, null, y);
        }

        public static At BottomLeft(double x, double y)
        {
            return new At(x, null, null, y);
        }

        internal Point GetPoint(BasicElement element)
        {
            var rect = element.AutomationElement.Current.BoundingRectangle;

            var x = CalculateX(rect);
            var y = CalculateY(rect);

            return new Point((int)x, (int)y);
        }

        private double CalculateX(Rect rect)
        {
            var x = 0.0;
            if (_left == null && _right == null)
                x = rect.Width / 2.0;
            if (_left != null)
                x = _left.Value;
            if (_right != null)
                x = rect.Width - _right.Value;
            return x + rect.Left;
        }

        private double CalculateY(Rect rect)
        {
            var y = 0.0;
            if (_top == null && _bottom == null)
                y = rect.Height / 2.0;
            if (_top != null)
                y = _top.Value;
            if (_bottom != null)
                y = rect.Height - _bottom.Value;
            return y + rect.Top;
        }
    }
}