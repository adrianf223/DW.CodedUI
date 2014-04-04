using System;
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

        internal abstract Predicate<BasicElement> GetCondition();
        internal abstract string GetConditionDescription();
    }
}
