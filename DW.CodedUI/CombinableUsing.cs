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
    public class CombinableUsing : Using
    {
        internal CombinableUsing()
        {
            _conditions = new List<Predicate<BasicWindow>>();
            _conditionDescriptions = new List<string>();
        }

        private readonly List<Predicate<BasicWindow>> _conditions;
        private readonly List<string> _conditionDescriptions;
        private bool _isAndCondition;

        /// <summary>
        /// Gets the instance of a combinable Using to be able to append additional conditions. By using this all conditions has to match.
        /// </summary>
        /// <remarks>If 'And' and 'Or' is in use, all conditions will be combined by the last used.</remarks>
        public CombinableUsing And
        {
            get
            {
                _isAndCondition = true;
                return this;
            }
        }

        /// <summary>
        /// Gets the instance of a combinable Using to be able to append additional conditions. By using this just one of the condition has to match.
        /// </summary>
        /// <remarks>If 'And' and 'Or' is in use, all conditions will be combined by the last used.</remarks>
        public CombinableUsing Or
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
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public new CombinableUsing Title(string title)
        {
            return Title(title, CompareKind.ContainsIgnoreCase);
        }

        /// <summary>
        /// Starts searching for windows by its title.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public new CombinableUsing Title(string title, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.Title, title, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.Title, \"{0}\", {1})", title, comparison));

            return this;
        }

        /// <summary>
        /// Starts searching for windows by its process name. By default the CompareKind.ContainsIgnoreCase will be use.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public new CombinableUsing Process(string name)
        {
            return Process(name, CompareKind.ContainsIgnoreCase);
        }

        /// <summary>
        /// Starts searching for windows by its process name.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public new CombinableUsing Process(string name, CompareKind comparison)
        {
            _conditions.Add(window => StringExtensions.Match(window.OwningProcess.ProcessName, name, comparison));
            _conditionDescriptions.Add(string.Format("StringExtensions.Match(window.OwningProcess.ProcessName, \"{0}\", {1})", name, comparison));
            return this;
        }

        /// <summary>
        /// Starts searching for windows by a custom condition.
        /// </summary>
        /// <param name="condition">The window condition to be used for compare.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public new CombinableUsing Condition(Predicate<BasicWindow> condition)
        {
            _conditions.Add(condition);
            _conditionDescriptions.Add("condition(element)");
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