#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2014 David Wendland

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

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile conditions to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public abstract class Use
    {
        /// <summary>
        /// Starts searching for windows by its title. By default the CompareKind.ContainsIgnoreCase will be use.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public static CombinableUse Title(string title)
        {
            var combinableUse = new CombinableUse();
            return combinableUse.Title(title);
        }

        /// <summary>
        /// Starts searching for windows by its title.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public static CombinableUse Title(string title, CompareKind comparison)
        {
            var combinableUse = new CombinableUse();
            return combinableUse.Title(title, comparison);
        }

        /// <summary>
        /// Starts searching for windows by its process name. By default the CompareKind.ContainsIgnoreCase will be use.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public static CombinableUse Process(string name)
        {
            var combinableUse = new CombinableUse();
            return combinableUse.Process(name);
        }

        /// <summary>
        /// Starts searching for windows by its process name.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public static CombinableUse Process(string name, CompareKind comparison)
        {
            var combinableUse = new CombinableUse();
            return combinableUse.Process(name, comparison);
        }

        /// <summary>
        /// Starts searching for windows by a custom condition.
        /// </summary>
        /// <param name="condition">The window condition to be used for compare.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public static CombinableUse Condition(Predicate<BasicWindow> condition)
        {
            var combinableUse = new CombinableUse();
            return combinableUse.Condition(condition);
        }

        /// <summary>
        /// Starts searching for a window which contains the given element.
        /// </summary>
        /// <param name="element">The element to start the window search for.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public static CombinableUse ContainingElement(BasicElement element)
        {
            var combinableUse = new CombinableUse();
            return combinableUse.ContainingElement(element);
        }

        internal abstract Predicate<BasicWindow> GetCondition();
        internal abstract string GetConditionDescription();
    }
}