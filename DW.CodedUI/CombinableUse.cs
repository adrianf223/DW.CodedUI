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
using System.Collections.Generic;
using System.Linq;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile conditions to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public class CombinableUse : Use
    {
        internal CombinableUse()
        {
            _conditions = new List<Predicate<BasicWindow>>();
            _conditionDescriptions = new List<string>();
        }

        private readonly List<Predicate<BasicWindow>> _conditions;
        private readonly List<string> _conditionDescriptions;
        private bool _isAndCondition;

        /// <summary>
        /// Gets the instance of a combinable Use to be able to append additional conditions. By using this all conditions has to match.
        /// </summary>
        /// <remarks>If 'And' and 'Or' is in use, all conditions will be combined by the last used.</remarks>
        public CombinableUse And
        {
            get
            {
                _isAndCondition = true;
                return this;
            }
        }

        /// <summary>
        /// Gets the instance of a combinable Use to be able to append additional conditions. By using this just one of the condition has to match.
        /// </summary>
        /// <remarks>If 'And' and 'Or' is in use, all conditions will be combined by the last used.</remarks>
        public CombinableUse Or
        {
            get
            {
                _isAndCondition = false;
                return this;
            }
        }

        /// <summary>
        /// Starts searching for windows by its title. By default the CompareKind.ContainsIgnoreCase will be use.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse Title(string title)
        {
            return Title(title, CompareKind.ContainsIgnoreCase);
        }

        /// <summary>
        /// Starts searching for windows by its title.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse Title(string title, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.Title, title, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.Title, \"{0}\", CompareKind.{1})", title, comparison));

            return this;
        }

        /// <summary>
        /// Starts searching for windows by its process name. By default the CompareKind.ContainsIgnoreCase will be use.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse Process(string name)
        {
            return Process(name, CompareKind.ContainsIgnoreCase);
        }

        /// <summary>
        /// Starts searching for windows by its process name.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse Process(string name, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.OwningProcess.ProcessName, name, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.OwningProcess.ProcessName, \"{0}\", CompareKind.{1})", name, comparison));
            return this;
        }

        /// <summary>
        /// Starts searching for a window by its automation ID. By default CompareKind.Exact will be used.
        /// </summary>
        /// <param name="automationId">The automation ID to search for.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse AutomationId(string automationId)
        {
            return AutomationId(automationId, CompareKind.Exact);
        }

        /// <summary>
        /// Starts searching for a window by its automation ID.
        /// </summary>
        /// <param name="automationId">The automation ID to search for.</param>
        /// <param name="comparison">The comparison kind how the automation ID will be compared.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse AutomationId(string automationId, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.AutomationId, automationId, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.AutomationId, \"{0}\", CompareKind.{1})", automationId, comparison));
            return this;
        }

        /// <summary>
        /// Starts searching for windows by a custom condition.
        /// </summary>
        /// <param name="condition">The window condition to be used for compare.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse Condition(Predicate<BasicWindow> condition)
        {
            _conditions.Add(condition);
            _conditionDescriptions.Add("condition(element)");
            return this;
        }

        /// <summary>
        /// Starts searching for a window which contains the given element.
        /// </summary>
        /// <param name="element">The element to start the window search for.</param>
        /// <returns>A combinable Use to be able to append additional conditions.</returns>
        public new CombinableUse ContainingElement(BasicElement element)
        {
            var condition = new Predicate<BasicWindow>(w => WindowFinder.IsOwnerOf(w, element));
            _conditions.Add(condition);
            _conditionDescriptions.Add("WindowFinder.IsOwnerOf(window, element)");
            return this;
        }

        internal override Predicate<BasicWindow> GetCondition()
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