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
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using DW.CodedUI.BasicElements;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace DW.CodedUI.UITree
{
    /// <summary>
    /// Brings methods to find basic elements in a UI tree
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// <![CDATA[
    /// [TestMethod]
    /// public void Method_TestCondition_ExpectedResult()
    /// {
    ///     var checkBox = BasicElementFinder.FindChildByAutomationId<BasicCheckBox>(_target, "MyCheckBox");
    /// 
    ///     MouseEx.Click(checkBox);
    /// 
    ///     Assert.IsTrue(checkBox.IsChecked);
    /// }]]>
    /// </code>
    /// </example>
    public static class BasicElementFinder
    {
        #region Child

        #region FindChildByAutomationId

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationId(WpfControl parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationId(WpfControl parent, string automationId, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationId(AutomationElement parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationId(AutomationElement parent, string automationId, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationId(BasicElement parent, string automationId)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationId(BasicElement parent, string automationId, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationId<TControl>(WpfControl parent, string automationId, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationId<TControl>(AutomationElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationId<TControl>(AutomationElement parent, string automationId, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationId<TControl>(BasicElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationId<TControl>(BasicElement parent, string automationId, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.AutomationId == automationId, timeout);
        }

        #endregion FindChildByAutomationId

        #region FindChildByAutomationIdCondition

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationIdCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationIdCondition(WpfControl parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationIdCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByAutomationIdCondition(BasicElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.AutomationId), timeout);
        }

        #endregion FindChildByAutomationIdCondition

        #region FindChildByName

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByName(WpfControl parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByName(WpfControl parent, string name, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByName(AutomationElement parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByName(AutomationElement parent, string name, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByName(BasicElement parent, string name)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByName(BasicElement parent, string name, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.Name == name, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByName<TControl>(WpfControl parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByName<TControl>(WpfControl parent, string name, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByName<TControl>(AutomationElement parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByName<TControl>(AutomationElement parent, string name, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByName<TControl>(BasicElement parent, string name) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="name">The name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByName<TControl>(BasicElement parent, string name, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.Name == name, timeout);
        }

        #endregion FindChildByName

        #region FindChildByNameCondition

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByNameCondition(WpfControl parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByNameCondition(AutomationElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByNameCondition(BasicElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.Name), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.Name), timeout);
        }

        #endregion FindChildByNameCondition

        #region FindChildByClassName

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassName(WpfControl parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassName(WpfControl parent, string className, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassName(AutomationElement parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassName(AutomationElement parent, string className, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassName(BasicElement parent, string className)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassName(BasicElement parent, string className, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => a.Current.ClassName == className, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassName<TControl>(WpfControl parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassName<TControl>(WpfControl parent, string className, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassName<TControl>(AutomationElement parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassName<TControl>(AutomationElement parent, string className, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassName<TControl>(BasicElement parent, string className) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively by its class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="className">The class name to search for</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassName<TControl>(BasicElement parent, string className, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => a.Current.ClassName == className, timeout);
        }

        #endregion FindChildByClassName

        #region FindChildByClassNameCondition

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), 0);
        }
        
        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassNameCondition(WpfControl parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassNameCondition(AutomationElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByClassNameCondition(BasicElement parent, Func<string, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, a => condition(a.Current.ClassName), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent, a => condition(a.Current.ClassName), timeout);
        }

        #endregion FindChildByClassNameCondition

        #region FindChildByCondition

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByCondition(WpfControl parent, Func<AutomationElement, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, condition);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByCondition(WpfControl parent, Func<AutomationElement, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, condition, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByCondition(AutomationElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, condition);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByCondition(AutomationElement parent, Func<AutomationElement, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, condition, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByCondition(BasicElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildByCondition<BasicElement>(parent, condition);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static BasicElement FindChildByCondition(BasicElement parent, Func<AutomationElement, bool> condition, int timeout)
        {
            return FindChildByCondition<BasicElement>(parent, condition, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildByCondition<TControl>(automationElement, condition, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition, int timeout) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildByCondition<TControl>(automationElement, condition, timeout);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
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

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
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

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent.AutomationElement, condition, 0);
        }

        /// <summary>
        /// Tries to find a child control recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the searched child</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <param name="timeout">How long it tries to find the child</param>
        /// <returns>The first found child element if any; otherwise null</returns>
        public static TControl FindChildByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition, int timeout) where TControl : BasicElement
        {
            return FindChildByCondition<TControl>(parent.AutomationElement, condition, timeout);
        }

        #endregion FindChildByCondition

        #endregion Child

        #region Children

        #region FindChildrenByAutomationId

        /// <summary>
        /// Collects all child controls recursively filtered by their automation id
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByAutomationId(WpfControl parent, string automationId)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their automation id
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByAutomationId(AutomationElement parent, string automationId)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their automation id
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByAutomationId(BasicElement parent, string automationId)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.AutomationId == automationId);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByAutomationId<TControl>(WpfControl parent, string automationId) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByAutomationId<TControl>(AutomationElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their automation id
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="automationId">The automation id to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByAutomationId<TControl>(BasicElement parent, string automationId) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.AutomationId == automationId);
        }

        #endregion FindChildrenByAutomationId

        #region FindChildrenByAutomationIdCondition

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByAutomationIdCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByAutomationIdCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByAutomationIdCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.AutomationId));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByAutomationIdCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.AutomationId));
        }

        #endregion FindChildrenByAutomationIdCondition

        #region FindChildrenByName

        /// <summary>
        /// Collects all child controls recursively filtered by their name
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByName(WpfControl parent, string name)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their name
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByName(AutomationElement parent, string name)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their name
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByName(BasicElement parent, string name)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.Name == name);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByName<TControl>(WpfControl parent, string name) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByName<TControl>(AutomationElement parent, string name) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByName<TControl>(BasicElement parent, string name) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.Name == name);
        }

        #endregion FindChildrenByName

        #region FindChildrenByNameCondition

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.Name));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        /// <summary>
        /// Collects all child controls recursively filtered
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.Name));
        }

        #endregion FindChildrenByNameCondition

        #region FindChildrenByClassName

        /// <summary>
        /// Collects all child controls recursively filtered by their class name
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByClassName(WpfControl parent, string className)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their class name
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByClassName(AutomationElement parent, string className)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their class name
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByClassName(BasicElement parent, string className)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => a.Current.ClassName == className);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByClassName<TControl>(WpfControl parent, string className) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByClassName<TControl>(AutomationElement parent, string className) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        /// <summary>
        /// Collects all child controls recursively filtered by their class name
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="className">The class name to search for</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByClassName<TControl>(BasicElement parent, string className) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => a.Current.ClassName == className);
        }

        #endregion FindChildrenByClassName

        #region FindChildrenByClassNameCondition

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByClassNameCondition(WpfControl parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByClassNameCondition(AutomationElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<BasicElement> FindChildrenByClassNameCondition(BasicElement parent, Func<string, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, a => condition(a.Current.ClassName));
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByClassNameCondition<TControl>(WpfControl parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByClassNameCondition<TControl>(AutomationElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        public static IEnumerable<TControl> FindChildrenByClassNameCondition<TControl>(BasicElement parent, Func<string, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent, a => condition(a.Current.ClassName));
        }

        #endregion FindChildrenByClassNameCondition

        #region FindChildrenByCondition

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        private static IEnumerable<BasicElement> FindChildrenByCondition(WpfControl parent, Func<AutomationElement, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, condition);
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        private static IEnumerable<BasicElement> FindChildrenByCondition(BasicElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, condition);
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        private static IEnumerable<BasicElement> FindChildrenByCondition(AutomationElement parent, Func<AutomationElement, bool> condition)
        {
            return FindChildrenByCondition<BasicElement>(parent, condition);
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        private static IEnumerable<TControl> FindChildrenByCondition<TControl>(WpfControl parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            var automationElement = AutomationElement.FromHandle(parent.WindowHandle);
            return FindChildrenByCondition<TControl>(automationElement, condition);
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
        private static IEnumerable<TControl> FindChildrenByCondition<TControl>(BasicElement parent, Func<AutomationElement, bool> condition) where TControl : BasicElement
        {
            return FindChildrenByCondition<TControl>(parent.AutomationElement, condition);
        }

        /// <summary>
        /// Collects all child controls recursively
        /// </summary>
        /// <typeparam name="TControl">The expected control type</typeparam>
        /// <param name="parent">A parent control of the children</param>
        /// <param name="condition">The condition to check on every child control</param>
        /// <returns>A list of found children</returns>
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

        #endregion FindChildrenByCondition

        #endregion Children

        #region Parent

        /// <summary>
        /// Gets the parent control of the passed child
        /// </summary>
        /// <param name="child">The child which parent control should be read</param>
        /// <returns>The parent control if any; otherwise null</returns>
        public static BasicElement GetParent(BasicElement child)
        {
            return GetParent<BasicElement>(child.AutomationElement);
        }

        /// <summary>
        /// Gets the parent control of the passed child
        /// </summary>
        /// <param name="child">The child which parent control should be read</param>
        /// <returns>The parent control if any; otherwise null</returns>
        public static BasicElement GetParent(AutomationElement child)
        {
            return GetParent<BasicElement>(child);
        }

        /// <summary>
        /// Gets the parent control of the passed child
        /// </summary>
        /// <typeparam name="TControl">The expectd parent control type</typeparam>
        /// <param name="child">The child which parent control should be read</param>
        /// <returns>The parent control if any; otherwise null</returns>
        public static BasicElement GetParent<TControl>(BasicElement child) where TControl : BasicElement
        {
            return GetParent<TControl>(child.AutomationElement);
        }

        /// <summary>
        /// Gets the parent control of the passed child
        /// </summary>
        /// <typeparam name="TControl">The expectd parent control type</typeparam>
        /// <param name="child">The child which parent control should be read</param>
        /// <returns>The parent control if any; otherwise null</returns>
        public static TControl GetParent<TControl>(AutomationElement child) where TControl : BasicElement
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(child);
            if (parent != null)
                return (TControl)Activator.CreateInstance(typeof(TControl), parent);
            return null;
        }

        #endregion Parent

        #region GetFullUITree

        /// <summary>
        /// Gets all available UI element recursively
        /// </summary>
        /// <param name="window">The parent control which tree should be read</param>
        /// <returns>A tree item with all available information</returns>
        public static BasicElementInfo GetFullUITree(WpfWindow window)
        {
            var rootElement = AutomationElement.FromHandle(window.WindowHandle);
            return GetFullUITree(rootElement);
        }

        /// <summary>
        /// Gets all available UI element recursively
        /// </summary>
        /// <param name="element">The parent control which tree should be read</param>
        /// <returns>A tree item with all available information</returns>
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

        #endregion GetFullUITree

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