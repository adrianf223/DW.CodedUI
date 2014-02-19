using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.UITree
{
    public static class BasicElementFinder
    {
        public static BasicElement FindChildByAutomationId(WpfControl parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        public static BasicElement FindChildByAutomationId(WpfControl parent, string automationId, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        public static BasicElement FindChildByAutomationId(AutomationElement parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        public static BasicElement FindChildByAutomationId(AutomationElement parent, string automationId, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        public static BasicElement FindChildByAutomationId(BasicElement parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        public static BasicElement FindChildByAutomationId(BasicElement parent, string automationId, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        public static TControl FindChildByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        public static TControl FindChildByAutomationId<TControl>(WpfControl parent, string automationId, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        public static TControl FindChildByAutomationId<TControl>(AutomationElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        public static TControl FindChildByAutomationId<TControl>(AutomationElement parent, string automationId, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        public static TControl FindChildByAutomationId<TControl>(BasicElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        public static TControl FindChildByAutomationId<TControl>(BasicElement parent, string automationId, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        public static BasicElement FindChildByAutomationIdCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), 0);
        }

        public static BasicElement FindChildByAutomationIdCondition(WpfControl parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        public static BasicElement FindChildByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), 0);
        }

        public static BasicElement FindChildByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        public static BasicElement FindChildByAutomationIdCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), 0);
        }

        public static BasicElement FindChildByAutomationIdCondition(BasicElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), 0);
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), 0);
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), 0);
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        public static BasicElement FindChildByName(WpfControl parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, 0);
        }

        public static BasicElement FindChildByName(WpfControl parent, string name, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, timeout);
        }

        public static BasicElement FindChildByName(AutomationElement parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, 0);
        }

        public static BasicElement FindChildByName(AutomationElement parent, string name, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, timeout);
        }

        public static BasicElement FindChildByName(BasicElement parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, 0);
        }

        public static BasicElement FindChildByName(BasicElement parent, string name, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, timeout);
        }

        public static TControl FindChildByName<TControl>(WpfControl parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, 0);
        }

        public static TControl FindChildByName<TControl>(WpfControl parent, string name, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, timeout);
        }

        public static TControl FindChildByName<TControl>(AutomationElement parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, 0);
        }

        public static TControl FindChildByName<TControl>(AutomationElement parent, string name, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, timeout);
        }

        public static TControl FindChildByName<TControl>(BasicElement parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, 0);
        }

        public static TControl FindChildByName<TControl>(BasicElement parent, string name, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, timeout);
        }

        public static BasicElement FindChildByNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), 0);
        }

        public static BasicElement FindChildByNameCondition(WpfControl parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), timeout);
        }

        public static BasicElement FindChildByNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), 0);
        }

        public static BasicElement FindChildByNameCondition(AutomationElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), timeout);
        }

        public static BasicElement FindChildByNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), 0);
        }

        public static BasicElement FindChildByNameCondition(BasicElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), timeout);
        }

        public static TControl FindChildByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), 0);
        }

        public static TControl FindChildByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), timeout);
        }

        public static TControl FindChildByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), 0);
        }

        public static TControl FindChildByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), timeout);
        }

        public static TControl FindChildByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), 0);
        }

        public static TControl FindChildByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), timeout);
        }

        public static BasicElement FindChildByClassName(WpfControl parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, 0);
        }

        public static BasicElement FindChildByClassName(WpfControl parent, string className, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, timeout);
        }

        public static BasicElement FindChildByClassName(AutomationElement parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, 0);
        }

        public static BasicElement FindChildByClassName(AutomationElement parent, string className, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, timeout);
        }

        public static BasicElement FindChildByClassName(BasicElement parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, 0);
        }

        public static BasicElement FindChildByClassName(BasicElement parent, string className, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, timeout);
        }

        public static TControl FindChildByClassName<TControl>(WpfControl parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, 0);
        }

        public static TControl FindChildByClassName<TControl>(WpfControl parent, string className, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, timeout);
        }

        public static TControl FindChildByClassName<TControl>(AutomationElement parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, 0);
        }

        public static TControl FindChildByClassName<TControl>(AutomationElement parent, string className, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, timeout);
        }

        public static TControl FindChildByClassName<TControl>(BasicElement parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, 0);
        }

        public static TControl FindChildByClassName<TControl>(BasicElement parent, string className, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, timeout);
        }

        public static BasicElement FindChildByClassNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), 0);
        }
        
        public static BasicElement FindChildByClassNameCondition(WpfControl parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), timeout);
        }

        public static BasicElement FindChildByClassNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), 0);
        }

        public static BasicElement FindChildByClassNameCondition(AutomationElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), timeout);
        }

        public static BasicElement FindChildByClassNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), 0);
        }

        public static BasicElement FindChildByClassNameCondition(BasicElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), timeout);
        }

        public static TControl FindChildByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), 0);
        }

        public static TControl FindChildByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), timeout);
        }

        public static TControl FindChildByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), 0);
        }

        public static TControl FindChildByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), timeout);
        }

        public static TControl FindChildByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), 0);
        }

        public static TControl FindChildByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), timeout);
        }

        public static BasicElement FindChildByCondition(WpfControl parent, Func<AutomationElement, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, condition);
        }

        public static BasicElement FindChildByCondition(WpfControl parent, Func<AutomationElement, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, condition, timeout);
        }

        public static BasicElement FindChildByCondition(AutomationElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, condition);
        }

        public static BasicElement FindChildByCondition(AutomationElement parent, Func<AutomationElement, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, condition, timeout);
        }

        public static BasicElement FindChildByCondition(BasicElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, condition);
        }

        public static BasicElement FindChildByCondition(BasicElement parent, Func<AutomationElement, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, condition, timeout);
        }

        public static TControl FindChildByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildByCondition<TControl>(automationElement, condition, 0);
        }

        public static TControl FindChildByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition, int timeout) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildByCondition<TControl>(automationElement, condition, timeout);
        }

        public static TControl FindChildByCondition<TControl>(AutomationElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            foreach (var child in GetChildren(parent))
            {
                if (condition(child))
                    return (TControl)Activator.CreateInstance(typeof(TControl), child);
                var foundItem = FindChildByCondition<TControl>(child, condition);
                if (foundItem != null)
                    return foundItem;
            }
            return null;
        }

        public static TControl FindChildByCondition<TControl>(AutomationElement parent, Func<AutomationElement, bool> condition, int timeout) where TControl : BasicElement
        {
            if (timeout == 0)
                return FindChildByCondition<TControl>(parent, condition);

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.Elapsed.TotalMilliseconds >= timeout)
                    return null;

                var foundItem = FindChildByCondition<TControl>(parent, condition);
                if (foundItem != null)
                    return foundItem;
                Thread.Sleep(200);
            }
        }

        public static TControl FindChildByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent.AutomationElement, condition, 0);
        }

        public static TControl FindChildByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent.AutomationElement, condition, timeout);
        }

        public static IEnumerable<BasicElement> FindChildrenByAutomationId(WpfControl parent, string automationId)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<BasicElement> FindChildrenByAutomationId(AutomationElement parent, string automationId)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<BasicElement> FindChildrenByAutomationId(BasicElement parent, string automationId)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<TControl> FindChildrenByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<TControl> FindChildrenByAutomationId<TControl>(AutomationElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<TControl> FindChildrenByAutomationId<TControl>(BasicElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<BasicElement> FindChildrenByAutomationIdCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<BasicElement> FindChildrenByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<BasicElement> FindChildrenByAutomationIdCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<BasicElement> FindChildrenByName(WpfControl parent, string name)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<BasicElement> FindChildrenByName(AutomationElement parent, string name)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<BasicElement> FindChildrenByName(BasicElement parent, string name)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<TControl> FindChildrenByName<TControl>(WpfControl parent, string name) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<TControl> FindChildrenByName<TControl>(AutomationElement parent, string name) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<TControl> FindChildrenByName<TControl>(BasicElement parent, string name) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<BasicElement> FindChildrenByNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<BasicElement> FindChildrenByNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<BasicElement> FindChildrenByNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<BasicElement> FindChildrenByClassName(WpfControl parent, string className)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<BasicElement> FindChildrenByClassName(AutomationElement parent, string className)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<BasicElement> FindChildrenByClassName(BasicElement parent, string className)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<TControl> FindChildrenByClassName<TControl>(WpfControl parent, string className) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<TControl> FindChildrenByClassName<TControl>(AutomationElement parent, string className) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<TControl> FindChildrenByClassName<TControl>(BasicElement parent, string className) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<BasicElement> FindChildrenByClassNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<BasicElement> FindChildrenByClassNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<BasicElement> FindChildrenByClassNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<TControl> FindChildrenByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<TControl> FindChildrenByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<TControl> FindChildrenByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        private static IEnumerable<BasicElement> FindChildrenByCondition(WpfControl parent, Func<AutomationElement, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, condition);
        }

        private static IEnumerable<BasicElement> FindChildrenByCondition(BasicElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, condition);
        }

        private static IEnumerable<BasicElement> FindChildrenByCondition(AutomationElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, condition);
        }

        private static IEnumerable<TControl> FindChildrenByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildrenByCondition<TControl>(automationElement, condition);
        }

        private static IEnumerable<TControl> FindChildrenByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent.AutomationElement, condition);
        }

        private static IEnumerable<TControl> FindChildrenByCondition<TControl>(AutomationElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var foundItems = new List<TControl>();
            foreach (var child in GetChildren(parent))
            {
                if (condition(child))
                    foundItems.Add((TControl)Activator.CreateInstance(typeof(TControl), child));
                foundItems.AddRange(FindChildrenByCondition<TControl>(child, condition));
            }
            return foundItems;
        }

        public static BasicElement GetParent(BasicElement child)
        {
            return GetParent<BasicElement>(child.AutomationElement);
        }

        public static BasicElement GetParent(AutomationElement child)
        {
            return GetParent<BasicElement>(child);
        }

        public static BasicElement GetParent<TControl>(BasicElement child) where TControl : BasicElement
        {
            return GetParent<TControl>(child.AutomationElement);
        }

        public static TControl GetParent<TControl>(AutomationElement child) where TControl : BasicElement
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(child);
            if (parent != null)
                return (TControl)Activator.CreateInstance(typeof(TControl), parent);
            return null;
        }

        public static BasicElementInfo GetFullUITree(AutomationElement element)
        {
            var rootElementInfo = new BasicElementInfo(element);
            Read(rootElementInfo);
            return rootElementInfo;
        }

        private static void Read(BasicElementInfo rootElement)
        {
            foreach (var child in GetChildren(rootElement.AutomationElement))
            {
                var childElementInfo = new BasicElementInfo(child);
                rootElement.Children.Add(childElementInfo);
                Read(childElementInfo);
            }
        }

        internal static IEnumerable<AutomationElement> GetChildren(AutomationElement parent)
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
            catch (ElementNotAvailableException )
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
            catch (ElementNotAvailableException )
            {
                return false;
            }
        }
    }
}