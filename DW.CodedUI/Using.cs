using System;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile conditions to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public abstract class Using
    {
        /// <summary>
        /// Starts searching for windows by its title. By default the CompareKind.ContainsIgnoreCase will be use.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public static CombinableUsing Title(string title)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Title(title);
        }

        /// <summary>
        /// Starts searching for windows by its title.
        /// </summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public static CombinableUsing Title(string title, CompareKind comparison)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Title(title, comparison);
        }

        /// <summary>
        /// Starts searching for windows by its process name. By default the CompareKind.ContainsIgnoreCase will be use.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public static CombinableUsing Process(string name)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Process(name);
        }

        /// <summary>
        /// Starts searching for windows by its process name.
        /// </summary>
        /// <param name="name">The process name to search for.</param>
        /// <param name="comparison">The comparison kind how the window title will be compared.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public static CombinableUsing Process(string name, CompareKind comparison)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Process(name, comparison);
        }

        /// <summary>
        /// Starts searching for windows by a custom condition.
        /// </summary>
        /// <param name="condition">The window condition to be used for compare.</param>
        /// <returns>A combinable Using to be able to append additional conditions.</returns>
        public static CombinableUsing Condition(Predicate<BasicWindow> condition)
        {
            var combinableUsing = new CombinableUsing();
            return combinableUsing.Condition(condition);
        }

        internal abstract Predicate<BasicWindow> GetCondition();
        internal abstract string GetConditionDescription();
    }
}