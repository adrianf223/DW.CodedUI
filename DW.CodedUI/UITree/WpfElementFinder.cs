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
    /// <summary>
    /// Brings methods to find WPF controls in a UI tree
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Method_TestCondition_ExpectedResult()
    /// {
    ///     var button = WpfElementFinder.FindChildByAutomationId<WpfButton>(_target, "MyButton");
    /// 
    ///     Mouse.Click(button);
    /// }]]>
    /// </code>
    /// </example>
    public static class WpfElementFinder
    {
        #region Child

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => c.AutomationId == automationId);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => condition(c.AutomationId));
        }

        /// <summary>
        /// Tries to find a child control recursively by its exact type
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByType<TControl>(WpfControl parent) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => c.GetType() == typeof(TControl));
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByName<TControl>(WpfControl parent, string name) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => c.Name == name);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildByCondition<TControl>(parent, c => condition(c.Name));
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByCondition<TControl>(WpfControl parent, Func<WpfControl, bool> condition) where TControl : WpfControl
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

        #endregion Child

        #region Children

        /// <summary>
        /// Collects all child controls recursively filtered by their automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control types</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildrenByCondition<TControl>(parent, c => condition(c.AutomationId));
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their exact type
        /// </summary>
        /// <typeparam name="TControl">The expected control types</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByType<TControl>(WpfControl parent) where TControl : WpfControl
        {
            return FindChildrenByCondition<TControl>(parent, c => c.GetType() == typeof(TControl));
        }

        /// <summary>
        /// Collects all child controls recursively by their name
        /// </summary>
        /// <typeparam name="TControl">The expected control types</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : WpfControl
        {
            return FindChildrenByCondition<TControl>(parent, c => condition(c.Name));
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control types</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByCondition<TControl>(WpfControl parent, Func<WpfControl, bool> condition) where TControl : WpfControl
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

        #endregion Children
    }
}
