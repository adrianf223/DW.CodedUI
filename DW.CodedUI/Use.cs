using System;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    /// <summary>
    /// Defines all possibile conditions to be used by searching for windows. See <see cref="DW.CodedUI.WindowFinder" />.
    /// </summary>
    public abstract class Use
    {
#if TRIAL
        static Use()
        {
            License1.LicenseChecker.Validate();
        }
#endif

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

        internal abstract Predicate<BasicWindow> GetCondition();
        internal abstract string GetConditionDescription();
    }
}