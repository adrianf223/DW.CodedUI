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

using DW.CodedUI.BasicElements;
using System.Drawing;
using Point = System.Drawing.Point;

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
        private readonly string _description;

        private At(double? left, double? top, double? right, double? bottom, string description)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
            _description = description;
        }

        /// <summary>
        /// Returns the relative position from the left border of the control.
        /// </summary>
        /// <param name="x">The distance from the left.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Left(double x)
        {
            return new At(x, null, null, null, string.Format("Left x{0}", x));
        }

        /// <summary>
        /// Returns the relative position from the top left corner of the control.
        /// </summary>
        /// <param name="x">The distance from the left.</param>
        /// <param name="y">The distance from the top.</param>
        /// <returns>Instance of the position object.</returns>
        public static At TopLeft(double x, double y)
        {
            return new At(x, y, null, null, string.Format("TopLeft x{0} y{1}", x, y));
        }

        /// <summary>
        /// Returns the relative position from the top border of the control.
        /// </summary>
        /// <param name="y">The distance from the top.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Top(double y)
        {
            return new At(null, y, null, null, string.Format("Top y{0}", y));
        }

        /// <summary>
        /// Returns the relative position from the top right corner of the control.
        /// </summary>
        /// <param name="x">The distance from the right.</param>
        /// <param name="y">The distance from the top.</param>
        /// <returns>Instance of the position object.</returns>
        public static At TopRight(double x, double y)
        {
            return new At(null, y, x, null, string.Format("TopRight x{0} y{1}", x, y));
        }

        /// <summary>
        /// Returns the relative position from the right border or the control.
        /// </summary>
        /// <param name="x">The distance from the right.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Right(double x)
        {
            return new At(null, null, x, null, string.Format("Right x{0}", x));
        }

        /// <summary>
        /// Returns the relative position from the bottom right corner of the control.
        /// </summary>
        /// <param name="x">The distance from the right.</param>
        /// <param name="y">The distance from the bottom.</param>
        /// <returns>Instance of the position object.</returns>
        public static At BottomRight(double x, double y)
        {
            return new At(null, null, x, y, string.Format("BottomRight x{0} y{1}", x, y));
        }

        /// <summary>
        /// Returns the relative position from the bottom border of the control.
        /// </summary>
        /// <param name="y">The distance from the bottom.</param>
        /// <returns>Instance of the position object.</returns>
        public static At Bottom(double y)
        {
            return new At(null, null, null, y, string.Format("Bottom y{0}", y));
        }

        /// <summary>
        /// Returns the relative position from the bottom left corner of the control.
        /// </summary>
        /// <param name="x">The distance from the left.</param>
        /// <param name="y">The distance from the bottom.</param>
        /// <returns>Instance of the position object.</returns>
        public static At BottomLeft(double x, double y)
        {
            return new At(x, null, null, y, string.Format("BottomLeft x{0}", x));
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

        /// <summary>
        /// Provides a description of the relative position.
        /// </summary>
        /// <returns>A description of the relative position.</returns>
        public override string ToString()
        {
            return _description;
        }
    }
}
