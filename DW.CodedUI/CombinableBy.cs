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

using System;
using System.Collections.Generic;
using System.Linq;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile conditions to be used by searching for UI elements. See <see cref="DW.CodedUI.UI" />.
    /// </summary>
    public class CombinableBy : By
    {
        internal CombinableBy()
        {
            _conditions = new List<Predicate<BasicElement>>();
            _conditionDescriptions = new List<string>();
            _isAndCondition = true;
        }

        /// <summary>
        /// Gets the instance of a combinable By to be able to append additional conditions. By using this all conditions has to match.
        /// </summary>
        /// <remarks>If 'And' and 'Or' is in use, all conditions will be combined by the last used.</remarks>
        public CombinableBy And
        {
            get
            {
                _isAndCondition = true;
                return this;
            }
        }

        /// <summary>
        /// Gets the instance of a combinable By to be able to append additional conditions. By using this just one of the condition has to match.
        /// </summary>
        /// <remarks>If 'And' and 'Or' is in use, all conditions will be combined by the last used.</remarks>
        public CombinableBy Or
        {
            get
            {
                _isAndCondition = false;
                return this;
            }
        }

        private readonly List<Predicate<BasicElement>> _conditions;
        private readonly List<string> _conditionDescriptions;
        private bool _isAndCondition;

        /// <summary>
        /// Starts the search for the UI element by the automation ID. By default CompareKind.Exact will be used.
        /// </summary>
        /// <param name="automationId">The automation ID to search for.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">automationId is null, empty or just whitespaces.</exception>
        public new CombinableBy AutomationId(string automationId)
        {
            return AutomationId(automationId, CompareKind.Exact);
        }

        /// <summary>
        /// Starts the search for the UI element by the automation ID.
        /// </summary>
        /// <param name="automationId">The automation ID to search for.</param>
        /// <param name="comparison">The comparison kind how the automation ID will be compared.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">automationId is null, empty or just whitespaces.</exception>
        public new CombinableBy AutomationId(string automationId, CompareKind comparison)
        {
            if (string.IsNullOrWhiteSpace(automationId))
                throw new ArgumentException("automationId is null, empty or just whitespaces.");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return StringExtensions.Match(element.Properties.AutomationId, automationId, comparison);
            });
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(element.Properties.AutomationId, \"{0}\", CompareKind.{1})", automationId, comparison));
            return this;
        }

        /// <summary>
        /// Starts the search for the UI element by the name. By default CompareKind.Exact will be used.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">name is null, empty or just whitespaces.</exception>
        public new CombinableBy Name(string name)
        {
            return Name(name, CompareKind.Exact);
        }

        /// <summary>
        /// Starts the search for the UI element by the name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <param name="comparison">The comparison kind how the name will be compared.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">name is null, empty or just whitespaces.</exception>
        public new CombinableBy Name(string name, CompareKind comparison)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is null, empty or just whitespaces.");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return StringExtensions.Match(element.Properties.Name, name, comparison);
            });
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(element.Properties.Name, \"{0}\", CompareKind.{1})", name, comparison));
            return this;
        }

        /// <summary>
        /// Starts the search for the UI element by the name. By default CompareKind.Exact will be used.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">className is null, empty or just whitespaces.</exception>
        public new CombinableBy ClassName(string className)
        {
            return ClassName(className, CompareKind.Exact);
        }

        /// <summary>
        /// Starts the search for the UI element by the name.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <param name="comparison">The comparison kind how the class name will be compared.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentException">className is null, empty or just whitespaces.</exception>
        public new CombinableBy ClassName(string className, CompareKind comparison)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("className is null, empty or just whitespaces.");

            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return StringExtensions.Match(element.Properties.ClassName, className, comparison);
            });
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(element.Properties.ClassName, \"{0}\", CompareKind.{1})", className, comparison));
            return this;
        }

        /// <summary>
        /// Starts the search for the UI element which has the keyboard focus.
        /// </summary>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        public new CombinableBy Focus()
        {
            _conditions.Add(element =>
            {
                if (element == null)
                    return false;
                return element.Properties.HasKeyboardFocus;
            });
            _conditionDescriptions.Add(string.Format("element.Properties.HasKeyboardFocus == true"));
            return this;
        }

        /// <summary>
        /// Starts the search for the UI element by a custom condition.
        /// </summary>
        /// <param name="condition">The condition to be called for each item to find a matching UI element.</param>
        /// <returns>A combinable By to be able to append additional conditions.</returns>
        /// <exception cref="System.ArgumentNullException">className is null.</exception>
        public new CombinableBy Condition(Predicate<BasicElement> condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition");

            _conditions.Add(condition);
            _conditionDescriptions.Add("condition(element)");
            return this;
        }

        internal override Predicate<BasicElement> GetCondition()
        {
            if (_isAndCondition)
                return element => _conditions.All(e => e(element));
            return element => _conditions.Any(e => e(element));
        }

        internal override string GetConditionDescription()
        {
            var andSeparator = Environment.NewLine + " AND " + Environment.NewLine;
            var orSeparator = Environment.NewLine + " OR " + Environment.NewLine;
            return string.Join(_isAndCondition ? andSeparator : orSeparator, _conditionDescriptions);
        }
    }
}
