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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using DW.CodedUI.BasicElements.Data;
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
            var rawCondition = by.GetRawCondition();
            var sourceElement = from.GetSourceElement();

            var settings = with.GetConditions();
            var useTimeout = settings.Contains(WithCondition.Timeout);
            var timeout = with.GetTimeout();
            var assertResult = settings.Contains(WithCondition.Assert);
            var useInterval = settings.Contains(WithCondition.Interval);
            var interval = with.GetInterval();
            var needsToBeReady = settings.Contains(WithCondition.ReadyToUse);

            if (CodedUIEnvironment.LoggerSettings.ShortLogging)
                LogPool.Append("Search for UI element. {0}", by.GetConditionDescription());
            else
                LogPool.Append("Search for UI element down from '{0}'. {1}", sourceElement, MessageBuilder.BuildMessage(by, useTimeout, useInterval, timeout, interval));

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                var foundItem = StartSearchChild<TControl>(sourceElement, condition, rawCondition);
                if (foundItem != null)
                {
                    if (!needsToBeReady)
                    {
                        LogPool.Append("UI element '{0}' found.", foundItem);
                        return foundItem;
                    }

                    return ReturnIfReady(assertResult, by, useTimeout, useInterval, timeout, watch, interval, false, foundItem);
                }

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

        private static TControl StartSearchChild<TControl>(BasicElement sourceElement, Predicate<BasicElement> condition, Condition rawCondition) where TControl : BasicElement
        {
            if (rawCondition == null)
                return StartSearchChild<TControl>(sourceElement, condition);
            return StartSearchChild<TControl>(sourceElement, rawCondition);
        }

        private static TControl StartSearchChild<TControl>(BasicElement sourceElement, Condition rawCondition) where TControl : BasicElement
        {
            var foundItem = sourceElement.AutomationElement.FindFirst(TreeScope.Descendants, rawCondition);
            if (foundItem == null)
                return null;
            return (TControl)Activator.CreateInstance(typeof(TControl), foundItem);
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
            var rawCondition = by.GetRawCondition();
            var sourceElement = from.GetSourceElement();

            var settings = with.GetConditions();
            var useTimeout = settings.Contains(WithCondition.Timeout);
            var timeout = with.GetTimeout();
            var assertResult = settings.Contains(WithCondition.Assert);
            var useInterval = settings.Contains(WithCondition.Interval);
            var interval = with.GetInterval();
            var needsToBeReady = settings.Contains(WithCondition.ReadyToUse);

            if (CodedUIEnvironment.LoggerSettings.ShortLogging)
                LogPool.Append("Search for UI elements. {0}", by.GetConditionDescription());
            else
                LogPool.Append("Search for UI elements down from '{0}'. {1}", sourceElement, MessageBuilder.BuildMessage(by, useTimeout, useInterval, timeout, interval));

            var foundItems = new List<TControl>();
            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                foundItems.AddRange(StartSearchChildren<TControl>(sourceElement, condition, rawCondition));
                if (foundItems.Any())
                {
                    if (!needsToBeReady)
                    {
                        LogPool.Append("{0} element(s) found.", foundItems.Count);
                        return foundItems;
                    }

                    for (var i = 0; i < foundItems.Count; ++i)
                    {
                        var foundItem = foundItems[i];
                        var readyElement = ReturnIfReady(assertResult, by, useTimeout, useInterval, timeout, watch, interval, true, foundItem);
                        if (readyElement == null)
                        {
                            foundItems.RemoveAt(i);
                            --i;
                        }
                    }
                }

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

        private static IEnumerable<TControl> StartSearchChildren<TControl>(BasicElement parent, Predicate<BasicElement> condition, Condition rawCondition) where TControl : BasicElement
        {
            if (rawCondition == null)
                return StartSearchChildren<TControl>(parent, condition);
            return StartSearchChildren<TControl>(parent, rawCondition);
        }

        private static IEnumerable<TControl> StartSearchChildren<TControl>(BasicElement parent, Condition rawCondition) where TControl : BasicElement
        {
            var foundItems = new List<TControl>();
            var automationElements = parent.AutomationElement.FindAll(TreeScope.Descendants, rawCondition);
            foreach (AutomationElement foundItem in automationElements)
                foundItems.Add((TControl)Activator.CreateInstance(typeof(TControl), foundItem));
            return foundItems;
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
            var needsToBeReady = settings.Contains(WithCondition.ReadyToUse);

            if (CodedUIEnvironment.LoggerSettings.ShortLogging)
                LogPool.Append("Search for parent element. {0}", by.GetConditionDescription());
            else
                LogPool.Append("Search for parent element of '{0}'. {1}", sourceElement, MessageBuilder.BuildMessage(by, useTimeout, useInterval, timeout, interval));

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                var foundItem = StartSearchParent<TControl>(sourceElement, condition);
                if (foundItem != null)
                {
                    if (!needsToBeReady)
                    {
                        LogPool.Append("Parent element '{0}' found.", foundItem);
                        return foundItem;
                    }

                    return ReturnIfReady(assertResult, by, useTimeout, useInterval, timeout, watch, interval, false, foundItem);
                }

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
        /// Returns a tree of information objects which shows the whole tree below the given object.
        /// </summary>
        /// <param name="element">The parent object from which all child elements have to be read.</param>
        /// <returns>The given element as an information object wich all its children in a tree.</returns>
        public static AutomationElementInfo GetFullUITree(AutomationElement element)
        {
            var rootElementInfo = new AutomationElementInfo(element);
            LogPool.Append("Read full UI tree down from '{0}'.", rootElementInfo);
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

        /// <summary>
        /// Returns a tree of data objects which are a shadow copy of each element at the call time.
        /// </summary>
        /// <param name="element">The parent object from which all child element data have to be read.</param>
        /// <returns>The given element as an shadow copy wich all its children in a tree.</returns>
        public static BasicElementData GetFullUITreeData(BasicElement element)
        {
            var data = element.GetDataCopy();
            Read(element, data);
            return data;
        }

        private static void Read(BasicElement rootElement, BasicElementData data)
        {
            foreach (var child in GetChildren(rootElement.AutomationElement))
            {
                var element = new BasicElement(child);
                var elementData = element.GetDataCopy();
                ((List<BasicElementData>)data.Children).Add(elementData);
                Read(element, elementData);
            }
        }

        #endregion GetFullUITree

        #region GetFocusedElement

        /// <summary>
        /// Returns the UI control which actually have the keyboard focus.
        /// </summary>
        /// <returns>The current focused automation element as BasicElement. Null if nothing is found.</returns>
        public static BasicElement GetFocusedElement()
        {
            return GetFocusedElement<BasicElement>();
        }

        /// <summary>
        /// Returns the UI control which actually have the keyboard focus.
        /// </summary>
        /// <typeparam name="TControl">The UI element type to return.</typeparam>
        /// <returns>The current focused automation element as the TControl element. Null if nothing is found.</returns>
        public static TControl GetFocusedElement<TControl>() where TControl : BasicElement
        {
            var foundItem = AutomationElement.FocusedElement;
            if (foundItem != null)
                return (TControl)Activator.CreateInstance(typeof(TControl), foundItem);
            return null;
        }

        #endregion GetFocusedElement

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

        private static TControl ReturnIfReady<TControl>(bool assertResult, By @by, bool useTimeout, bool useInterval, uint timeout, Stopwatch watch, uint interval, bool multiply, TControl foundItem) where TControl : BasicElement
        {
            var timeLeft = TimeSpan.FromMilliseconds(timeout - watch.Elapsed.TotalMilliseconds);
            var readyInterval = TimeSpan.FromMilliseconds(interval);

            LogPool.Append("Wait for UI control '{0}' to become ready.", foundItem);
            foundItem.WaitForCondition(timeLeft, readyInterval, e => !e.IsEnabled || !e.IsVisible);

            if (!foundItem.IsEnabled || !foundItem.IsVisible)
            {
                if (assertResult)
                    throw new UIElementNotReadyException(foundItem.IsEnabled, foundItem.IsVisible, by, useTimeout, useInterval, interval, watch.Elapsed, multiply);
                return null;
            }

            LogPool.Append("The element is ready to use.");
            return foundItem;
        }

        #endregion Internals
    }
}
