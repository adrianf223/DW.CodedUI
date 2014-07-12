using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Internal;

namespace DW.CodedUI
{
    /// <summary>
    /// Brings possibilities to search for UI element in the application surface started from a specific UI element.
    /// </summary>
    public static class UI
    {
        #region GetChild

        /// <summary>
        /// Searches for a given child element with the passed By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <returns>The found control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetChild<TControl>(By by, From from) where TControl : BasicElement
        {
            return StartSearchChild<TControl>(by, from, new CombinableWith());
        }

        /// <summary>
        /// Searches for a given child element with the passed By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The found control if any; otherwise an exception if it is not disabled. If it is disabled null gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetChild<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            return StartSearchChild<TControl>(by, from, with);
        }

        /// <summary>
        /// Searches for a given child element with the passed By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <returns>The found control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetChild(By by, From from)
        {
            return StartSearchChild<BasicElement>(by, from, new CombinableWith());
        }

        /// <summary>
        /// Searches for a given child element with the passed By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The found control if any; otherwise an exception if it is not disabled. If it is disabled null gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetChild(By by, From from, With with)
        {
            return StartSearchChild<BasicElement>(by, from, with);
        }

        private static TControl StartSearchChild<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            var condition = by.GetCondition();
            var sourceElement = from.GetSourceElement();

            var settings = with.GetConditions();
            var useTimeout = settings.Contains(WithCondition.Timeout);
            var timeout = with.GetTimeout();
            var assertResult = settings.Contains(WithCondition.Assert);
            var useInterval = settings.Contains(WithCondition.Interval);
            var interval = with.GetInterval();

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                var foundItem = StartSearchChild<TControl>(sourceElement, condition);
                if (foundItem != null)
                    return foundItem;

                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new UIElementNotFoundException(by, useTimeout, useInterval, interval, watch.Elapsed, false);
                    return null;
                }

                if (useInterval)
                    Thread.Sleep((int)interval);
            }
        }

        private static TControl StartSearchChild<TControl>(BasicElement sourceElement, Predicate<BasicElement> condition) where TControl : BasicElement
        {
            foreach (var child in GetChildren(sourceElement.AutomationElement))
            {
                var childBasicElement = new BasicElement(child);
                if (condition(childBasicElement))
                    return (TControl)Activator.CreateInstance(typeof(TControl), child);
                var foundItem = StartSearchChild<TControl>(childBasicElement, condition);
                if (foundItem != null)
                    return foundItem;
            }
            return null;
        }

        #endregion GetChild

        #region GetChildren

        /// <summary>
        /// Returns all child elements which passes the By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element types to search for.</typeparam>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <returns>A list of found child elements if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<TControl> GetChildren<TControl>(By by, From from) where TControl : BasicElement
        {
            return StartSearchChildren<TControl>(by, from, new CombinableWith());
        }

        /// <summary>
        /// Returns all child elements which passes the By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <typeparam name="TControl">The UI element types to search for.</typeparam>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>A list of found child elements if any; otherwise an exception if it is not disabled. If it is disabled an empty list gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<TControl> GetChildren<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            return StartSearchChildren<TControl>(by, from, with);
        }

        /// <summary>
        /// Returns all child elements which passes the By conditions. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <returns>A list of found child elements if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<BasicElement> GetChildren(By by, From from)
        {
            return StartSearchChildren<BasicElement>(by, from, new CombinableWith());
        }

        /// <summary>
        /// Returns all child elements which passes the By conditions and With settings. If not disabled With.Timeout(10000).And.Assert() gets appended.
        /// </summary>
        /// <param name="by">Provides the conditions to be used by searching the UI elements.</param>
        /// <param name="from">The source where the start of the UI element has to start from.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>A list of found child elements if any; otherwise an exception if it is not disabled. If it is disabled an empty list gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">The UI element could not be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static IEnumerable<BasicElement> GetChildren(By by, From from, With with)
        {
            return StartSearchChildren<BasicElement>(by, from, with);
        }

        private static IEnumerable<TControl> StartSearchChildren<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            var condition = by.GetCondition();
            var sourceElement = from.GetSourceElement();

            var settings = with.GetConditions();
            var useTimeout = settings.Contains(WithCondition.Timeout);
            var timeout = with.GetTimeout();
            var assertResult = settings.Contains(WithCondition.Assert);
            var useInterval = settings.Contains(WithCondition.Interval);
            var interval = with.GetInterval();

            var foundItems = new List<TControl>();
            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                foundItems.AddRange(StartSearchChildren<TControl>(sourceElement, condition));
                if (foundItems.Any())
                    return foundItems;

                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new UIElementNotFoundException(by, useTimeout, useInterval, interval, watch.Elapsed, true);
                    return foundItems;
                }

                if (useInterval)
                    Thread.Sleep((int)interval);
            }
        }

        private static IEnumerable<TControl> StartSearchChildren<TControl>(BasicElement parent, Predicate<BasicElement> condition) where TControl : BasicElement
        {
            var foundItems = new List<TControl>();
            foreach (var child in GetChildren(parent.AutomationElement))
            {
                var childBasicElement = new BasicElement(child);
                if (condition(childBasicElement))
                    foundItems.Add((TControl)Activator.CreateInstance(typeof(TControl), child));
                foundItems.AddRange(StartSearchChildren<TControl>(childBasicElement, condition));
            }
            return foundItems;
        }

        #endregion GetChildren

        #region GetParent

        /// <summary>
        /// Returns the parent element of the given source. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(From from)
        {
            return StartSearchParent<BasicElement>(By.Condition(e => true), from, new CombinableWith());
        }

        /// <summary>
        /// Returns the parent element of the given source. If not disabled With.Assert().And.Timeout(10000) gets appended.
        /// </summary>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The found parent control if any; otherwise an exception if it is not disabled. If it is disabled null gets returned.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found. (If not disabled.)</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(From from, With with)
        {
            return StartSearchParent<BasicElement>(By.Condition(e => true), from, with);
        }

        /// <summary>
        /// Returns the parent element of the given source. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(From from) where TControl : BasicElement
        {
            return StartSearchParent<TControl>(By.Condition(e => true), from, new CombinableWith());
        }

        /// <summary>
        /// Returns the parent element of the given source. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(From from, With with) where TControl : BasicElement
        {
            return StartSearchParent<TControl>(By.Condition(e => true), from, with);
        }

        /// <summary>
        /// Returns the parent element of the given source. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(By by, From from)
        {
            return StartSearchParent<BasicElement>(by, from, new CombinableWith());
        }

        /// <summary>
        /// Returns the parent element of the given source. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static BasicElement GetParent(By by, From from, With with)
        {
            return StartSearchParent<BasicElement>(by, from, with);
        }

        /// <summary>
        /// Returns the parent element of the given source. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(By by, From from) where TControl : BasicElement
        {
            return StartSearchParent<TControl>(by, from, new CombinableWith());
        }

        /// <summary>
        /// Returns the parent element of the given source. By default With.Assert().And.Timeout(10000) is in use.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to search for.</typeparam>
        /// <param name="by">Provides the conditions to be used by searching the UI element.</param>
        /// <param name="from">The source from where to start reading the parent elements.</param>
        /// <param name="with">The settings to be used while searching.</param>
        /// <returns>The available parent control if any; otherwise an exception.</returns>
        /// <exception cref="DW.CodedUI.UIElementNotFoundException">No UI element could be found.</exception>
        /// <remarks>To change the default With settings globaly consider changing the values in the <see cref="DW.CodedUI.CodedUIEnvironment" />.</remarks>
        public static TControl GetParent<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            return StartSearchParent<TControl>(by, from, with);
        }

        private static TControl StartSearchParent<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            var condition = by.GetCondition();
            var sourceElement = from.GetSourceElement();

            var settings = with.GetConditions();
            var useTimeout = settings.Contains(WithCondition.Timeout);
            var timeout = with.GetTimeout();
            var assertResult = settings.Contains(WithCondition.Assert);
            var useInterval = settings.Contains(WithCondition.Interval);
            var interval = with.GetInterval();

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                var foundItem = StartSearchParent<TControl>(sourceElement, condition);
                if (foundItem != null)
                    return foundItem;

                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new UIElementNotFoundException(by, useTimeout, useInterval, interval, watch.Elapsed, false);
                    return null;
                }

                if (useInterval)
                    Thread.Sleep((int)interval);
            }
        }

        private static TControl StartSearchParent<TControl>(BasicElement child, Predicate<BasicElement> condition) where TControl : BasicElement
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(child.AutomationElement);
            if (parent != null)
            {
                var basicElement = new BasicElement(parent);
                if (!condition(basicElement))
                    return StartSearchParent<TControl>(basicElement, condition);
                return (TControl)Activator.CreateInstance(typeof(TControl), parent);
            }

            return null;
        }

        #endregion GetParent

        #region GetFullUITree

        /// <summary>
        /// Returns a tree if information objects which shows the whole application tree.
        /// </summary>
        /// <param name="element">The parent object from which all child elements have to be read.</param>
        /// <returns>The given element as an information object wich all its childs as a tree.</returns>
        /// <remarks>This object is intended to be used in the ElementFinder.</remarks>
        public static AutomationElementInfo GetFullUITree(AutomationElement element)
        {
            var rootElementInfo = new AutomationElementInfo(element);
            Read(rootElementInfo);
            return rootElementInfo;
        }

        private static void Read(AutomationElementInfo rootElement)
        {
            foreach (var child in GetChildren(rootElement.AutomationElement))
            {
                var childElementInfo = new AutomationElementInfo(child);
                rootElement.Children.Add(childElementInfo);
                Read(childElementInfo);
            }
        }

        #endregion GetFullUITree

        #region Internals

        private static IEnumerable<AutomationElement> GetChildren(AutomationElement parent)
        {
            var children = new List<AutomationElement>();
            try
            {
                var child = TreeWalker.ControlViewWalker.GetFirstChild(parent);
                if (child != null && IsAvailable(child))
                {
                    children.Add(child);
                    while ((child = TreeWalker.ControlViewWalker.GetNextSibling(child)) != null)
                    {
                        if (!IsAvailable(child))
                            return children;

                        children.Add(child);
                    }
                }

                return children;
            }
            catch (ElementNotAvailableException)
            {
                return children;
            }
        }

        private static bool IsAvailable(AutomationElement automationElement)
        {
            try
            {
                var elementAvailbilityCheck = automationElement.Current.Name;
                return true;
            }
            catch (ElementNotAvailableException)
            {
                return false;
            }
        }

        #endregion Internals
    }
}
