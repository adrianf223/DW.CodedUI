#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2012-2013 David Wendland

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
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.UITree
{
    public static class WpfElementFinder
    {
        #region Child

        #region FindChildByAutomationId

        public static TControl FindChildByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => c.AutomationId == automationId);
        }

        public static TControl FindChildByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => condition(c.AutomationId));
        }

        #endregion FindChildByAutomationId

        #region FindChildByType

        public static TControl FindChildByType<TControl>(WpfControl parent) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => c.GetType() == typeof(TControl));
        }

        #endregion FindChildByType

        #region FindChildByName

        public static TControl FindChildByName<TControl>(WpfControl parent, string name) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => c.Name == name);
        }

        #endregion FindChildByName

        #region FindChildByNameCondition

        public static TControl FindChildByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => condition(c.Name));
        }

        #endregion FindChildByNameCondition

        #endregion Child

        #region Children

        #region FindChildrenByAutomationIdCondition

        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildrenByCondition<TControl>(parent, c => condition(c.AutomationId));
        }

        #endregion FindChildrenByAutomationIdCondition

        #region FindChildrenByType

        public static IEnumerable<TControl> FindChildrenByType<TControl>(WpfControl parent) where TControl : WpfControl
        {
            return FindChildrenByCondition<TControl>(parent, c => c.GetType() == typeof(TControl));
        }

        #endregion FindChildrenByType

        #region FindChildrenByNameCondition

        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildrenByCondition<TControl>(parent, c => condition(c.Name));
        }

        #endregion FindChildrenByNameCondition

        #endregion Children

        private static TControl FindChildByCondition<TControl>(WpfControl parent, Func<WpfControl, bool> condition) where TControl : WpfControl
        {
            foreach (WpfControl child in parent.GetChildren())
            {
                if (condition(child))
                    return (TControl)child;
                var foundItem = FindChildByCondition<TControl>(child, condition);
                if (foundItem != null)
                    return foundItem;
            }
            return null;
        }

        private static IEnumerable<TControl> FindChildrenByCondition<TControl>(WpfControl parent, Func<WpfControl, bool> condition) where TControl : WpfControl
        {
            var childs = new List<TControl>();
            foreach (WpfControl child in parent.GetChildren())
            {
                if (condition(child))
                    childs.Add((TControl)child);
                childs.AddRange(FindChildrenByCondition<TControl>(child, condition));
            }
            return childs;
        }
    }
}
