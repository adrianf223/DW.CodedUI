#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System;
using System.Collections.Generic;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using DW.CodedUI.Waiting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.UITree
{
    public static class BasicElementFinder
    {
        #region Child

        #region FindChildByAutomationId

        public static BasicElement FindChildByAutomationId(WpfControl parent, string automationId)
        {
            //var condition = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            //var element = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, condition);

            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static BasicElement FindChildByAutomationId(AutomationElement parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static BasicElement FindChildByAutomationId(BasicElement parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static TControl FindChildByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        public static TControl FindChildByAutomationId<TControl>(AutomationElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        public static TControl FindChildByAutomationId<TControl>(BasicElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        #endregion FindChildByAutomationId

        #region FindChildByAutomationIdCondition

        public static BasicElement FindChildByAutomationIdCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static BasicElement FindChildByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static BasicElement FindChildByAutomationIdCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        #endregion FindChildByAutomationIdCondition

        #region FindChildByName

        public static BasicElement FindChildByName(WpfControl parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static BasicElement FindChildByName(AutomationElement parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static BasicElement FindChildByName(BasicElement parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static TControl FindChildByName<TControl>(WpfControl parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        public static TControl FindChildByName<TControl>(AutomationElement parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        public static TControl FindChildByName<TControl>(BasicElement parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        #endregion FindChildByName

        #region FindChildByNameCondition

        public static BasicElement FindChildByNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static BasicElement FindChildByNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static BasicElement FindChildByNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static TControl FindChildByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        public static TControl FindChildByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        public static TControl FindChildByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        #endregion FindChildByNameCondition

        #region FindChildByClassName

        public static BasicElement FindChildByClassName(WpfControl parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static BasicElement FindChildByClassName(AutomationElement parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static BasicElement FindChildByClassName(BasicElement parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static TControl FindChildByClassName<TControl>(WpfControl parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        public static TControl FindChildByClassName<TControl>(AutomationElement parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        public static TControl FindChildByClassName<TControl>(BasicElement parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        #endregion FindChildByClassName

        #region FindChildByNameCondition

        public static BasicElement FindChildByClassNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static BasicElement FindChildByClassNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static BasicElement FindChildByClassNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static TControl FindChildByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        public static TControl FindChildByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        public static TControl FindChildByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        #endregion FindChildByNameCondition

        private static TControl FindChildByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildByCondition<TControl>(automationElement, condition);
        }

        private static TControl FindChildByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent.AutomationElement, condition);
        }

        private static TControl FindChildByCondition<TControl>(AutomationElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            foreach (var child in GetChilds(parent))
            {
                if (condition(child))
                    return (TControl)Activator.CreateInstance(typeof(TControl), child);
                var foundItem = FindChildByCondition<TControl>(child, condition);
                if (foundItem != null)
                    return foundItem;
            }
            return null;
        }

        #endregion Child

        #region Childs

        #region FindChildsByAutomationId

        public static IEnumerable<BasicElement> FindChildsByAutomationId(WpfControl parent, string automationId)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<BasicElement> FindChildsByAutomationId(AutomationElement parent, string automationId)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<BasicElement> FindChildsByAutomationId(BasicElement parent, string automationId)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<TControl> FindChildsByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<TControl> FindChildsByAutomationId<TControl>(AutomationElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        public static IEnumerable<TControl> FindChildsByAutomationId<TControl>(BasicElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        #endregion FindChildsByAutomationId

        #region FindChildsByAutomationIdCondition

        public static IEnumerable<BasicElement> FindChildsByAutomationIdCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<BasicElement> FindChildsByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<BasicElement> FindChildsByAutomationIdCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<TControl> FindChildsByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<TControl> FindChildsByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        public static IEnumerable<TControl> FindChildsByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        #endregion FindChildsByAutomationIdCondition

        #region FindChildsByName

        public static IEnumerable<BasicElement> FindChildsByName(WpfControl parent, string name)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<BasicElement> FindChildsByName(AutomationElement parent, string name)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<BasicElement> FindChildsByName(BasicElement parent, string name)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<TControl> FindChildsByName<TControl>(WpfControl parent, string name) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<TControl> FindChildsByName<TControl>(AutomationElement parent, string name) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        public static IEnumerable<TControl> FindChildsByName<TControl>(BasicElement parent, string name) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        #endregion FindChildsByName

        #region FindChildsByNameCondition

        public static IEnumerable<BasicElement> FindChildsByNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<BasicElement> FindChildsByNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<BasicElement> FindChildsByNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<TControl> FindChildsByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<TControl> FindChildsByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        public static IEnumerable<TControl> FindChildsByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        #endregion FindChildsByNameCondition

        #region FindChildsByClassName

        public static IEnumerable<BasicElement> FindChildsByClassName(WpfControl parent, string className)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<BasicElement> FindChildsByClassName(AutomationElement parent, string className)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<BasicElement> FindChildsByClassName(BasicElement parent, string className)
        {
            return FindChildsByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<TControl> FindChildsByClassName<TControl>(WpfControl parent, string className) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<TControl> FindChildsByClassName<TControl>(AutomationElement parent, string className) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        public static IEnumerable<TControl> FindChildsByClassName<TControl>(BasicElement parent, string className) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        #endregion FindChildsByClassName

        #region FindChildsByNameCondition

        public static IEnumerable<BasicElement> FindChildsByClassNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<BasicElement> FindChildsByClassNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<BasicElement> FindChildsByClassNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildsByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<TControl> FindChildsByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<TControl> FindChildsByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        public static IEnumerable<TControl> FindChildsByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        #endregion FindChildsByNameCondition

        private static IEnumerable<TControl> FindChildsByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildsByCondition<TControl>(automationElement, condition);
        }

        private static IEnumerable<TControl> FindChildsByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            return FindChildsByCondition<TControl>(parent.AutomationElement, condition);
        }

        private static IEnumerable<TControl> FindChildsByCondition<TControl>(AutomationElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var foundItems = new List<TControl>();
            foreach (var child in GetChilds(parent))
            {
                if (condition(child))
                    foundItems.Add((TControl)Activator.CreateInstance(typeof(TControl), child));
                foundItems.AddRange(FindChildsByCondition<TControl>(child, condition));
            }
            return foundItems;
        }

        #endregion Childs

        #region Parent

        public static BasicElement GetParent(BasicTreeItem child)
        {
            return GetParent<BasicElement>(child);
        }

        public static TControl GetParent<TControl>(BasicTreeItem child) where TControl : BasicElement
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(child.AutomationElement);
            if (parent != null)
                return (TControl)Activator.CreateInstance(typeof(TControl), parent);
            return null;
        }

        #endregion Parent

        #region GetFullUITree

        public static BasicElementInfo GetFullUITree(WpfWindow window)
        {
            var rootElement = AutomationElement.FromHandle(window.WindowHandle);
            return GetFullUITree(rootElement);
        }

        public static BasicElementInfo GetFullUITree(AutomationElement element)
        {
            var rootElementInfo = new BasicElementInfo(element);
            Read(rootElementInfo);
            return rootElementInfo;
        }

        private static void Read(BasicElementInfo rootElement)
        {
            foreach (var child in GetChilds(rootElement.AutomationElement))
            {
                var childElementInfo = new BasicElementInfo(child);
                rootElement.Childs.Add(childElementInfo);
                Read(childElementInfo);
            }
        }

        #endregion GetFullUITree

        private static IEnumerable<AutomationElement> GetChilds(AutomationElement parent)
        {
            var childs = new List<AutomationElement>();
            var child = TreeWalker.ControlViewWalker.GetFirstChild(parent);
            if (child != null)
            {
                childs.Add(child);
                while ((child = TreeWalker.ControlViewWalker.GetNextSibling(child)) != null)
                    childs.Add(child);
            }
            return childs;
        }
    }
}