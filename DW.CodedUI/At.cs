using DW.CodedUI.BasicElements;
using System.Drawing;

namespace DW.CodedUI
{
    /// <summary>
    /// Describes the relative position inside a control.
    /// </summary>
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

        /// <summary>
        /// Returns the relative position from the left border of the control.
        /// </summary>
        /// <param name="x">The distance from the left.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Left(double x)
        {
            return new At(x, null, null, null);
        }

        /// <summary>
        /// Returns the relative position from the top left corner of the control.
        /// </summary>
        /// <param name="x">The distance from the left.</param>
        /// <param name="y">The distance from the top.</param>
        /// <returns>Instance of the position object.</returns>
        public static At TopLeft(double x, double y)
        {
            return new At(x, y, null, null);
        }

        /// <summary>
        /// Returns the relative position from the top border of the control.
        /// </summary>
        /// <param name="y">The distance from the top.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Top(double y)
        {
            return new At(null, y, null, null);
        }

        /// <summary>
        /// Returns the relative position from the top right corner of the control.
        /// </summary>
        /// <param name="x">The distance from the right.</param>
        /// <param name="y">The distance from the top.</param>
        /// <returns>Instance of the position object.</returns>
        public static At TopRight(double x, double y)
        {
            return new At(null, y, x, null);
        }

        /// <summary>
        /// Returns the relative position from the right border or the control.
        /// </summary>
        /// <param name="x">The distance from the right.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Right(double x)
        {
            return new At(null, null, x, null);
        }

        /// <summary>
        /// Returns the relative position from the bottom right corner of the control.
        /// </summary>
        /// <param name="x">The distance from the right.</param>
        /// <param name="y">The distance from the bottom.</param>
        /// <returns>Instance of the position object.</returns>
        public static At BottomRight(double x, double y)
        {
            return new At(null, null, x, y);
        }

        /// <summary>
        /// Returns the relative position from the bottom border of the control.
        /// </summary>
        /// <param name="y">The distance from the bottom.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Bottom(double y)
        {
            return new At(null, null, null, y);
        }

        /// <summary>
        /// Returns the relative position from the bottom left corner of the control.
        /// </summary>
        /// <param name="x">The distance from the left.</param>
        /// <param name="y">The distance from the bottom.</param>
        /// <returns>Instance of the position object.</returns>
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

        private double CalculateX(Rectangle rect)
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

        private double CalculateY(Rectangle rect)
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