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

using System;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile conditions to be used by searching for UI elements. See <see cref="DW.CodedUI.UI" />.
    /// </summary>
    public abstract class By
    {
        /// <summary>
        /// Starts the search for the UI element by the automation ID. By default CompareKind.Exact will be used.
        /// </summary>
        /// <param name="automationId">The automation ID to search for.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">automationId is null, empty or just whitespaces.</exception>
        public static CombinableBy AutomationId(string automationId)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.AutomationId(automationId);
        }

        /// <summary>
        /// Starts the search for the UI element by the automation ID.
        /// </summary>
        /// <param name="automationId">The automation ID to search for.</param>
        /// <param name="comparison">The comparison kind how the automation ID will be compared.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">automationId is null, empty or just whitespaces.</exception>
        public static CombinableBy AutomationId(string automationId, CompareKind comparison)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.AutomationId(automationId, comparison);
        }

        /// <summary>
        /// Starts the search for the UI element by the name. By default CompareKind.Exact will be used.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">name is null, empty or just whitespaces.</exception>
        public static CombinableBy Name(string name)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.Name(name);
        }

        /// <summary>
        /// Starts the search for the UI element by the name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <param name="comparison">The comparison kind how the name will be compared.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">name is null, empty or just whitespaces.</exception>
        public static CombinableBy Name(string name, CompareKind comparison)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.Name(name, comparison);
        }

        /// <summary>
        /// Starts the search for the UI element by the name. By default CompareKind.Exact will be used.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">className is null, empty or just whitespaces.</exception>
        public static CombinableBy ClassName(string className)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.ClassName(className);
        }

        /// <summary>
        /// Starts the search for the UI element by the name.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <param name="comparison">The comparison kind how the class name will be compared.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">className is null, empty or just whitespaces.</exception>
        public static CombinableBy ClassName(string className, CompareKind comparison)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.ClassName(className, comparison);
        }

        /// <summary>
        /// Starts the search for the UI element which has the keyboard focus.
        /// </summary>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        [Obsolete("This method still works but it obsolete and causes memory leaks. Consier using UI.GetFocusedElement<T>")]
        public static CombinableBy Focus()
        {
            var combinableBy = new CombinableBy();
            return combinableBy.Focus();
        }

        /// <summary>
        /// Starts the search for the UI element by a custom condition.
        /// </summary>
        /// <param name="condition">The condition to be called for each item to find a matching UI element.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentNullException">className is null.</exception>
        public static CombinableBy Condition(Predicate<BasicElement> condition)
        {
            var combinableBy = new CombinableBy();
            return combinableBy.Condition(condition);
        }

        internal abstract Condition GetRawCondition();
        internal abstract string GetRawConditionDescription();
        internal abstract Predicate<BasicElement> GetCondition();
        internal abstract string GetConditionDescription();
    }
}
