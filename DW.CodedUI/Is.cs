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
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines which relation the window have to another window or element. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public class Is
    {
        private readonly IsCondition _condition;
        private readonly BasicWindow _window;
        private readonly BasicElement _element;

        internal Is()
        {
            _condition = IsCondition.Nothing;
        }

        internal Is(IsCondition condition)
        {
            _condition = condition;
        }

        internal Is(IsCondition condition, BasicWindow window)
        {
            _condition = condition;
            _window = window;
        }

        internal Is(IsCondition condition, BasicElement element)
        {
            _condition = condition;
            _element = element;
        }

        /// <summary>
        /// The window is a child window of the given window.
        /// </summary>
        /// <param name="parentWindow">The parent window of the window to find.</param>
        /// <returns>Instance of the Is to be used in the <see cref="DW.CodedUI.WindowFinder" /> object.</returns>
        /// <exception cref="System.ArgumentNullException">parentWindow is null.</exception>
        public static Is ChildOf(BasicWindow parentWindow)
        {
            if (parentWindow == null)
                throw new ArgumentNullException("parentWindow");

            return new Is(IsCondition.ChildOf, parentWindow);
        }

        /// <summary>
        /// The window is the parent window of the given window.
        /// </summary>
        /// <param name="childWindow">The child window of the window to find.</param>
        /// <returns>Instance of the Is to be used in the <see cref="DW.CodedUI.WindowFinder" /> object.</returns>
        /// <exception cref="System.ArgumentNullException">childWindow is null.</exception>
        public static Is ParentOf(BasicWindow childWindow)
        {
            if (childWindow == null)
                throw new ArgumentNullException("childWindow");

            return new Is(IsCondition.ParentOf, childWindow);
        }

        /// <summary>
        /// The window is the owner of the given basic element.
        /// </summary>
        /// <param name="childElement">The BasicElement contained in the window.</param>
        /// <returns>Instance of the Is to be used in the <see cref="DW.CodedUI.WindowFinder" /> object.</returns>
        /// <exception cref="System.ArgumentNullException">childElement is null.</exception>
        public static Is OwnerOf(BasicElement childElement)
        {
            if (childElement == null)
                throw new ArgumentNullException("childElement");

            return new Is(IsCondition.OwnerOf, childElement);
        }

        /// <summary>
        /// The window is the main window of the own process.
        /// </summary>
        /// <returns>Instance of the Is to be used in the <see cref="DW.CodedUI.WindowFinder" /> object.</returns>
        public static Is MainWindow()
        {
            return new Is(IsCondition.MainWindow);
        }

        internal IsCondition GetCondition()
        {
            return _condition;
        }

        internal BasicWindow GetWindow()
        {
            return _window;
        }

        internal BasicElement GetElement()
        {
            return _element;
        }
    }
}