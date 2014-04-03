using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;

namespace DW.CodedUI
{
    public static class UI
    {
        #region GetChild
        
        public static TControl GetChild<TControl>(By by, From from) where TControl : BasicElement
        {
            return StartSearchChild<TControl>(by, from, new CombinableWith());
        }

        public static TControl GetChild<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            return StartSearchChild<TControl>(by, from, with);
        }

        public static BasicElement GetChild(By by, From from)
        {
            return StartSearchChild<BasicElement>(by, from, new CombinableWith());
        }

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
                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new UIElementNotFoundException(by, useTimeout, useInterval, interval, watch.Elapsed, false);
                    return null;
                }

                var foundItem = StartSearchChild<TControl>(sourceElement, condition);
                if (foundItem != null)
                    return foundItem;

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

        public static IEnumerable<TControl> GetChildren<TControl>(By by, From from) where TControl : BasicElement
        {
            return StartSearchChildren<TControl>(by, from, new CombinableWith());
        }

        public static IEnumerable<TControl> GetChildren<TControl>(By by, From from, With with) where TControl : BasicElement
        {
            return StartSearchChildren<TControl>(by, from, with);
        }

        public static IEnumerable<BasicElement> GetChildren(By by, From from)
        {
            return StartSearchChildren<BasicElement>(by, from, new CombinableWith());
        }

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
                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new UIElementNotFoundException(by, useTimeout, useInterval, interval, watch.Elapsed, true);
                    return foundItems;
                }

                foundItems.AddRange(StartSearchChildren<TControl>(sourceElement, condition));
                if (foundItems.Any())
                    return foundItems;

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

        public static BasicElement GetParent(From from)
        {
            return StartSearchParent<BasicElement>(By.Condition(e => true), from, new CombinableWith());
        }

        public static BasicElement GetParent(From from, With with)
        {
            return StartSearchParent<BasicElement>(By.Condition(e => true), from, with);
        }

        public static TControl GetParent<TControl>(From from) where TControl : BasicElement
        {
            return StartSearchParent<TControl>(By.Condition(e => true), from, new CombinableWith());
        }

        public static TControl GetParent<TControl>(From from, With with) where TControl : BasicElement
        {
            return StartSearchParent<TControl>(By.Condition(e => true), from, with);
        }

        public static BasicElement GetParent(By by, From from)
        {
            return StartSearchParent<BasicElement>(by, from, new CombinableWith());
        }

        public static BasicElement GetParent(By by, From from, With with)
        {
            return StartSearchParent<BasicElement>(by, from, with);
        }

        public static TControl GetParent<TControl>(By by, From from) where TControl : BasicElement
        {
            return StartSearchParent<TControl>(by, from, new CombinableWith());
        }

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
                if (!useTimeout || watch.Elapsed.TotalMilliseconds >= timeout)
                {
                    if (assertResult)
                        throw new UIElementNotFoundException(by, useTimeout, useInterval, interval, watch.Elapsed, false);
                    return null;
                }

                var foundItem = StartSearchParent<TControl>(sourceElement, condition);
                if (foundItem != null)
                    return foundItem;

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
