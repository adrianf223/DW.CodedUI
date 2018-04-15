#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

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

using System.Windows;
using System.Windows.Forms;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Tests.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents a specific position.
    /// </summary>
    public class Position
    {
        private readonly BasicElement _element;
        private readonly At _relativePosition;
        private readonly Point? _point;

        private Position(BasicElement element, At relativePosition, Point? point)
        {
            _element = element;
            _relativePosition = relativePosition;
            _point = point;
        }

        /// <summary>
        /// The current position.
        /// </summary>
        /// <returns>The position object to work with.</returns>
        public static Position Current()
        {
            return new Position(null, null, null);
        }

        /// <summary>
        /// Center position of the given BasicElement.
        /// </summary>
        /// <param name="element">The BasicElement which position should be taken from.</param>
        /// <returns>The position object to work with.</returns>
        public static Position Element(BasicElement element)
        {
            return new Position(element, null, null);
        }

        /// <summary>
        /// Relative position inside a specific BasicElement.
        /// </summary>
        /// <param name="element">The BasicElement which relative position should be taken from.</param>
        /// <param name="relativePosition">The relative porision inside the BasicElement.</param>
        /// <returns>The position object to work with.</returns>
        public static Position Element(BasicElement element, At relativePosition)
        {
            return new Position(element, relativePosition, null);
        }

        /// <summary>
        /// A specific point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The position object to work with.</returns>
        public static Position Point(Point point)
        {
            return new Position(null, null, point);
        }

        internal Point GetPosition()
        {
            if (_point != null)
                return _point.Value;
            if (_element != null && _relativePosition == null)
            {
                Point point;
                _element.AutomationElement.TryGetClickablePoint(out point);
                return point;
            }
            if (_element != null && _relativePosition != null)
                return _relativePosition.GetPoint(_element);

            return Cursor.Position.ToWindowsPoint();
        }
    }
}